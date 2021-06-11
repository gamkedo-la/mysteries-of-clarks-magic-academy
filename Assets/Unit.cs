using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    #region MC Attacks
    public int MCSpell1Damage;
    public int MCSpell1MagicConsumed;
    public int MCSpell2Damage;
    public int MCSpell2MagicConsumed;
    public int MCSpell3Damage;
    public int MCSpell3MagicConsumed;
    public int MCSpell4Damage;
    public int MCSpell4MagicConsumed;
    public int MCSpell5Damage;
    public int MCSpell5MagicConsumed;
    public int MCSpell6Damage;
    public int MCSpell6MagicConsumed;
    public int MCSpell7Damage;
    public int MCSpell7MagicConsumed;
    public int MCSpell8Damage;
    public int MCSpell8MagicConsumed;
    public int MCSpell9Damage;
    public int MCSpell9MagicConsumed;
    public int MCSpell10Damage;
    public int MCSpell10MagicConsumed;
    public int MCSpell11Damage;
    public int MCSpell11MagicConsumed;
    public int MCSpell12Damage;
    public int MCSpell12MagicConsumed;
    public int MCSpell13Damage;
    public int MCSpell13MagicConsumed;
    public int MCSpell14Damage;
    public int MCSpell14MagicConsumed;
    public int MCSpell15Damage;
    public int MCSpell15MagicConsumed;
    public int MCSpell16Damage;
    public int MCSpell16MagicConsumed;
    public int MCSpell17Damage;
    public int MCSpell17MagicConsumed;
    public int MCSpell18Damage;
    public int MCSpell18MagicConsumed;
    public int MCSpell19Damage;
    public int MCSpell19MagicConsumed;
    public int MCSpell20Damage;
    public int MCSpell20MagicConsumed;
    public int MCSpell21Damage;
    public int MCSpell21MagicConsumed;
    public int MCSpell22Damage;
    public int MCSpell22MagicConsumed;
    public int MCSpell23Damage;
    public int MCSpell23MagicConsumed;

    #endregion

    #region RhysAttacks
    public int RhysSpell1Damage;
    public int RhysSpell1MagicConsumed;
    public int RhysSpell2Damage;
    public int RhysSpell2MagicConsumed;
    public int RhysSpell3Damage;
    public int RhysSpell3MagicConsumed;
    public int RhysSpell4Damage;
    public int RhysSpell4MagicConsumed;
    public int RhysSpell5Damage;
    public int RhysSpell5MagicConsumed;
    public int RhysSpell6Damage;
    public int RhysSpell6MagicConsumed;
    public int RhysSpell7Damage;
    public int RhysSpell7MagicConsumed;
    public int RhysSpell8Damage;
    public int RhysSpell8MagicConsumed;
    public int RhysSpell9Damage;
    public int RhysSpell9MagicConsumed;
    public int RhysSpell10Damage;
    public int RhysSpell10MagicConsumed;
    public int RhysSpell11Damage;
    public int RhysSpell11MagicConsumed;
    public int RhysSpell12Damage;
    public int RhysSpell12MagicConsumed;
    public int RhysSpell13Damage;
    public int RhysSpell13MagicConsumed;
    #endregion

    #region Jameel Attacks
    public int JameelSpell1Damage;
    public int JameelSpell1MagicConsumed;
    public int JameelSpell2Damage;
    public int JameelSpell2MagicConsumed;
    public int JameelSpell3Damage;
    public int JameelSpell3MagicConsumed;
    public int JameelSpell4Damage;
    public int JameelSpell4MagicConsumed;
    public int JameelSpell5Damage;
    public int JameelSpell5MagicConsumed;
    public int JameelSpell6Damage;
    public int JameelSpell6MagicConsumed;
    public int JameelSpell7Damage;
    public int JameelSpell7MagicConsumed;
    public int JameelSpell8Damage;
    public int JameelSpell8MagicConsumed;
    public int JameelSpell9Damage;
    public int JameelSpell9MagicConsumed;
    public int JameelSpell10Damage;
    public int JameelSpell10MagicConsumed;
    public int JameelSpell11Damage;
    public int JameelSpell11MagicConsumed;
    public int JameelSpell12Damage;
    public int JameelSpell12MagicConsumed;
    public int JameelSpell13Damage;
    public int JameelSpell13MagicConsumed;
    public int JameelSpell14Damage;
    public int JameelSpell14MagicConsumed;
    public int JameelSpell15Damage;
    public int JameelSpell15MagicConsumed;
    #endregion

    #region Harper Attacks
    public int HarperSpell1Damage;
    public int HarperSpell1MagicConsumed;
    public int HarperSpell2Damage;
    public int HarperSpell2MagicConsumed;
    public int HarperSpell3Damage;
    public int HarperSpell3MagicConsumed;
    public int HarperSpell4Damage;
    public int HarperSpell4MagicConsumed;
    public int HarperSpell5Damage;
    public int HarperSpell5MagicConsumed;
    public int HarperSpell6Damage;
    public int HarperSpell6MagicConsumed;
    public int HarperSpell7Damage;
    public int HarperSpell7MagicConsumed;
    public int HarperSpell8Damage;
    public int HarperSpell8MagicConsumed;
    public int HarperSpell9Damage;
    public int HarperSpell9MagicConsumed;
    public int HarperSpell10Damage;
    public int HarperSpell10MagicConsumed;
    public int HarperSpell11Damage;
    public int HarperSpell11MagicConsumed;
    public int HarperSpell12Damage;
    public int HarperSpell12MagicConsumed;
    public int HarperSpell13Damage;
    public int HarperSpell13MagicConsumed;

    #endregion

    #region Skye Attacks 
    public int SkyeSpell1Damage;
    public int SkyeSpell1MagicConsumed;
    public int SkyeSpell2Damage;
    public int SkyeSpell2MagicConsumed;
    public int SkyeSpell3Damage;
    public int SkyeSpell3MagicConsumed;
    public int SkyeSpell4Damage;
    public int SkyeSpell4MagicConsumed;
    public int SkyeSpell5Damage;
    public int SkyeSpell5MagicConsumed;
    public int SkyeSpell6Damage;
    public int SkyeSpell6MagicConsumed;
    public int SkyeSpell7Damage;
    public int SkyeSpell7MagicConsumed;
    public int SkyeSpell8Damage;
    public int SkyeSpell8MagicConsumed;
    public int SkyeSpell9Damage;
    public int SkyeSpell9MagicConsumed;
    public int SkyeSpell10Damage;
    public int SkyeSpell10MagicConsumed;
    public int SkyeSpell11Damage;
    public int SkyeSpell11MagicConsumed;
    #endregion

    #region Sullivan Attacks
    public int SullivanSpell1Damage;
    public int SullivanSpell1MagicConsumed;
    public int SullivanSpell2Damage;
    public int SullivanSpell2MagicConsumed;
    public int SullivanSpell3Damage;
    public int SullivanSpell3MagicConsumed;
    public int SullivanSpell4Damage;
    public int SullivanSpell4MagicConsumed;
    public int SullivanSpell5Damage;
    public int SullivanSpell5MagicConsumed;
    public int SullivanSpell6Damage;
    public int SullivanSpell6MagicConsumed;
    public int SullivanSpell7Damage;
    public int SullivanSpell7MagicConsumed;
    public int SullivanSpell8Damage;
    public int SullivanSpell8MagicConsumed;
    public int SullivanSpell9Damage;
    public int SullivanSpell9MagicConsumed;
    public int SullivanSpell10Damage;
    public int SullivanSpell10MagicConsumed;
    public int SullivanSpell11Damage;
    public int SullivanSpell11MagicConsumed;
    public int SullivanSpell12Damage;
    public int SullivanSpell12MagicConsumed;
    public int SullivanSpell13Damage;
    public int SullivanSpell13MagicConsumed;
    #endregion
    //enemyAttack
    public int minAttackAvil, maxAttackAvil;
    int attackToDo;
    int minDamage, maxDamage;
    public int enemyDamage;
    public string attackName;

    public Text DamageUI;
    public Slider Health;

    public bool isEnemy;

    private void Start()
    {
        if (isEnemy)
        {
            Health.maxValue = maxHP;
        }
    }

    private void Update()
    {
        if (isEnemy)
        {
            Health.value = currentHP;
        }
    }

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

    public bool TakeDamageSpell1(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg ;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        Debug.Log(Health.value);
        Debug.Log(currentHP + "/" + maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    #region MC Attacks
    public bool ThrowRock(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        Debug.Log(Health.value);
        Debug.Log(currentHP + "/" + maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool Flippendo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool PulsateSunt(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool Stupefaciunt(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool Incendio(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool IncendioMaxima(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool Avis(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool AvisMaxima(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool Glacius(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool MinorCura(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool ImpetumSubsisto(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool Augamenti(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool MothsDeorsum(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool MothsInteriore(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool InternaCombustione(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool Bombarda(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool BombardaMaxima(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool BombardaUltima(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);

        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool MinusSanaCoetus(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool ChorusPedes(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool CriticaFocus(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool Diffindo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool DiffindoMaxima(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }


    #endregion

    #region RhysAttacks
    public bool RhysFlippendo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysCorpusLiget(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysMothsDeorsum(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysMothsInteriore(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysInternumCombustione(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysTenuiLabor(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysIncendio(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysFumos(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysWaddiwasi(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysConjurePugione(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysImpetumSubsisto(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool RhysIraUolueris(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    #endregion

    #region Jameel Attacks
    public bool JameelFlippendo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelMinusSanaCoetus(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelMinorCura(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelMaiorCura(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelPartumNix(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelHiemsImpetus(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelBombarda(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelBombardaMaxima(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelBombardaUltima(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelRepellere(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelDiffindo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelDiffindoMaxima(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelImpetumSubsisto(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool JameelChorusPedes(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    #endregion

    #region Harper Attacks
    public bool HarperFlippendo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool HarperDeflectorImpetum(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool HarperMinorFortitudinem(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool HarperMoserateFortitudinem(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool HarperMaiorFortitudinem(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool HarperInternumCombustione(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool HarperLaedo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool HarperLociPraesidium(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool HarperPerturbo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool HarperPulsateSunt(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool HarperFumes(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    public bool HarperDiminuendo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    #endregion

    #region Skye Attacks
    public bool SkyeFlippendo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SkyeMinorCura(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SkyeMaiorCura(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SkyeSenaPlenaPotion(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SkyeReanimatePotion(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SkyeSanaCoetusPotion(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SkyeAntidoteToCommonPoisons(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SkyeStrengthPotion(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SkyeConfundus(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SkyeIraUolueris(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }
    #endregion

    #region Sullivan Attacks
    public bool SullivanFlippendo(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanExiling(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanProtego(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanIgnusMagnum(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanSagittaLecit(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanMonstrumSella(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanIncarcerous(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanUltimumChao(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanMutareStatum(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanEngorgement(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanStatuamLocomotion(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }

    public bool SullivanCriticaFocus(int dmg)
    {
        Health.value = currentHP / maxHP;

        currentHP -= dmg;
        //This is a bool to determine if after the attack has landed - if it kills the enemy or not
        Health.value = (currentHP / maxHP);
        DamageUI.text = "-" + dmg.ToString();

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());

        if (currentHP <= 0)
        {
            //  anim.Play("Armature|Downed");
            return true;
        }

        else
        {
            //  anim.Play("Armature|Damage");
            return false;
        }
    }



    #endregion

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
        SoftPunch();
        /*
        attackToDo = Random.Range(minAttackAvil, maxAttackAvil);

        if (attackToDo == 0)
            //using this as an example
        { SoftPunch(); }*/
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

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2f);
        DamageUI.text = "".ToString();
    }
}
