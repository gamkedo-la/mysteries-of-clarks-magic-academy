using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCharm : MonoBehaviour
{
    public bool Charisma, Proficiency;
    void Start()
    {
        if (Charisma)
        {
            GameManager.Charisma++;
        }
        if (Proficiency)
        {
            GameManager.Proficiency++;
        }
    }
}
