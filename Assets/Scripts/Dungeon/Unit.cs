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
    public float currentHP;
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

    public GameObject DADAParticle,TransParticle,CharmsParticle,PotionsParticle;
    bool isDADA, isTrans, isCharms, isPotions;

    bool deathDoor;

    //Build these and rename these later based on the player
    #region MC Attacks
    public float MCSpell1Damage;
    public float MCSpell1MagicConsumed;
    public float MCSpell2Damage;
    public float MCSpell2MagicConsumed;
    public float MCSpell3Damage;
    public float MCSpell3MagicConsumed;
    public float MCSpell4Damage;
    public float MCSpell4MagicConsumed;
    public float MCSpell5Damage;
    public float MCSpell5MagicConsumed;
    public float MCSpell6Damage;
    public float MCSpell6MagicConsumed;
    public float MCSpell7Damage;
    public float MCSpell7MagicConsumed;
    public float MCSpell8Damage;
    public float MCSpell8MagicConsumed;
    public float MCSpell9Damage;
    public float MCSpell9MagicConsumed;
    public float MCSpell10Damage;
    public float MCSpell10MagicConsumed;
    public float MCSpell11Damage;
    public float MCSpell11MagicConsumed;
    public float MCSpell12Damage;
    public float MCSpell12MagicConsumed;
    public float MCSpell13Damage;
    public float MCSpell13MagicConsumed;
    public float MCSpell14Damage;
    public float MCSpell14MagicConsumed;
    public float MCSpell15Damage;
    public float MCSpell15MagicConsumed;
    public float MCSpell16Damage;
    public float MCSpell16MagicConsumed;
    public float MCSpell17Damage;
    public float MCSpell17MagicConsumed;
    public float MCSpell18Damage;
    public float MCSpell18MagicConsumed;
    public float MCSpell19Damage;
    public float MCSpell19MagicConsumed;
    public float MCSpell20Damage;
    public float MCSpell20MagicConsumed;
    public float MCSpell21Damage;
    public float MCSpell21MagicConsumed;
    public float MCSpell22Damage;
    public float MCSpell22MagicConsumed;
    public float MCSpell23Damage;
    public float MCSpell23MagicConsumed;

    #endregion

    #region RhysAttacks
    public float RhysSpell1Damage;
    public float RhysSpell1MagicConsumed;
    public float RhysSpell2Damage;
    public float RhysSpell2MagicConsumed;
    public float RhysSpell3Damage;
    public float RhysSpell3MagicConsumed;
    public float RhysSpell4Damage;
    public float RhysSpell4MagicConsumed;
    public float RhysSpell5Damage;
    public float RhysSpell5MagicConsumed;
    public float RhysSpell6Damage;
    public float RhysSpell6MagicConsumed;
    public float RhysSpell7Damage;
    public float RhysSpell7MagicConsumed;
    public float RhysSpell8Damage;
    public float RhysSpell8MagicConsumed;
    public float RhysSpell9Damage;
    public float RhysSpell9MagicConsumed;
    public float RhysSpell10Damage;
    public float RhysSpell10MagicConsumed;
    public float RhysSpell11Damage;
    public float RhysSpell11MagicConsumed;
    public float RhysSpell12Damage;
    public float RhysSpell12MagicConsumed;
    public float RhysSpell13Damage;
    public float RhysSpell13MagicConsumed;
    #endregion

    #region Jameel Attacks
    public float JameelSpell1Damage;
    public float JameelSpell1MagicConsumed;
    public float JameelSpell2Damage;
    public float JameelSpell2MagicConsumed;
    public float JameelSpell3Damage;
    public float JameelSpell3MagicConsumed;
    public float JameelSpell4Damage;
    public float JameelSpell4MagicConsumed;
    public float JameelSpell5Damage;
    public float JameelSpell5MagicConsumed;
    public float JameelSpell6Damage;
    public float JameelSpell6MagicConsumed;
    public float JameelSpell7Damage;
    public float JameelSpell7MagicConsumed;
    public float JameelSpell8Damage;
    public float JameelSpell8MagicConsumed;
    public float JameelSpell9Damage;
    public float JameelSpell9MagicConsumed;
    public float JameelSpell10Damage;
    public float JameelSpell10MagicConsumed;
    public float JameelSpell11Damage;
    public float JameelSpell11MagicConsumed;
    public float JameelSpell12Damage;
    public float JameelSpell12MagicConsumed;
    public float JameelSpell13Damage;
    public float JameelSpell13MagicConsumed;
    public float JameelSpell14Damage;
    public float JameelSpell14MagicConsumed;
    public float JameelSpell15Damage;
    public float JameelSpell15MagicConsumed;
    #endregion

    #region Harper Attacks
    public float HarperSpell1Damage;
    public float HarperSpell1MagicConsumed;
    public float HarperSpell2Damage;
    public float HarperSpell2MagicConsumed;
    public float HarperSpell3Damage;
    public float HarperSpell3MagicConsumed;
    public float HarperSpell4Damage;
    public float HarperSpell4MagicConsumed;
    public float HarperSpell5Damage;
    public float HarperSpell5MagicConsumed;
    public float HarperSpell6Damage;
    public float HarperSpell6MagicConsumed;
    public float HarperSpell7Damage;
    public float HarperSpell7MagicConsumed;
    public float HarperSpell8Damage;
    public float HarperSpell8MagicConsumed;
    public float HarperSpell9Damage;
    public float HarperSpell9MagicConsumed;
    public float HarperSpell10Damage;
    public float HarperSpell10MagicConsumed;
    public float HarperSpell11Damage;
    public float HarperSpell11MagicConsumed;
    public float HarperSpell12Damage;
    public float HarperSpell12MagicConsumed;
    public float HarperSpell13Damage;
    public float HarperSpell13MagicConsumed;

    #endregion

    #region Skye Attacks 
    public float SkyeSpell1Damage;
    public float SkyeSpell1MagicConsumed;
    public float SkyeSpell2Damage;
    public float SkyeSpell2MagicConsumed;
    public float SkyeSpell3Damage;
    public float SkyeSpell3MagicConsumed;
    public float SkyeSpell4Damage;
    public float SkyeSpell4MagicConsumed;
    public float SkyeSpell5Damage;
    public float SkyeSpell5MagicConsumed;
    public float SkyeSpell6Damage;
    public float SkyeSpell6MagicConsumed;
    public float SkyeSpell7Damage;
    public float SkyeSpell7MagicConsumed;
    public float SkyeSpell8Damage;
    public float SkyeSpell8MagicConsumed;
    public float SkyeSpell9Damage;
    public float SkyeSpell9MagicConsumed;
    public float SkyeSpell10Damage;
    public float SkyeSpell10MagicConsumed;
    public float SkyeSpell11Damage;
    public float SkyeSpell11MagicConsumed;
    #endregion

    #region Sullivan Attacks
    public float SullivanSpell1Damage;
    public float SullivanSpell1MagicConsumed;
    public float SullivanSpell2Damage;
    public float SullivanSpell2MagicConsumed;
    public float SullivanSpell3Damage;
    public float SullivanSpell3MagicConsumed;
    public float SullivanSpell4Damage;
    public float SullivanSpell4MagicConsumed;
    public float SullivanSpell5Damage;
    public float SullivanSpell5MagicConsumed;
    public float SullivanSpell6Damage;
    public float SullivanSpell6MagicConsumed;
    public float SullivanSpell7Damage;
    public float SullivanSpell7MagicConsumed;
    public float SullivanSpell8Damage;
    public float SullivanSpell8MagicConsumed;
    public float SullivanSpell9Damage;
    public float SullivanSpell9MagicConsumed;
    public float SullivanSpell10Damage;
    public float SullivanSpell10MagicConsumed;
    public float SullivanSpell11Damage;
    public float SullivanSpell11MagicConsumed;
    public float SullivanSpell12Damage;
    public float SullivanSpell12MagicConsumed;
    public float SullivanSpell13Damage;
    public float SullivanSpell13MagicConsumed;
    #endregion
    //enemyAttack
    public int minAttackAvil, maxAttackAvil;
    int attackToDo;
    int minDamage, maxDamage;
    int maxChance;
    public float enemyDamage;
    float secondEnemyDamage;
    public string attackName;

    public Text DamageUI;
    public Slider Health;

    public bool isEnemy;

    public bool weakRed, weakBlue, weakYellow, weakGreen, weakPhys;
    public bool strRed, strBlue, strYellow, strGreen, strPhys;
    public Text Summary;

    public string[] enemyAttacks;
    float attackModifier = 1;

    public bool increaseEnemyHealth;

    private void Start()
    {
        if (isEnemy)
        {
            Health.maxValue = maxHP;
        }

        ExperienceToDistribute = Random.Range(minExperience, maxExperience);
        MoneyToDistribute = Random.Range(minMoney, maxMoney);
    }

    private void Update()
    {
        if (isEnemy)
        {
            Health.value = currentHP;
        }
    }

    public bool TakeDamageReflected(float dmg)
    {
        currentHP -= dmg;
        DamageUI.text = "-" + dmg.ToString();

        StartCoroutine(WaitingForText());
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

    public bool TakeDamage(float dmg)
    {
        if (weakBlue && GameManager.isBlue || weakYellow && GameManager.isYellow || weakRed && GameManager.isRed || weakGreen && GameManager.isGreen || weakPhys && GameManager.isPhysical)
        {
            Summary.text = "Critical!";
            attackModifier *= 2;
        }

        if (strBlue && GameManager.isBlue || strYellow && GameManager.isYellow || strRed && GameManager.isRed || strGreen && GameManager.isGreen || strPhys && GameManager.isPhysical)
        {
            Summary.text = "Resist!";
            attackModifier *= .5f;
        }

        else
        {
            Summary.text = "";
            attackModifier *= 1f;
        }
        dmg = secondEnemyDamage;
    //    print(dmg);

        secondEnemyDamage = dmg * attackModifier;

     //   print(secondEnemyDamage);

        currentHP -= secondEnemyDamage;

    //    print(secondEnemyDamage + "" + attackModifier);
     //   print(secondEnemyDamage * attackModifier);

        StartCoroutine(WaitingForText());

        if (currentHP <= 0)
        {
            return true;
        }
        else
            return false;
    }

    IEnumerator WaitingForText()
    {
        yield return new WaitForSeconds(2.5f);
        Summary.text = "".ToString();
    }

    public bool TakeDamageSpell1(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }

        StartCoroutine(WaitingForText());
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
    public bool ThrowRock(float dmg)
    {
        Health.value = currentHP / maxHP;
        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }

        StartCoroutine(WaitingForText());

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

    public bool Flippendo(float dmg)
    {
        isCharms = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool PulsateSunt(float dmg)
    {
        isCharms = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool Stupefaciunt(float dmg)
    {
        isDADA = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool Incendio(float dmg)
    {
        isDADA = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());


        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool IncendioMaxima(float dmg)
    {
        isDADA = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());


        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool Avis(float dmg)
    {
        isTrans = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());


        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool AvisMaxima(float dmg)
    {
        isTrans = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());


        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool Glacius(float dmg)
    {
        isCharms = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());


        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool MinorCura(float dmg)
    {
        isPotions = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool ImpetumSubsisto(float dmg)
    {
        isDADA = true;
        Health.value = currentHP / maxHP;
        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool Augamenti(float dmg)
    {
        isCharms = true;
        Health.value = currentHP / maxHP;
        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool MothsDeorsum(float dmg)
    {
        isDADA = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool MothsInteriore(float dmg)
    {
        isDADA = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool InternaCombustione(float dmg)
    {
        isCharms = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool Bombarda(float dmg)
    {
        isTrans = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool BombardaMaxima(float dmg)
    {
        isTrans = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool BombardaUltima(float dmg)
    {
        isTrans = true;
        Health.value = currentHP / maxHP;
        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);

        StartCoroutine(ClearText());
        WandActive();
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
    public bool MinusSanaCoetus(float dmg)
    {
        isPotions = true;
        Health.value = currentHP / maxHP;
        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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

    public bool ChorusPedes(float dmg)
    {
        isCharms = true;
        Health.value = currentHP / maxHP;
        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool CriticaFocus(float dmg)
    {
        isTrans = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool Diffindo(float dmg)
    {
        isCharms = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool DiffindoMaxima(float dmg)
    {
        isCharms = true;
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearText());
        WandActive();
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
    public bool RhysFlippendo(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysCorpusLiget(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysMothsDeorsum(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysMothsInteriore(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysInternumCombustione(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool RhysTenuiLabor(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysIncendio(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysFumos(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysWaddiwasi(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysConjurePugione(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysImpetumSubsisto(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool RhysIraUolueris(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearTextIra());

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
    public bool JameelFlippendo(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool JameelMinusSanaCoetus(float dmg)
    {
        Health.value = currentHP / maxHP;
        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelMinorCura(float dmg)
    {
        Health.value = currentHP / maxHP;
        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelMaiorCura(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelPartumNix(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelHiemsImpetus(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool JameelBombarda(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelBombardaMaxima(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelBombardaUltima(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelRepellere(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool JameelDiffindo(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelDiffindoMaxima(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelImpetumSubsisto(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool JameelChorusPedes(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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
    public bool HarperFlippendo(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool HarperDeflectorImpetum(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool HarperMinorFortitudinem(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool HarperMoserateFortitudinem(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool HarperMaiorFortitudinem(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool HarperInternumCombustione(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool HarperLaedo(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool HarperLociPraesidium(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool HarperPerturbo(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool HarperPulsateSunt(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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
    public bool HarperFumes(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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
    public bool HarperDiminuendo(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            dmg = currentHP * .5f;
            currentHP -= (dmg);
            DamageUI.text = "-" + (dmg).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            dmg = 0;
            DamageUI.text = "-" + (dmg).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            dmg = 0;
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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
    public bool SkyeFlippendo(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
 
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

    public bool SkyeMinorCura(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SkyeMaiorCura(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SkyeSenaPlenaPotion(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SkyeReanimatePotion(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SkyeSanaCoetusPotion(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SkyeAntidoteToCommonPoisons(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SkyeStrengthPotion(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SkyeConfundus(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SkyeIraUolueris(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

        Health.value = (currentHP / maxHP);
        StartCoroutine(ClearTextIra());

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
    public bool SullivanFlippendo(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SullivanExiling(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SullivanProtego(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool SullivanIgnusMagnum(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool SullivanSagittaLecit(float dmg)
    {
        Health.value = currentHP / maxHP;
        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool SullivanMonstrumSella(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SullivanIncarcerous(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());

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

    public bool SullivanUltimumChao(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool SullivanMutareStatum(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool SullivanEngorgement(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool SullivanStatuamLocomotion(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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

    public bool SullivanCriticaFocus(float dmg)
    {
        Health.value = currentHP / maxHP;

        if ((GameManager.isBlue && weakBlue) || (GameManager.isRed && weakRed) || (GameManager.isGreen && weakGreen) || (GameManager.isYellow && weakYellow) || (GameManager.isPhysical && weakPhys))
        {
            currentHP -= (dmg * 2);
            DamageUI.text = "-" + (dmg * 2).ToString();
            Summary.text = "Critical Hit!";
        }

        else if ((GameManager.isBlue && strBlue) || (GameManager.isRed && strRed) || (GameManager.isGreen && strGreen) || (GameManager.isYellow && strYellow) || (GameManager.isPhysical && strPhys))
        {
            currentHP -= (dmg * .5f);
            DamageUI.text = "-" + (dmg * .5f).ToString();
            Summary.text = "Resist!";
        }

        else
        {
            currentHP -= dmg;
            DamageUI.text = "-" + dmg.ToString();
        }
        StartCoroutine(WaitingForText());
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
        if (BattleSystem.deathDoor)
        {
            DeathsDoor();
        }
        else
        {
            int AttackToDo = Random.Range(0, enemyAttacks.Length);

            if (enemyAttacks[AttackToDo].ToString() == "SoftPunch();")
            {
                SoftPunch();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "HeftyHook();")
            {
                HeftyHook();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "HeavyAssault();")
            {
                HeavyAssault();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "GodsHand();")
            {
                GodsHand();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "FollowThrough();")
            {
                FollowThrough();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "JabJabJab();")
            {
                JabJabJab();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "HeavyPounding();")
            {
                HeavyPounding();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "ThrustedFist();")
            {
                ThrustedFist();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "HeadButt();")
            {
                HeadButt();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "BrainShake();")
            {
                BrainShake();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "SkullCracker();")
            {
                SkullCracker();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "ColossalSlam();")
            {
                ColossalSlam();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "Earthquake();")
            {
                Earthquake();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "DeathsDoor();")
            {
                DeathsDoor();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "ExorcismAmbush();")
            {
                ExorcismAmbush();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "DevilWing();")
            {
                DevilWing();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "DemonicDecree();")
            {
                DemonicDecree();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "CannonOfAura();")
            {
                CannonOfAura();
            }

            else if (enemyAttacks[AttackToDo].ToString() == "LifeDrain();")
            {
                LifeDrain();
            }
        }
    }

    public void PlayerElementalWeakness()
    {
        Summary.text = "Here";
        if (weakBlue && GameManager.isBlue || weakYellow && GameManager.isYellow || weakRed && GameManager.isRed || weakGreen && GameManager.isGreen || weakPhys && GameManager.isPhysical)
        {
            Summary.text = "Critical!";
         //   print(Summary.text);
            attackModifier *= 2;
        }

        if (strBlue && GameManager.isBlue || strYellow && GameManager.isYellow || strRed && GameManager.isRed || strGreen && GameManager.isGreen || strPhys && GameManager.isPhysical)
        {
            Summary.text = "Resist!";
            attackModifier *= .5f;
        }

        else 
        {
            Summary.text = "";
            attackModifier *= 1f;
        }
      //  print(weakPhys +" " + GameManager.isPhysical);
     //   print(attackModifier);

        StartCoroutine(WaitingForText());
    }

    #region Enemy Attacks

    void SoftPunch()
    {
        GameManager.isPhysical = true;

        if (weakBlue && GameManager.isBlue || weakYellow && GameManager.isYellow || weakRed && GameManager.isRed || weakGreen && GameManager.isGreen || weakPhys && GameManager.isPhysical)
        {
            Summary.text = "Critical!";
         //   print(Summary.text);
            attackModifier *= 2;

        }

        if (strBlue && GameManager.isBlue || strYellow && GameManager.isYellow || strRed && GameManager.isRed || strGreen && GameManager.isGreen || strPhys && GameManager.isPhysical)
        {
            Summary.text = "Resist!";
            attackModifier *= .5f;
        }

        else
        {
            Summary.text = "";
            attackModifier *= 1f;
        }

        minDamage = 3;
        maxDamage = 8;

        enemyDamage = Random.Range(minDamage, maxDamage);
        secondEnemyDamage = enemyDamage;
     //   print(secondEnemyDamage);
        attackName = "Soft Punch".ToString();
    }

    void HeftyHook()
    {
        GameManager.isPhysical = true;
        minDamage = 10;
        maxDamage = 20;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Hefty Hook".ToString();
    }

    void HeavyAssault()
    {
        GameManager.isPhysical = true;
        minDamage = 25;
        maxDamage = 40;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Hefty Hook".ToString();
    }

    void GodsHand()
    {
        GameManager.isPhysical = true;
        minDamage = 60;
        maxDamage = 85;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Hefty Hook".ToString();
    }

    void FollowThrough()
    {
        GameManager.isPhysical = true;
        BattleSystem.secondaryAttack = true;
        minDamage = 10;
        maxDamage = 20;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Follow Through".ToString();
    }

    void JabJabJab()
    {
        GameManager.isPhysical = true;
        BattleSystem.secondaryAttack = true;
        minDamage = 3;
        maxDamage = 7;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Follow Through".ToString();
    }

    void HeavyPounding()
    {
        GameManager.isPhysical = true;
        BattleSystem.secondaryAttack = true;
        minDamage = 15;
        maxDamage = 25;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Heavy Pounding".ToString();
    }

    void ThrustedFist()
    {
        GameManager.isPhysical = true;
        attackName = "Thrusted Fist".ToString();
        print(attackName);

        int confusionChance;
        maxChance = 90;
        confusionChance = Random.Range(0, 100);

        if (confusionChance <= maxChance)
        {
            BattleSystem.confusionChance = true;
        }
        
        minDamage = 10;
        maxDamage = 15;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;

    }

    void HeadButt()
    {
        GameManager.isPhysical = true;
        int confusionChance;
        maxChance = 20;
        confusionChance = Random.Range(0, 100);
        if (confusionChance <= maxChance)
        {
            BattleSystem.confusionChance = true;
        }
        minDamage = 3;
        maxDamage = 8;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Head Butt".ToString();
    }

    void BrainShake()
    {
        GameManager.isPhysical = true;
        BattleSystem.confusionChance = true;

        int confusionChance;
        maxChance = 60;
        confusionChance = Random.Range(0, 100);
        if (confusionChance <= maxChance)
        {
            BattleSystem.confusionChance = true;
        }
        minDamage = 10;
        maxDamage = 20;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Brain Shake".ToString();
    }

    void SkullCracker()
    {
        GameManager.isPhysical = true;
        BattleSystem.confusionChance = true;

        int confusionChance;
        maxChance = 90;
        confusionChance = Random.Range(0, 100);
        if (confusionChance <= maxChance)
        {
            BattleSystem.confusionChance = true;
        }

        minDamage = 25;
        maxDamage = 40;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Skull Cracker".ToString();
    }

    void ColossalSlam()
    {
        GameManager.isPhysical = true;
        BattleSystem.attackAll = true;

        minDamage = 30;
        maxDamage = 40;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Colossal Slam".ToString();
    }

    void Earthquake()
    {
        GameManager.isPhysical = true;
        BattleSystem.attackAll = true;

        minDamage = 15;
        maxDamage = 25;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Earthquake".ToString();
    }

    void DeathsDoor()
    {
        GameManager.isPhysical = true;
        //Only for bosses
        BattleSystem.attackAll = true;

        minDamage = 125;
        maxDamage = 175;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;

        if (BattleSystem.deathDoor && !BattleSystem.ReaperCalling)
        {

            attackName = "Reaper's Calling".ToString();
            BattleSystem.ReaperCalling = true;

        }

        if (!BattleSystem.deathDoor && !BattleSystem.ReaperCalling)
        {
            BattleSystem.deathDoor = true;
        }

    }


    void ExorcismAmbush()
    {
        GameManager.isRed = true;
        minDamage = 5;
        maxDamage = 15;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Exorcism Ambush".ToString();
    }

    void DevilWing()
    {
        GameManager.isRed = true;
        minDamage = 15;
        maxDamage = 25;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Devil's Wings".ToString();
    }

    void DemonicDecree()
    {
        GameManager.isRed = true;
        minDamage = 30;
        maxDamage = 45;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Decmonic Decree".ToString();
    }

    void CannonOfAura()
    {
        GameManager.isRed = true;
        BattleSystem.attackAll = true;

        minDamage = 5;
        maxDamage = 15;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Cannon of Aura".ToString();
    }

    void LifeDrain()
    {
        GameManager.isRed = true;

        increaseEnemyHealth = true;

        minDamage = 10;
        maxDamage = 11;

        enemyDamage = Random.Range(minDamage, maxDamage) * attackModifier;
        attackName = "Life Drain".ToString();

    }

    #endregion

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2f);
        DamageUI.text = "".ToString();
    }

    IEnumerator ClearTextIra()
    {
        yield return new WaitForSeconds(.5f);
        DamageUI.text = "".ToString();
    }

    void WandActive()
    {
       /* if (isDADA)
        {
            DADAParticle.SetActive(true);
        }
        else if (isCharms)
        {
            CharmsParticle.SetActive(true);
        }
        else if (isTrans)
        {
            TransParticle.SetActive(true);
        }
        else if (isPotions)
        {
            PotionsParticle.SetActive(true);
        }

        isDADA = false;
        isCharms = false;
        isTrans = false;
        isPotions = false;
       */
        WandClear();
    }

    IEnumerator WandClear()
    {
        yield return new WaitForSeconds(2f);
        DADAParticle.SetActive(false);
        CharmsParticle.SetActive(false);
        TransParticle.SetActive(false);
        PotionsParticle.SetActive(false);
    }
}
