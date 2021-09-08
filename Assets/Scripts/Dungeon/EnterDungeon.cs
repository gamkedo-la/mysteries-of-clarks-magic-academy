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

    public GameObject ChoiceBox;

    public GameObject EnterDungeonAnim;

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
            ChoiceBox.SetActive(false);
        }
    }
    public void Enter()
    {
        canLeaveIcon.SetActive(false);
        leaveStay.SetActive(false);
        EnterDungeonAnim.SetActive(true);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.1f);
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
