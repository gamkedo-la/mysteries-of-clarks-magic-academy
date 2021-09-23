using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityToSleep : MonoBehaviour
{
    public GameObject question;
    public GameObject toNapNorNot;
    bool isInRange;
    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                question.SetActive(false);
                toNapNorNot.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            question.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
            question.SetActive(false);
            toNapNorNot.SetActive(false);
        }
    }

    public void Nap()
    {
        GameManager.ProgressDay();
    }

    public void Nvm()
    {
        question.SetActive(false);
        toNapNorNot.SetActive(false);
    }
}
