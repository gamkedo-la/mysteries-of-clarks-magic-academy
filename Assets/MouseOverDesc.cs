using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOverDesc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text toDisplay;
    public string descrption;

    public void OnPointerEnter(PointerEventData eventData)
    {
        toDisplay.text = descrption;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toDisplay.text = "";
    }
}
