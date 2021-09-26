using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetPlayerName : MonoBehaviour
{
    public InputField first, last;
    [SerializeField] Text playersSavedNameTextComponent;
    [SerializeField] GameObject welcomeTextCanvas;
    public GameObject Advance;

    public void SaveName()
    {
        playersSavedNameTextComponent.text = "Your saved name is: " + first.text + " " + last.text;
        GameManager.MCFirstName = first.text;
        GameManager.MCLastName = last.text;
        Advance.GetComponent<Button>().interactable = true;
    }

    public void Continue()
    {
        if (first.text != "" && last.text != "")
        {
            gameObject.SetActive(false);
            welcomeTextCanvas.SetActive(true);
            print(GameManager.MCFirstName + " " + GameManager.MCLastName);
            Time.timeScale = 1;
        }
        else if (first.text != "" && last.text == "")
        {
            playersSavedNameTextComponent.text = "Please enter a last name, then save ";
        }
        else if (first.text == "" && last.text != "")
        {
            playersSavedNameTextComponent.text = "Please enter a first name, then save";
        }
        else
        {
            playersSavedNameTextComponent.text = "Please enter and save a first and last name";
        }
    }
}
