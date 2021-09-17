using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailStates : MonoBehaviour
{
    public GameObject[] FailStatesConversations;

    private void Start()
    {
        if (!GameManager.SkyeSaved && (GameManager.month == 4 && GameManager.day == 26))
        {
            FailStatesConversations[0].SetActive(true);
        }

        else if (!GameManager.JameelSaved && (GameManager.month == 5 && GameManager.day == 3))
        {
            FailStatesConversations[1].SetActive(true);
        }

        else if (!GameManager.GracieMaySaved && (GameManager.month == 5 && GameManager.day == 10))
        {
            FailStatesConversations[2].SetActive(true);
        }

        else if (!GameManager.HarperSaved && (GameManager.month == 5 && GameManager.day == 17))
        {
            FailStatesConversations[3].SetActive(true);
        }

        else if (!GameManager.SullivanSaved && (GameManager.month == 5 && GameManager.day == 23))
        {
            FailStatesConversations[4].SetActive(true);
        }
    }
}
