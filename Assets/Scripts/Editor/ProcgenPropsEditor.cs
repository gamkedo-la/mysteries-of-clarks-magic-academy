using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ProcgenProps))]
public class ProcgenPropsEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		if (GUILayout.Button("Generate")) {
			(target as ProcgenProps).Generate();
		}
	}
}
