using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToHolding : MonoBehaviour
{
    bool canReturnLevel;
    public GameObject returnOption;
    GameObject dialogueToGoToNextLevel;
    TurnObjectOnWhenStarting turnObjectOn;

    private void Start()
    {
        dialogueToGoToNextLevel = GameObject.Find("TurnPortalOn");
        turnObjectOn = GameObject.Find("TurnPortalOn").GetComponent<TurnObjectOnWhenStarting>();
    }

    private void Update()
    {
        if (canReturnLevel)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Prompt Dialogue
                turnObjectOn.ToStartLater();
                dialogueToGoToNextLevel.GetComponent<TurnObjectOnWhenStarting>().enabled = true;
                returnOption.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("can return started");
            canReturnLevel = true;
            //Turn Indicator On
            returnOption.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("can return");
            canReturnLevel = false;
            returnOption.SetActive(false);
        }
    }
}
