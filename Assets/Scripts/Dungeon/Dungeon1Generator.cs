using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.AI.Navigation;

public class Dungeon1Generator : MonoBehaviour {
	public static Dungeon1Generator Instance;
	public NavMeshSurface surface;

	public int dungeonNumber = 0;
	public int currentLevel;
	public Text currentFloorText;

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
	public int maxLengthOfHall = 4;

	public float oddsOfEnemyPerRoom = 0.5f;

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
	/*	if (Input.GetKey(KeyCode.P)) {
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
		}*/
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
		int newIndex = 0;
		while (numberOfRooms <= currentLevel + 3) {
			newIndex = Random.Range(0, roomsVec2.Count);
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
				int hallLength = Random.Range(minLengthOfHall, maxLengthOfHall+1);
				for (int i = 0; i < hallLength; i++) {
					if (!roomsVec2.Contains(newPos)) {
						roomsVec2.Add(newPos);
						roomsBool.Add(new bool[] { false, false, false, false });
						roomRotation.Add(0);
						roomType.Add(RoomType.Hall);

						roomsBool[roomsVec2.IndexOf(oldPos)][newDir] = true;
						roomsBool[roomsVec2.IndexOf(newPos)][(newDir + 2) % 4] = true;
						oldPos = newPos;
						newPos = newPos + dir[newDir];
					} else {
						i = hallLength;
						roomsBool[roomsVec2.IndexOf(oldPos)][newDir] = true;
						roomsBool[roomsVec2.IndexOf(newPos)][(newDir + 2) % 4] = true;
						oldPos = newPos;
						newPos = newPos + dir[newDir];
					}
				}

				if (!roomsVec2.Contains(newPos)) {
					roomsVec2.Add(newPos);
					roomsBool.Add(new bool[] { false, false, false, false });
					roomRotation.Add(0);
					roomType.Add(RoomType.Room);

					roomsBool[roomsVec2.IndexOf(oldPos)][newDir] = true;
					roomsBool[roomsVec2.IndexOf(newPos)][(newDir + 2) % 4] = true;

					numberOfRooms++;
				}


			} else if (!roomsVec2.Contains(newPos)) { //New room
				roomsVec2.Add(newPos);
				roomsBool.Add(new bool[] { false, false, false, false });
				roomRotation.Add(0);
				roomType.Add(RoomType.Room);

				roomsBool[newIndex][newDir] = true;
				roomsBool[roomsBool.Count-1][(newDir + 2) % 4] = true;

				numberOfRooms++;

			} else if (roomType[roomsVec2.IndexOf(newPos)] == RoomType.Room || roomType[roomsVec2.IndexOf(newPos)] == RoomType.Hall) { //Connect old room
				roomsBool[newIndex][newDir] = true;
				roomsBool[roomsVec2.IndexOf(newPos)][(newDir + 2) % 4] = true;
			}
		}

		//Assign tiles and Instanciate Map
		List<Vector2Int> roomsForSpawning = new List<Vector2Int>();
		for (int i = 0; i < roomsVec2.Count; i++) {
			GameObject toSpawn = null;

			if (roomType[i] == RoomType.Room) {
				//roomWith1Door
				if (roomsBool[i][0]) {
					toSpawn = roomWith1Door[Random.Range(0, roomWith1Door.Count)];
					roomRotation[i] = 0;
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
					roomRotation[i] = 0;
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
					roomRotation[i] = 0;
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
					roomRotation[i] = Random.Range(0, 4);
					roomType[i] = RoomType.Hall;
				}
			} else if (roomType[i] == RoomType.Big) {
				toSpawn = bigRoom[Random.Range(0, bigRoom.Count)];
			} else if (roomType[i] == RoomType.Hall) {
				//hallWith1Door
				if (roomsBool[i][0]) {
					toSpawn = roomWith1Door[Random.Range(0, roomWith1Door.Count)];
					roomRotation[i] = 0;
					roomType[i] = RoomType.Room;
				} else if (roomsBool[i][1]) {
					toSpawn = roomWith1Door[Random.Range(0, roomWith1Door.Count)];
					roomRotation[i] = 1;
					roomType[i] = RoomType.Room;
				} else if (roomsBool[i][2]) {
					toSpawn = roomWith1Door[Random.Range(0, roomWith1Door.Count)];
					roomRotation[i] = 2;
					roomType[i] = RoomType.Room;
				} else if (roomsBool[i][3]) {
					toSpawn = roomWith1Door[Random.Range(0, roomWith1Door.Count)];
					roomRotation[i] = 3;
					roomType[i] = RoomType.Room;
				}
				//hallWith2OpenI
				if (roomsBool[i][0] && roomsBool[i][2]) {
					toSpawn = hallWith2OpenI[Random.Range(0, hallWith2OpenI.Count)];
					roomRotation[i] = Random.Range(0f, 1f) > 0.5f ? 0 : 2;
					roomType[i] = RoomType.Hall;
				} else if (roomsBool[i][1] && roomsBool[i][3]) {
					toSpawn = hallWith2OpenI[Random.Range(0, hallWith2OpenI.Count)];
					roomRotation[i] = Random.Range(0f, 1f) > 0.5f ? 1 : 3;
					roomType[i] = RoomType.Hall;
				}
				//hallWith2OpenL
				if (roomsBool[i][0] && roomsBool[i][1]) {
					toSpawn = hallWith2OpenL[Random.Range(0, hallWith2OpenL.Count)];
					roomRotation[i] = 0;
					roomType[i] = RoomType.Hall;
				} else if (roomsBool[i][1] && roomsBool[i][2]) {
					toSpawn = hallWith2OpenL[Random.Range(0, hallWith2OpenL.Count)];
					roomRotation[i] = 1;
					roomType[i] = RoomType.Hall;
				} else if (roomsBool[i][2] && roomsBool[i][3]) {
					toSpawn = hallWith2OpenL[Random.Range(0, hallWith2OpenL.Count)];
					roomRotation[i] = 2;
					roomType[i] = RoomType.Hall;
				} else if (roomsBool[i][3] && roomsBool[i][0]) {
					toSpawn = hallWith2OpenL[Random.Range(0, hallWith2OpenL.Count)];
					roomRotation[i] = 3;
					roomType[i] = RoomType.Hall;
				}
				//hallWith3Open
				if (roomsBool[i][0] && roomsBool[i][1] && roomsBool[i][2]) {
					toSpawn = hallWith3Open[Random.Range(0, hallWith3Open.Count)];
					roomRotation[i] = 0;
					roomType[i] = RoomType.Hall;
				} else if (roomsBool[i][1] && roomsBool[i][2] && roomsBool[i][3]) {
					toSpawn = hallWith3Open[Random.Range(0, hallWith3Open.Count)];
					roomRotation[i] = 1;
					roomType[i] = RoomType.Hall;
				} else if (roomsBool[i][2] && roomsBool[i][3] && roomsBool[i][0]) {
					toSpawn = hallWith3Open[Random.Range(0, hallWith3Open.Count)];
					roomRotation[i] = 2;
					roomType[i] = RoomType.Hall;
				} else if (roomsBool[i][3] && roomsBool[i][0] && roomsBool[i][1]) {
					toSpawn = hallWith3Open[Random.Range(0, hallWith3Open.Count)];
					roomRotation[i] = 3;
					roomType[i] = RoomType.Hall;
				}
				//hallWith4Open
				if (roomsBool[i][0] && roomsBool[i][1] && roomsBool[i][2] && roomsBool[i][3]) {
					toSpawn = hallWith4Open[Random.Range(0, hallWith4Open.Count)];
					roomRotation[i] = Random.Range(0, 4);
					roomType[i] = RoomType.Hall;
				}
			}

			if (!toSpawn) continue;
			toSpawn = Instantiate(toSpawn);
			toSpawn.SetActive(true);
			toSpawn.transform.position = new Vector3(roomsVec2[i].x, 0f, roomsVec2[i].y) * gridScale;
			toSpawn.transform.Rotate(0f, roomRotation[i] * 90f, 0f);
			toSpawn.transform.parent = transform;
			toSpawn.name = roomsVec2[i].ToString();
			if (roomType[i] == RoomType.Room || roomType[i] == RoomType.Big) { roomsForSpawning.Add(roomsVec2[i]); }
			currentRooms.Add(toSpawn);
		}

		foreach (Vector2Int item in roomsForSpawning) {
			Debug.Log(item.ToString());
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
		roomsForSpawning.Remove(Vector2Int.zero);

		//Spawn Exit
		GameObject theExit = null;
		if (exit.scene.rootCount == 0) {
			theExit = Instantiate(exit);
		} else {
			theExit = exit;
		}
		Vector2Int farthestRoom = Vector2Int.zero;
		foreach (Vector2Int room in roomsForSpawning) {
			if (Vector2Int.Distance(room, Vector2Int.zero) > Vector2Int.Distance(farthestRoom, Vector2Int.zero)) {
				farthestRoom = room;
			}
		}
		Vector3 newPosition = new Vector3(farthestRoom.x, 0f, farthestRoom.y);
		theExit.transform.position = newPosition * gridScale;
		theExit.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
		theExit.transform.parent = transform;
		roomsForSpawning.Remove(farthestRoom);

		//Spawn Portal
		newIndex = Random.Range(0, roomsForSpawning.Count);
		Vector2Int portalRoom = roomsForSpawning[newIndex];
		GameObject thePortal = null;
		if (portal.scene.rootCount == 0) {
			thePortal = Instantiate(portal);
		} else {
			thePortal = portal;
		}
		thePortal.transform.position = new Vector3(portalRoom.x, 0f, portalRoom.y) * gridScale;
		thePortal.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
		thePortal.transform.parent = transform;

		//Spawn Treasure
		newIndex = Random.Range(0, roomsForSpawning.Count);
		Vector2Int treasureRoom = roomsForSpawning[newIndex];
		GameObject theTreasure = null;
		if (treasure.scene.rootCount == 0) {
			theTreasure = Instantiate(treasure);
		} else {
			theTreasure = treasure;
		}
		theTreasure.transform.position = new Vector3(treasureRoom.x, 0f, treasureRoom.y) * gridScale;
		theTreasure.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
		theTreasure.transform.parent = transform;

		//Spawn Enemies
		foreach (Vector2Int thisRoom in roomsForSpawning) {
			if (Random.Range(0f, 1f) < oddsOfEnemyPerRoom) {
				Vector3 offset = new Vector3(0, 1.25f, 0);
				GameObject enemySpawn = Instantiate(enemy, new Vector3(thisRoom.x, 0f, thisRoom.y) * gridScale + offset, Quaternion.identity);
				enemySpawn.transform.parent = transform;
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
	public void ReturnPortal()
	{
		GameManager.currentFloor = 0;
		Destroy(gameObject);
		SceneManager.LoadScene("HoldingRoom");
	}

	IEnumerator BuildNavMesh() {
		yield return null;

		surface.BuildNavMesh();
	}
}




#if UNITY_EDITOR
[CustomEditor(typeof(Dungeon1Generator))]
public class Dungeon1GeneratorEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		if (GUILayout.Button("Generate")) {
			(target as Dungeon1Generator).Generate();
		}

		if (GUILayout.Button("Clear")) {
			(target as Dungeon1Generator).Clear();
		}
	}
}
#endif