using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager2 : MonoBehaviour
{
	public GameObject storePanel;
	public InventoryObject[] storeInventories;
	public Transform storeInventoryContents;
	public GameObject storeItemPrefab;
    public Text playerMoney;
	private const int SINVENTORY_ITEM_X_OFFSET = 90;
    private const int SINVENTORY_ITEM_Y_OFFSET = 30;
    private bool buyingItem; // to avoid multiclick issue
    public int selectedInventory = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartStore();
    }

    // Update is called once per frame
    void Update()
    {
        //    if(Input.GetKeyDown(KeyCode.P)){
        //       ToggleStore();
        //  }


        if (GameManager.month == 4 && (GameManager.day >= 17 && GameManager.day <= 25))
        {
            SwitchStore(0);
        }

        else if (GameManager.month == 4 && (GameManager.day >= 26 && GameManager.day <= 30))
        {
            SwitchStore(1);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 1 && GameManager.day <= 2))
        {
            SwitchStore(2);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 2 && GameManager.day <= 9))
        {
            SwitchStore(3);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 10 && GameManager.day <= 16))
        {
            SwitchStore(4);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 17 && GameManager.day <= 28))
        {
            SwitchStore(5);
        }

        else if (GameManager.month == 5 && (GameManager.day >= 29 && GameManager.day <= 31))
        {
            SwitchStore(6);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)){
            buyingItem = false;
        }
    }

    public void BuyItem (int index) {
        ItemObject item = storeInventories[selectedInventory].Container[index].item;
        if(GameManager.Money >= item.price && !buyingItem) {
            buyingItem = true;
            bool outOfStock = storeInventories[selectedInventory].Container[index].RemoveAmount(1);
            GameManager.instance.inventory.AddItem(item, 1);
            GameManager.Money -= item.price;
            if(outOfStock) {
                storeInventories[selectedInventory].RemoveItem(index);
                Destroy(storeInventoryContents.transform.GetChild(storeInventories[selectedInventory].Container.Count ).gameObject); // Remove last element
            }
            UpdateStore();
        }
    }

    public void UpdateStore() {
        for (int i = 0; i < storeInventories[selectedInventory].Container.Count ; i++)
        {
            GameObject item = storeInventoryContents.GetChild(i).gameObject;
            item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
			item.GetComponent<Text>().text = storeInventories[selectedInventory].Container[i].item.itemName;
            item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventories[selectedInventory].Container[i].amount;
            item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventories[selectedInventory].Container[i].item.price;
            item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener( delegate { BuyItem(item.transform.GetSiblingIndex()); });
		}
        playerMoney.text = "$ " + GameManager.Money;
    }

    public void StartStore() {
        for (int i = 0; i < storeInventories[selectedInventory].Container.Count ; i++)
        {
            GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents);
            item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
			item.GetComponent<Text>().text = storeInventories[selectedInventory].Container[i].item.itemName;
            item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventories[selectedInventory].Container[i].amount;
            item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventories[selectedInventory].Container[i].item.price;
            item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener( delegate { BuyItem(item.transform.GetSiblingIndex()); });
		}
        playerMoney.text = "$ " + GameManager.Money;
    }

    public void SwitchStore(int newIndex){
        selectedInventory = newIndex;
        foreach (Transform child in storeInventoryContents) {
            GameObject.Destroy(child.gameObject);
        }
        StartStore();
    }

	public void ToggleStore() {
        if(Time.timeScale == 1){
            Time.timeScale = 0;
            storePanel.SetActive(true);
        } else {
            Time.timeScale = 1;
				storePanel.SetActive(false);
        }
    }
}
