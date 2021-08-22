using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetPlayerName : MonoBehaviour
{
    public GameObject NameMenu;
    public InputField first, last;
    private TMP_Text playersSetNameTextComponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NameMenu.SetActive(true);
            playersSetNameTextComponent = GameObject.FindGameObjectWithTag("NameText").GetComponent<TMP_Text>();
            Time.timeScale = 0;
        }
    }

    public void SaveFirst()
    {

        playersSetNameTextComponent.text = first.text + " " + last.text;
        GameManager.MCFirstName = first.text;
    }
    public void SaveLast()
    {
        playersSetNameTextComponent.text = first.text + " " + last.text;
        GameManager.MCLastName = last.text;
    }

    public void Continue()
    {
        if (first.text != "" && last.text != "")
        {
            NameMenu.SetActive(false);
            print(GameManager.MCFirstName + " " + GameManager.MCLastName);
            Time.timeScale = 1;
        }
        else if (first.text != "" && last.text == "")
        {
            playersSetNameTextComponent.text = "Please enter and save a last name";
        }
        else if (first.text == "" && last.text != "")
        {
            playersSetNameTextComponent.text = "Please enter and save a first name";
        }
        else
        {
            playersSetNameTextComponent.text = "Please enter and save a first and last name";
            Debug.Log("Please enter and save a first and last name");
        }
    }
}
