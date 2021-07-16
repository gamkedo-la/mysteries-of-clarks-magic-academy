using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon2Generator : MonoBehaviour {
	public static Dungeon2Generator Instance;
	public int dungeonNumber = 2;
	public int currentLevel;

	public List<PrefabLevelPair> specialLevels;
	public bool levelIsSpecial = false;

	public float gridScale = 15f;

	public List<GameObject> streetSide;
	public List<GameObject> streetCourner;
	public List<GameObject> streetEnds;
	public List<GameObject> alleywayStart;
	public List<GameObject> alleyway;
	public List<GameObject> alleywayEnd;

	public float percentChanceToSpawnTreasure = 50f;
	public int enemiesSpawnedPerClearingeMin = 3, enemiesSpawnedPerClearingMax = 10;

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
				return;
			}
		}



	}

	public void AdvanceFloor() {
		GameManager.currentFloor++;
		if (GameManager.currentFloor < 0) GameManager.currentFloor = 0;
		if (GameManager.currentFloor > GameManager.DungeonFloorCount[dungeonNumber]) GameManager.DungeonFloorCount[dungeonNumber] = GameManager.currentFloor;
		Destroy(gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
