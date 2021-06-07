using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState {START, MCTURN, RHYSTURN, JAMEELTURN, HARPERTURN, SKYETURN, SULLIVANTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject MCPrefab;
    public GameObject RhysPrefab;
    public GameObject JameelPrefab;
    public GameObject HarperPrefab;
    public GameObject SkyePrefab;
    public GameObject SullivanPrefab;

    Animator MCAnim;
    Animator RhysAnim;
    Animator JameelAnim;
    Animator HarperAnim;
    Animator SkyeAnim;
    Animator SullivanAnim;

    public Transform MCBattleStation;
    public Transform SecondBattleStation;
    public Transform ThirdBattleStation;
    public Transform FourthBattleStation;

    #region Players UI Menus
    public GameObject MCMenu;
    public GameObject MCSpells;
    public GameObject MCConfirmMenu;
    public GameObject MCEndingMenu;

    public GameObject RhysMenu;
    public GameObject RhysSpells;
    public GameObject RhysConfirmMenu;
    public GameObject RhysEndingMenu;

    public GameObject JameelMenu;
    public GameObject JameelSpells;
    public GameObject JameelConfirmMenu;
    public GameObject JameelEndingMenu;

    public GameObject HarperMenu;
    public GameObject HarperSpells;
    public GameObject HarperConfirmMenu;
    public GameObject HarperEndingMenu;

    public GameObject SkyeMenu;
    public GameObject SkyeSpells;
    public GameObject SkyeConfirmMenu;
    public GameObject SkyeEndingMenu;

    public GameObject SullivanMenu;
    public GameObject SullivanSpells;
    public GameObject SullivanConfirmMenu;
    public GameObject SullivanEndingMenu;
    #endregion

    //The Player's Party
    Unit MC;
    Unit Rhys;
    Unit Jameel;
    Unit Harper;
    Unit Skye;
    Unit Sullivan;

    //UI for Health and Magic
    public Slider MCHealth, MCMagic;
    public Slider RhysHealth, RhysMagic;
    public Slider JameelHealth, JameelMagic;
    public Slider HarperHealth, HarperMagic;
    public Slider SkyeHealth, SkyeMagic;
    public Slider SullivanHealth, SullivanMagic;

    //Setting Color for being up versus downed
    public Color staminaBaseColor, energyBaseColor, downedColor;

    #region Experience Section
    /*
    public Text MCExpGain, RhysExpGain, JameelExpGain, HarperExpGain, SkyeExpGain, SullivanExpGain;
    public Text MCExpToNext, RhysExpToNext, JameelExpToNext, HarperExpToNext, SkyeExpToNext, SullivanExpToNext;
    public Text MCTotalExp, RhysTotalExp, JameelTotalExp, HarperTotalExp, SkyeTotalExp, SullivanTotalExp;
    bool MCLevel, RhysLevel, JameelLevel, HarperLevel, SkyeLevel, SullivanLevel;
    public GameObject MCLevelUp, RhysLevelUp, JameelLevelUp, HarperLevelUp, SkyeLevelUp, SullivanLevelUp;

    public GameObject PlayerStatsScreen, MCLevelUpScreen, RhysLevelUpScreen, JameelLevelUpScreen, HarperLevelUpScreen, SkyeLevelUpScreen, SullivanLevelUpScreen;

    //This is the attack menu, come back to this when you've determined who does what attack
    public Slider SFSlider, SSSlider, SCSlider, SChSlider, SASlider;
    public Slider MFSlider, MSSlider, MCSlider, MChSlider, MASlider;
    public Slider SeFSlider, SeSSlider, SeCSlider, SeChSlider, SeASlider;
    public Slider CFSlider, CSSlider, CCSlider, CChSlider, CASlider;
    public Text SPoints, MPoints, SePoints, CPoints;

    int SPointsToGive, MPointsToGive, SePointsToGive, CPointsToGive;
    */
    #endregion

    public Text MoneyText;
    //Particle System for selection
    public GameObject enemySelectionParticle;
    public GameObject playerSelectionParticle;

    //determining enemySelection
    public int enemyUnitSelected;
    public List<Transform> enemyBattleStationLocations;
    public List<GameObject> enemyPrefab;
    public List<Unit> enemyUnit;
    public List<Animator> enemyAnim;
    //text informing the player what is going on
    public Text dialogueText;


    //PlayerSpellChoice

    //This needs to be determined later - right now, it is a placeholder from Strike Out
    bool fastball;
    bool curveball;
    bool slider;
    bool changeup;

    //Enemy
    bool isDead;
    //determing player losing conditions - this is different from Strike Out - now only the MC needs to die
    public GameObject[] playerStations;
    //MCDead triggers a game over
    bool MCDead;
    //Other dead just play animations and can come back
    bool RhysDead;
    bool JameelDead;
    bool HarperDead;
    bool SkyeDead;
    bool SullivanDead;
    int enemyCount;

    //Choosing which player to attack
    int WhoToAttack;

    //
    bool enemySelect;
    bool isOver;
    int totalExp;
    //Witch/Wizard LevelUp
    bool MCLevel, RhysLevel, JameelLevel, HarperLevel, SkyeLevel, SullivanLevel;

    //Im leaving this in here for now, but in Strike Out - you could choose which level up items you choose, but I think in this one, I'd like it automatic
    public GameObject FastballButton, SliderButton, CurveballButton, ChangeUpButton, AgilityButton, Macro;

    //Initiated GameObjects
    GameObject playerGO1, playerGO2, playerGO3, playerGO4;

    //ItemMenuButton
    GameObject ItemMenu;
    public GameObject backButtonItem;

    GameObject GameManagerObject;

    //Cam positions
    public GameObject Camera, cutsceneCam;
    public Transform player1Cam, player2Cam, player3Cam, player4Cam, enemyCam, battleCam, enemyCamTarget;

    //bools to determine enemy count
    public bool Boss;
    int enemyStartCount = 0;

    //cutscene cam anim 
    public Animator cutSceneCamAnim;
    public GameObject cutSceneCamSecond;

    // Inventory System, will come in later
    //GameObject InventoryManage;
    //public Text InventoryItemPostBattle;

    //Damage UI against players
    public Text MCDamageUI, RhysDamageUI, JameelDamageUI, HarperDamageUI, SkyeDamageUI, SullivanDamageUI;

    public enum CharacterIdentifier
    { MC, Rhys, Jameel, Harper, Skye, Sullivan, Enemy1, Enemy2, Enemy3, Enemy4, Enemy5 };

    public List<CharacterIdentifier> playerTurnOrder = new List<CharacterIdentifier>();
    public List<CharacterIdentifier> enemyTurnOrder = new List<CharacterIdentifier>();

    public bool isPlayerTurn;

    //Turn Order Display
    public Text Next;

    //We'll deal with this when im doing the experience system
    bool gameOverToPreventDuplicates;
    bool preventingAddXPDup;

    public string DungeonRoomToLoad, LosingScreenToLoad;


    private void Start()
    {
        Debug.LogWarning("The GameManager needs to be in this scene for everything to work");

        //   InventoryManage = GameObject.Find("Inventory");

        MCDamageUI.text = "".ToString();
        RhysDamageUI.text = "".ToString();
        JameelDamageUI.text = "".ToString();
        HarperDamageUI.text = "".ToString();
        SkyeDamageUI.text = "".ToString();
        SullivanDamageUI.text = "".ToString();

        playerTurnOrder.Add(CharacterIdentifier.MC);

        if (GameManager.RhysInParty)
        {
            playerTurnOrder.Add(CharacterIdentifier.Rhys);
        }
        if (GameManager.JameelInParty)
        {
            playerTurnOrder.Add(CharacterIdentifier.Jameel);
        }
        if (GameManager.HarperInParty)
        {
            playerTurnOrder.Add(CharacterIdentifier.Harper);
        }
        if (GameManager.SkyeInParty)
        {
            playerTurnOrder.Add(CharacterIdentifier.Skye);
        }
        if (GameManager.SullivanInParty)
        {
            playerTurnOrder.Add(CharacterIdentifier.Sullivan);
        }


        Camera.transform.position = battleCam.transform.position;
        Camera.transform.LookAt(enemyCamTarget.transform.position);

        state = BattleState.START;

        print(enemyBattleStationLocations.Count);

        if (GameManager.RhysHealth <= 0)
        {
            GameManager.RhysHealth = 1;
        }
        if (GameManager.JameelHealth <= 0)
        {
            GameManager.JameelHealth = 1;
        }
        if (GameManager.HarperHealth <= 0)
        {
            GameManager.HarperHealth = 1;
        }
        if (GameManager.SkyeHealth <= 0)
        {
            GameManager.SkyeHealth = 1;
        }
        if (GameManager.SullivanHealth <= 0)
        {
            GameManager.SullivanHealth = 1;
        }

        if (Boss)
        {
            enemyStartCount = 1;
        }

        else
        {
            //Adjust this later - instead of percent chance, build on it for GameManager.CurrentFloor;
            int RandRangeEnemySpawn = Random.Range(0, 100);

            if (RandRangeEnemySpawn < 14)
            {
                enemyStartCount = 1;
            }
            else if (RandRangeEnemySpawn <= 39)
            {
                enemyStartCount = 2;
            }
            else if (RandRangeEnemySpawn <= 69)
            {
                enemyStartCount = 3;
            }
            else if (RandRangeEnemySpawn <= 89)
            {
                enemyStartCount = 4;
            }
            else
            {
                enemyStartCount = 5;
            }
        }

        enemyTurnOrder.Add(CharacterIdentifier.Enemy1);

        if (enemyStartCount >= 2)
        {
            enemyTurnOrder.Add(CharacterIdentifier.Enemy2);
        }
        if (enemyStartCount >= 3)
        {
            enemyTurnOrder.Add(CharacterIdentifier.Enemy3);
        }
        if (enemyStartCount >= 4)
        {
            enemyTurnOrder.Add(CharacterIdentifier.Enemy4);
        }
        if (enemyStartCount >= 5)
        {
            enemyTurnOrder.Add(CharacterIdentifier.Enemy5);
        }



        for (int i = 0; i < enemyStartCount; i++)
        {
            enemyCount++;
            //enemyPrefab[i].SetActive(true);

        }

        MCDead = false;
        RhysDead = false;
        JameelDead = false;
        HarperDead = false;
        SkyeDead = false;
        SullivanDead = false;

        MCHealth.value = (GameManager.MCHealth / GameManager.MCMaxHealth);
        RhysHealth.value = (GameManager.RhysHealth / GameManager.RhysMaxHealth);
        JameelHealth.value = (GameManager.JameelHealth / GameManager.JameelMaxHealth);
        HarperHealth.value = (GameManager.HarperHealth / GameManager.HarperMaxHealth);
        SkyeHealth.value = (GameManager.SkyeHealth / GameManager.SkyeMaxHealth);
        SullivanHealth.value = (GameManager.SullivanHealth / GameManager.SullivanMaxHealth);

        MCMagic.value = (GameManager.MCMagic / GameManager.MCMaxMagic);
        RhysMagic.value = (GameManager.RhysMagic / GameManager.RhysMaxMagic);
        JameelMagic.value = (GameManager.JameelMagic / GameManager.JameelMaxMagic);
        HarperMagic.value = (GameManager.HarperMagic / GameManager.HarperMaxMagic);
        SkyeMagic.value = (GameManager.SkyeMagic / GameManager.SkyeMaxMagic);
        SullivanMagic.value = (GameManager.SullivanMagic / GameManager.SullivanMaxMagic);

    //    ItemMenu = GameObject.Find("Inventory");
        GameManagerObject = GameObject.Find("GameManager");

        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        #region This places all the UI and assigns the player and enemy values from the Unit Script
        playerGO1 = Instantiate(MCPrefab, MCBattleStation);
        MC = playerGO1.GetComponent<Unit>();

        //I don't think this is structured correctly. Come back to this later.
        #region Determining Second Player Battle Station
        if (GameManager.RhysInParty)
        {
            playerGO2 = Instantiate(RhysPrefab, SecondBattleStation);
            Rhys = playerGO2.GetComponent<Unit>();
            //   Rhys = playerGO2.GetComponent<Animator>();
        }
        else if (!GameManager.RhysInParty && GameManager.JameelInParty)
        {
            playerGO2 = Instantiate(JameelPrefab, SecondBattleStation);
            Jameel = playerGO2.GetComponent<Unit>();
            //   Jameel = playerGO2.GetComponent<Animator>();
        }
        else if (!GameManager.RhysInParty && !GameManager.JameelInParty && GameManager.HarperInParty)
        {
            playerGO2 = Instantiate(HarperPrefab, SecondBattleStation);
            Harper = playerGO2.GetComponent<Unit>();
            //   Harper = playerGO2.GetComponent<Animator>();
        }
        else if (GameManager.PartyCount == 2 && GameManager.SkyeInParty)
        {
            playerGO2 = Instantiate(SkyePrefab, SecondBattleStation);
            Skye = playerGO2.GetComponent<Unit>();
            //   Skye = playerGO2.GetComponent<Animator>();
        }
        else if (GameManager.PartyCount == 2 && GameManager.SullivanInParty)
        {
            playerGO2 = Instantiate(SullivanPrefab, SecondBattleStation);
            Sullivan = playerGO2.GetComponent<Unit>();
            //   Sullivan = playerGO2.GetComponent<Animator>();
        }
        #endregion
        # region Determining Third Player Battle Station
        if (GameManager.RhysInParty && GameManager.JameelInParty)
        {
            playerGO3 = Instantiate(JameelPrefab, ThirdBattleStation);
            Jameel = playerGO3.GetComponent<Unit>();
            //   Jameel = playerGO3.GetComponent<Animator>();
        }
        else if (GameManager.RhysInParty || GameManager.JameelInParty && GameManager.HarperInParty)
        {
            playerGO3 = Instantiate(HarperPrefab, ThirdBattleStation);
            Harper = playerGO3.GetComponent<Unit>();
            //   Harper = playerGO3.GetComponent<Animator>();
        }
        else if (GameManager.SkyeInParty && !GameManager.SullivanInParty)
        {
            playerGO3 = Instantiate(SkyePrefab, ThirdBattleStation);
            Skye = playerGO3.GetComponent<Unit>();
            //   Skye = playerGO3.GetComponent<Animator>();
        }
        else if (GameManager.PartyCount == 3 && GameManager.SullivanInParty)
        {
            playerGO3 = Instantiate(SullivanPrefab, ThirdBattleStation);
            Sullivan = playerGO3.GetComponent<Unit>();
            //   Sullivan = playerGO3.GetComponent<Animator>();
        }
        #endregion
        #region
        if (GameManager.RhysInParty && GameManager.JameelInParty && GameManager.HarperInParty)
        {
            playerGO4 = Instantiate(HarperPrefab, FourthBattleStation);
            Harper = playerGO4.GetComponent<Unit>();
            //   Harper = playerGO4.GetComponent<Animator>();
        }
        else if (GameManager.PartyCount == 4 && GameManager.SkyeInParty && !GameManager.SullivanInParty)
        {
            playerGO4 = Instantiate(SkyePrefab, FourthBattleStation);
            Skye = playerGO4.GetComponent<Unit>();
            //   Skye = playerGO4.GetComponent<Animator>();
        }
        if (GameManager.PartyCount == 4 && GameManager.SullivanInParty)
        {
            playerGO4 = Instantiate(SullivanPrefab, FourthBattleStation);
            Sullivan = playerGO4.GetComponent<Unit>();
         //   Sullivan = playerGO4.GetComponent<Animator>();
        }
        #endregion

        for (int i = 0; i < enemyStartCount; i++)
        {
            int RandEnemy = Random.Range(0, enemyPrefab.Count);
            GameObject enemyGO = Instantiate(enemyPrefab[RandEnemy], enemyBattleStationLocations[i]);
            enemyUnit.Add(enemyGO.GetComponent<Unit>());
            enemyAnim.Add(enemyGO.GetComponentInChildren<Animator>());
        }
        enemyUnit[0].GetComponent<Unit>().myEnumValue = CharacterIdentifier.Enemy1;
        if (enemyStartCount >= 2)
        {
            enemyUnit[1].GetComponent<Unit>().myEnumValue = CharacterIdentifier.Enemy2;
        }
        if (enemyStartCount >= 3)
        {
            enemyUnit[2].GetComponent<Unit>().myEnumValue = CharacterIdentifier.Enemy3;
        }
        if (enemyStartCount >= 4)
        {
            enemyUnit[3].GetComponent<Unit>().myEnumValue = CharacterIdentifier.Enemy4;
        }
        if (enemyStartCount >= 5)
        {
            enemyUnit[4].GetComponent<Unit>().myEnumValue = CharacterIdentifier.Enemy5;
        }

        yield return new WaitForSeconds(4f);
        cutsceneCam.SetActive(false);



        if (GameManager.enemyAttackedPlayer)
        {
            isPlayerTurn = true;
        }
        else
        {
            isPlayerTurn = false;
        }
        NextTurn();
        #endregion
    }

    private void Update()
    {
        //Cheat Code to Win Battle
        /*{
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheatToInstantlyWin();
            }
        }
        */
        //If MC Health <= 0, game is over (at the bottom of this function)
        if (GameManager.RhysHealth <= 0)
        {
            playerTurnOrder.Remove(CharacterIdentifier.Rhys);
        }

        if (GameManager.JameelHealth <= 0)
        {
            playerTurnOrder.Remove(CharacterIdentifier.Jameel);
        }

        if (GameManager.HarperHealth <= 0)
        {
            playerTurnOrder.Remove(CharacterIdentifier.Harper);
        }

        if (GameManager.SkyeHealth <= 0)
        {
            playerTurnOrder.Remove(CharacterIdentifier.Skye);
        }

        if (GameManager.SullivanHealth <= 0)
        {
            playerTurnOrder.Remove(CharacterIdentifier.Sullivan);
        }

        //Adding back into party after knockout
        if (GameManager.RhysHealth >= 0 && RhysDead)
        {
         //   RhysAnim.SetBool("isDead", false);
            RhysDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Rhys);
        }
        if (GameManager.JameelHealth >= 0 && JameelDead)
        {
          //  JameelAnim.SetBool("isDead", false);
            JameelDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Jameel);
        }
        if (GameManager.HarperHealth >= 0 && HarperDead)
        {
         //  HarperAnim.SetBool("isDead", false);
            HarperDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Harper);
        }
        if (GameManager.SkyeHealth >= 0 && SkyeDead)
        {
          //  SkyeAnim.SetBool("isDead", false);
            SkyeDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Skye);
        }
        if (GameManager.SullivanHealth >= 0 && SullivanDead)
        {
         //   SullivanAnim.SetBool("isDead", false);
            SullivanDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Sullivan);
        }

        
        #region Select Enemy
        if ((state == BattleState.MCTURN || state == BattleState.RHYSTURN || state == BattleState.JAMEELTURN || state == BattleState.HARPERTURN || state == BattleState.SKYETURN || state == BattleState.SULLIVANTURN) && enemySelect)
        {
            //SelectionProcess
            enemySelectionParticle.SetActive(true);
            enemySelectionParticle.transform.position = enemyBattleStationLocations[enemyUnitSelected].transform.position;
            if (Input.GetKeyDown(KeyCode.A) && enemyStartCount > 1)
            {
                enemyUnitSelected--;
                if (enemyUnitSelected < 0)
                {
                    enemyUnitSelected = enemyBattleStationLocations.Count - (6 - enemyStartCount);
                }

                enemySelectionParticle.transform.position = enemyBattleStationLocations[enemyUnitSelected].transform.position;
                Camera.transform.LookAt(enemyBattleStationLocations[enemyUnitSelected]);
            }
            if (Input.GetKeyDown(KeyCode.D) && enemyStartCount > 1)
            {
                enemyUnitSelected++;
                if (enemyUnitSelected >= enemyStartCount)
                {
                    enemyUnitSelected = 0;
                }

                enemySelectionParticle.transform.position = enemyBattleStationLocations[enemyUnitSelected].transform.position;
                Camera.transform.LookAt(enemyBattleStationLocations[enemyUnitSelected]);
            }

            if (state == BattleState.MCTURN)
            {
                MC.transform.LookAt(enemyBattleStationLocations[enemyUnitSelected]);
            }

            if (state == BattleState.RHYSTURN)
            {
                Rhys.transform.LookAt(enemyBattleStationLocations[enemyUnitSelected]);
            }

            if (state == BattleState.JAMEELTURN)
            {
                Jameel.transform.LookAt(enemyBattleStationLocations[enemyUnitSelected]);
            }

            if (state == BattleState.HARPERTURN)
            {
                Harper.transform.LookAt(enemyBattleStationLocations[enemyUnitSelected]);
            }
            if (state == BattleState.SKYETURN)
            {
                Skye.transform.LookAt(enemyBattleStationLocations[enemyUnitSelected]);
            }
            if (state == BattleState.SULLIVANTURN)
            {
                Sullivan.transform.LookAt(enemyBattleStationLocations[enemyUnitSelected]);
            }
        }

        if (enemyCount == 0 && !isOver)
        {
            state = BattleState.WON;
            EndBattle();
        }

        if (MCDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }

        #endregion
        #region Animations based on Health
        /*
        //Starter
        if (GameManager.StarterMorale > (GameManager.StarterMoraleMax * .2))
        {
            StarterAnim.SetBool("isInjured", false);
        }
        if (GameManager.StarterMorale <= (GameManager.StarterMoraleMax * .2) && GameManager.StarterMorale > 0)
        {
            StarterAnim.SetBool("isInjured", true);
        }
        if (GameManager.StarterMorale <= 0)
        {
            starterDead = true;
            StarterAnim.SetBool("isDead", true);
        }
        //MR
        if (GameManager.MidRelivMorale > (GameManager.MidRelivMoraleMax * .2))
        {
            MidRelAnim.SetBool("isInjured", false);
        }
        if (GameManager.MidRelivMorale <= (GameManager.MidRelivMoraleMax * .2) && GameManager.MidRelivMorale > 0)
        {
            MidRelAnim.SetBool("isInjured", true);
        }
        if (GameManager.MidRelivMorale <= 0)
        {
            middleDead = true;
            MidRelAnim.SetBool("isDead", true);
        }
        //SetUp
        if (GameManager.SetUpMorale > (GameManager.SetUpMoraleMax * .2))
        {
            SetUpAnim.SetBool("isInjured", false);
        }
        if (GameManager.SetUpMorale <= (GameManager.SetUpMoraleMax * .2) && GameManager.SetUpMorale > 0)
        {
            SetUpAnim.SetBool("isInjured", true);
        }
        if (GameManager.SetUpMorale <= 0)
        {
            setupDead = true;
            SetUpAnim.SetBool("isDead", true);
        }
        //Closer
        if (GameManager.CloserMorale > (GameManager.CloserMoraleMax * .2))
        {
            CloserAnim.SetBool("isInjured", false);
        }
        if (GameManager.CloserMorale <= (GameManager.CloserMoraleMax * .2) && GameManager.CloserMorale > 0)
        {
            CloserAnim.SetBool("isInjured", true);
        }
        if (GameManager.CloserMorale <= 0)
        {
            closerDead = true;
            CloserAnim.SetBool("isDead", true);
        }
        */
        #endregion
    }

    void NextTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        CharacterIdentifier upRightNow;
        if (isPlayerTurn)
        {
            //DebugPrintList(playerTurnOrder);
            upRightNow = playerTurnOrder[0];
            playerTurnOrder.RemoveAt(0);
            playerTurnOrder.Add(upRightNow);
        }

        else
        {
            if (enemyCount > 0)
            {
                upRightNow = enemyTurnOrder[0];
                enemyTurnOrder.RemoveAt(0);
                enemyTurnOrder.Add(upRightNow);
            }
            else
            {
                upRightNow = 0;
                state = BattleState.WON;
                EndBattle();
            }
        }


        //  Debug.Log("NextTurnCalled: " + upRightNow);

        switch (upRightNow)
        {
            case CharacterIdentifier.MC:
                //       print("Starter");
                MCTurn();
                state = BattleState.MCTURN;
                break;
            case CharacterIdentifier.Rhys:
                //       print("Middle");
                RhysTurn();
                state = BattleState.RHYSTURN;
                break;
            case CharacterIdentifier.Jameel:
                //       print("SetUp");
                JameelTurn();
                state = BattleState.JAMEELTURN;
                break;
            case CharacterIdentifier.Harper:
                //       print("Closer");
                HarperTurn();
                state = BattleState.HARPERTURN;
                break;

            case CharacterIdentifier.Skye:
                //       print("Closer");
                SkyeTurn();
                state = BattleState.SKYETURN;
                break;
            case CharacterIdentifier.Sullivan:
                //       print("Closer");
                SullivanTurn();
                state = BattleState.SULLIVANTURN;
                break;
            case CharacterIdentifier.Enemy1:
                //      print("Enemy1");
                state = BattleState.ENEMYTURN;
                StartCoroutine("EnemyTurn", 0);
                break;
            case CharacterIdentifier.Enemy2:
                //       print("Enemy2");
                state = BattleState.ENEMYTURN;
                StartCoroutine("EnemyTurn", 1);
                break;
            case CharacterIdentifier.Enemy3:
                //     print("Enemy3");
                state = BattleState.ENEMYTURN;
                StartCoroutine("EnemyTurn", 2);
                break;
            case CharacterIdentifier.Enemy4:
                //      print("Enemy4");
                state = BattleState.ENEMYTURN;
                StartCoroutine("EnemyTurn", 3);
                break;
            case CharacterIdentifier.Enemy5:
                //    print("Enemy5");
                state = BattleState.ENEMYTURN;
                StartCoroutine("EnemyTurn", 4);
                break;
        }
        if (isPlayerTurn)
        {
            Next.text = "Up Next:  " + ReturnNameOfEnemy(enemyTurnOrder[0]);
        }

        if (!isPlayerTurn)
        {
            Next.text = "Up Next:  " + playerTurnOrder[0].ToString();
        }

    }
    private string ReturnNameOfEnemy(CharacterIdentifier forID)
    {
        for (int i = 0; i < enemyUnit.Count; i++)
        {
            if (enemyUnit[i].myEnumValue == forID)
            {
                string nameToRemoveCloneFrom = enemyUnit[i].name;
                nameToRemoveCloneFrom = nameToRemoveCloneFrom.Replace("(Clone)", "");
                return nameToRemoveCloneFrom;
            }
        }
        return "Error: No Match Found";
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

    #endregion

    #region ItemManagement
    /*
     * 
     *Initially Borrowed from Strike Out - will adjust later
    public void SportsDrink()
    {
        if (state == BattleStateMultiple.STARTER)
        {
            GameManagerObject.GetComponent<GameManager>().StarterHealthUp(20);
        }
        if (state == BattleStateMultiple.SETUP)
        {
            GameManagerObject.GetComponent<GameManager>().SetUpHealthUp(20);
        }
        if (state == BattleStateMultiple.MIDDLE)
        {
            GameManagerObject.GetComponent<GameManager>().MiddleHealthUp(20);
        }
        if (state == BattleStateMultiple.CLOSER)
        {
            GameManagerObject.GetComponent<GameManager>().CloserHealthUp(20);
        }

        AdvanceTurn();
    }

    public void GranolaBar()
    {
        if (state == BattleStateMultiple.STARTER)
        {
            GameManagerObject.GetComponent<GameManager>().StarterEnergyUp(10);
        }
        if (state == BattleStateMultiple.SETUP)
        {
            GameManagerObject.GetComponent<GameManager>().MiddleEnergyUp(10);
        }
        if (state == BattleStateMultiple.MIDDLE)
        {
            GameManagerObject.GetComponent<GameManager>().SetUpEnergyUp(10);
        }
        if (state == BattleStateMultiple.CLOSER)
        {
            GameManagerObject.GetComponent<GameManager>().CloserEnergyUp(10);
        }
        AdvanceTurn();
    }

    public void UpdateHealthUI()
    {
        AdvanceTurn();
    }
    public void DefensiveShiftItem()
    {
        print("Shift");
        for (int i = 0; i < enemyUnit.Count; i++)
        {
            isDead = enemyUnit[i].TakeDamage(20);

            if (isDead)
            {
                totalExp += enemyUnit[i].ExperienceToDistribute;
                enemyCount--;
                RemoveCurrentEnemy();
            }

            if (enemyCount > 0)
            {
                AdvanceTurn();
            }
            else
            {
                backButtonItem.SetActive(false);
                PlayerMenu.SetActive(false);
                PlayerPitches.SetActive(false);
                ItemMenu.transform.localPosition = new Vector3(233, -900, 0);

                state = BattleStateMultiple.WON;
                EndBattle();
            }
        }
    }

    public void ScoutingReportItem()
    {
        isDead = enemyUnit[enemyUnitSelected].TakeDamage(20);

        if (isDead)
        {
            totalExp += enemyUnit[enemyUnitSelected].ExperienceToDistribute;
            enemyCount--;
            enemyBattleStationLocations.Remove(enemyBattleStationLocations[enemyUnitSelected]);
            RemoveCurrentEnemy();
            enemyUnitSelected = 0;
            enemySelectionParticle.transform.position = enemyBattleStationLocations[enemyUnitSelected].transform.position;
        }
        if (enemyCount > 0)
        {
            AdvanceTurn();
        }
        else
        {
            backButtonItem.SetActive(false);
            PlayerMenu.SetActive(false);
            PlayerPitches.SetActive(false);
            ItemMenu.transform.localPosition = new Vector3(233, -900, 0);

            state = BattleStateMultiple.WON;
            EndBattle();
        }
    }

    public void ItemMenuButton()
    {
        ItemMenu.transform.localPosition = new Vector3(233, 20, 0);
        print(ItemMenu.name);
        backButtonItem.SetActive(true);
        PlayerMenu.SetActive(false);
        PlayerPitches.SetActive(false);
    }

    public void ItemMenuBack()
    {
        backButtonItem.SetActive(false);
        ItemMenu.transform.localPosition = new Vector3(233, -900, 0);
        PlayerMenu.SetActive(true);
        PlayerPitches.SetActive(false);
    }
    */
    #endregion
    public void AdvanceTurn()
    {
        backButtonItem.SetActive(false);
        MCMenu.SetActive(false);
        MCSpells.SetActive(false);
        ItemMenu.transform.localPosition = new Vector3(233, -900, 0);

        MCHealth.value = (GameManager.MCHealth / GameManager.MCMaxHealth);
        RhysHealth.value = (GameManager.RhysHealth / GameManager.RhysMaxHealth);
        JameelHealth.value = (GameManager.JameelHealth / GameManager.JameelMaxHealth);
        HarperHealth.value = (GameManager.HarperHealth / GameManager.HarperMaxHealth);
        SkyeHealth.value = (GameManager.SkyeHealth / GameManager.SkyeMaxHealth);
        SullivanHealth.value = (GameManager.SullivanHealth / GameManager.SullivanMaxHealth);

        MCMagic.value = (GameManager.MCMagic / GameManager.MCMaxMagic);
        RhysMagic.value = (GameManager.RhysMagic / GameManager.RhysMaxMagic);
        JameelMagic.value = (GameManager.JameelMagic / GameManager.JameelMaxMagic);
        HarperMagic.value = (GameManager.HarperMagic / GameManager.HarperMaxMagic);
        SkyeMagic.value = (GameManager.SkyeMagic / GameManager.SkyeMaxMagic);
        SullivanMagic.value = (GameManager.SullivanMagic / GameManager.SullivanMaxMagic);

        //If the player is below 20% health, they can play an animation to show they are injured. As is, it is a little buggy.
        /*
                if (GameManager.StarterMorale > (GameManager.StarterMoraleMax * .2))
                {
                    StarterAnim.SetBool("isInjured", false);
                }
                //MR
                if (GameManager.MidRelivMorale > (GameManager.MidRelivMoraleMax * .2))
                {
                    MidRelAnim.SetBool("isInjured", false);
                }
                //SetUp
                if (GameManager.SetUpMorale > (GameManager.SetUpMoraleMax * .2))
                {
                    SetUpAnim.SetBool("isInjured", false);
                }
                //Closer
                if (GameManager.CloserMorale > (GameManager.CloserMoraleMax * .2))
                {
                    CloserAnim.SetBool("isInjured", false);
                }
        */
        NextTurn();
    }

    public void RunAway()
    {
      /*  if (THIS IS A BOSS)
        {
            dialogueText.text = "You can't run from this fight!";
            StartCoroutine(WaitingForCall());
        }
      */
     //   else
     //   {
     //Build into this system a little - add their agility score
            int Rand = Random.Range(0, 2);
            if (Rand == 0)
            {
                if (GameManager.GracieMayAvailable)
                {
                    dialogueText.text = "Gracie May: You can't leave now! I'll look for an opening!";
                }
                else
                {
                    dialogueText.text = "You don't see an opening.";
                }
                MCMenu.SetActive(false);
                NextTurn();
            }
            if (Rand == 1)
            {
                if (GameManager.GracieMayAvailable)
                {
                    dialogueText.text = "Gracie May: I found an opening! You can run!";
                }
                else
                {
                    dialogueText.text = "You think you can get away";
                }
                StartCoroutine(WaitingAtEndOfBattle());
        }
      //  }
    }

    public void ConfirmAttack()
    {

        if (state == BattleState.MCTURN)
        {
            StartCoroutine(MCAttack());
        }

        if (state == BattleState.RHYSTURN)
        {
            StartCoroutine(RhysAttack());
        }

        if (state == BattleState.JAMEELTURN)
        {
            StartCoroutine(JameelAttack());
        }

        if (state == BattleState.HARPERTURN)
        {
            StartCoroutine(HarperAttack());
        }

        if (state == BattleState.SKYETURN)
        {
            StartCoroutine(SkyeAttack());
        }

        if (state == BattleState.SULLIVANTURN)
        {
            StartCoroutine(SullivanAttack());
        }
        MCConfirmMenu.SetActive(false);
        enemySelectionParticle.SetActive(false);
        enemySelect = false;
    }

    public void CancelAttack()
    {
        MCMenu.SetActive(true);
        MCConfirmMenu.SetActive(false);
        enemySelectionParticle.SetActive(false);
        enemySelect = false;
    }

    void RemoveCurrentEnemy()
    {
        enemyTurnOrder.Remove(enemyUnit[enemyUnitSelected].myEnumValue);
        totalExp += enemyUnit[enemyUnitSelected].ExperienceToDistribute;
    }


    #region Player Attacks/Heal

    public void OnHealButton()
    {
        if (state == BattleState.MCTURN)
        {
            GameManager.MCMagic += 5;
            GameManager.MCHealth += 5;

            if (GameManager.MCMagic >= GameManager.MCMaxMagic)
            {
                GameManager.MCMagic = GameManager.MCMaxMagic;
            }
            if (GameManager.MCHealth >= GameManager.MCMaxHealth)
            {
                GameManager.MCHealth = GameManager.MCMaxHealth;
            }
        }

        if (state == BattleState.RHYSTURN)
        {
            GameManager.RhysMagic += 5;
            GameManager.RhysHealth += 5;

            if (GameManager.RhysMagic >= GameManager.RhysMaxMagic)
            {
                GameManager.RhysMagic = GameManager.RhysMaxMagic;
            }
            if (GameManager.RhysHealth >= GameManager.RhysMaxHealth)
            {
                GameManager.RhysHealth = GameManager.RhysMaxHealth;
            }
        }

        if (state == BattleState.JAMEELTURN)
        {
            GameManager.JameelMagic += 5;
            GameManager.JameelHealth += 5;

            if (GameManager.JameelMagic >= GameManager.JameelMaxMagic)
            {
                GameManager.JameelMagic = GameManager.JameelMaxMagic;
            }
            if (GameManager.JameelHealth >= GameManager.JameelMaxHealth)
            {
                GameManager.JameelHealth = GameManager.JameelMaxHealth;
            }
        }

        if (state == BattleState.HARPERTURN)
        {
            GameManager.HarperMagic += 5;
            GameManager.HarperHealth += 5;

            if (GameManager.HarperMagic >= GameManager.HarperMaxMagic)
            {
                GameManager.HarperMagic = GameManager.HarperMaxMagic;
            }
            if (GameManager.HarperHealth >= GameManager.HarperMaxHealth)
            {
                GameManager.HarperHealth = GameManager.HarperMaxHealth;
            }
        }

        if (state == BattleState.SKYETURN)
        {
            GameManager.SkyeMagic += 5;
            GameManager.SkyeHealth += 5;

            if (GameManager.SkyeMagic >= GameManager.SkyeMaxMagic)
            {
                GameManager.SkyeMagic = GameManager.SkyeMaxMagic;
            }
            if (GameManager.SkyeHealth >= GameManager.SkyeMaxHealth)
            {
                GameManager.SkyeHealth = GameManager.SkyeMaxHealth;
            }
        }

        if (state == BattleState.SULLIVANTURN)
        {
            GameManager.SullivanMagic += 5;
            GameManager.SullivanHealth += 5;

            if (GameManager.SullivanMagic >= GameManager.SullivanMaxMagic)
            {
                GameManager.SullivanMagic = GameManager.SullivanMaxMagic;
            }
            if (GameManager.SullivanHealth >= GameManager.SullivanMaxHealth)
            {
                GameManager.SullivanHealth = GameManager.SullivanMaxHealth;
            }
        }

        //If you want the enemies to heal when the player heals, take this comment out
        /*
                    for (int i = 0; i < enemyUnit.Count; i++)
                    {
                        if (enemyUnit[i].currentHP > 0)
                        {
                            enemyUnit[i].TakeDamage(-5);
                        }
                    }
        */

        AdvanceTurn();
    }

    IEnumerator MCAttack()
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
