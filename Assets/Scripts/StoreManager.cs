using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
	public GameObject storePanel;
	public InventoryObject storeInventory1;
    public InventoryObject storeInventory2;
    public InventoryObject storeInventory3;
    public InventoryObject storeInventory4;
    public InventoryObject storeInventory5;
    public InventoryObject storeInventory6;

    public Transform storeInventoryContents;
    public Transform storeInventoryContents2;
    public Transform storeInventoryContents3;
    public Transform storeInventoryContents4;
    public Transform storeInventoryContents5;
    public Transform storeInventoryContents6;

    public GameObject storeItemPrefab;
    public Text playerMoney;
	private const int SINVENTORY_ITEM_X_OFFSET = 90;
    private const int SINVENTORY_ITEM_Y_OFFSET = 30;
    private bool buyingItem; // to avoid multiclick issue
    // Start is called before the first frame update
    void Start()
    {
        playerMoney.text = "W$ " + GameManager.Money;

        if (GameManager.month == 4 && (GameManager.day >= 15 && GameManager.day <= 25))
        {
            for (int i = 0; i < storeInventory1.Container.Count; i++)
            {
                GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents);
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory1.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory1.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory1.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }

            print(storeInventory1.name);
        }

        else if (GameManager.month == 4 && (GameManager.day >= 28 && GameManager.day <= 30))
        {
            for (int i = 0; i < storeInventory2.Container.Count; i++)
            {
                GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents2);
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory2.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory2.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory2.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 1 && GameManager.day <= 2))
        {
            for (int i = 0; i < storeInventory2.Container.Count; i++)
            {
                GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents2);
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory2.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory2.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory2.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 5 && GameManager.day <= 9))
        {
            for (int i = 0; i < storeInventory3.Container.Count; i++)
            {
                GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents3);
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory3.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory3.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory3.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 10 && GameManager.day <= 16))
        {
            for (int i = 0; i < storeInventory4.Container.Count; i++)
            {
                GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents4);
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory4.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory4.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory4.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 18 && GameManager.day <= 22))
        {
            for (int i = 0; i < storeInventory5.Container.Count; i++)
            {
                GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents5);
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory5.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory5.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory5.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 29 && GameManager.day <= 31))
        {
            for (int i = 0; i < storeInventory6.Container.Count; i++)
            {
                GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents6);
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory6.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory6.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory6.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
            print(storeInventory6.name);
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

        if (GameManager.month == 4 && (GameManager.day >= 15 && GameManager.day <= 25))
        {
            ItemObject item = storeInventory1.Container[index].item;
            if (GameManager.Money >= item.price && !buyingItem)
            {
                buyingItem = true;
                bool outOfStock = storeInventory1.Container[index].RemoveAmount(1);
                GameManager.instance.inventory.AddItem(item, 1);
                GameManager.Money -= item.price;
                if (outOfStock)
                {
                    storeInventory1.RemoveItem(index);
                    Destroy(storeInventoryContents.transform.GetChild(storeInventory1.Container.Count).gameObject); // Remove last element
                }
            }
        }

        else if (GameManager.month == 4 && (GameManager.day >= 28 && GameManager.day <= 30))
        {
            ItemObject item = storeInventory2.Container[index].item;
            if (GameManager.Money >= item.price && !buyingItem)
            {
                buyingItem = true;
                bool outOfStock = storeInventory2.Container[index].RemoveAmount(1);
                GameManager.instance.inventory.AddItem(item, 1);
                GameManager.Money -= item.price;
                if (outOfStock)
                {
                    storeInventory2.RemoveItem(index);
                    Destroy(storeInventoryContents2.transform.GetChild(storeInventory2.Container.Count).gameObject); // Remove last element
                }
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 1 && GameManager.day <= 2))
        {
            ItemObject item = storeInventory2.Container[index].item;
            if (GameManager.Money >= item.price && !buyingItem)
            {
                buyingItem = true;
                bool outOfStock = storeInventory2.Container[index].RemoveAmount(1);
                GameManager.instance.inventory.AddItem(item, 1);
                GameManager.Money -= item.price;
                if (outOfStock)
                {
                    storeInventory2.RemoveItem(index);
                    Destroy(storeInventoryContents2.transform.GetChild(storeInventory2.Container.Count).gameObject); // Remove last element
                }
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 5 && GameManager.day <= 9))
        {
            ItemObject item = storeInventory3.Container[index].item;
            if (GameManager.Money >= item.price && !buyingItem)
            {
                buyingItem = true;
                bool outOfStock = storeInventory3.Container[index].RemoveAmount(1);
                GameManager.instance.inventory.AddItem(item, 1);
                GameManager.Money -= item.price;
                if (outOfStock)
                {
                    storeInventory3.RemoveItem(index);
                    Destroy(storeInventoryContents3.transform.GetChild(storeInventory3.Container.Count).gameObject); // Remove last element
                }
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 10 && GameManager.day <= 16))
        {
            ItemObject item = storeInventory4.Container[index].item;
            if (GameManager.Money >= item.price && !buyingItem)
            {
                buyingItem = true;
                bool outOfStock = storeInventory4.Container[index].RemoveAmount(1);
                GameManager.instance.inventory.AddItem(item, 1);
                GameManager.Money -= item.price;
                if (outOfStock)
                {
                    storeInventory4.RemoveItem(index);
                    Destroy(storeInventoryContents4.transform.GetChild(storeInventory4.Container.Count).gameObject); // Remove last element
                }
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 18 && GameManager.day <= 22))
        {
            ItemObject item = storeInventory5.Container[index].item;
            if (GameManager.Money >= item.price && !buyingItem)
            {
                buyingItem = true;
                bool outOfStock = storeInventory5.Container[index].RemoveAmount(1);
                GameManager.instance.inventory.AddItem(item, 1);
                GameManager.Money -= item.price;
                if (outOfStock)
                {
                    storeInventory5.RemoveItem(index);
                    Destroy(storeInventoryContents5.transform.GetChild(storeInventory5.Container.Count).gameObject); // Remove last element
                }
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 29 && GameManager.day <= 31))
        {
            ItemObject item = storeInventory6.Container[index].item;
            if (GameManager.Money >= item.price && !buyingItem)
            {
                buyingItem = true;
                bool outOfStock = storeInventory6.Container[index].RemoveAmount(1);
                GameManager.instance.inventory.AddItem(item, 1);
                GameManager.Money -= item.price;
                if (outOfStock)
                {
                    storeInventory6.RemoveItem(index);
                    Destroy(storeInventoryContents6.transform.GetChild(storeInventory6.Container.Count).gameObject); // Remove last element
                }
            }
        }

        UpdateStore();
    }

    public void UpdateStore() {
        if (GameManager.month == 4 && (GameManager.day >= 15 && GameManager.day <= 25))
        {
            for (int i = 0; i < storeInventory1.Container.Count; i++)
            {
                GameObject item = storeInventoryContents.GetChild(i).gameObject;
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory1.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory1.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory1.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 4 && (GameManager.day >= 28 && GameManager.day <= 30))
        {
            for (int i = 0; i < storeInventory2.Container.Count; i++)
            {
                GameObject item = storeInventoryContents2.GetChild(i).gameObject;
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory2.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory2.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory2.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 1 && GameManager.day <= 2))
        {
            for (int i = 0; i < storeInventory2.Container.Count; i++)
            {
                GameObject item = storeInventoryContents2.GetChild(i).gameObject;
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory2.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory2.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory2.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 5 && GameManager.day <= 9))
        {
            for (int i = 0; i < storeInventory3.Container.Count; i++)
            {
                GameObject item = storeInventoryContents3.GetChild(i).gameObject;
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory3.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory3.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory3.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 10 && GameManager.day <= 16))
        {
            for (int i = 0; i < storeInventory4.Container.Count; i++)
            {
                GameObject item = storeInventoryContents4.GetChild(i).gameObject;
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory4.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory4.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory4.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 18 && GameManager.day <= 22))
        {
            for (int i = 0; i < storeInventory5.Container.Count; i++)
            {
                GameObject item = storeInventoryContents5.GetChild(i).gameObject;
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory5.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory5.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory5.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        else if (GameManager.month == 5 && (GameManager.day >= 29 && GameManager.day <= 31))
        {
            for (int i = 0; i < storeInventory6.Container.Count; i++)
            {
                GameObject item = storeInventoryContents6.GetChild(i).gameObject;
                item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
                item.GetComponent<Text>().text = storeInventory6.Container[i].item.itemName;
                item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory6.Container[i].amount;
                item.transform.GetChild(1).GetComponent<Text>().text = "$ " + storeInventory6.Container[i].item.price;
                item.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item.transform.GetSiblingIndex()); });
            }
        }

        playerMoney.text = "$ " + GameManager.Money;
    }

    public void LeaveStore()
    {
        storePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
