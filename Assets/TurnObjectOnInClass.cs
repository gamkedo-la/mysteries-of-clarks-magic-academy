using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectOnInClass : MonoBehaviour
{
    public GameObject[] objectToTurnOn;

    public bool isApples;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectToTurnOn.Length; i++)
        {
            if (!isApples)
            {
                objectToTurnOn[i].GetComponent<MannequinFaceFlip>().enabled = true;
            }
            if (isApples)
            {
                objectToTurnOn[i].GetComponent<AppleGrow>().enabled = true;
            }
        }
        
    }
}
