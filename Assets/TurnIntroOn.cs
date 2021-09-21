using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIntroOn : MonoBehaviour
{
    public int day;
    public int month;
    public int timeOfDay;

    public GameObject sceneToTurnOn;
    private void Start()
    {
        if (GameManager.day == day && GameManager.month == month && GameManager.timeOfDay == timeOfDay)
        {
            sceneToTurnOn.SetActive(true);
        }
    }
}
