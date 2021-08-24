using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecallPlayerName : MonoBehaviour
{
    public Text playerName;

    private void Start()
    {
        playerName.text = GameManager.MCFirstName + " " + GameManager.MCLastName;
    }
}
