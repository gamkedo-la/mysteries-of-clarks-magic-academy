using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.AI.Navigation;

public class Dungeon4Generator : MonoBehaviour {
	public static Dungeon4Generator Instance;
	public NavMeshSurface surface;

	public int dungeonNumber = 4;
	public int currentLevel;

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

		//Initialize map abstraction
		List<Vector2> roomsVec2 = new List<Vector2>();
		List<bool[]> roomsbool = new List<bool[]>();
		List<Vector2> dir = new List<Vector2>() {Vector2.up, Vector2.right, Vector2.down, Vector2.left};
		roomsVec2.Add(Vector2.zero);
		roomsbool.Add(new bool[] { false, false, false, false });

		//Generate map
		while (roomsVec2.Count <= currentLevel + 1) {
			int newIndex = Random.Range(0, roomsVec2.Count);
			int newDir = Random.Range(0, 4);
			Vector2 oldPos = roomsVec2[newIndex];
			Vector2 newPos = oldPos + dir[newDir];
			if (!roomsVec2.Contains(newPos)) {
				roomsVec2.Add(newPos);
				roomsbool.Add(new bool[] { false, false, false, false });
			}
			roomsbool[newIndex][newDir] = true;
			roomsbool[roomsbool.Count-1][(newDir + 2) % 4] = true;
		}

		//Instanciate map
		for (int i = 0; i < roomsVec2.Count; i++) {
			GameObject floor = Instantiate(floorTemplate.gameObject);
			List<GameObject> targetTransforms = floor.GetComponent<FourSidedTileGenerator>().targetTransforms;

			floor.transform.position = new Vector3(roomsVec2[i].x, 0f, roomsVec2[i].y) * gridScale;
			floor.transform.parent = transform;
		}


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