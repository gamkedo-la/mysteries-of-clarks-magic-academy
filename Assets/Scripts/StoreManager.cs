using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
	public GameObject storePanel;
	public InventoryObject storeInventory;
	public Transform storeInventoryContents;
	public GameObject storeItemPrefab;
    public Text playerMoney;
	private const int SINVENTORY_ITEM_X_OFFSET = 90;
    private const int SINVENTORY_ITEM_Y_OFFSET = 30;
    private bool buyingItem; // to avoid multiclick issue
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < storeInventory.Container.Count ; i++)
        {
            GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents);
            item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
			item.GetComponent<Text>().text = storeInventory.Container[i].item.itemName;
            item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory.Container[i].amount;
            item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory.Container[i].item.price;
            item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener( delegate { BuyItem(item.transform.GetSiblingIndex()); });
		}
        playerMoney.text = "$ " + GameManager.Money;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            buyingItem = false;
        }
    }

    public void BuyItem (int index) {
        ItemObject item = storeInventory.Container[index].item;
        if(GameManager.Money >= item.price && !buyingItem) {
            buyingItem = true;
            bool outOfStock = storeInventory.Container[index].RemoveAmount(1);
            GameManager.instance.inventory.AddItem(item, 1);
            GameManager.Money -= item.price;
            if(outOfStock) {
                storeInventory.RemoveItem(index);
                Destroy(storeInventoryContents.transform.GetChild(storeInventory.Container.Count ).gameObject); // Remove last element
            }
            UpdateStore();
        }
    }

    public void UpdateStore() {
        for (int i = 0; i < storeInventory.Container.Count ; i++)
        {
            GameObject item = storeInventoryContents.GetChild(i).gameObject;
            item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
			item.GetComponent<Text>().text = storeInventory.Container[i].item.itemName;
            item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory.Container[i].amount;
            item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory.Container[i].item.price;
            item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener( delegate { BuyItem(item.transform.GetSiblingIndex()); });
		}
        playerMoney.text = "$ " + GameManager.Money;
    }

    public void LeaveStore()
    {
        storePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
