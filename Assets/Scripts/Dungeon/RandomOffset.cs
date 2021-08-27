using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOffset : MonoBehaviour {
	public Vector3 positionOffsetRange;
	public Vector3 rotationOffsetRange;
	public Vector3 scaleOffsetRange;

	void Start() {
		Vector3 newPositionOffset = new Vector3();
		newPositionOffset.x = positionOffsetRange.x * Random.Range(-1f, 1f);
		newPositionOffset.y = positionOffsetRange.y * Random.Range(-1f, 1f);
		newPositionOffset.z = positionOffsetRange.z * Random.Range(-1f, 1f);

		transform.Translate(newPositionOffset, Space.Self);

		Vector3 newRotationOffset = new Vector3();
		newRotationOffset.x = rotationOffsetRange.x * Random.Range(-1f, 1f);
		newRotationOffset.y = rotationOffsetRange.y * Random.Range(-1f, 1f);
		newRotationOffset.z = rotationOffsetRange.z * Random.Range(-1f, 1f);

		transform.Rotate(newRotationOffset);

		Vector3 newScaleOffset = new Vector3();
		newScaleOffset.x = scaleOffsetRange.x * Random.Range(-1f, 1f);
		newScaleOffset.y = scaleOffsetRange.y * Random.Range(-1f, 1f);
		newScaleOffset.z = scaleOffsetRange.z * Random.Range(-1f, 1f);

		transform.localScale += newScaleOffset;


	}
}
