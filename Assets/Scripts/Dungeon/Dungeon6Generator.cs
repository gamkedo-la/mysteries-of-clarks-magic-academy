using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.AI.Navigation;
using UnityEditor;

public class Dungeon6Generator : MonoBehaviour {
	public static Dungeon6Generator Instance;
	public NavMeshSurface surface;

	public int dungeonNumber = 5;
	public int currentLevel;

	public List<PrefabLevelPair> specialLevels;
	public bool levelIsSpecial = false;
	public List<TileDensityPair> tiles;

	public float gridScale = 15f;
	public AnimationCurve densityFalloffCurve, clearingSeperation;

	public float minRadius = 3f;
	public float maxRadius = 7f;
	
	public int enemiesSpawnedPerClearingeMin = 3, enemiesSpawnedPerClearingMax = 10;

	public GameObject enemy;
	public GameObject treasure;
	public GameObject exit;
	public GameObject portal;
	public GameObject player;

	public List<GameObject> currentRooms = new List<GameObject>();

	[System.Serializable]
	public class PrefabLevelPair {
		public GameObject levelPrefab;
		public int levelNumber;
	}

	[System.Serializable]
	public class TileDensityPair {
		public List<GameObject> tilePrefabs;
		public float density;
	}

	void Update() {
		if (Input.GetKey(KeyCode.P)) {
			AdvanceFloor();
		}
		if (Input.GetKey(KeyCode.O)) {
			GameManager.currentFloor--;
			AdvanceFloor();
		}
		if (Input.GetKey(KeyCode.I)) {
			GameManager.currentFloor--;
			GameManager.currentFloor--;
			AdvanceFloor();
		}
	}

	void Start() {
		if (Instance != null) {
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);

		Generate();
	}

	public void Generate() {
		Clear();

		currentLevel = GameManager.currentFloor;

		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GameState", 0);
		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Dungeon", dungeonNumber);
		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Floor", currentLevel % 5);

		//Check for special levels
		foreach (PrefabLevelPair floor in specialLevels) {
			if (currentLevel == floor.levelNumber) {
				GameObject specialLevel = null;
				if (floor.levelPrefab.scene.rootCount == 0) {
					specialLevel = Instantiate(floor.levelPrefab);
				} else {
					specialLevel = floor.levelPrefab;
				}

				specialLevel.SetActive(true);
				levelIsSpecial = true;
				StartCoroutine(BuildNavMesh());
				return;
			}
		}

		//Generate clearings
		Dictionary<Vector2, float> clearings = new Dictionary<Vector2, float>();
		clearings.Add(new Vector2(0f, 0f), Random.Range(minRadius, maxRadius));
		int numberOfClearings = (int)(currentLevel*1.34f)+1;
		Vector2 lastPos = new Vector2(0f, 0f);
		float lastRadius = clearings[lastPos];
		for (int i = 0; i <= numberOfClearings; i++) {
			Vector2 newPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
			float newRadius = Random.Range(minRadius, maxRadius);
			float placementMultiplier = (lastRadius + newRadius) * clearingSeperation.Evaluate(Random.Range(0f, 1f));
			newPos *= placementMultiplier;
			newPos = newPos + lastPos;
			clearings.Add(newPos, newRadius);
			lastPos = newPos;
			lastRadius = newRadius;
		}

		//Calculate map size
		int farLeft = 0;
		int farRight = 0;
		int farTop = 0;
		int farBottom = 0;
		foreach (KeyValuePair<Vector2, float> room in clearings) {
			int testLeft = (int)Mathf.Abs(Mathf.Min(room.Key.x - room.Value));
			int testRight = (int)Mathf.Max(room.Key.x + room.Value);
			int testTop = (int)Mathf.Abs(Mathf.Min(room.Key.y - room.Value));
			int testBottom = (int)Mathf.Max(room.Key.y + room.Value);

			if (farLeft < testLeft) farLeft = testLeft;
			if (farRight < testRight) farRight = testRight;
			if (farTop < testTop) farTop = testTop;
			if (farBottom < testBottom) farBottom = testBottom;
		}
		int mapWidth = farLeft + farRight + 4;
		int mapHeight = farTop + farBottom + 4;
		int offsetX = farLeft+2;
		int offsetY = farTop+2;
		Debug.Log(currentLevel + " " + mapWidth + "x" + mapHeight + " " + clearings.Count);

		//Create empty density map
		float[,] densityMap = new float[mapWidth, mapHeight];
		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {
				densityMap[x, y] = 2f;
			}
		}

		//room generation
		foreach (KeyValuePair<Vector2, float> room in clearings) {
			for (int x = 0; x < mapWidth; x++) {
				for (int y = 0; y < mapHeight; y++) {
					float newValue = densityFalloffCurve.Evaluate(Vector2.Distance(new Vector2((int)x-offsetX, (int)y-offsetY), room.Key) / room.Value);
					if (newValue >= 0f && newValue <= 1f && newValue < densityMap[x, y]) densityMap[x, y] = newValue;
				}
			}
		}

		//Generate level from density map
		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {
				float density = densityMap[x, y];
				if (density == 2f) continue;

				float newTileDensity = float.MaxValue;
				int newTileIndex = 0;
				for (int i = 0; i < tiles.Count; i++) {
					if (Mathf.Abs(density - tiles[i].density) < Mathf.Abs(density - newTileDensity)) {
						newTileDensity = tiles[i].density;
						newTileIndex = i;
					}
				}
				
				GameObject newTile = Instantiate(tiles[newTileIndex].tilePrefabs[Random.Range(0, tiles[newTileIndex].tilePrefabs.Count)], new Vector3((x-offsetX)*gridScale, 0, (y-offsetY)*gridScale), Quaternion.identity, gameObject.transform);
				newTile.transform.Rotate(0f, Random.Range(0,5)*90, 0f);
				newTile.SetActive(true);
				currentRooms.Add(newTile);
			}
		}

		//Spawn Exit
		GameObject theExit = null;
		if (exit.scene.rootCount == 0) {
			theExit = Instantiate(exit);
		} else {
			theExit = exit;
		}
		Vector2 farthestClearing = new Vector2(0f, 0f);
		foreach (KeyValuePair<Vector2, float> room in clearings) {
			if (Vector2.Distance(room.Key, new Vector2(0f, 0f)) > Vector2.Distance(farthestClearing, new Vector2(0f, 0f))) {
				farthestClearing = room.Key;
			}
		}
		Vector3 newPosition = new Vector3(farthestClearing.x, 0f, farthestClearing.y);
		theExit.transform.position = newPosition * gridScale;
		theExit.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
		theExit.transform.parent = transform;

		//Spawn Treasure and Portal
		bool treasureSpawned = false;
		bool portalSpawned = false;
		Debug.Log("Odds: " + 1f/clearings.Count);
		foreach (KeyValuePair<Vector2, float> room in clearings) {
			if (room.Key == new Vector2(0f, 0f)) continue;
			if (room.Key == farthestClearing) continue;

			float percentRange = Random.Range(0f, 1f);
			Debug.Log(percentRange);
			if (1f/clearings.Count >= percentRange && !portalSpawned) {
				GameObject theSpawn = null;
				if (!treasureSpawned) {
					if (exit.scene.rootCount == 0) {
						theSpawn = Instantiate(treasure);
					} else {
						theSpawn = treasure;
					}
					treasureSpawned = true;
					Debug.Log("Spawned treasure");
				} else {
					if (exit.scene.rootCount == 0) {
						theSpawn = Instantiate(portal);
					} else {
						theSpawn = portal;
					}
					portalSpawned = true;
					Debug.Log("Spawned portal");
				}

				newPosition = new Vector3(room.Key.x, 0f, room.Key.y);
				theSpawn.transform.position = newPosition * gridScale;
				theSpawn.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
				theSpawn.transform.parent = transform;
			}
		}

		//Spawn Enemies
		int enemiesToSpawn = Random.Range((clearings.Count-1) * enemiesSpawnedPerClearingeMin, (clearings.Count-1)  * enemiesSpawnedPerClearingMax);
		Debug.Log(enemiesToSpawn);
		while (enemiesToSpawn > 0) {
			foreach (KeyValuePair<Vector2, float> room in clearings) {
				if (room.Key == new Vector2(0f, 0f)) continue;
				if (room.Key == farthestClearing) continue;

				if (Random.Range(0, 1f) < clearings.Count/1f) {
					GameObject newEnemy = Instantiate(enemy);
					Vector2 newPos = ((new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * (Random.Range(-1f, 1f)*room.Value/1.5f)) + room.Key) * gridScale;
					newEnemy.transform.position = new Vector3(newPos.x, 1.25f, newPos.y);
					newEnemy.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
					newEnemy.transform.parent = transform;
					enemiesToSpawn--;
				}

				if (enemiesToSpawn <= 0) break;
			}
		}

		//Spawn Player
		GameObject thePlayer = null;
		if (player.scene.rootCount == 0) {
			thePlayer = Instantiate(player);
		} else {
			thePlayer = player;
		}
		thePlayer.transform.position = new Vector3(0f, 1.4f, 0f);
		thePlayer.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
		thePlayer.transform.parent = transform;

		StartCoroutine(BuildNavMesh());
	}

	public void Clear() {
		for (int i = transform.childCount-1; i >= 0; i--) {
			DestroyImmediate(transform.GetChild(i).gameObject);
		}
	}

	public void AdvanceFloor() {
		GameManager.currentFloor++;
		if (GameManager.currentFloor < 0) GameManager.currentFloor = 0;
		if (GameManager.currentFloor > GameManager.DungeonFloorCount[dungeonNumber]) GameManager.DungeonFloorCount[dungeonNumber] = GameManager.currentFloor;
		Destroy(gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	IEnumerator BuildNavMesh() {
		yield return null;

		surface.BuildNavMesh();
	}
}



#if UNITY_EDITOR
[CustomEditor(typeof(Dungeon6Generator))]
public class Dungeon6GeneratorEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		if (GUILayout.Button("Generate")) {
			(target as Dungeon6Generator).Generate();
		}

		if (GUILayout.Button("Clear")) {
			(target as Dungeon6Generator).Clear();
		}
	}
}
#endif