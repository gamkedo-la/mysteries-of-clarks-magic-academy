using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLessonOn : MonoBehaviour
{
    public bool Charms, DADA, Trans, Potions;
    public GameObject[] Lessons; 

    void Update()
    {
        if (Charms)
        {
            if (GameManager.day == 18 && GameManager.month == 4)
            {
                Lessons[0].SetActive(true);
            }

            if (GameManager.day == 25 && GameManager.month == 4)
            {
                Lessons[1].SetActive(true);
            }

            if (GameManager.day == 29 && GameManager.month == 4)
            {
                Lessons[2].SetActive(true);
            }

            if (GameManager.day == 9 && GameManager.month == 5)
            {
                Lessons[3].SetActive(true);
            }

            if (GameManager.day == 13 && GameManager.month == 5)
            {
                Lessons[4].SetActive(true);
            }

            if (GameManager.day == 17 && GameManager.month == 5)
            {
                Lessons[5].SetActive(true);
            }

            if (GameManager.day == 17 && GameManager.month == 5)
            {
                Lessons[6].SetActive(true);
            }

            if (GameManager.day == 24 && GameManager.month == 5)
            {
                Lessons[7].SetActive(true);
            }

            if (GameManager.day == 26 && GameManager.month == 5)
            {
                Lessons[8].SetActive(true);
            }
        }

        else if (Potions)
        {
            if (GameManager.day == 20 && GameManager.month == 4)
            {
                Lessons[0].SetActive(true);
            }

            if (GameManager.day == 26 && GameManager.month == 4)
            {
                Lessons[1].SetActive(true);
            }

            if (GameManager.day == 3 && GameManager.month == 5)
            {
                Lessons[2].SetActive(true);
            }

            if (GameManager.day == 4 && GameManager.month == 5)
            {
                Lessons[3].SetActive(true);
            }

            if (GameManager.day == 10 && GameManager.month == 5)
            {
                Lessons[4].SetActive(true);
            }

            if (GameManager.day == 18 && GameManager.month == 5)
            {
                Lessons[5].SetActive(true);
            }

            if (GameManager.day == 24 && GameManager.month == 5)
            {
                Lessons[6].SetActive(true);
            }

            if (GameManager.day == 27 && GameManager.month == 5)
            {
                Lessons[7].SetActive(true);
            }
        }

        else if (Trans)
        {
            if (GameManager.day == 22 && GameManager.month == 4)
            {
                Lessons[0].SetActive(true);
            }

            if (GameManager.day == 27 && GameManager.month == 4)
            {
                Lessons[1].SetActive(true);
            }

            if (GameManager.day == 2 && GameManager.month == 5)
            {
                Lessons[2].SetActive(true);
            }

            if (GameManager.day == 6 && GameManager.month == 5)
            {
                Lessons[3].SetActive(true);
            }

            if (GameManager.day == 11 && GameManager.month == 5)
            {
                Lessons[4].SetActive(true);
            }

            if (GameManager.day == 20 && GameManager.month == 5)
            {
                Lessons[5].SetActive(true);
            }

            if (GameManager.day == 25 && GameManager.month == 5)
            {
                Lessons[6].SetActive(true);
            }

            if (GameManager.day == 27 && GameManager.month == 5)
            {
                Lessons[7].SetActive(true);
            }
        }

        else if (DADA)
        {
            if (GameManager.day == 21 && GameManager.month == 4)
            {
                Lessons[0].SetActive(true);
            }

            if (GameManager.day == 28 && GameManager.month == 4)
            {
                Lessons[1].SetActive(true);
            }

            if (GameManager.day == 5 && GameManager.month == 5)
            {
                Lessons[2].SetActive(true);
            }

            if (GameManager.day == 12 && GameManager.month == 5 && GameManager.timeOfDay == 0)
            {
                Lessons[3].SetActive(true);
            }

            if (GameManager.day == 12 && GameManager.month == 5 && GameManager.timeOfDay == 2)
            {
                Lessons[4].SetActive(true);
            }

            if (GameManager.day == 19 && GameManager.month == 5)
            {
                Lessons[5].SetActive(true);
            }

            if (GameManager.day == 25 && GameManager.month == 5)
            {
                Lessons[6].SetActive(true);
            }

            if (GameManager.day == 26 && GameManager.month == 5)
            {
                Lessons[7].SetActive(true);
            }
        }
    }
}
