using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconColors : MonoBehaviour
{
    public Image Rhys, Jameel, Harper, Skye, Sullivan;
    public Image RHS, RMS;
    public Image JHS, JMS;
    public Image HHS, HMS;
    public Image SkHS, SkMS;
    public Image SuHS, SuMS;

    public GameObject RhysAvail, JameelAvail, HarperAvail, SkyeAvail, SullivanAvail;

    private void Start()
    {
        if (!GameManager.RhysInParty)
        {
            Rhys.GetComponent<Image>().color = Color.gray;
            RHS.GetComponent<Image>().color = Color.gray;
            RMS.GetComponent<Image>().color = Color.gray;
        }

        if (!GameManager.JameelInParty)
        {
            Jameel.GetComponent<Image>().color = Color.gray;
            JHS.GetComponent<Image>().color = Color.gray;
            JMS.GetComponent<Image>().color = Color.gray;
        }

        if (!GameManager.HarperInParty)
        {
            Harper.GetComponent<Image>().color = Color.gray;
            HHS.GetComponent<Image>().color = Color.gray;
            HMS.GetComponent<Image>().color = Color.gray;
        }

        if (!GameManager.SkyeInParty)
        {
            Skye.GetComponent<Image>().color = Color.gray;
            SkHS.GetComponent<Image>().color = Color.gray;
            SkMS.GetComponent<Image>().color = Color.gray;
        }

        if (!GameManager.SullivanInParty)
        {
            Sullivan.GetComponent<Image>().color = Color.gray;
            SuHS.GetComponent<Image>().color = Color.gray;
            SuMS.GetComponent<Image>().color = Color.gray;
        }

        if (!GameManager.RhysAvailable)
        {
            RhysAvail.SetActive(false);
        }

        if (!GameManager.JameelAvailable)
        {
            JameelAvail.SetActive(false);
        }

        if (!GameManager.SkyeAvailable)
        {
            SkyeAvail.SetActive(false);
        }

        if (!GameManager.SullivanAvailable)
        {
            SullivanAvail.SetActive(false);
        }

        if (!GameManager.HarperAvailable)
        {
            HarperAvail.SetActive(false);
        }
    }
}
