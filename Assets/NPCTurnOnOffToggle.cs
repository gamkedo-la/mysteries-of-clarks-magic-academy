using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTurnOnOffToggle : MonoBehaviour
{
    public GameObject[] Convos;

    private void Start()
    {
        if (GameManager.month == 4 && (GameManager.day >= 15 && GameManager.day <= 22))
        {
            Convos[0].SetActive(true);
        }
        else if (GameManager.month == 4 && (GameManager.day >= 23 && GameManager.day <= 30))
        {
            Convos[1].SetActive(true);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 1 && GameManager.day <= 7))
        {
            Convos[2].SetActive(true);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 8 && GameManager.day <= 15))
        {
            Convos[3].SetActive(true);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 16 && GameManager.day <= 23))
        {
            Convos[4].SetActive(true);
        }
        else if (GameManager.month == 5 && (GameManager.day >= 24 && GameManager.day <= 31))
        {
            Convos[5].SetActive(true);
        }
        else if (GameManager.month == 6 && GameManager.day == 1)
        {
            Convos[5].SetActive(true);
        }
    }
}

