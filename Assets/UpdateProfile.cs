using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateProfile : MonoBehaviour
{
    public GameObject Rhys, Skye, Jameel, Harper, Sullivan;

    private void Update()
    {
        if (GameManager.RhysAvailable)
        {
            Rhys.SetActive(true);
        }
        if (GameManager.SkyeAvailable)
        {
            Skye.SetActive(true);
        }
        if (GameManager.JameelAvailable)
        {
            Jameel.SetActive(true);
        }
        if (GameManager.HarperAvailable)
        {
            Harper.SetActive(true);
        }
        if (GameManager.SullivanAvailable)
        {
            Sullivan.SetActive(true);
        }

        if (!GameManager.RhysAvailable)
        {
            Rhys.SetActive(false);
        }
        if (!GameManager.SkyeAvailable)
        {
            Skye.SetActive(false);
        }
        if (!GameManager.JameelAvailable)
        {
            Jameel.SetActive(false);
        }
        if (!GameManager.HarperAvailable)
        {
            Harper.SetActive(false);
        }
        if (!GameManager.SullivanAvailable)
        {
            Sullivan.SetActive(false);
        }

        if (GameManager.RhysInParty)
        {            
            Rhys.GetComponent<Image>().color = Color.cyan;
        }
        if (!GameManager.RhysInParty)
        {
            Rhys.GetComponent<Image>().color = Color.gray;
        }

        if (GameManager.SkyeInParty)
        {
            Skye.GetComponent<Image>().color = Color.cyan;
        }
        if (!GameManager.SkyeInParty)
        {
            Skye.GetComponent<Image>().color = Color.gray;
        }

        if (GameManager.JameelInParty)
        {
            Jameel.GetComponent<Image>().color = Color.cyan;
        }
        if (!GameManager.JameelInParty)
        {
            Jameel.GetComponent<Image>().color = Color.gray;
        }

        if (GameManager.HarperInParty)
        {
            Harper.GetComponent<Image>().color = Color.cyan;
        }
        if (!GameManager.HarperInParty)
        {
            Harper.GetComponent<Image>().color = Color.gray;
        }

        if (GameManager.SullivanInParty)
        {
            Sullivan.GetComponent<Image>().color = Color.cyan;
        }
        if (!GameManager.SullivanInParty)
        {
            Sullivan.GetComponent<Image>().color = Color.gray;
        }

    }
}
