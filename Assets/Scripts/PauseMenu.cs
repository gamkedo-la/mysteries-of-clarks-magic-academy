using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject DefaultButton;
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject InventoryContents;

    public GameObject ItemPrefab;
    private InventoryObject inventory;

    private const int INVENTORY_ITEM_Y_OFFSET = 30;
    // Update is called once per frame

    void Start() {
        inventory = GameManager.instance.inventory;
        // Initial inventory population
        for (int i = 0; i < inventory.Container.Count ; i++)
        {
            GameObject item = Instantiate(ItemPrefab, Vector3.zero, Quaternion.identity, InventoryContents.transform);
            item.GetComponent<RectTransform>().localPosition = new Vector3(298, -INVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
            item.transform.GetChild(0).GetComponent<Text>().text = inventory.Container[i].item.itemName;
            item.transform.GetChild(1).GetComponent<Text>().text = inventory.Container[i].item.description;
            item.transform.GetChild(2).GetComponent<Text>().text = "x" + inventory.Container[i].amount;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            TogglePause();
        }
    }

    public void TogglePause() {
        if(Time.timeScale == 0){
            Time.timeScale = 1;
            MenuPanel.SetActive(false);
        } else {
            Time.timeScale = 0;
            MenuPanel.SetActive(true);
        }
    }

    public void Save() {
        Debug.Log("Pressed Save Button");
    }

    public void MainMenu() {
        Debug.Log("Pressed Main Menu Button");
    }
    public void Party() {
        Debug.Log("Pressed Party Button");
    }
    public void Inventory() {
        InventoryPanel.SetActive(!InventoryPanel.activeSelf);
    }
}
