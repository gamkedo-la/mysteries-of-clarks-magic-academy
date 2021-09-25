using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBasedOnTime : MonoBehaviour
{
    public bool morning, lunch, afternoon, evening, night;
    public GameObject studentToTurnOn;
    void Update()
    {
        if (GameManager.timeOfDay == 0 && morning)
        {
            studentToTurnOn.SetActive(true);
        }

        if (GameManager.timeOfDay == 1 && lunch)
        {
            studentToTurnOn.SetActive(true);
        }

        if (GameManager.timeOfDay == 2 && afternoon)
        {
            studentToTurnOn.SetActive(true);
        }

        if (GameManager.timeOfDay == 3 && evening)
        {
            studentToTurnOn.SetActive(true);
        }

        if (GameManager.timeOfDay == 4 && night)
        {
            studentToTurnOn.SetActive(true);
        }
    }
}
