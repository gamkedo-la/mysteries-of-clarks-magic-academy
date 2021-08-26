using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButtonScript : MonoBehaviour
{
    [SerializeField] GameObject titleCanvas;
    [SerializeField] GameObject controlsMenuCanvas;

    public void TurnOnControlsMenu()
    {
        controlsMenuCanvas.SetActive(true);
        titleCanvas.SetActive(false);
    }
}
