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

	private int currentLevel;
	private float[,] densityMap;
	private int mapSize = 20;
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

		densityMap = new float[mapSize, mapSize];
		for (int x = 0; x < mapSize; x++) {
			for (int y = 0; y < mapSize; y++) {
				densityMap[x, y] = 1f;
			}
		}


		//room generation
		for (int i = 0; i <= currentLevel; i++) {
			float radius = Random.Range(5f, 10f);
			float centerX = Random.Range(0, mapSize);
			float centerY = Random.Range(0, mapSize);
			
			for (int x = 0; x < mapSize; x++) {
				for (int y = 0; y < mapSize; y++) {
					densityMap[x, y] = 1f - densityFalloffCurve.Evaluate(Vector2.Distance(new Vector2((int)x, (int)y), new Vector2(centerX, centerY)) / radius);
				}
			}
		}



		for (int x = 0; x < mapSize; x++) {
			for (int y = 0; y < mapSize; y++) {
				float density = densityMap[x, y];
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
