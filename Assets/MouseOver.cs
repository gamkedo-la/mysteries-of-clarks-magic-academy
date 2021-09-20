using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject creature;
    public void OnPointerEnter(PointerEventData eventData)
    {
        creature.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        creature.SetActive(false);
    }
}
