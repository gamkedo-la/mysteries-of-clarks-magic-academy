using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    string itemName;
    string itemDescription;
    int itemAmount;
    public Text displayedName;
    public GameObject DescriptionObject;

    public void Initialize(string name, string description, int amount, GameObject previewItem) {
        itemName = name;
        itemDescription = description;
        itemAmount = amount;
        displayedName.text = name;
        DescriptionObject = previewItem;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        DescriptionObject.SetActive(true);
        Transform temp = DescriptionObject.transform;
        temp.GetChild(0).GetComponent<Text>().text = itemName; // child 0 is name
        temp.GetChild(1).GetComponent<Text>().text = "x " + itemAmount; // child 1 is amount
        temp.GetChild(2).GetComponent<Text>().text = itemDescription; // child 2 is description
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DescriptionObject.SetActive(false);
    }
}
