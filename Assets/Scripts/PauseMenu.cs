using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject DefaultButton;
    [SerializeField] private GameObject MainButtons;
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject InventoryContents;
    [SerializeField] private GameObject PartyFrames;

    public Slider MCHealth, MCMagic, RhysHealth, RhysMagic, JameelHealth, JameelMagic, HarperHealth, HarperMagic, SkyeHealth, SkyeMagic, SullivanHealth, SullivanMagic;

    public GameObject ItemPrefab;
    private InventoryObject inventory;
    private int currentlySelectedItem;

    private const int INVENTORY_ITEM_X_OFFSET = 248;
    private const int INVENTORY_ITEM_Y_OFFSET = 30;
    // Update is called once per frame

    void Start() {
        inventory = GameManager.instance.inventory;
        currentlySelectedItem = -1; // No item selected
        // Initial inventory population
        for (int i = 0; i < inventory.Container.Count ; i++)
        {
            GameObject item = Instantiate(ItemPrefab, Vector3.zero, Quaternion.identity, InventoryContents.transform);
            item.GetComponent<RectTransform>().localPosition = new Vector3(INVENTORY_ITEM_X_OFFSET, -INVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
            item.transform.GetChild(0).GetComponent<Text>().text = inventory.Container[i].item.itemName;
            item.transform.GetChild(1).GetComponent<Text>().text = inventory.Container[i].item.description;
            item.transform.GetChild(2).GetComponent<Text>().text = "x" + inventory.Container[i].amount;
            item.GetComponent<Button>().onClick.AddListener( delegate { ClickItem(item.transform.GetSiblingIndex()); });
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
            PartyFrames.SetActive(false);
            InventoryPanel.SetActive(false);
        } else {
            Time.timeScale = 0;
            MenuPanel.SetActive(true);
            UpdateUI();
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

    public void ClickItem (int index) {
        ItemObject item = inventory.Container[index].item;
        // Only support items can be used from menu
        if(item.type == ItemType.Support) {
            // TODO: ADD UI functionality to select a party member if the item is not a multi-target
            currentlySelectedItem = index;
            if(item.multiTarget) {
                UseItem("all");
            } else {
                ToggleInventoryButtons();
            }
        }
    }

    public void UseItem (string target) {
        GameManager.instance.UseItem(inventory.Container[currentlySelectedItem].item, target);
        UpdateUI();
        bool outOfStock = inventory.Container[currentlySelectedItem].RemoveAmount(1);
        if(outOfStock) {
            inventory.RemoveItem(currentlySelectedItem);
            RemoveItem(currentlySelectedItem);
        } else {
            UpdateItems();
        }

        currentlySelectedItem = -1;
        if(target != "all") { //re-enable buttons
            ToggleInventoryButtons();
        }
    }

    public void ToggleInventoryButtons () {
        foreach (Transform item in InventoryContents.transform)
        {
            Button itemButton = item.GetComponent<Button>();
            itemButton.interactable = !itemButton.interactable;
        }
    }

     public void ToggleMainButtons () {
        foreach (Transform item in MainButtons.transform)
        {
            Button itemButton = item.GetComponent<Button>();
            itemButton.interactable = !itemButton.interactable;
        }
    }

    public void ClickPartyFrame (string name) {
        // I Imagine these elements might have more functionalities, thats why I'm using this flag
        if(currentlySelectedItem != -1) {
            UseItem(name);
        }
    }

    public void RemoveItem (int index) {
        int itemsInInventory = inventory.Container.Count;
        for (int i = index; i < itemsInInventory; i++)
        {
            GameObject item = InventoryContents.transform.GetChild(i).gameObject;
            item.transform.GetChild(0).GetComponent<Text>().text = inventory.Container[i].item.itemName;
            item.transform.GetChild(1).GetComponent<Text>().text = inventory.Container[i].item.description;
            item.transform.GetChild(2).GetComponent<Text>().text = "x" + inventory.Container[i].amount;
        }
        Destroy(InventoryContents.transform.GetChild(itemsInInventory).gameObject); // Remove last element
    }

    public void UpdateItems () {
        for (int i = 0; i < inventory.Container.Count ; i++)
        {
            GameObject item = InventoryContents.transform.GetChild(i).gameObject;
            item.transform.GetChild(0).GetComponent<Text>().text = inventory.Container[i].item.itemName;
            item.transform.GetChild(1).GetComponent<Text>().text = inventory.Container[i].item.description;
            item.transform.GetChild(2).GetComponent<Text>().text = "x" + inventory.Container[i].amount;
        }
    }

    private float intDivideToFloat(int a, int b)
    {
        return ((float)a) / ((float)b);
    }


    public void UpdateUI()
    {
        Debug.Log(GameManager.MCHealth / GameManager.MCMaxHealth);
        MCHealth.value = intDivideToFloat(GameManager.MCHealth, GameManager.MCMaxHealth);
        MCMagic.value = intDivideToFloat(GameManager.MCMagic, GameManager.MCMaxMagic);

        RhysHealth.value = GameManager.RhysHealth / GameManager.RhysMaxHealth;
        RhysMagic.value = GameManager.RhysMagic / GameManager.RhysMaxMagic;

        JameelHealth.value = GameManager.JameelHealth / GameManager.JameelMaxHealth;
        JameelMagic.value = GameManager.JameelMagic / GameManager.JameelMaxMagic;

        HarperHealth.value = GameManager.HarperHealth / GameManager.HarperMaxHealth;
        HarperMagic.value = GameManager.HarperMagic / GameManager.HarperMaxMagic;

        SkyeHealth.value = GameManager.SkyeHealth / GameManager.SkyeMaxHealth;
        SkyeMagic.value = GameManager.SkyeMagic / GameManager.SkyeMaxMagic;

        SullivanHealth.value = GameManager.SullivanHealth / GameManager.SullivanMaxHealth;
        SullivanMagic.value = GameManager.SullivanMagic / GameManager.SullivanMaxMagic;
    }
}
