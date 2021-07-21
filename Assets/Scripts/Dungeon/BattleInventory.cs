using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleInventory : MonoBehaviour
{
    private InventoryObject inventory;
    public GameObject battleItemPrefab;
    public GameObject previewItem;
    public Transform contents;

    public BattleSystem battleSystem;

    const int X_START = 145;
    const int Y_START = -235;

    const int INVENTORY_ITEM_X_OFFSET = 100;
    const int INVENTORY_ITEM_Y_OFFSET = 40;
    const int COLUMNS = 4;

    private void Start() {
        inventory = GameManager.instance.inventory;
        // Initial inventory population
        for (int i = 0; i < inventory.Container.Count ; i++)
        {
            GameObject item = Instantiate(battleItemPrefab, Vector3.zero, Quaternion.identity, contents);
            item.GetComponent<RectTransform>().localPosition = new Vector3(X_START + (INVENTORY_ITEM_X_OFFSET * (i % COLUMNS)), Y_START + (-INVENTORY_ITEM_Y_OFFSET * (i / COLUMNS)), 0);
            BattleItem temp =  item.GetComponent<BattleItem>();
            temp.Initialize(inventory.Container[i].item.itemName, inventory.Container[i].item.description, inventory.Container[i].amount, previewItem);
            item.GetComponent<Button>().onClick.AddListener( delegate { ClickItem(item.transform.GetSiblingIndex()); });
        }
    }

    public void ClickItem (int index) {
        battleSystem.AttemptItemUse(index);
    }

    public void RemoveItem (int index) {
        int itemsInInventory = inventory.Container.Count;
        for (int i = index; i < itemsInInventory; i++)
        {
            GameObject item = contents.GetChild(i).gameObject;
            BattleItem temp =  item.GetComponent<BattleItem>();
            temp.Initialize(inventory.Container[i].item.itemName, inventory.Container[i].item.description, inventory.Container[i].amount, previewItem);
        }
        Destroy(contents.GetChild(itemsInInventory).gameObject); // Remove last element
    }

    public void UpdateItem (int index) {
        GameObject item = contents.GetChild(index).gameObject;
        BattleItem temp =  item.GetComponent<BattleItem>();
        temp.Initialize(inventory.Container[index].item.itemName, inventory.Container[index].item.description, inventory.Container[index].amount, previewItem);
    }
}
