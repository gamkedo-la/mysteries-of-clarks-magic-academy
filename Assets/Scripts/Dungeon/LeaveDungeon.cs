using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveDungeon : MonoBehaviour
{
    bool canLeave;
    public GameObject canLeaveIcon;
    public GameObject leaveStay;

    public string LevelToLoad;

    Animator datePlay;

    public GameObject choiceBox;

    private void Start()
    {
        datePlay = GameObject.Find("CanvasForDate").GetComponent<Animator>();
    }
    private void Update()
    {
        if (canLeave)
        {
            canLeaveIcon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canLeave = false;
                canLeaveIcon.SetActive(false);
                leaveStay.SetActive(true);
            }
        }

        else
        {
            canLeaveIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canLeave = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canLeave = false;
            choiceBox.SetActive(false);
        }
    }
    public void Leave()
    {
        GameManager.ProgressDay();
        canLeaveIcon.SetActive(false);
        leaveStay.SetActive(false);
       // datePlay.SetBool("ToPlay", true);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.1f);
       // datePlay.SetBool("ToPlay", false);
        StartCoroutine(LoadRoomWait());
    }

    IEnumerator LoadRoomWait()
    {
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(LevelToLoad);
    }

    public void StayHere()
    {
        leaveStay.SetActive(false);
        canLeave = false;
    }
}
