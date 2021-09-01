using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAfterPeriodOfTime : MonoBehaviour
{
    public float TimeToTurnOff;
    public bool TurnDiffObjOn;
    public GameObject toTurnOn;

    private void Update()
    {
        TimeToTurnOff -= Time.deltaTime;

        if (TimeToTurnOff <= 0)
        {
            if (TurnDiffObjOn)
            {
                toTurnOn.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
    }
}
