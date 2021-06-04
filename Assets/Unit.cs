using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;
    public int heal;

    public int maxHP;
    public int currentHP;

    public int agilityPercent;
    public int critialChance;

    public bool TakeDamage(int dmg)
    {
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
