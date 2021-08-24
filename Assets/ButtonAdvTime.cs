using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAdvTime : MonoBehaviour
{
    Animator datePlay;

    private void Start()
    {
        datePlay = GameObject.Find("CanvasForDate").GetComponent<Animator>();
    }

    public void AdvTime()
    {
        StartCoroutine(StatsWaiting());

    }

    IEnumerator StatsWaiting()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.CanvasForStats.SetActive(false);
        datePlay.SetBool("ToPlay", true);
        StartCoroutine(Waiting());
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.1f);
        datePlay.SetBool("ToPlay", false);
        StartCoroutine(LoadRoomWait());
    }

    IEnumerator LoadRoomWait()
    {
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene("CharmsClassroom");
    }
}
