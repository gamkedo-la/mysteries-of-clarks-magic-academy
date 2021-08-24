using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public void LoadTestScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void LoadGame()
    {
        //SceneManager.LoadScene("Test");
    }

    public void Credits()
    {
        //SceneManager.LoadScene("Test");
    }
}
