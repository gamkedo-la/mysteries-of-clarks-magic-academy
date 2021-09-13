using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTimeTutorial : MonoBehaviour
{
    public GameObject FirstScreen, SecondScreen, ThirdScreen;

    public void Start()
    {
        if (!GameManager.hasSeenTutorial)
        {
            FirstScreen.SetActive(true);
        }
    }

    public void FirstNextSecond()
    {
        SecondScreen.SetActive(true);
        FirstScreen.SetActive(false);
    }

    public void SecondNextThird()
    {
        ThirdScreen.SetActive(true);
        SecondScreen.SetActive(false);
    }

    public void Third()
    {
        GameManager.hasSeenTutorial = true;
        ThirdScreen.SetActive(false);
    }
}
