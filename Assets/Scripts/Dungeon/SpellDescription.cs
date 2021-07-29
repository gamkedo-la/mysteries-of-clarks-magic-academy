using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject descriptionBox;
    public string descrption;
    public string cost;
    public bool HP;

    public bool DADA, Trans, Charms, Potions, Health;

    public Text descriptionText, costText, HPText;

    void Start()
    {
        if (HP)
        {
            HPText.text = "HP";
        }
        else
            HPText.text = "MP";

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionBox.SetActive(true);
        descriptionText.text = descrption;
        costText.text = cost;

        if (DADA)
        {
            descriptionBox.GetComponent<Image>().color = Color.yellow;
        }

        else if (Trans)
        {
            descriptionBox.GetComponent<Image>().color = Color.grey;
        }

        else if (Charms)
        {
            descriptionBox.GetComponent<Image>().color = Color.blue;
        }

        else if (Potions)
        {
            descriptionBox.GetComponent<Image>().color = Color.green;
        }
        else if (Health)
        {
            descriptionBox.GetComponent<Image>().color = Color.red;
        }

        if (HP)
        {
            HPText.text = "HP";
        }
        else
            HPText.text = "MP";

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionBox.SetActive(false);
    }
}
