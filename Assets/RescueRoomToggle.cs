using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueRoomToggle : MonoBehaviour
{
    public GameObject[] Rooms;

    private void Start()
    {
        if (GameManager.month == 4 && (GameManager.day >= 21 && GameManager.day <= 25))
        {
            Rooms[0].SetActive(true);
            GameManager.SkyeSaved = true;
        }

        else if (GameManager.month == 4 && (GameManager.day >= 28 && GameManager.day <= 30))
        {
            Rooms[1].SetActive(true);
            GameManager.JameelSaved = true;
        }

        else if (GameManager.month == 5 && (GameManager.day >= 1 && GameManager.day <= 2))
        {
            Rooms[1].SetActive(true);
            GameManager.JameelSaved = true;
        }

        else if (GameManager.month == 5 && (GameManager.day >= 5 && GameManager.day <= 9))
        {
            Rooms[2].SetActive(true);
            GameManager.GracieMaySaved = true;
        }

        else if (GameManager.month == 5 && (GameManager.day >= 10 && GameManager.day <= 16))
        {
            Rooms[3].SetActive(true);
            GameManager.HarperSaved = true;
        }

        else if (GameManager.month == 5 && (GameManager.day >= 18 && GameManager.day <= 22))
        {
            Rooms[4].SetActive(true);
            GameManager.SullivanSaved = true;
        }

        else if (GameManager.month == 5 && (GameManager.day >= 29 && GameManager.day <= 31))
        {
            Rooms[5].SetActive(true);
            GameManager.AtornSaved = true;
        }
    }
}
