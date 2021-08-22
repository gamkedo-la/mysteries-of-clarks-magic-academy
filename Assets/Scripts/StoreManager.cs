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
	private const int SINVENTORY_ITEM_X_OFFSET = 90;
    private const int SINVENTORY_ITEM_Y_OFFSET = 30;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < storeInventory.Container.Count ; i++)
        {
            GameObject item = Instantiate(storeItemPrefab, Vector3.zero, Quaternion.identity, storeInventoryContents);
            item.GetComponent<RectTransform>().localPosition = new Vector3(SINVENTORY_ITEM_X_OFFSET, -SINVENTORY_ITEM_Y_OFFSET * (i + 1), 0);
				item.GetComponent<Text>().text = storeInventory.Container[i].item.itemName;
            item.transform.GetChild(0).GetComponent<Text>().text = "x" + storeInventory.Container[i].amount;
		  }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            ToggleStore();
        }
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
