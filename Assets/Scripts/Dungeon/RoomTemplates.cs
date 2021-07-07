using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTemplates : MonoBehaviour {
	public static RoomTemplates Instance;
	//If you want a room to have a higher % chance to get pulled, add multiple instances in the array

	public int dungeonNumber = 0;

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRooms;

	public List<GameObject> rooms;

	public float waitTime;
	private bool exitRoom;
	public GameObject staircase;

	private bool treasurePlaced;
	public float percentChanceToSpawnTreasure = 50;
	float TreasureSpawnPercent;
	public GameObject treasure;

	private bool playerPlaced;
	Vector3 spawnHeight = new Vector3(0, 1.4f, 0);
	GameObject loadScreen;

	public GameObject enemy;
	public int EnemiesSpawnedPercentageMin = 10, EnemiesSpawnedPercentageMax = 50;
	int enemiesToSpawn;

	GameObject parented;
	GameObject playerSpawn;
	GameObject staircaseSpawn, enemySpawn, treasureSpawn;

	public GameObject StartingPointRoom;
	GameObject startingP;

	GameObject turnOffMenu;
	public string LevelName;

	public List<PrefabLevelPair> specialLevels;
	public bool levelIsSpecial = false;
	public int currentLevel;
	public bool startHasRun = false;

	[System.Serializable]
	public class PrefabLevelPair {
		public GameObject levelPrefab;
		public int levelNumber;
	}

	private void Start() {
		if (startHasRun) return;

		if (Instance != null) {
			Destroy(gameObject);
			return;
		}
		else 
		{
			Instance = this;
		}

		DontDestroyOnLoad(gameObject);

		playerSpawn = GameObject.FindGameObjectWithTag("Player");
		loadScreen = GameObject.Find("LoadingScreen");
		turnOffMenu = GameObject.Find("DialogueBoxForStairs");
		turnOffMenu.SetActive(false);
		parented = GameObject.FindGameObjectWithTag("Rooms");
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
				specialLevel.transform.parent = gameObject.transform;
				levelIsSpecial = true;
				break;
			}
		}

		if (!levelIsSpecial) {
			Debug.Log("Instanciating first room");
			startingP = Instantiate(StartingPointRoom, transform.position, Quaternion.identity) as GameObject;
			startingP.transform.parent = parented.transform;
			StartCoroutine(Waiting());
			TreasureSpawnPercent = Random.Range(0, 100);
			//  print(TreasureSpawnPercent + " " + percentChanceToSpawnTreasure);
		}

		startHasRun = true;
	}

	private void Update() {
		if (Input.GetKey(KeyCode.Q)) {
			ClearTheRooms();
		}

		if (waitTime <= 0) {
			if (!playerPlaced) {
				if (!exitRoom) {
					for (int i = 0; i < rooms.Count; i++) {
						if (i == rooms.Count - 1) {
							staircaseSpawn = Instantiate(staircase, rooms[i].transform.position, Quaternion.identity) as GameObject;

							if (!treasurePlaced && percentChanceToSpawnTreasure >= TreasureSpawnPercent) {
								treasureSpawn = Instantiate(treasure, rooms[Random.Range(1, rooms.Count - 1)].transform.position, Quaternion.identity) as GameObject;
								treasurePlaced = true;
							}
							exitRoom = true;
							playerPlaced = true;

							staircaseSpawn.transform.parent = parented.transform;
							treasureSpawn.transform.parent = parented.transform;

						}
					}
				}

				playerSpawn.transform.position = rooms[0].transform.position + spawnHeight;
				loadScreen.SetActive(false);
			}
			for (int i = 0; i < enemiesToSpawn; i++) {
				if (enemiesToSpawn > 0) {
					Vector3 offset = new Vector3(0, 1.25f, 0);
					enemySpawn = Instantiate(enemy, rooms[Random.Range(1, rooms.Count - 1)].transform.position + offset, Quaternion.identity) as GameObject;
					enemiesToSpawn--;
					enemySpawn.transform.parent = parented.transform;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}

	}

	public void RunStartOfScene() {
		playerSpawn = GameObject.FindGameObjectWithTag("Player");
		loadScreen = GameObject.Find("LoadingScreen");
		loadScreen?.SetActive(false);
		turnOffMenu = GameObject.Find("DialogueBoxForStairs");
		turnOffMenu?.SetActive(false);
		parented = GameObject.FindGameObjectWithTag("Rooms");
	}

	public void ClearTheRooms() {
		for (int i = rooms.Count - 1; i >= 0; i--) {
			Destroy(rooms[i]);
			rooms.RemoveAt(i);
		}
	}

	IEnumerator Waiting() {
		yield return new WaitForSeconds(waitTime);
		enemiesToSpawn = Random.Range(rooms.Count * EnemiesSpawnedPercentageMin / 100, rooms.Count  * EnemiesSpawnedPercentageMax/100);
		//   print(enemiesToSpawn);
	}

	public void AdvanceFloor() {
		GameManager.currentFloor++;
		if (GameManager.currentFloor > GameManager.DungeonFloorCount[dungeonNumber]) GameManager.DungeonFloorCount[dungeonNumber] = GameManager.currentFloor;
		Destroy(gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void StayOnFloor() {
		turnOffMenu.SetActive(false);
	}
}
