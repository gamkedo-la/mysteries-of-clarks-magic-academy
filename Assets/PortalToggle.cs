using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToggle : MonoBehaviour
{
    public GameObject door, portal;
    public bool dungeonSkye, dungeonJameel, dungeonGracieMay, dungeonHarper, dungeonSullivan, dungeonGrounds;


    private void Update()
    {
        if (dungeonSkye)
        {
            if (GameManager.month == 4 && (GameManager.day >= 21 && GameManager.day <= 25))
            {
                portal.SetActive(true);
                door.SetActive(false);
            }

            else
            {
                portal.SetActive(false);
                door.SetActive(door);
            }
        }

        else if (dungeonJameel)
        {
            if (GameManager.month == 4 && (GameManager.day >= 28 && GameManager.day <= 30))
            {
                portal.SetActive(true);
                door.SetActive(false);
            }

            else
            {
                portal.SetActive(false);
                door.SetActive(true);
            }
        }

        else if (dungeonJameel)
        {
            if (GameManager.month == 5 && (GameManager.day >= 1 && GameManager.day <= 2))
            {
                portal.SetActive(true);
                door.SetActive(false);
            }

            else
            {
                portal.SetActive(false);
                door.SetActive(true);
            }
        }

        else if (dungeonGracieMay)
        {
            if (GameManager.month == 5 && (GameManager.day >= 5 && GameManager.day <= 9))
            {
                portal.SetActive(true);
                door.SetActive(false);
            }

            else
            {
                portal.SetActive(false);
                door.SetActive(true);
            }
        }

        else if (dungeonHarper)
        {
            if (GameManager.month == 5 && (GameManager.day >= 10 && GameManager.day <= 16))
            {
                portal.SetActive(true);
                door.SetActive(false);
            }

            else
            {
                portal.SetActive(false);
                door.SetActive(true);
            }
        }

        else if (dungeonSullivan)
        {
            if (GameManager.month == 5 && (GameManager.day >= 18 && GameManager.day <= 22))
            {
                portal.SetActive(true);
                door.SetActive(false);
            }

            else
            {
                portal.SetActive(false);
                door.SetActive(true);
            }
        }

        else if (dungeonGrounds)
        {
        if (GameManager.month == 5 && (GameManager.day >= 29 && GameManager.day <= 31))
            {
                portal.SetActive(true);
                door.SetActive(false);
            }

            else
            {
                portal.SetActive(false);
                door.SetActive(true);
            }
        }
    }
}
