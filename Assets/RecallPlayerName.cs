using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecallPlayerName : MonoBehaviour
{
    public Text playerName;

    public bool justFirstName;

    private void Start()
    {
        if (justFirstName)
        {
            playerName.text = GameManager.MCFirstName;
        }

        else
        {
            playerName.text = GameManager.MCFirstName + " " + GameManager.MCLastName;
        }
    }
}
