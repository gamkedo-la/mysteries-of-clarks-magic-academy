using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateProfile : MonoBehaviour
{
    public GameObject Rhys, Skye, Jameel, Harper, Sullivan;
    public Slider MCHealth, RhysHealth, SkyeHealth, JameelHealth, HarperHealth, SullivanHealth;
    public Slider MCMagic, RhysMagic, SkyeMagic, JameelMagic, HarperMagic, SullivanMagic;

    private void Update()
    {
        #region IsAvailable
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
        #endregion
        #region InParty
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
        #endregion
        #region Health
        MCHealth.value = GameManager.MCHealth / GameManager.MCMaxHealth;
        RhysHealth.value = GameManager.RhysHealth / GameManager.RhysMaxHealth;
        JameelHealth.value = GameManager.JameelHealth / GameManager.JameelMaxHealth;
        HarperHealth.value = GameManager.HarperHealth / GameManager.HarperMaxHealth;
        SkyeHealth.value = GameManager.SkyeHealth / GameManager.SkyeMaxHealth;
        SullivanHealth.value = GameManager.SullivanHealth / GameManager.SullivanMaxHealth;
        #endregion

        #region Magic
        MCMagic.value = GameManager.MCMagic / GameManager.MCMaxMagic;
        RhysMagic.value = GameManager.RhysMagic / GameManager.RhysMaxMagic;
        JameelMagic.value = GameManager.JameelMagic / GameManager.JameelMaxMagic;
        HarperMagic.value = GameManager.HarperMagic / GameManager.HarperMaxMagic;
        SkyeMagic.value = GameManager.SkyeMagic / GameManager.SkyeMaxMagic;
        SullivanMagic.value = GameManager.SullivanMagic / GameManager.SullivanMaxMagic;
        #endregion
    }
}
