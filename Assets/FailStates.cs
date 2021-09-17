using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailStates : MonoBehaviour
{
    public GameObject[] FailStatesConversations;
    public GameObject[] SuccessfulOperation;

    private void Start()
    {
        if (GameManager.month == 4 && GameManager.day == 25)
        {
            if (!GameManager.SkyeSaved)
            {
                FailStatesConversations[0].SetActive(true);
            }
            else
            {
                SuccessfulOperation[0].SetActive(true);
            }
            
        }

        else if (GameManager.month == 5 && GameManager.day == 2)
        {
            if (!GameManager.SkyeSaved)
            {
                FailStatesConversations[1].SetActive(true);
            }
            else
            {
                SuccessfulOperation[1].SetActive(true);
            }
        }

        else if (GameManager.month == 5 && GameManager.day == 9)
        {
            if (!GameManager.SkyeSaved)
            {
                FailStatesConversations[2].SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("GroundFloor");
                GameManager.playerSpawn = new Vector3(-15.32f, -6.6f, 35.85f);
                GameManager.playerRotation = new Quaternion(0, 90, 0, 0);
            }
        }

        else if (GameManager.month == 5 && GameManager.day == 16)
        {
            if (!GameManager.SkyeSaved)
            {
                FailStatesConversations[3].SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("GroundFloor");
                GameManager.playerSpawn = new Vector3(-15.32f, -6.6f, 35.85f);
                GameManager.playerRotation = new Quaternion(0, 90, 0, 0);
            }
        }

        else if (GameManager.month == 5 && GameManager.day == 22)
        {
            if (!GameManager.SkyeSaved)
            {
                FailStatesConversations[4].SetActive(true);
            }
            else
            {
                SuccessfulOperation[4].SetActive(true);
            }
        }
    }
}
