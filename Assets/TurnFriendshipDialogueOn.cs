using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFriendshipDialogueOn : MonoBehaviour
{
    public GameObject[] Convo;

    private void Start()
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
