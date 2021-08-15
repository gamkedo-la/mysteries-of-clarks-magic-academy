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

	public float gridScale = 15f;

	public GameObject enemy;
	public GameObject treasure;
	public GameObject exit;
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