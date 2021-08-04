using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColor : MonoBehaviour
{
    public GameObject stars;

    private void Start()
    {
        if (GameManager.timeOfDay == 4)
        {
            stars.SetActive(true);
        }
        else
            stars.SetActive(false);
    }
}
