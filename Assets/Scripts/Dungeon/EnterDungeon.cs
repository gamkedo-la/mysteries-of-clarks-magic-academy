using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDungeon : MonoBehaviour
{
    bool canLeave;
    public GameObject canLeaveIcon;
    public GameObject leaveStay;

    public string LevelToLoad;

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
        }
    }
    public void Enter()
    {
        canLeaveIcon.SetActive(false);
        leaveStay.SetActive(false);
        // This is where you'd play animations to load dungeon
        //datePlay.SetBool("ToPlay", true);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.1f);
      //  datePlay.SetBool("ToPlay", false);
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
