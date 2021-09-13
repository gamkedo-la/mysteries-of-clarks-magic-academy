using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInStairs : MonoBehaviour
{
    public InventoryObject[] StoreInventory;
    public GameObject storePanel;

    public GameObject dialogueBox;
    bool isInRange;

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialogueBox.SetActive(false);
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    storePanel.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1;
                    storePanel.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
            dialogueBox.SetActive(false);
        }
    }
}
