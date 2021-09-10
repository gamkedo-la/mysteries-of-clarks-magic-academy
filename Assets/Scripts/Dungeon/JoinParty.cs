using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinParty : MonoBehaviour
{
    public bool Rhys, Jameel, Harper, Skye, Sullivan;

    public bool GracieMay;
    bool canEnterNextLevel;

    bool canTalk;
    public GameObject TalkingIcon;
    public GameObject leaveStay;

    public Button JoinButton;

    public Text addLeaveParty;

    public string characterName;
    public Text nameOfCharacter;

    private void Update()
    {
        if (canTalk)
        {
            TalkingIcon.SetActive(true);
            nameOfCharacter.text = characterName.ToString();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canTalk = false;
                TalkingIcon.SetActive(false);
                leaveStay.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canTalk = true;
        }

        if (GameManager.RhysInParty && Rhys)
        {
            addLeaveParty.text = "Leave Party";
        }
        else if (Jameel && GameManager.JameelInParty)
        {
            addLeaveParty.text = "Leave Party";
        }
        else if (Harper && GameManager.HarperInParty)
        {
            addLeaveParty.text = "Leave Party";
        }
        else if (Skye && GameManager.SkyeInParty)
        {
            addLeaveParty.text = "Leave Party";
        }
        else if (Sullivan && GameManager.SullivanInParty)
        {
            addLeaveParty.text = "Leave Party";
        }

        else if (Rhys && !GameManager.RhysInParty)
        {
            if (GameManager.PartyCount >= 4)
            {
                JoinButton.interactable = false;
                addLeaveParty.text = "Your party is full. Please drop someone first.";
            }
            else
            {
                JoinButton.interactable = true;
                addLeaveParty.text = "Join Party";
            }
        }
        else if (Jameel && !GameManager.JameelInParty)
        {
            if (GameManager.PartyCount >= 4)
            {
                JoinButton.interactable = false;
                addLeaveParty.text = "Your party is full. Please drop someone first.";
            }
            else
            {
                JoinButton.interactable = true;
                addLeaveParty.text = "Join Party";
            }
        }
        else if (Harper && !GameManager.HarperInParty)
        {
            if (GameManager.PartyCount >= 4)
            {
                JoinButton.interactable = false;
                addLeaveParty.text = "Your party is full. Please drop someone first.";
            }
            else
            {
                JoinButton.interactable = true;
                addLeaveParty.text = "Join Party";
            }
        }
        else if (Skye && !GameManager.SkyeInParty)
        {
            if (GameManager.PartyCount >= 4)
            {
                JoinButton.interactable = false;
                addLeaveParty.text = "Your party is full. Please drop someone first.";
            }
            else
            {
                JoinButton.interactable = true;
                addLeaveParty.text = "Join Party";
            }
        }
        else if (Sullivan && !GameManager.SullivanInParty)
        {
            if (GameManager.PartyCount >= 4)
            {
                JoinButton.interactable = false;
                addLeaveParty.text = "Your party is full. Please drop someone first.";
            }
            else
            {
                JoinButton.interactable = true;
                addLeaveParty.text = "Join Party";
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canTalk = false;
            TalkingIcon.SetActive(false);
            nameOfCharacter.text = "";
            leaveStay.SetActive(false);
        }
    }

    public void AddRhys()
    {
        if (GameManager.RhysInParty && Rhys)
        {
            GameManager.RhysInParty = false;
            GameManager.PartyCount--;
        }

        else if (Rhys && !GameManager.RhysInParty)
        {
            GameManager.RhysInParty = true;
            GameManager.PartyCount++;
        }
        leaveStay.SetActive(false);
        canTalk = false;
    }

    public void AddJameel()
    {
        if (Jameel && GameManager.JameelInParty)
        {
            GameManager.JameelInParty = false;
            GameManager.PartyCount--;
        }

        else if (Jameel && !GameManager.JameelInParty)
        {
            GameManager.JameelInParty = true;
            GameManager.PartyCount++;
        }
        leaveStay.SetActive(false);
        canTalk = false;
    }

    public void AddHarper()
    {
        if (Harper && GameManager.HarperInParty)
        {
            GameManager.HarperInParty = false;
            GameManager.PartyCount--;
        }
        else if (Harper && !GameManager.HarperInParty)
        {
            GameManager.HarperInParty = true;
            GameManager.PartyCount++;
        }
        leaveStay.SetActive(false);
        canTalk = false;
    }

    public void AddSkye()
    {
        if (Skye && GameManager.SkyeInParty)
        {
            GameManager.SkyeInParty = false;
            GameManager.PartyCount--;
        }
        else if (Skye && !GameManager.SkyeInParty)
        {
            GameManager.SkyeInParty = true;
            GameManager.PartyCount++;
        }
        leaveStay.SetActive(false);
        canTalk = false;
    }

    public void AddSullivan()
    {
        if (Sullivan && GameManager.SullivanInParty)
        {
            GameManager.SullivanInParty = false;
            GameManager.PartyCount--;
        }
        else if (Sullivan && !GameManager.SullivanInParty)
        {
            GameManager.SullivanInParty = true;
            GameManager.PartyCount++;
        }
        leaveStay.SetActive(false);
        canTalk = false;
    }

    public void CloseWindow()
    {
        canTalk = false;
        TalkingIcon.SetActive(false);
        leaveStay.SetActive(false);
    }
}