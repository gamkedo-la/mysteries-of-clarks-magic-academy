using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPlayerSpells : MonoBehaviour
{
    public bool isTrans, isPotions, isCharms, isDADA;

    void Start()
    {
        GameManager.Courage++;
        if (isTrans)
        {
            GameManager.MCTrans++;
        }

        if (isPotions)
        {
            GameManager.MCPotions++;
        }

        if (isCharms)
        {
            GameManager.MCCharms++;
        }

        if (isDADA)
        {
            GameManager.MCDADA++;
        }
    }

}
