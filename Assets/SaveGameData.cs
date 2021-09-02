using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameData 
{
    public string MCFirstName, MCLastName;

    public SaveGameData(GameManager gameManager)
    {
        MCFirstName = GameManager.MCFirstName;
        MCLastName = GameManager.MCLastName;

        Debug.Log(MCFirstName + " " + MCLastName);
    }
}
