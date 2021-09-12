using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingItems : MonoBehaviour
{
    public Text NumberLeft;
    int itemsToMake;
    public GameObject Level01Items, Level2Items, Level3Items, Level4Items, Level5Items;

    public GameObject Menus;

    public GameObject MCIdle, MCAttack;

    public InventoryObject craftingInventory;

    public GameObject EndingDialogue;

    public Text itemAdded;

    void Start()
    {
        if (GameManager.ProficiencyLevel == 1 || GameManager.ProficiencyLevel == 0)
        {
            Level01Items.SetActive(true);
            itemsToMake = 1;
        }
        if (GameManager.ProficiencyLevel == 2)
        {
            Level2Items.SetActive(true);
            itemsToMake = 2;
        }
        if (GameManager.ProficiencyLevel == 3)
        {
            Level3Items.SetActive(true);
            itemsToMake = 3;
        }
        if (GameManager.ProficiencyLevel == 4)
        {
            Level4Items.SetActive(true);
            itemsToMake = 4;
        }
        if (GameManager.ProficiencyLevel == 5)
        {
            Level5Items.SetActive(true);
            itemsToMake = 5;
        }
    }

    private void Update()
    {
        NumberLeft.text = "Items you can make: " + itemsToMake;
    }

    void StartingForEach()
    {
        Menus.SetActive(false);
        MCAttack.SetActive(true);
        MCIdle.SetActive(false);
    }

    public void Petite()
    {
        ItemObject item = craftingInventory.Container[0].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    public void Shielding()
    {
        ItemObject item = craftingInventory.Container[1].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    public void Mad()
    {
        ItemObject item = craftingInventory.Container[2].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    public void Spirit()
    {
        ItemObject item = craftingInventory.Container[3].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    public void Lion()
    {
        ItemObject item = craftingInventory.Container[4].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    public void Clarity()
    {
        ItemObject item = craftingInventory.Container[5].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    public void Concentration()
    {
        ItemObject item = craftingInventory.Container[6].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    public void Bottles()
    {
        ItemObject item = craftingInventory.Container[7].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    public void Disruption()
    {
        ItemObject item = craftingInventory.Container[8].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    public void PotionOfEclipsed()
    {
        ItemObject item = craftingInventory.Container[9].item;
        GameManager.instance.inventory.AddItem(item, 1);

        StartingForEach();
        StartCoroutine(Helper());
    }

    IEnumerator Helper()
    {
        yield return new WaitForSeconds(3);
        itemsToMake--;
        GameManager.Proficiency++;
        MCAttack.SetActive(false);
        MCIdle.SetActive(true);
        itemAdded.text = "Item Added!";
        yield return new WaitForSeconds(1.5f);
        itemAdded.text = "";
        if (itemsToMake <= 0)
        {
            EndingDialogue.SetActive(true);
            Menus.SetActive(false);
        }
        else
        {
            Menus.SetActive(true);
        }
    }
}
