using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawnStudent : MonoBehaviour
{
    public GameObject[] students;
    public int min, max;
    private void Start()
    {
        int randomRange = Random.Range(min, max);
        for (int i = 0; i < randomRange; i++)
        {
            GameObject studentSpawn = Instantiate(students[i], transform.position, transform.rotation) as GameObject;
            i++;
        }
    }
}
