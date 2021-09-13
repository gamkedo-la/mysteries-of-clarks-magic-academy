using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInStairs : MonoBehaviour
{
    public InventoryObject[] StoreInventory;
    public GameObject storePanel;

    public GameObject dialogueBox;
    bool isInRange;

    private void Start()
    {
        /*if (GameManager.month == 4 && (GameManager.day >= 15 && GameManager.day <= 25))
        {
            StoreInventory[0].SetActive(true);
        }

        else if (GameManager.month == 4 && (GameManager.day >= 28 && GameManager.day <= 30))
        {
            StoreInventory[1].SetActive(true);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 1 && GameManager.day <= 2))
        {
            StoreInventory[1].SetActive(true);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 5 && GameManager.day <= 9))
        {
            StoreInventory[2].SetActive(true);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 10 && GameManager.day <= 16))
        {
            StoreInventory[3].SetActive(true);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 18 && GameManager.day <= 22))
        {
            StoreInventory[4].SetActive(true);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 29 && GameManager.day <= 31))
        {
            StoreInventory[5].SetActive(true);
        }
        */
    }

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
