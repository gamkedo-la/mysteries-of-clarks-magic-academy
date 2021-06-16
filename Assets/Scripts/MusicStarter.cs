using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour {
	[FMODUnity.EventRef]
	public string musicEvent = "";
	public static FMOD.Studio.EventInstance instance;

	void Start() {
		if(!instance.isValid()) {
			instance = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
			instance.start();
		}
	}
}
