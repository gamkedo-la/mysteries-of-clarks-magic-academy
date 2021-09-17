using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecallSaveFile : MonoBehaviour
{
    public GameObject FailDate;
    public Text DateSlide;

    private void Start()
    {
        StartCoroutine(RewindTime());
    }

    IEnumerator RewindTime()
    {
        FailDate.SetActive(true);
        int day2 = GameManager.day - 2;
        if (GameManager.day - 2 == 0)
        {
            day2 = 30;
        }

        int day3 = GameManager.day - 3;
        if (GameManager.day - 3 <= -1)
        {
            day3 = 29;
        }


        DateSlide.text = (day3 + "     " +  day2 + "     " + (GameManager.day - 1) + "     " + GameManager.day + "     " + (GameManager.day + 1) + "     " + (GameManager.day + 2)).ToString();

        print("Loading Fail State");
        yield return new WaitForSeconds(4f);
        GameManager.instance.SoftLoadGame();
    }
}
