using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTimeTutorial : MonoBehaviour
{
    public GameObject FirstScreen, SecondScreen, ThirdScreen;

    public static bool hasSeenTutorial;

    public void Start()
    {
        if (!hasSeenTutorial)
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
        hasSeenTutorial = true;
        ThirdScreen.SetActive(false);
    }
}
