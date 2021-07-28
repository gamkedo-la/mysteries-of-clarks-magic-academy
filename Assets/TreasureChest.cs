using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    GameObject TreasureDialogue;
    bool canOpen;
    bool hasOpened;
    public Animator openingAnim;
    public ItemObject item;

    private void Start()
    {
        TreasureDialogue = GameObject.Find("InteractImageDisplay");
        TreasureDialogue?.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
            TreasureDialogue?.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
            TreasureDialogue?.SetActive(false);
        }
    }

    private void Update()
    {
        if (canOpen && !hasOpened)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                openingAnim.SetBool("Open", true);
                hasOpened = true;
                //Show UI for what you got
                //Add item to inventory
                GameManager.instance.inventory.AddItem(item, 1);
                GameManager.instance.ToggleNotificationPanel($"You obtained {item.name} x1!");
            }
        }
    }
}
