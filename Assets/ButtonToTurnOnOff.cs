using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToTurnOnOff : MonoBehaviour
{
    public GameObject toTurnOn, toTurnOff;
    public void TurnOnOff()
    {
        toTurnOn.SetActive(true);
        toTurnOff.SetActive(false);
    }
}
