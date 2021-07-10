using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInventory : MonoBehaviour
{
    private InventoryObject inventory;
    public GameObject battleItemPrefab;
    public GameObject previewItem;

    const int X_START = 145;
    const int Y_START = -235;

    const int INVENTORY_ITEM_X_OFFSET = 100;
    const int INVENTORY_ITEM_Y_OFFSET = 40;
    const int COLUMNS = 4;

    private void Start() {
        inventory = GameManager.instance.inventory;
        Debug.Log(inventory.Container.Count);
        // Initial inventory population
        for (int i = 0; i < inventory.Container.Count ; i++)
        {
            GameObject item = Instantiate(battleItemPrefab, Vector3.zero, Quaternion.identity, transform);
            item.GetComponent<RectTransform>().localPosition = new Vector3(X_START + (INVENTORY_ITEM_X_OFFSET * (i % COLUMNS)), Y_START + (-INVENTORY_ITEM_Y_OFFSET * (i / COLUMNS)), 0);
            BattleItem temp =  item.GetComponent<BattleItem>();
            temp.Initialize(inventory.Container[i].item.itemName, inventory.Container[i].item.description, inventory.Container[i].amount, previewItem);
        }
    }

}
