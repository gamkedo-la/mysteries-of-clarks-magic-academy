using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon6Generator : MonoBehaviour {
	public static Dungeon6Generator Instance;

	public int dungeonNumber = 5;

	public List<PrefabLevelPair> specialLevels;
	public bool levelIsSpecial = false;
	public List<TileDensityPair> tiles;

	public AnimationCurve densityFalloffCurve;
	public float gridScale = 15f;

	public float minRadius = 3f;
	public float maxRadius = 7f;

	private int currentLevel;
	private float[,] densityMap;
	private int mapSize = 30;
	private List<Vector2> clearings;
	private List<GameObject> currentRooms = new List<GameObject>();

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

	private void Start() {

		if (Instance != null) {
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);


		currentLevel = GameManager.currentFloor;

		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Floor", currentLevel % 5);

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
				return;
			}
		}

		Dictionary<Vector2, float> clearings = new Dictionary<Vector2, float>();
		clearings.Add(new Vector2(mapSize/2, mapSize/2), Random.Range(minRadius, maxRadius));
		Vector2 lastPos = new Vector2(mapSize/2, mapSize/2);
		float lastRadius = clearings[lastPos];
		for (int i = 0; i <= currentLevel+3; i++) {
			Vector2 newPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
			float newRadius = Random.Range(minRadius, maxRadius);
			float placementMultiplier = (lastRadius + newRadius) * Random.Range(0.5f, 0.75f);
			newPos *= placementMultiplier;
			newPos = newPos + lastPos;
			clearings.Add(newPos, newRadius);
		}

		//////////////////////////////////////////////////////////////////////////////////////////
		densityMap = new float[mapSize, mapSize];
		for (int x = 0; x < mapSize; x++) {
			for (int y = 0; y < mapSize; y++) {
				densityMap[x, y] = 2f;
			}
		}


		//room generation
		foreach (KeyValuePair<Vector2, float> room in clearings) {
			for (int x = 0; x < mapSize; x++) {
				for (int y = 0; y < mapSize; y++) {
					float newValue = densityFalloffCurve.Evaluate(Vector2.Distance(new Vector2((int)x, (int)y), room.Key) / room.Value);
					if (newValue >= 0f && newValue <= 1f && newValue < densityMap[x, y]) densityMap[x, y] = newValue;
				}
			}
		}



		//Generate level from density map
		for (int x = 0; x < mapSize; x++) {
			for (int y = 0; y < mapSize; y++) {
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

				GameObject newTile = Instantiate(tiles[newTileIndex].tilePrefabs[Random.Range(0, tiles[newTileIndex].tilePrefabs.Count)], new Vector3(x*gridScale, 0, y*gridScale), Quaternion.identity, gameObject.transform);
				newTile.SetActive(true);
				currentRooms.Add(newTile);
			}
		}
		

	}

	public void AdvanceFloor() {
		GameManager.currentFloor++;
		if (GameManager.currentFloor > GameManager.DungeonFloorCount[dungeonNumber]) GameManager.DungeonFloorCount[dungeonNumber] = GameManager.currentFloor;
		Destroy(this);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
