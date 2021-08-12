using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectOnWhenStarting : MonoBehaviour
{
    public GameObject ToTurnOn;
    GameObject toTurnOn2;

    public bool isTurnoff;
    public GameObject TurnOffOnStart;

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
        ToTurnOn.SetActive(true);
    }
}
