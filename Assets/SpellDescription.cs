using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellDescription : MonoBehaviour, IPointerEnterHandler
{
    public GameObject descriptionBox;
    public string descrption;
    public string cost;
    public bool HP;

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

    public void OnMouseEnterFunction()
    {
        descriptionBox.SetActive(true);
        descriptionText.text = descrption;
        costText.text = cost;
        if (HP)
        {
            HPText.text = "HP";
        }
        else
            HPText.text = "MP";
    }

    public void OnMouseExitFunction()
    {
        descriptionBox.SetActive(false);
    }
}
