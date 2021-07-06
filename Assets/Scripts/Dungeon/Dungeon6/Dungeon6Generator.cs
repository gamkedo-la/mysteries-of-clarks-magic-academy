using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon6Generator : MonoBehaviour {
	public List<PrefabLevelPair> specialLevels;
	public List<TileDensityPair> tiles;

	public AnimationCurve densityFalloffCurve;
	public float gridScale;

	private int currentLevel;
	private float[] densityMap;
	private List<GameObject> currentRooms;

	[System.Serializable]
	public class PrefabLevelPair {
		public GameObject levelPrefab;
		public int levelNumber;
	}

	[System.Serializable]
	public class TileDensityPair {
		public GameObject tilePrefab;
		public float density;
	}

}
