using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerName : MonoBehaviour
{
    public GameObject NameMenu;
    public InputField first, last;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NameMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void SaveFirst()
    {
        GameManager.MCFirstName = first.text;
    }
    public void SaveLast()
    {
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
        else
        {
            Debug.Log("Please enter and save a first and last name");
        }
    }
}
