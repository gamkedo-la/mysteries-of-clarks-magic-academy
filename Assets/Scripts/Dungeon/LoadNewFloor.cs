using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewFloor : MonoBehaviour
{
    bool canEnterNextLevel;
    public GameObject nextLevelOption;
    GameObject dialogueToGoToNextLevel;
    TurnObjectOnWhenStarting turnObjectOn;

    private void Start()
    {
        dialogueToGoToNextLevel = GameObject.Find("TurnObjectOn");
        turnObjectOn = GameObject.Find("TurnObjectOn").GetComponent<TurnObjectOnWhenStarting>();
    }

    private void Update()
    {
        if (canEnterNextLevel)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Prompt Dialogue
                turnObjectOn.ToStartLater();
                dialogueToGoToNextLevel.GetComponent<TurnObjectOnWhenStarting>().enabled = true;
                nextLevelOption.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canEnterNextLevel = true;
            //Turn Indicator On
            nextLevelOption.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canEnterNextLevel = false;
            nextLevelOption.SetActive(false);
        }
    }
}
