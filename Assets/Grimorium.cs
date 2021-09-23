using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grimorium : MonoBehaviour
{
    public GameObject dialogueOption;
    public GameObject thisFriend;
    bool isInRange;
    public GameObject GirmoriumQuestion;
    public GameObject GrimoriumBacklog;

    public GameObject oneSeven1, eightFourteen1;
    public GameObject oneSeven2, eightFourteen2;

    public GameObject FirstPage, SecondPage;

    public Text money;

    public GameObject mainCam, grimCam;

    private void Update()
    {
        money.text = "W$ " + GameManager.Money.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isInRange)
            {
                dialogueOption.SetActive(false);
                GirmoriumQuestion.SetActive(true);
            }
        }
        if (isInRange)
        {
            Vector3 lookPos = GameObject.FindGameObjectWithTag("Player").transform.position - thisFriend.transform.position;
            Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
            float eulerY = lookRot.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
            thisFriend.transform.rotation = rotation;
        }
        else
        {
            thisFriend.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            dialogueOption.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
            dialogueOption.SetActive(false);
            GirmoriumQuestion.SetActive(false);
        }
    }

    public void OpenGrimorium()
    {
        GirmoriumQuestion.SetActive(false);
        GrimoriumBacklog.SetActive(true);
        mainCam.SetActive(false);
        grimCam.SetActive(true);
    }

    public void Healing()
    {
        GameManager.MCHealth = GameManager.MCMaxHealth;
        GameManager.MCMagic = GameManager.MCMaxMagic;

        GameManager.RhysHealth = GameManager.RhysMaxHealth;
        GameManager.RhysMagic = GameManager.RhysMaxMagic;

        GameManager.SkyeHealth = GameManager.SkyeMaxHealth;
        GameManager.SkyeMagic = GameManager.SkyeMaxMagic;

        GameManager.JameelHealth = GameManager.JameelMaxHealth;
        GameManager.JameelMagic = GameManager.JameelMaxMagic;

        GameManager.HarperHealth = GameManager.HarperMaxHealth;
        GameManager.HarperMagic = GameManager.HarperMaxMagic;

        GameManager.SullivanHealth = GameManager.SullivanMaxHealth;
        GameManager.SullivanMagic = GameManager.SullivanMaxMagic;

        GirmoriumQuestion.SetActive(false);
        GrimoriumBacklog.SetActive(false);
        dialogueOption.SetActive(false);
        mainCam.SetActive(true);
        grimCam.SetActive(false);
    }

    public void Nevermind()
    {
        GirmoriumQuestion.SetActive(false);
        GrimoriumBacklog.SetActive(false);
        dialogueOption.SetActive(false);
        mainCam.SetActive(true);
        grimCam.SetActive(false);
    }


    public void NextPage()
    {
        oneSeven1.SetActive(false);
        eightFourteen1.SetActive(false);

        oneSeven2.SetActive(true);
        eightFourteen2.SetActive(true);

        FirstPage.SetActive(false);
        SecondPage.SetActive(true);
    }

    public void BackPage()
    {
        oneSeven1.SetActive(true);
        eightFourteen1.SetActive(true);

        oneSeven2.SetActive(false);
        eightFourteen2.SetActive(false);

        FirstPage.SetActive(true);
        SecondPage.SetActive(false);
    }
}
