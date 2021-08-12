using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectOnWhenStarting : MonoBehaviour
{
    public GameObject ToTurnOn;
    GameObject toTurnOn2;

    public bool isTurnoff;
    public GameObject TurnOffOnStart;
    public GameObject toTurnOnDelay;

    void Start()
    {
        if (isTurnoff)
        {
            TurnOffOnStart.SetActive(false);
        }

        else
        {
            ToTurnOn.SetActive(true);
        }
    }

    public void ToStartLater()
    {
        toTurnOnDelay.SetActive(true);
      // ToTurnOn.SetActive(true);
    }
}
