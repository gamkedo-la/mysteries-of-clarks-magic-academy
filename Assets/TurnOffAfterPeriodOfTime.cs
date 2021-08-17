using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAfterPeriodOfTime : MonoBehaviour
{
    public float TimeToTurnOff;

    private void Update()
    {
        TimeToTurnOff -= Time.deltaTime;

        if (TimeToTurnOff <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
