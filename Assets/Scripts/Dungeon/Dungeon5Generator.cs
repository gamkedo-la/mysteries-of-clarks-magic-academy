using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.AI.Navigation;

public class Dungeon5Generator : MonoBehaviour {
	public static Dungeon5Generator Instance;
	public NavMeshSurface surface;

	public int dungeonNumber = 5;
	public int currentLevel;

	public List<PrefabLevelPair> specialLevels;
	public bool levelIsSpecial = false;

	public List<GameObject> roomWith1Door;
	public List<GameObject> roomWith2DoorsI;
	public List<GameObject> roomWith2DoorsL;
	public List<GameObject> roomWith3Doors;

	public List<GameObject> hallWith2OpenI;
	public List<GameObject> hallWith2OpenL;
	public List<GameObject> hallWith3Open;
	public List<GameObject> hallWith4Open;

	public List<GameObject> bigRoom;

	public float gridScale = 15f;
	public float oddsOfBigRoom = 0.5f;
	public float oddsOfHall = 0.15f;
	public int minLengthOfHall = 2;
	public int maxLengthOfHall = 5;

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

	public enum RoomType {
		Room,
		Hall,
		Big,
		Empty
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

		Generate();
	}

	public void Generate() {
		Clear();

		currentLevel = GameManager.currentFloor;
		if (GameManager.currentFloor > GameManager.DungeonFloorCount[dungeonNumber]) GameManager.DungeonFloorCount[dungeonNumber] = GameManager.currentFloor;

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

		List<Vector2Int> roomsVec2 = new List<Vector2Int>();
		List<bool[]> roomsBool = new List<bool[]>();
		List<int> roomRotation = new List<int>();
		List<RoomType> roomType = new List<RoomType>();
		List<Vector2Int> dir = new List<Vector2Int>() { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

		//Generate first room
		roomsVec2.Add(Vector2Int.zero);
		roomsBool.Add(new bool[] { false, false, false, false });
		roomRotation.Add(0);
		roomType.Add(RoomType.Room);

		//Generate map
		int numberOfRooms = 1;
		while (numberOfRooms <= currentLevel + 3) {
			int newIndex = Random.Range(0, roomsVec2.Count);
			int newDir = Random.Range(0, 4);
			float newRoomType = Random.Range(0f, 1f);
			Vector2Int oldPos = roomsVec2[newIndex];
			Vector2Int newPos = oldPos + dir[newDir];

			if (roomType[newIndex] != RoomType.Room) continue;

			if (newRoomType <= oddsOfBigRoom) { //Big Room
				newPos = newPos + dir[newDir];

				bool hasSpace = true;
				for (int x = -1; x <= 1; x++) {
					for (int y = -1; y <= 1; y++) {
						if (roomsVec2.Contains(newPos + new Vector2Int(x, y))) {
							hasSpace = false;
						}
					}
				}
				if (!hasSpace) continue;

				for (int x = -1; x <= 1; x++) {
					for (int y = -1; y <= 1; y++) {
						roomsVec2.Add(newPos + new Vector2Int(x, y));
						roomsBool.Add(new bool[] { false, false, false, false });
						roomRotation.Add(0);
						roomType.Add(RoomType.Empty);
					}
				}

				roomsBool[newIndex][newDir] = true;
				roomsBool[roomsVec2.IndexOf(newPos)][(newDir + 2) % 4] = true;
				roomRotation[roomsVec2.IndexOf(newPos)] = (newDir + 2) % 4;
				roomType[roomsVec2.IndexOf(newPos)] = RoomType.Big;

				numberOfRooms++;

			} else if (newRoomType <= oddsOfHall + oddsOfBigRoom) { //Hallway

				

			} else if (!roomsVec2.Contains(newPos)) { //New room
				roomsVec2.Add(newPos);
				roomsBool.Add(new bool[] { false, false, false, false });
				roomRotation.Add(0);
				roomType.Add(RoomType.Room);

				roomsBool[newIndex][newDir] = true;
				roomsBool[roomsBool.Count-1][(newDir + 2) % 4] = true;

				numberOfRooms++;

			} else if (roomType[roomsVec2.IndexOf(newPos)] == RoomType.Room) { //Connect old room
				roomsBool[newIndex][newDir] = true;
				roomsBool[roomsVec2.IndexOf(newPos)][(newDir + 2) % 4] = true;
			}
		}

		//Assign tiles and Instanciate Map
		for (int i = 0; i < roomsVec2.Count; i++) {
			GameObject toSpawn = null;

			if (roomType[i] == RoomType.Room) {
				//roomWith1Door
				if (roomsBool[i][0]) {
					toSpawn = roomWith1Door[Random.Range(0, roomWith1Door.Count)];
				} else if (roomsBool[i][1]) {
					toSpawn = roomWith1Door[Random.Range(0, roomWith1Door.Count)];
					roomRotation[i] = 1;
				} else if (roomsBool[i][2]) {
					toSpawn = roomWith1Door[Random.Range(0, roomWith1Door.Count)];
					roomRotation[i] = 2;
				} else if (roomsBool[i][3]) {
					toSpawn = roomWith1Door[Random.Range(0, roomWith1Door.Count)];
					roomRotation[i] = 3;
				}
				//roomWith2DoorsI
				if (roomsBool[i][0] && roomsBool[i][2]) {
					toSpawn = roomWith2DoorsI[Random.Range(0, roomWith2DoorsI.Count)];
					roomRotation[i] = Random.Range(0f, 1f) > 0.5f ? 0 : 2;
				} else if (roomsBool[i][1] && roomsBool[i][3]) {
					toSpawn = roomWith2DoorsI[Random.Range(0, roomWith2DoorsI.Count)];
					roomRotation[i] = Random.Range(0f, 1f) > 0.5f ? 1 : 3;
				}
				//roomWith2DoorsL
				if (roomsBool[i][0] && roomsBool[i][1]) {
					toSpawn = roomWith2DoorsL[Random.Range(0, roomWith2DoorsL.Count)];
				} else if (roomsBool[i][1] && roomsBool[i][2]) {
					toSpawn = roomWith2DoorsL[Random.Range(0, roomWith2DoorsL.Count)];
					roomRotation[i] = 1;
				} else if (roomsBool[i][2] && roomsBool[i][3]) {
					toSpawn = roomWith2DoorsL[Random.Range(0, roomWith2DoorsL.Count)];
					roomRotation[i] = 2;
				} else if (roomsBool[i][3] && roomsBool[i][0]) {
					toSpawn = roomWith2DoorsL[Random.Range(0, roomWith2DoorsL.Count)];
					roomRotation[i] = 3;
				}
				//roomWith3Doors
				if (roomsBool[i][0] && roomsBool[i][1] && roomsBool[i][2]) {
					toSpawn = roomWith3Doors[Random.Range(0, roomWith3Doors.Count)];
				} else if (roomsBool[i][1] && roomsBool[i][2] && roomsBool[i][3]) {
					toSpawn = roomWith3Doors[Random.Range(0, roomWith3Doors.Count)];
					roomRotation[i] = 1;
				} else if (roomsBool[i][2] && roomsBool[i][3] && roomsBool[i][0]) {
					toSpawn = roomWith3Doors[Random.Range(0, roomWith3Doors.Count)];
					roomRotation[i] = 2;
				} else if (roomsBool[i][3] && roomsBool[i][0] && roomsBool[i][1]) {
					toSpawn = roomWith3Doors[Random.Range(0, roomWith3Doors.Count)];
					roomRotation[i] = 3;
				}
				//roomWith4Doors
				if (roomsBool[i][0] && roomsBool[i][1] && roomsBool[i][2] && roomsBool[i][3]) {
					toSpawn = hallWith4Open[Random.Range(0, hallWith4Open.Count)];
				}
			}
			else if (roomType[i] == RoomType.Big) {
				toSpawn = bigRoom[Random.Range(0, bigRoom.Count)];
			}

			if (!toSpawn) continue;
			toSpawn = Instantiate(toSpawn);
			toSpawn.SetActive(true);
			toSpawn.transform.position = new Vector3(roomsVec2[i].x, 0f, roomsVec2[i].y) * gridScale;
			toSpawn.transform.Rotate(0f, roomRotation[i] * 90f, 0f);
			toSpawn.transform.parent = transform;
			toSpawn.name = roomsVec2[i].ToString();
		}
		

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
[CustomEditor(typeof(Dungeon5Generator))]
public class Dungeon5GeneratorEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		if (GUILayout.Button("Generate")) {
			(target as Dungeon5Generator).Generate();
		}

		if (GUILayout.Button("Clear")) {
			(target as Dungeon5Generator).Clear();
		}
	}
}
#endif