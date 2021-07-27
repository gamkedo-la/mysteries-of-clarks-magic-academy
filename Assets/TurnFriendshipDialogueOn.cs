using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFriendshipDialogueOn : MonoBehaviour
{
    public bool isGreatHall;
    public GameObject[] Convo;

    private void Start()
    {
        if (isGreatHall)
        {
            if (GameManager.month == 4)
            {
                if (GameManager.day == 18)
                {
                    Convo[0].SetActive(true);
                }

                if (GameManager.day == 20)
                {
                    Convo[1].SetActive(true);
                }

                if (GameManager.day == 25)
                {
                    Convo[2].SetActive(true);
                }

                if (GameManager.day == 27)
                {
                    Convo[3].SetActive(true);
                }
            }

            if (GameManager.month == 5)
            {
                if (GameManager.day == 2)
                {
                    Convo[4].SetActive(true);
                }

                if (GameManager.day == 15)
                {
                    Convo[5].SetActive(true);
                }

                if (GameManager.day == 18)
                {
                    Convo[6].SetActive(true);
                }

                if (GameManager.day == 23)
                {
                    Convo[7].SetActive(true);
                }

                if (GameManager.day == 29)
                {
                    Convo[8].SetActive(true);
                }
            }

            if (GameManager.month == 6)
            {
                if (GameManager.day == 1)
                {
                    Convo[9].SetActive(true);
                }
            }
        }

        else
        {
            if (GameManager.RhysTalk)
            {
                Convo[GameManager.RhysFriendship].SetActive(true);
            }
            if (GameManager.JameelTalk)
            {
                Convo[GameManager.JameelFriendship].SetActive(true);
            }
            if (GameManager.HarperTalk)
            {
                Convo[GameManager.HarperFriendship].SetActive(true);
            }
            if (GameManager.SkyeTalk)
            {
                Convo[GameManager.SkyeFriendship].SetActive(true);
            }
            if (GameManager.SullivanTalk)
            {
                Convo[GameManager.SullivanFriendship].SetActive(true);
            }
            if (GameManager.GracieMayTalk)
            {
                Convo[GameManager.GracieMayFriendship].SetActive(true);
            }
            if (GameManager.AtornTalk)
            {
                Convo[GameManager.AtornFriendship].SetActive(true);
            }
            if (GameManager.ManrajTalk)
            {
                Convo[GameManager.ManrajFriendship].SetActive(true);
            }
            if (GameManager.SpecterTalk)
            {
                Convo[GameManager.SpecterFriendship].SetActive(true);
            }
        }
    }
}
