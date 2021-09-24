using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameState : MonoBehaviour {
	[FMODUnity.ParamRef]
	public string parameter = "GameState";
	public gameState value;


	void Start() {
		FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameter, (float)value);
	}

	public enum gameState {
		Dungeon,
		Castle,
		Class,
		Freetime,
		Friendship
	}
}
