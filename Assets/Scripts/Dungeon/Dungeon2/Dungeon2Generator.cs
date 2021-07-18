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

	public int minStreetLength = 1;
	public int maxStreetLength = 4;
	public int blockLength = 6;

	public List<GameObject> streetSide;
	public List<GameObject> streetInsideCourner;
	public List<GameObject> streetOutsideCourner;
	public List<GameObject> streetEndL;
	public List<GameObject> streetEndR;
	
	public int enemiesSpawnedPerTileMin = 10, enemiesSpawnedPerTileMax = 50;

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

		if (blockLength <= 2) blockLength += 2;

		//Generate Street Map
		List<Vector2> horStreets = new List<Vector2>();
		List<Vector2> verStreets = new List<Vector2>();
		List<Vector2> streets = new List<Vector2>();
		int streetLength = (int)(currentLevel*0.2f)+1;
		Debug.Log(currentLevel + " " + streetLength*blockLength);
		for (int x = 0; x < streetLength*blockLength; x++) {
			horStreets.Add(new Vector2(x, 0));
			horStreets.Add(new Vector2(x, 1));
			streets.Add(new Vector2(x, 0));
			streets.Add(new Vector2(x, 1));
		}
		for (int i = 0; i <= currentLevel; i++) {
			streetLength = Random.Range(minStreetLength, maxStreetLength+1) * blockLength;
			int x1 = 0;
			int x2 = 0;
			int y1 = 0;
			int y2 = 0;
			if (i % 2 == 0) {
				//Debug.Log("Ver");
				Vector2 startPos = horStreets[Random.Range(0, horStreets.Count)];
				x1 = (int)startPos.x;
				x2 = x1 + 1;
				y1 = (int)startPos.y - (Random.Range(0, streetLength));
				y2 = y1 + (streetLength)-1;
			} else {
				//Debug.Log("Hor");
				Vector2 startPos = verStreets[Random.Range(0, verStreets.Count)];
				x1 = (int)startPos.x - (Random.Range(0, streetLength));
				x2 = x1 + (streetLength)-1;
				y1 = (int)startPos.y;
				y2 = y1 + 1;
			}
			while (x1 % blockLength != 0) { x1--; x2--; }
			while (y1 % blockLength != 0) { y1--; y2--; }

			for (int x = x1; x <= x2; x++) {
				for (int y = y1; y <= y2; y++) {
					Vector2 newPosition = new Vector2(x, y);
					if (i % 2 == 0) {
						verStreets.Add(newPosition);
						if (!streets.Contains(newPosition)) streets.Add(newPosition);
					} else {
						horStreets.Add(newPosition);
						if (!streets.Contains(newPosition)) streets.Add(newPosition);
					}
				}
			}
		}

		//Instanciate tiles
		List<GameObject> ends = new List<GameObject>();
		foreach (Vector2 tile in streets) {
			GameObject toSpawn = null;
			float spawnRotation = 0f;
			bool isEnd = false;

			//streetSide
			if (streets.Contains(tile + Vector2.down) && !streets.Contains(tile + Vector2.up)) {
				toSpawn = streetSide[Random.Range(0, streetSide.Count)];
				spawnRotation = 0f;
			} else if (streets.Contains(tile + Vector2.left) && !streets.Contains(tile + Vector2.right)) {
				toSpawn = streetSide[Random.Range(0, streetSide.Count)];
				spawnRotation = 90f;
			} else if (streets.Contains(tile + Vector2.up) && !streets.Contains(tile + Vector2.down)) {
				toSpawn = streetSide[Random.Range(0, streetSide.Count)];
				spawnRotation = 180f;
			} else if (streets.Contains(tile + Vector2.right) && !streets.Contains(tile + Vector2.left)) {
				toSpawn = streetSide[Random.Range(0, streetSide.Count)];
				spawnRotation = 270f;
			}
			//streetInsideCourner
			if (!streets.Contains(tile + Vector2.up) && !streets.Contains(tile + Vector2.right)) {
				toSpawn = streetInsideCourner[Random.Range(0, streetInsideCourner.Count)];
				spawnRotation = 0f;
			} else if (!streets.Contains(tile + Vector2.right) && !streets.Contains(tile + Vector2.down)) {
				toSpawn = streetInsideCourner[Random.Range(0, streetInsideCourner.Count)];
				spawnRotation = 90f;
			} else if (!streets.Contains(tile + Vector2.down) && !streets.Contains(tile + Vector2.left)) {
				toSpawn = streetInsideCourner[Random.Range(0, streetInsideCourner.Count)];
				spawnRotation = 180f;
			} else if (!streets.Contains(tile + Vector2.left) && !streets.Contains(tile + Vector2.up)) {
				toSpawn = streetInsideCourner[Random.Range(0, streetInsideCourner.Count)];
				spawnRotation = 270f;
			}
			//streetOutsideCourner
			if (streets.Contains(tile + Vector2.up) && streets.Contains(tile + Vector2.right) && !streets.Contains(tile + Vector2.up + Vector2.right)) {
				toSpawn = streetOutsideCourner[Random.Range(0, streetOutsideCourner.Count)];
				spawnRotation = 0f;
			} else if (streets.Contains(tile + Vector2.right) && streets.Contains(tile + Vector2.down) && !streets.Contains(tile + Vector2.right + Vector2.down)) {
				toSpawn = streetOutsideCourner[Random.Range(0, streetOutsideCourner.Count)];
				spawnRotation = 90f;
			} else if (streets.Contains(tile + Vector2.down) && streets.Contains(tile + Vector2.left) && !streets.Contains(tile + Vector2.down + Vector2.left)) {
				toSpawn = streetOutsideCourner[Random.Range(0, streetOutsideCourner.Count)];
				spawnRotation = 180f;
			} else if (streets.Contains(tile + Vector2.left) && streets.Contains(tile + Vector2.up) && !streets.Contains(tile + Vector2.left + Vector2.up)) {
				toSpawn = streetOutsideCourner[Random.Range(0, streetOutsideCourner.Count)];
				spawnRotation = 270f;
			}
			//streetEndL
			if (streets.Contains(tile + Vector2.right) && !streets.Contains(tile + Vector2.left) && !streets.Contains(tile + Vector2.up) && !streets.Contains(tile + Vector2.right*2)) {
				toSpawn = streetEndL[Random.Range(0, streetEndL.Count)];
				spawnRotation = 0f;
				isEnd = true;
			} else if (streets.Contains(tile + Vector2.down) && !streets.Contains(tile + Vector2.up) && !streets.Contains(tile + Vector2.right) && !streets.Contains(tile + Vector2.down*2)) {
				toSpawn = streetEndL[Random.Range(0, streetEndL.Count)];
				spawnRotation = 90f;
				isEnd = true;
			} else if (streets.Contains(tile + Vector2.left) && !streets.Contains(tile + Vector2.right) && !streets.Contains(tile + Vector2.down) && !streets.Contains(tile + Vector2.left*2)) {
				toSpawn = streetEndL[Random.Range(0, streetEndL.Count)];
				spawnRotation = 180f;
				isEnd = true;
			} else if (streets.Contains(tile + Vector2.up) && !streets.Contains(tile + Vector2.down) && !streets.Contains(tile + Vector2.left) && !streets.Contains(tile + Vector2.up*2)) {
				toSpawn = streetEndL[Random.Range(0, streetEndL.Count)];
				spawnRotation = 270f;
				isEnd = true;
			}
			//streetEndR
			if (streets.Contains(tile + Vector2.left) && !streets.Contains(tile + Vector2.right) && !streets.Contains(tile + Vector2.up) && !streets.Contains(tile + Vector2.left*2)) {
				toSpawn = streetEndR[Random.Range(0, streetEndR.Count)];
				spawnRotation = 0f;
				isEnd = true;
			} else if (streets.Contains(tile + Vector2.up) && !streets.Contains(tile + Vector2.down) && !streets.Contains(tile + Vector2.right) && !streets.Contains(tile + Vector2.up*2)) {
				toSpawn = streetEndR[Random.Range(0, streetEndR.Count)];
				spawnRotation = 90f;
				isEnd = true;
			} else if (streets.Contains(tile + Vector2.right) && !streets.Contains(tile + Vector2.left) && !streets.Contains(tile + Vector2.down) && !streets.Contains(tile + Vector2.right*2)) {
				toSpawn = streetEndR[Random.Range(0, streetEndR.Count)];
				spawnRotation = 180f;
				isEnd = true;
			} else if (streets.Contains(tile + Vector2.down) && !streets.Contains(tile + Vector2.up) && !streets.Contains(tile + Vector2.left) && !streets.Contains(tile + Vector2.down*2)) {
				toSpawn = streetEndR[Random.Range(0, streetEndR.Count)];
				spawnRotation = 270f;
				isEnd = true;
			}


			if (!toSpawn) continue;
			toSpawn = Instantiate(toSpawn);
			toSpawn.SetActive(true);
			toSpawn.transform.position = new Vector3(tile.x, 0f, tile.y) * gridScale;
			toSpawn.transform.Rotate(0f, spawnRotation, 0f);
			toSpawn.transform.parent = transform;
			if (isEnd) ends.Add(toSpawn);
			else currentRooms.Add(toSpawn);
		}

		//Spawn Player
		GameObject thePlayer = null;
		if (player.scene.rootCount == 0) {
			thePlayer = Instantiate(player);
		} else {
			thePlayer = player;
		}
		thePlayer.transform.position = new Vector3(0f, 1.4f, 0f);
		if (ends.Count > 0) {
			GameObject theEnd = ends[Random.Range(0, ends.Count)];
			thePlayer.transform.position += theEnd.transform.position;
			thePlayer.transform.rotation = theEnd.transform.rotation;
			thePlayer.transform.Rotate(0f, 90f, 0f);
			ends.Remove(theEnd);
		} else {
			thePlayer.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
		}

		//Spawn Exit
		GameObject theExit = null;
		if (exit.scene.rootCount == 0) {
			theExit = Instantiate(exit);
		} else {
			theExit = exit;
		}
		if (ends.Count > 0) {
			GameObject theEnd = ends[Random.Range(0, ends.Count)];
			foreach (GameObject room in ends) {
				if (Vector3.Distance(thePlayer.transform.position, theEnd.transform.position) < Vector3.Distance(thePlayer.transform.position, room.transform.position)) {
					theEnd = room;
				}
			}
			theExit.transform.position = theEnd.transform.position;
			theExit.transform.rotation = theEnd.transform.rotation;
			thePlayer.transform.Rotate(0f, 180f, 0f);
			ends.Remove(theEnd);
		} else {
			theExit.transform.position = currentRooms[Random.Range(0, currentRooms.Count)].transform.position;
			theExit.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
		}
		theExit.transform.parent = transform;

		//Spawn Treasure
		GameObject theTreasure = null;
		if (treasure.scene.rootCount == 0) {
			theTreasure = Instantiate(treasure);
		} else {
			theTreasure = treasure;
		}
		theTreasure.transform.position = currentRooms[Random.Range(0, currentRooms.Count)].transform.position;
		theTreasure.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
		theTreasure.transform.parent = transform;

		//Spawn Enemies
		int enemiesToSpawn = Random.Range(currentRooms.Count * enemiesSpawnedPerTileMin / 100, currentRooms.Count  * enemiesSpawnedPerTileMax/100);
		Debug.Log(enemiesToSpawn);
		for (int i = 0; i < enemiesToSpawn; i++) {
			if (enemiesToSpawn > 0) {
				Vector3 offset = new Vector3(0, 1.25f, 0);
				GameObject enemySpawn = Instantiate(enemy, currentRooms[Random.Range(1, currentRooms.Count)].transform.position + offset, Quaternion.identity);
				enemiesToSpawn--;
				enemySpawn.transform.parent = transform;
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
