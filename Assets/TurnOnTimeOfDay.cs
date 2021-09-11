using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTimeOfDay : MonoBehaviour
{
    public GameObject morning, lunch, afternoon, evening, night;

    private void Start()
    {
        if (GameManager.timeOfDay == 0)
        {
            morning.SetActive(true);
            lunch.SetActive(false);
            afternoon.SetActive(false);
            evening.SetActive(false);
            night.SetActive(false);
        }

        else if (GameManager.timeOfDay == 1)
        {
            morning.SetActive(false);
            lunch.SetActive(true);
            afternoon.SetActive(false);
            evening.SetActive(false);
            night.SetActive(false);
        }

        else if (GameManager.timeOfDay == 2)
        {
            morning.SetActive(false);
            lunch.SetActive(false);
            afternoon.SetActive(true);
            evening.SetActive(false);
            night.SetActive(false);
        }

        else if (GameManager.timeOfDay == 3)
        {
            morning.SetActive(false);
            lunch.SetActive(false);
            afternoon.SetActive(false);
            evening.SetActive(true);
            night.SetActive(false);
        }

        else
        {
            morning.SetActive(false);
            lunch.SetActive(false);
            afternoon.SetActive(false);
            evening.SetActive(false);
            night.SetActive(true);
        }
    }
}
