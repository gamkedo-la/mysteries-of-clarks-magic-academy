using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectOnWhenStarting : MonoBehaviour
{
    public GameObject ToTurnOn;
    GameObject toTurnOn2;

    void Start()
    {
        ToTurnOn.SetActive(true);
    }

    public void ToStartLater()
    {
        ToTurnOn.SetActive(true);
    }
}
