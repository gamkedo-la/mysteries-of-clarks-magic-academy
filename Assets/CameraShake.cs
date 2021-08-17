using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject[] cameras;

    public Animator[] camerasAnim;

    private void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            camerasAnim[i].GetComponent<Animator>().Play("Shake");
        }
    }
}
