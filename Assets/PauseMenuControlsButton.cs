using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuControlsButton : MonoBehaviour
{
    [SerializeField] GameObject controlsCanvas;
    [SerializeField] GameObject pauseMenu;

    public void TurnOnControlsCanvasPrefab()
    {
        Debug.Log("controls button click recognized");
        Debug.Log("controlsCanvas: " + controlsCanvas);
        controlsCanvas.SetActive(true);
       // pauseMenu.SetActive(false);
    }
}
