using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public BattleSystem.CharacterIdentifier myEnumValue;

    public string unitName;
    public int unitLevel;

    public int damage;
    public int heal;

    public int maxHP;
    public int currentHP;
    //I don't think these are functional right now
    public int agilityPercent;
    public int critialChance;
    //
    public int ExperienceToDistribute;
    public int minExperience;
    public int maxExperience;

    public int MoneyToDistribute;
    public int minMoney;
    public int maxMoney;

    //Build these and rename these later based on the player
    public int Spell1Damage;
    public int Spell1MagicConsumed;

    //enemyAttack
    public int minAttackAvil, maxAttackAvil;
    int attackToDo;
    int minDamage, maxDamage;
    public int enemyDamage;
    public string attackName;

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

    //This is for the Enemys to reference for their choice of attack (start of the AI system)
    public void DetermineAttack()
    {
        attackToDo = Random.Range(minAttackAvil, maxAttackAvil);

        if (attackToDo == 0)
            //using this as an example
        { SoftPunch(); }
        #region Attacks from Strike Out - To Be Replaced
        /*
                if (attackToDo == 1)
                { SeeingEye(); AttackVO(attackToDo); }

                if (attackToDo == 2)
                { PopUp(); AttackVO(attackToDo); }

                if (attackToDo == 3)
                { LineDrive(); AttackVO(attackToDo); }

                if (attackToDo == 4)
                { Shagging(); AttackVO(attackToDo); }

                if (attackToDo == 5)
                { GroundRule(); AttackVO(attackToDo); }

                if (attackToDo == 6)
                { TakingPitch(); AttackVO(attackToDo); }

                if (attackToDo == 7)
                { DeepFoul(); AttackVO(attackToDo); }

                if (attackToDo == 8)
                { CircusPlay(); AttackVO(attackToDo); }

                if (attackToDo == 9)
                { Grandstanding(); AttackVO(attackToDo); }

                if (attackToDo == 10)
                { TheCall(); AttackVO(attackToDo); }

                if (attackToDo == 11)
                { DucksOnPond(); AttackVO(attackToDo); }

                if (attackToDo == 12)
                { SouvenirDay(); AttackVO(attackToDo); }

                if (attackToDo == 13)
                { DeadBall(); AttackVO(attackToDo); }

                if (attackToDo == 14)
                { Balk(); AttackVO(attackToDo); }

                if (attackToDo == 15)
                { Walk(); AttackVO(attackToDo); }

                if (attackToDo == 16)
                { OverTurnedCall(); AttackVO(attackToDo); }

                if (attackToDo == 17)
                { StrikeOut(); AttackVO(attackToDo); }

                if (attackToDo == 18)
                { Ejection(); AttackVO(attackToDo); }

                if (attackToDo == 19)
                { TightStrikeZone(); AttackVO(attackToDo); }



                if (attackToDo == 20)
                { Clutch(); AttackVO(attackToDo); }

                if (attackToDo == 21)
                { GrandSlam(); AttackVO(attackToDo); }

                if (attackToDo == 22)
                { CalledShot(); AttackVO(attackToDo); }

                if (attackToDo == 23)
                { Rally(); AttackVO(attackToDo); }

                if (attackToDo == 24)
                { Double(); AttackVO(attackToDo); }

                if (attackToDo == 25)
                { RBIMachine(); AttackVO(attackToDo); }

                if (attackToDo == 26)
                { DeepDrive(); AttackVO(attackToDo); }
        */
        #endregion
    }

    void SoftPunch()
    {
        minDamage = 1;
        maxDamage = 5;

        enemyDamage = Random.Range(minDamage, maxDamage);
        //  DamageUI.text = "-" + enemyDamage.ToString();
        attackName = "Soft Punch".ToString();
    }
}
