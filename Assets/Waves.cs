using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    private Vector3 startPos;

    float frequency = 1;
    float magnitude = 2f;
    float offset = 0;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position = startPos + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }
}
