using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuControlsButton : MonoBehaviour
{
    [SerializeField] GameObject controlsCanvasPrefab;
    [SerializeField] GameObject pauseMenu;

    public void TurnOnControlsCanvasPrefab()
    {
        controlsCanvasPrefab.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
