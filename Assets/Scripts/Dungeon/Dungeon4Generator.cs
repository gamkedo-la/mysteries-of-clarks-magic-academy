using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.AI.Navigation;

public class Dungeon4Generator : MonoBehaviour {
	public static Dungeon4Generator Instance;
	public NavMeshSurface surface;

	public int dungeonNumber = 3;
	public int currentLevel;
	public Text currentFloorText;

	public List<PrefabLevelPair> specialLevels;
	public bool levelIsSpecial = false;

	public float gridScale = 45f;
	public FourSidedTileGenerator floorTemplate;

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

	void Update() {
		if (Input.GetKey(KeyCode.P)) {
			AdvanceFloor();
		}
		if (Input.GetKey(KeyCode.O)) {
			GameManager.currentFloor--;
			if (GameManager.currentFloor < 0) GameManager.currentFloor = 0;
			AdvanceFloor();
		}
		if (Input.GetKey(KeyCode.I)) {
			GameManager.currentFloor--;
			GameManager.currentFloor--;
			if (GameManager.currentFloor < 0) GameManager.currentFloor = 0;
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

		currentLevel = GameManager.currentFloor;
		if (GameManager.currentFloor > GameManager.DungeonFloorCount[dungeonNumber]) GameManager.DungeonFloorCount[dungeonNumber] = GameManager.currentFloor;
		currentFloorText.text = (currentLevel + 1).ToString();

		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GameState", 0);
		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Dungeon", dungeonNumber);
		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Floor", currentLevel % 5);

		Generate();
	}

	public void Generate() {
		Clear();

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

		//Initialize map abstraction
		List<Vector2Int> roomsVec2 = new List<Vector2Int>();
		List<bool[]> roomsbool = new List<bool[]>();
		List<Vector2Int> dir = new List<Vector2Int>() { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};
		roomsVec2.Add(Vector2Int.zero);
		roomsbool.Add(new bool[] { false, false, false, false });

		//Generate map
		while (roomsVec2.Count <= currentLevel + 1) {
			int newIndex = Random.Range(0, roomsVec2.Count);
			int newDir = Random.Range(0, 4);
			Vector2Int oldPos = roomsVec2[newIndex];
			Vector2Int newPos = oldPos + dir[newDir];
			if (!roomsVec2.Contains(newPos)) {
				roomsVec2.Add(newPos);
				roomsbool.Add(new bool[] { false, false, false, false });
				roomsbool[newIndex][newDir] = true;
				roomsbool[roomsbool.Count-1][(newDir + 2) % 4] = true;
			} else {
				roomsbool[newIndex][newDir] = true;
				roomsbool[roomsVec2.IndexOf(newPos)][(newDir + 2) % 4] = true;
			}
		}

		//Instanciate map
		for (int i = 0; i < roomsVec2.Count; i++) {
			GameObject floor = Instantiate(floorTemplate.gameObject);
			List<GameObject> targetTransforms = floor.GetComponent<FourSidedTileGenerator>().targetTransforms;

			floor.transform.position = new Vector3(roomsVec2[i].x, 0f, roomsVec2[i].y) * gridScale;
			floor.gameObject.name = roomsVec2[i].ToString();
			floor.transform.parent = transform;

			//Instanciate walls and bridges
			for (int j = 0; j < 4; j++) {
				if (roomsbool[i][j]) {
					GameObject openSide = Instantiate(floorTemplate.openSide[Random.Range(0, floorTemplate.openSide.Count)]);
					openSide.transform.position = targetTransforms[j].transform.position;
					openSide.transform.rotation = targetTransforms[j].transform.rotation;
					openSide.transform.parent = floor.transform;
				} else {
					GameObject closedSide = Instantiate(floorTemplate.closedSide[Random.Range(0, floorTemplate.closedSide.Count)]);
					closedSide.transform.position = targetTransforms[j].transform.position;
					closedSide.transform.rotation = targetTransforms[j].transform.rotation;
					closedSide.transform.parent = floor.transform;

					GameObject decoration = Instantiate(floorTemplate.decorations[Random.Range(0, floorTemplate.decorations.Count)]);
					decoration.transform.position = targetTransforms[j].transform.position;
					decoration.transform.rotation = targetTransforms[j].transform.rotation;
					decoration.transform.parent = floor.transform;
				}
			}

			currentRooms.Add(floor);
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
		
		//Spawn Exit
		GameObject theExit = null;
		if (exit.scene.rootCount == 0) {
			theExit = Instantiate(exit);
		} else {
			theExit = exit;
		}
		Vector2Int farthestRoom = Vector2Int.zero;
		foreach (Vector2Int room in roomsVec2) {
			if (Vector2Int.Distance(room, Vector2Int.zero) > Vector2Int.Distance(farthestRoom, Vector2Int.zero)) {
				farthestRoom = room;
			}
		}
		Vector3 newPosition = new Vector3(farthestRoom.x, 0f, farthestRoom.y);
		theExit.transform.position = newPosition * gridScale;
		theExit.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
		theExit.transform.parent = transform;

		//Spawn Treasure and Portal
		Vector2Int portalRoom = new Vector2Int();
		if (currentRooms.Count > 2) {
			int newIndex = Random.Range(1, roomsVec2.Count);
			portalRoom = roomsVec2[newIndex];
			while (portalRoom == farthestRoom) {
				newIndex = Random.Range(1, roomsVec2.Count);
				portalRoom = roomsVec2[newIndex];
			}

			GameObject thePortal = null;
			if (portal.scene.rootCount == 0) {
				thePortal = Instantiate(portal);
			} else {
				thePortal = portal;
			}
			thePortal.transform.position = new Vector3(portalRoom.x, 0f, portalRoom.y) * gridScale;
			thePortal.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
			thePortal.transform.parent = transform;
		}
		Vector2Int treasureRoom = new Vector2Int();
		if (currentRooms.Count > 3) {
			int newIndex = Random.Range(1, roomsVec2.Count);
			treasureRoom = roomsVec2[newIndex];
			while (treasureRoom == farthestRoom || treasureRoom == portalRoom) {
				newIndex = Random.Range(1, roomsVec2.Count);
				treasureRoom = roomsVec2[newIndex];
			}

			GameObject theTreasure = null;
			if (treasure.scene.rootCount == 0) {
				theTreasure = Instantiate(treasure);
			} else {
				theTreasure = treasure;
			}
			theTreasure.transform.position = new Vector3(treasureRoom.x, 0f, treasureRoom.y) * gridScale;
			theTreasure.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
			theTreasure.transform.parent = transform;
		}


		bool treasureSpawned = false;
		bool portalSpawned = false;
		foreach (Vector2 room in roomsVec2) {
			if (room == new Vector2(0f, 0f)) continue;
			if (room == farthestRoom) continue;

			float percentRange = Random.Range(0f, 1f);
			if (1f/roomsVec2.Count >= percentRange && !portalSpawned) {
				GameObject theSpawn = null;
				if (!treasureSpawned) {
					if (exit.scene.rootCount == 0) {
						theSpawn = Instantiate(treasure);
					} else {
						theSpawn = treasure;
					}
					treasureSpawned = true;
				} else {
					if (exit.scene.rootCount == 0) {
						theSpawn = Instantiate(portal);
					} else {
						theSpawn = portal;
					}
					portalSpawned = true;
				}

				newPosition = new Vector3(room.x, 0f, room.y);
				theSpawn.transform.position = newPosition * gridScale;
				theSpawn.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
				theSpawn.transform.parent = transform;
			}
		}

		StartCoroutine(BuildNavMesh());
	}

	public void Clear() {
		for (int i = transform.childCount-1; i >= 0; i--) {
			DestroyImmediate(transform.GetChild(i).gameObject);
		}
		currentRooms = new List<GameObject>();
	}

	public void AdvanceFloor() {
		GameManager.currentFloor++;
		Destroy(gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	IEnumerator BuildNavMesh() {
		yield return null;

		surface.BuildNavMesh();
	}
}



#if UNITY_EDITOR
[CustomEditor(typeof(Dungeon4Generator))]
public class Dungeon4GeneratorEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		if (GUILayout.Button("Generate")) {
			(target as Dungeon4Generator).Generate();
		}

		if (GUILayout.Button("Clear")) {
			(target as Dungeon4Generator).Clear();
		}
	}
}
#endif