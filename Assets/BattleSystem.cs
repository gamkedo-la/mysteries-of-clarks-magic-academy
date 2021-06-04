using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject playerPrefab, enemyPrefab;
    public Transform playerBattleStation, enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD, enemyHUD;

    public GameObject playerAttackButtons, HUDButtons, WinningScreen;

    public string DungeonRoomToLoad, LosingScreenToLoad;


    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        #region This places all the UI and assigns the player and enemy values from the Unit Script
        GameObject playerGameObject = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGameObject.GetComponent<Unit>();


        GameObject enemyGameObject = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGameObject.GetComponent<Unit>();

        dialogueText.text = "An enemy named: " + enemyUnit.unitName + " has appeared.";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        #endregion

        #region This Waits 2 Seconds to show the player what is happening, then makes it the players turn
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
        #endregion
    }

    void PlayerTurn()
    {
        #region This turns the player's attack buttons on to indicate it is the player's turn
        dialogueText.text = "Choose an action:";
        playerAttackButtons.SetActive(true);
        //The buttons that turn on are represented by "OnAttackButton" and "OnHealButton"
        #endregion
    }

    #region Player UI Buttons
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());
    }

    #endregion

    #region Player Attacks/Heal

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(playerUnit.heal);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You have healed for " + playerUnit.heal + " HP.";
        playerAttackButtons.SetActive(false);
        yield return new WaitForSeconds(1.5f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerAttack()
    {
        int randomDodgePercentChance = Random.Range(0, 100);
        if (randomDodgePercentChance <= enemyUnit.agilityPercent)
        {
            //Attack missed
            dialogueText.text = enemyUnit.unitName + " dodged the attack";
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            //Chance for a Critical hit to land
            int randomCriticalPercentChance = Random.Range(0, 100);
            if (randomCriticalPercentChance <= playerUnit.critialChance)
            {
                //If critical hit lands, double the damage
                bool isDead = enemyUnit.TakeDamage(playerUnit.damage * 2);
                enemyHUD.SetHP(enemyUnit.currentHP);
                dialogueText.text = "The attack against " + enemyUnit.unitName + " was CRITICAL.";

                if (isDead)
                {
                    //If the enemy died, the battle is over
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    //If the enemy didn't die, the battle continues
                    state = BattleState.ENEMYTURN;
                    StartCoroutine(EnemyTurn());
                }
            }
            else
            {
            //If not a critical hit, then apply damage normally
                bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
                enemyHUD.SetHP(enemyUnit.currentHP);
                dialogueText.text = "The attack against " + enemyUnit.unitName + " was successful.";

                if (isDead)
                {
                    //If the enemy died, the battle is over
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    //If the enemy didn't die, the battle continues
                    state = BattleState.ENEMYTURN;
                    StartCoroutine(EnemyTurn());
                }
            }
        }
        playerAttackButtons.SetActive(false);
        yield return new WaitForSeconds(2f);
    }

    #endregion

    #region Enemy Attack

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks " + playerUnit.unitName;
        yield return new WaitForSeconds(1f);
        //You can put your logic here for the enemy attack to figure out which attack to do.

        int randomDodgePercentChance = Random.Range(0, 100);
        if (randomDodgePercentChance <= playerUnit.agilityPercent)
        {
            //Attack missed
            dialogueText.text = playerUnit.unitName + " dodged the attack";

            yield return new WaitForSeconds(1f);

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else
        {
            //Chance for a Critical hit to land
            int randomCriticalPercentChance = Random.Range(0, 100);
            if (randomCriticalPercentChance <= enemyUnit.critialChance)
            {
                //If critical hit lands, double the damage
                bool isDead = playerUnit.TakeDamage(enemyUnit.damage * 2);
                playerHUD.SetHP(playerUnit.currentHP);
                dialogueText.text = "The attack against " + playerUnit.unitName + " was CRITICAL.";

                yield return new WaitForSeconds(1f);

                if (isDead)
                {
                    //If the player died, the battle is over
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                {
                    //If the player didn't die, the battle continues
                    state = BattleState.PLAYERTURN;
                    PlayerTurn();
                }
            }
            //If not a critical hit, then apply damage normally
            else
            {
                bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
                playerHUD.SetHP(playerUnit.currentHP);
                dialogueText.text = "The attack against " + playerUnit.unitName + " was successful.";

                yield return new WaitForSeconds(1f);

                if (isDead)
                {
                    //If the player died, the battle is over
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                {
                    //If the player didn't die, the battle continues
                    state = BattleState.PLAYERTURN;
                    PlayerTurn();
                }
            }
        }
        yield return new WaitForSeconds(2f);
    }

    #endregion

    #region End of Battle States
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            StartCoroutine(WinningScreenWaiting());
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
            StartCoroutine(LosingScreenWaiting());
            //Load Lost Menu
        }
    }
    #endregion
    #region Losing Screen Menus

    IEnumerator LosingScreenWaiting()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(LosingScreenToLoad);
    }

    #endregion
    #region WinningScreenMenus

    IEnumerator WinningScreenWaiting()
    {
        yield return new WaitForSeconds(2f);
        HUDButtons.SetActive(false);
        WinningScreen.SetActive(true);
    }

    public void WinningScreenButton()
    {
        //This is where you will advance to return to the Battle Scene
        SceneManager.LoadScene(DungeonRoomToLoad);
    }
    #endregion
}
