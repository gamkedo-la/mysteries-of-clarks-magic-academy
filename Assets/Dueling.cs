using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dueling : MonoBehaviour
{
    public GameObject StartingConversation, TransConvo, DADAConvo, CharmsConvo, PotionsConvo, StartCam, MainCam, StartMC, EndMC;

    public void Trans()
    {
        TransConvo.SetActive(true);
        CleanUp();
    }

    public void DADA()
    {
        DADAConvo.SetActive(true);
        CleanUp();
    }

    public void Charms()
    {
        CharmsConvo.SetActive(true);
        CleanUp();
    }

    public void Potions()
    {
        PotionsConvo.SetActive(true);
        CleanUp();
    }

    void CleanUp()
    {
        StartMC.SetActive(false);
        EndMC.SetActive(true);
        StartingConversation.SetActive(false);
        StartCam.SetActive(false);
        MainCam.SetActive(true);
    }
}
