using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon6Generator : MonoBehaviour {
	public List<PrefabLevelPair> specialLevels;

	private int currentLevel;
	private float[] densityMap;

	public class PrefabLevelPair {
		public GameObject levelPrefab;
		public int levelNumber;
	}

}
