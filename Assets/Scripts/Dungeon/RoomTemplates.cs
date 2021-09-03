using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.AI.Navigation;

public class RoomTemplates : MonoBehaviour {

    public bool spawnedRoomsAreStatic = true; // not allowed to move, but they draw faster

	public static RoomTemplates Instance;
	//If you want a room to have a higher % chance to get pulled, add multiple instances in the array

	public NavMeshSurface surface;

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


	public GameObject portal;
	private bool portalPlaced;
	public float percentChanceToSpawnPortal = 50;
	float PortalSpawnPercent;

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
	GameObject staircaseSpawn, enemySpawn, treasureSpawn, portalSpawn;

	public GameObject StartingPointRoom;
	GameObject startingP;

	GameObject turnOffMenu;
	public string LevelName;

	public List<PrefabLevelPair> specialLevels;
	public bool levelIsSpecial = false;
	public int currentLevel;
	public bool startHasRun = false;

	public Text currentFloorText;

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
		currentFloorText.text = (currentLevel + 1).ToString();

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
                if (spawnedRoomsAreStatic) specialLevel.isStatic = true; // static prefabs draw faster but can't move
				levelIsSpecial = true;

				break;
			}
		}

		if (!levelIsSpecial) {
			Debug.Log("Instanciating first room");
			startingP = Instantiate(StartingPointRoom, transform.position, Quaternion.identity) as GameObject;
			startingP.transform.parent = parented.transform;
            if (spawnedRoomsAreStatic) startingP.isStatic = true; // static prefabs draw faster but can't move

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
						if (i == rooms.Count - 2)
						{
							if (!portalPlaced && percentChanceToSpawnPortal >= PortalSpawnPercent)
							{
								portalSpawn = Instantiate(portal, rooms[Random.Range(1, rooms.Count - 2)].transform.position, Quaternion.identity) as GameObject;
								portalPlaced = true;
							}
							portalSpawn.transform.parent = parented.transform;
                            if (spawnedRoomsAreStatic) portalSpawn.isStatic = true; // static prefabs draw faster but can't move

						}
						if (i == rooms.Count - 1) 
						{
							staircaseSpawn = Instantiate(staircase, rooms[i].transform.position, Quaternion.identity) as GameObject;

							if (!treasurePlaced && percentChanceToSpawnTreasure >= TreasureSpawnPercent) {
								treasureSpawn = Instantiate(treasure, rooms[Random.Range(1, rooms.Count - 1)].transform.position, Quaternion.identity) as GameObject;
								treasurePlaced = true;
							}
							exitRoom = true;
							playerPlaced = true;

							staircaseSpawn.transform.parent = parented.transform;
                            if (spawnedRoomsAreStatic) staircaseSpawn.isStatic = true; // static prefabs draw faster but can't move
							treasureSpawn.transform.parent = parented.transform;
                            // if (spawnedRoomsAreStatic) treasureSpawn.isStatic = true; // static prefabs draw faster but can't move

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

			StartCoroutine(BuildNavMesh());
		} 
		
		else 
		
		{
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

	public void ReturnToPortal()
	{
		GameManager.currentFloor = 0;
		if (GameManager.currentFloor > GameManager.DungeonFloorCount[dungeonNumber]) GameManager.DungeonFloorCount[dungeonNumber] = GameManager.currentFloor;
		Destroy(gameObject);
		SceneManager.LoadScene("HoldingRoom");
	}



	IEnumerator BuildNavMesh()
	{
		yield return null;

		surface.BuildNavMesh();
	}
}


/*
#if UNITY_EDITOR
[CustomEditor(typeof(Dungeon5Generator))]
public class Dungeon5GeneratorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Generate"))
		{
			(target as Dungeon5Generator).Generate();
		}

		if (GUILayout.Button("Clear"))
		{
			(target as Dungeon5Generator).Clear();
		}
	}
}
#endif*/