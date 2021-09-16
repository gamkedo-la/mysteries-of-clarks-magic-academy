using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradesWaving : MonoBehaviour
{
    public GameObject ifFail, isPass;

    private void Start()
    {
        if (GameManager.FinalsScore >= 6)
        {
            isPass.SetActive(true);
        }
        else
        {
            ifFail.SetActive(true);
        }
    }
}
