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

    public GameObject RhysMenu;
    public GameObject RhysSpells;
    public GameObject RhysConfirmMenu;

    public GameObject JameelMenu;
    public GameObject JameelSpells;
    public GameObject JameelConfirmMenu;

    public GameObject HarperMenu;
    public GameObject HarperSpells;
    public GameObject HarperConfirmMenu;

    public GameObject SkyeMenu;
    public GameObject SkyeSpells;
    public GameObject SkyeConfirmMenu;

    public GameObject SullivanMenu;
    public GameObject SullivanSpells;
    public GameObject SullivanConfirmMenu;

    public GameObject EndingMenu;
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

      //  print(enemyBattleStationLocations.Count);

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
        else if (GameManager.PartyCount == 4 && GameManager.SkyeInParty && GameManager.SullivanInParty)
        {
            playerGO3 = Instantiate(SkyePrefab, ThirdBattleStation);
            Skye = playerGO3.GetComponent<Unit>();
            //   Skye = playerGO4.GetComponent<Animator>();
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

        yield return new WaitForSeconds(3f);
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
     //   playerAttackButtons.SetActive(true);
        //The buttons that turn on are represented by "OnAttackButton" and "OnHealButton"
        #endregion
    }

    #region Player UI Buttons
   /* public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(MCTurn());
    }
   */
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
            MCConfirmMenu.SetActive(false);
            StartCoroutine(MCAttack());
        }

        if (state == BattleState.RHYSTURN)
        {
            RhysConfirmMenu.SetActive(false);
            StartCoroutine(RhysAttack());
        }

        if (state == BattleState.JAMEELTURN)
        {
            JameelConfirmMenu.SetActive(false);
            StartCoroutine(JameelAttack());
        }

        if (state == BattleState.HARPERTURN)
        {
            HarperConfirmMenu.SetActive(false);
            StartCoroutine(HarperAttack());
        }

        if (state == BattleState.SKYETURN)
        {
            SkyeConfirmMenu.SetActive(false);
            StartCoroutine(SkyeAttack());
        }

        if (state == BattleState.SULLIVANTURN)
        {
            SullivanConfirmMenu.SetActive(false);
            StartCoroutine(SullivanAttack());
        }

        enemySelectionParticle.SetActive(false);
        enemySelect = false;
    }

    public void CancelAttack()
    {
        if (state == BattleState.MCTURN)
        {
            MCMenu.SetActive(true);
            MCConfirmMenu.SetActive(false);
        }

        if (state == BattleState.RHYSTURN)
        {
            RhysMenu.SetActive(true);
            RhysConfirmMenu.SetActive(false);
        }

        if (state == BattleState.JAMEELTURN)
        {
            JameelMenu.SetActive(true);
            JameelConfirmMenu.SetActive(false);
        }

        if (state == BattleState.HARPERTURN)
        {
            HarperMenu.SetActive(true);
            HarperConfirmMenu.SetActive(false);
        }

        if (state == BattleState.SKYETURN)
        {
            SkyeMenu.SetActive(true);
            SkyeConfirmMenu.SetActive(false);
        }

        if (state == BattleState.SULLIVANTURN)
        {
            SullivanMenu.SetActive(true);
            SullivanConfirmMenu.SetActive(false);
        }
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
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        //Modify the Spell1Damage and Spell1Magic used based on the player, the spell, and their level 
        if (state == BattleState.MCTURN)
        {
            if (fastball)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    fastball = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.Spell1MagicConsumed;
                    MCMagic.value = GameManager.MCMagic / GameManager.MCMaxMagic;
                    //    StarterAnim.Play("StarterWindup");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].TakeDamage(MC.Spell1Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                    fastball = false;
                    slider = false;
                    curveball = false;
                    changeup = false;
                    dialogueText.text = "The attack is successful!";
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();

                        //     totalExp += enemyUnit[enemyUnitSelected].ExperienceToDistribute;
                        enemyCount--;

                        enemySelectionParticle.transform.position = enemyBattleStationLocations[enemyUnitSelected].transform.position;
                    }
                    NextTurn();

                }
            }
            if (slider)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    fastball = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.Spell1MagicConsumed;
                    MCMagic.value = GameManager.MCMagic / GameManager.MCMaxMagic;
                    //    StarterAnim.Play("StarterWindup");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].TakeDamage(MC.Spell1Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                    fastball = false;
                    slider = false;
                    curveball = false;
                    changeup = false;
                    dialogueText.text = "The attack is successful!";
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();

                        //     totalExp += enemyUnit[enemyUnitSelected].ExperienceToDistribute;
                        enemyCount--;

                        enemySelectionParticle.transform.position = enemyBattleStationLocations[enemyUnitSelected].transform.position;
                    }
                    NextTurn();

                }
            }
            if (curveball)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    fastball = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.Spell1MagicConsumed;
                    MCMagic.value = GameManager.MCMagic / GameManager.MCMaxMagic;
                    //    StarterAnim.Play("StarterWindup");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].TakeDamage(MC.Spell1Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                    fastball = false;
                    slider = false;
                    curveball = false;
                    changeup = false;
                    dialogueText.text = "The attack is successful!";
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();

                        //     totalExp += enemyUnit[enemyUnitSelected].ExperienceToDistribute;
                        enemyCount--;

                        enemySelectionParticle.transform.position = enemyBattleStationLocations[enemyUnitSelected].transform.position;
                    }
                    NextTurn();

                }
            }
            if (changeup)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    fastball = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.Spell1MagicConsumed;
                    MCMagic.value = GameManager.MCMagic / GameManager.MCMaxMagic;
                    //    StarterAnim.Play("StarterWindup");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].TakeDamage(MC.Spell1Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                    fastball = false;
                    slider = false;
                    curveball = false;
                    changeup = false;
                    dialogueText.text = "The attack is successful!";
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();

                        //     totalExp += enemyUnit[enemyUnitSelected].ExperienceToDistribute;
                        enemyCount--;

                        enemySelectionParticle.transform.position = enemyBattleStationLocations[enemyUnitSelected].transform.position;
                    }
                    NextTurn();
                }
            }
        }
    }
    IEnumerator RhysAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
            //Modify the Spell1Damage and Spell1Magic used based on the player, the spell, and their level 
            //Paste in MCAttack here once the modifications have been made. 
            Debug.Log("I'm here");
    }
    IEnumerator JameelAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        //Modify the Spell1Damage and Spell1Magic used based on the player, the spell, and their level 
        //Paste in MCAttack here once the modifications have been made. 
        Debug.Log("I'm here");
    }
    IEnumerator HarperAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        //Modify the Spell1Damage and Spell1Magic used based on the player, the spell, and their level 
        //Paste in MCAttack here once the modifications have been made. 
        Debug.Log("I'm here");
    }
    IEnumerator SkyeAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        //Modify the Spell1Damage and Spell1Magic used based on the player, the spell, and their level 
        //Paste in MCAttack here once the modifications have been made. 
        Debug.Log("I'm here");
    }
    IEnumerator SullivanAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        //Modify the Spell1Damage and Spell1Magic used based on the player, the spell, and their level 
        //Paste in MCAttack here once the modifications have been made. 
        Debug.Log("I'm here");
    }
        #endregion

    #region Enemy Attack
        IEnumerator EnemyTurn(int enemyIndex)
        {
            Camera.transform.position = enemyCam.transform.position;
            Camera.transform.LookAt(MC.transform.position);
        // GameManager.Instance.DebugBall.transform.position = enemyUnit[enemyIndex].transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
            if (enemyUnit[enemyIndex].currentHP <= 0)
            {
                // NextPlayerTurnAfterEnemyTurn(enemyIndex);
            }
            else
            {
                if (MCDead)
                {
                    EndBattle();
                }

                enemyUnit[enemyUnitSelected].DetermineAttack();

            //This is attacking all the players - a little buggy from Stike Out so commenting out for now. 
                #region Attack all or take Magic from All
                /* if (Unit.attackAll)
                 {
                     dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Everyone with " + enemyUnit[enemyUnitSelected].attackName + "!";

                     enemyAnim[enemyIndex].Play("Armature|Swing");

                     if (Announcer)
                     {
                         yield return new WaitForSeconds(3.5f);
                     }
                     else
                     {
                         yield return new WaitForSeconds(2f);
                     }

                     int RandomAttack = Random.Range(0, 100);

                     if (GameManager.MiddleAgil >= RandomAttack)
                     {
                         dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Mid Reliever with " + enemyUnit[enemyUnitSelected].attackName + "!";
                         yield return new WaitForSeconds(.5f);
                         dialogueText.text = "Mid Reliever Dodges!";
                         yield return new WaitForSeconds(1f);

                     }

                     bool isDead1 = Starter.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                     bool isDead2 = MiddleReliever.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                     bool isDead3 = SetUp.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                     bool isDead4 = Closer.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);

                     if (isDead1 && GameManager.StarterAgil < RandomAttack)
                     {
                         GameManager.StarterMorale -= enemyUnit[enemyUnitSelected].enemyDamage;
                         StarterMorale.value = (GameManager.StarterMorale / GameManager.StarterMoraleMax);
                         starterDead = true;
                         StarterDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                         //
                         playerTurnOrder.Remove(CharacterIdentifier.Starter);
                         //   Debug.Log("Removing Starter");

                         //
                         StarterAnim.SetBool("isDead", true);
                     }
                     if (isDead2 && GameManager.MiddleAgil < RandomAttack)
                     {
                         GameManager.MidRelivMorale -= enemyUnit[enemyUnitSelected].enemyDamage;
                         MiddleMorale.value = (GameManager.MidRelivMorale / GameManager.MidRelivMoraleMax);
                         middleDead = true;
                         MiddleDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();

                         playerTurnOrder.Remove(CharacterIdentifier.Middle);
                         //  Debug.Log("Removing Middle");


                         MidRelAnim.SetBool("isDead", true);

                     }
                     if (isDead3 && GameManager.SetUpAgil < RandomAttack)
                     {
                         GameManager.SetUpMorale -= enemyUnit[enemyUnitSelected].enemyDamage;
                         SetUpMorale.value = (GameManager.SetUpMorale / GameManager.SetUpMoraleMax);
                         setupDead = true;
                         SetUpDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();

                         playerTurnOrder.Remove(CharacterIdentifier.SetUp);
                         //   Debug.Log("Removing SetUp");


                         SetUpAnim.SetBool("isDead", true);
                     }
                     if (isDead4 && GameManager.CloserAgil < RandomAttack)
                     {
                         GameManager.CloserMorale -= enemyUnit[enemyUnitSelected].enemyDamage;
                         CloserMorale.value = (GameManager.CloserMorale / GameManager.CloserMoraleMax);
                         closerDead = true;
                         CloserDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();

                         playerTurnOrder.Remove(CharacterIdentifier.Closer);
                         //    Debug.Log("Removing Closer");


                         CloserAnim.SetBool("isDead", true);

                     }

                     if (!isDead1 && GameManager.StarterAgil < RandomAttack)
                     {
                         yield return new WaitForSeconds(.5f);
                         StarterAnim.Play("Armature|Oof");

                         GameManager.StarterMorale -= enemyUnit[enemyUnitSelected].enemyDamage;
                         StarterDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                         StarterMorale.value = (GameManager.StarterMorale / GameManager.StarterMoraleMax);
                     }

                     if (!isDead2 && GameManager.MiddleAgil < RandomAttack)
                     {
                         yield return new WaitForSeconds(.5f);
                         MidRelAnim.Play("Armature|Oof");

                         GameManager.MidRelivMorale -= enemyUnit[enemyUnitSelected].enemyDamage;
                         MiddleDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                         MiddleMorale.value = (GameManager.MidRelivMorale / GameManager.MidRelivMoraleMax);
                     }

                     if (!isDead3 && GameManager.SetUpAgil < RandomAttack)
                     {
                         yield return new WaitForSeconds(.5f);
                         SetUpAnim.Play("Armature|Oof");

                         GameManager.SetUpMorale -= enemyUnit[enemyUnitSelected].enemyDamage;
                         SetUpDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                         SetUpMorale.value = (GameManager.SetUpMorale / GameManager.SetUpMoraleMax);
                     }

                     if (!isDead4 && GameManager.CloserAgil < RandomAttack)
                     {
                         yield return new WaitForSeconds(.5f);
                         CloserAnim.Play("Armature|Oof");

                         GameManager.CloserMorale -= enemyUnit[enemyUnitSelected].enemyDamage;
                         CloserDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                         CloserMorale.value = (GameManager.CloserMorale / GameManager.CloserMoraleMax);
                     }
                     Unit.attackAll = false;
                     yield return new WaitForSeconds(2f);
                     StartCoroutine(TurnOffDamageUI());
                     // NextPlayerTurnAfterEnemyTurn(enemyIndex);
                 }

                 else if (Unit.energyAll)
                 {
                     dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " tires the Pitchers with " + enemyUnit[enemyUnitSelected].attackName + "!";

                     enemyAnim[enemyIndex].Play("Armature|Swing");

                     yield return new WaitForSeconds(1f);

                     bool isDead1 = Starter.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                     bool isDead2 = MiddleReliever.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                     bool isDead3 = SetUp.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                     bool isDead4 = Closer.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);

                     if (!isDead1)
                     {
                         yield return new WaitForSeconds(.5f);
                         StarterAnim.Play("Armature|Oof");

                         GameManager.StarterEnergy -= enemyUnit[enemyUnitSelected].enemyDamage;
                         StarterDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                         StarterEnergy.value = (GameManager.StarterEnergy / GameManager.StarterEnergyMax);
                     }

                     if (!isDead2)
                     {
                         yield return new WaitForSeconds(.5f);
                         MidRelAnim.Play("Armature|Oof");

                         GameManager.MidRelivEnergy -= enemyUnit[enemyUnitSelected].enemyDamage;
                         MiddleDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                         MiddleEnergy.value = (GameManager.MidRelivEnergy / GameManager.MidRelievEnergyMax);
                     }

                     if (!isDead3)
                     {
                         yield return new WaitForSeconds(.5f);
                         SetUpAnim.Play("Armature|Oof");

                         GameManager.SetUpEnergy -= enemyUnit[enemyUnitSelected].enemyDamage;
                         SetUpDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                         SetUpEnergy.value = (GameManager.SetUpEnergy / GameManager.SetUpEnergyMax);
                     }

                     if (!isDead4)
                     {
                         yield return new WaitForSeconds(.5f);
                         CloserAnim.Play("Armature|Oof");

                         GameManager.CloserEnergy -= enemyUnit[enemyUnitSelected].enemyDamage;
                         CloserDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                         CloserEnergy.value = (GameManager.CloserEnergy / GameManager.CloserEnergyMax);
                     }
                     Unit.energyAll = false;
                     yield return new WaitForSeconds(1f);
                     StartCoroutine(TurnOffDamageUI());
                     //NextPlayerTurnAfterEnemyTurn(enemyIndex);
                 }

                 */
                #endregion
               // else
               // {
                    int RandomAttack = Random.Range(0, 100);

                    //attack animation

                    //Choosing Who To Attack
                    //happens at least once, if it is true, it does it again. (keep going until valid)
                    int safteyCounter = 1000;
                    do
                    {
                        WhoToAttack = Random.Range(0, 4);
                        if (safteyCounter-- < 0)
                        {
                            //        Debug.LogError("Couldn't find a living WhoToAttack, is the Whole Team Dead?");
                            break;
                            //bails us out of the do while
                        }

                    } while (isPlayerIndexDead(WhoToAttack));

                    yield return new WaitForSeconds(1.5f);

                    //enemyAnim[enemyIndex].Play("Armature|Swing");
        
                    yield return new WaitForSeconds(.5f);


                    if (WhoToAttack == 0 && !MCDead)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(MC.transform.position);

                        Camera.transform.LookAt(MC.transform.position);

                        if (GameManager.MCAgility >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks [PLAYER NAME] with " + enemyUnit[enemyUnitSelected].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            dialogueText.text = "[PLAYER NAME] Dodges!";
                            yield return new WaitForSeconds(1f);

                        }

                        else
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks [PLAYER NAME] with " + enemyUnit[enemyUnitSelected].attackName + "!";

                            yield return new WaitForSeconds(2f);

                            bool isDead = MC.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);

                            print(isDead + " Main Character");

                            if (isDead)
                            {
                            GameManager.MCHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                            MCHealth.value = (GameManager.MCHealth / GameManager.MCMaxHealth);
                            MCDead = true;
                            //   MCAnim.SetBool("isDead", true);
                            Debug.Log("Game Over because Main Character died");
                            yield return new WaitForSeconds(3f);
                            }

                            else
                            {
                                yield return new WaitForSeconds(.5f);
                             //   MCAnim.Play("Armature|Oof");
                                MCDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                                GameManager.MCHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                MCHealth.value = (GameManager.MCHealth / GameManager.MCMaxHealth);
                                yield return new WaitForSeconds(2f);

                            }
                        }
                        StartCoroutine(TurnOffDamageUI());
                    }
                    else if (WhoToAttack == 1 && !RhysDead && GameManager.RhysInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Rhys.transform.position);
                       
                        Camera.transform.LookAt(Rhys.transform.position);

                        if (GameManager.RhysAgility >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Rhys with " + enemyUnit[enemyUnitSelected].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            dialogueText.text = "Rhys Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Rhys with " + enemyUnit[enemyUnitSelected].attackName + "!";

                            yield return new WaitForSeconds(1f);
                            bool isDead = Rhys.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                            print(isDead + " Middle");
                            if (isDead)
                            {
                                GameManager.RhysHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                RhysHealth.value = (GameManager.RhysHealth / GameManager.RhysMaxHealth);
                                RhysDead = true;

                                playerTurnOrder.Remove(CharacterIdentifier.Rhys);

                                //   Debug.Log("Removing Middle");
                                //   DebugPrintList(playerTurnOrder);

                            //    RhysAnim.SetBool("isDead", true);
                                yield return new WaitForSeconds(3f);

                            }

                            else
                            {
                                yield return new WaitForSeconds(.5f);
                                 //RhysAnim.Play("Armature|Oof");
                                RhysDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                                GameManager.RhysHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                            RhysHealth.value = (GameManager.RhysHealth / GameManager.RhysMaxHealth);
                                yield return new WaitForSeconds(2f);

                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                    }
                    else if (WhoToAttack == 2 && !JameelDead && GameManager.JameelInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Jameel.transform.position);

                        Camera.transform.LookAt(Jameel.transform.position);

                        if (GameManager.JameelAgility >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Jameel with " + enemyUnit[enemyUnitSelected].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            dialogueText.text = "Jameel Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                            {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Jameel with " + enemyUnit[enemyUnitSelected].attackName + "!";

                            yield return new WaitForSeconds(1f);
                            bool isDead = Jameel.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                            print(isDead + " Jameel");
                            if (isDead)
                            {
                                GameManager.JameelHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                JameelHealth.value = (GameManager.JameelHealth / GameManager.JameelMaxHealth);
                                JameelDead = true;

                                playerTurnOrder.Remove(CharacterIdentifier.Jameel);

                                //   Debug.Log("Removing Middle");
                                //   DebugPrintList(playerTurnOrder);

                                //    HarperAnim.SetBool("isDead", true);
                                yield return new WaitForSeconds(3f);

                            }

                            else
                            {
                                yield return new WaitForSeconds(.5f);
                                //HarperAnim.Play("Armature|Oof");
                                JameelDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                                GameManager.JameelHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                JameelHealth.value = (GameManager.JameelHealth / GameManager.JameelMaxHealth);
                                yield return new WaitForSeconds(2f);

                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                     }
                    else if (WhoToAttack == 3 && !HarperDead && GameManager.HarperInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Harper.transform.position);

                        Camera.transform.LookAt(Harper.transform.position);

                        if (GameManager.HarperAgility >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Harper with " + enemyUnit[enemyUnitSelected].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            dialogueText.text = "Harper Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Harper with " + enemyUnit[enemyUnitSelected].attackName + "!";

                            yield return new WaitForSeconds(1f);
                            bool isDead = Harper.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                            print(isDead + " Harper");
                            if (isDead)
                            {
                                GameManager.HarperHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                HarperHealth.value = (GameManager.HarperHealth / GameManager.HarperMaxHealth);
                                HarperDead = true;

                                playerTurnOrder.Remove(CharacterIdentifier.Harper);

                                //   Debug.Log("Removing Middle");
                                //   DebugPrintList(playerTurnOrder);

                                //    HarperAnim.SetBool("isDead", true);
                                yield return new WaitForSeconds(3f);

                            }

                            else
                            {
                                yield return new WaitForSeconds(.5f);
                                //HarperAnim.Play("Armature|Oof");
                                HarperDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                                GameManager.HarperHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                HarperHealth.value = (GameManager.HarperHealth / GameManager.HarperMaxHealth);
                                yield return new WaitForSeconds(2f);

                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                    }
                    else if (WhoToAttack == 4 && !SkyeDead && GameManager.SkyeInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Skye.transform.position);

                        Camera.transform.LookAt(Skye.transform.position);

                        if (GameManager.SkyeAgility >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Skye with " + enemyUnit[enemyUnitSelected].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            dialogueText.text = "Skye Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Skye with " + enemyUnit[enemyUnitSelected].attackName + "!";

                            yield return new WaitForSeconds(1f);
                            bool isDead = Skye.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                            print(isDead + " Middle");
                            if (isDead)
                            {
                                GameManager.SkyeHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                SkyeHealth.value = (GameManager.SkyeHealth / GameManager.SkyeMaxHealth);
                                SkyeDead = true;

                                playerTurnOrder.Remove(CharacterIdentifier.Skye);

                                //   Debug.Log("Removing Middle");
                                //   DebugPrintList(playerTurnOrder);

                                //    SkyeAnim.SetBool("isDead", true);
                                yield return new WaitForSeconds(3f);

                            }

                            else
                            {
                                yield return new WaitForSeconds(.5f);
                                //SkyeAnim.Play("Armature|Oof");
                                SkyeDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                                        GameManager.SkyeHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                SkyeHealth.value = (GameManager.SkyeHealth / GameManager.SkyeMaxHealth);
                                yield return new WaitForSeconds(2f);

                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                    }
                    else if (WhoToAttack == 5 && !SullivanDead && GameManager.SullivanInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Sullivan.transform.position);

                        Camera.transform.LookAt(Sullivan.transform.position);

                        if (GameManager.SullivanAgility >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Sullivan with " + enemyUnit[enemyUnitSelected].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            dialogueText.text = "Sullivan Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                        {
                            dialogueText.text = enemyUnit[enemyUnitSelected].unitName + " attacks Sullivan with " + enemyUnit[enemyUnitSelected].attackName + "!";

                            yield return new WaitForSeconds(1f);
                            bool isDead = Sullivan.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage);
                            print(isDead + " Middle");
                            if (isDead)
                            {
                                GameManager.SullivanHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                SullivanHealth.value = (GameManager.SullivanHealth / GameManager.SullivanMaxHealth);
                                SullivanDead = true;

                                playerTurnOrder.Remove(CharacterIdentifier.Sullivan);

                                //   Debug.Log("Removing Middle");
                                //   DebugPrintList(playerTurnOrder);

                                //    RhysAnim.SetBool("isDead", true);
                                yield return new WaitForSeconds(3f);

                            }

                            else
                            {
                                yield return new WaitForSeconds(.5f);
                                //SullivanAnim.Play("Armature|Oof");
                                SullivanDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                                GameManager.SullivanHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                                SullivanHealth.value = (GameManager.SullivanHealth / GameManager.SullivanMaxHealth);
                                yield return new WaitForSeconds(2f);

                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                    }

            // }
        }
            NextTurn();
        }

    bool isPlayerIndexDead(int playerID)
    {
        switch (playerID)
        {
            case 0:
                return MCDead;
            case 1:
                return RhysDead;
            case 2:
                return JameelDead;
            case 3:
                return HarperDead;
            case 4:
                return SkyeDead;
            case 5:
                return SullivanDead;
        }

        //  Debug.LogError("isPlayerIndexDead received an invalid index " + playerID);
        return false;
    }

    IEnumerator TurnOffDamageUI()
    {
            yield return new WaitForSeconds(1f);
            MCDamageUI.text = "".ToString();
        RhysDamageUI.text = "".ToString();
        JameelDamageUI.text = "".ToString();
        HarperDamageUI.text = "".ToString();
        SkyeDamageUI.text = "".ToString();
        SullivanDamageUI.text = "".ToString();
    }
        #endregion

    #region Player Turns (button select)
    void MCTurn()
    {
        // Camera.transform.position = starterCam.transform.position;
        Camera.transform.position = player1Cam.transform.position;
        Camera.transform.LookAt(enemyCamTarget);
        //  GameManager.Instance.DebugBall.transform.position = Starter.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (MCDead)
        {
            NextTurn();
        }
        if (!MCDead)
        {
            MCMenu.SetActive(true);
            dialogueText.text = "Starter: Choose an Action.";

            fastball = false;
            slider = false;
            changeup = false;
            curveball = false;
        }
    }

    void RhysTurn()
    {
    //    Camera.transform.position = .transform.position;
        Camera.transform.LookAt(enemyCamTarget);
        //    GameManager.Instance.DebugBall.transform.position = MiddleReliever.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (RhysDead || !GameManager.RhysInParty)
        {
            NextTurn();

        }
        if (!RhysDead)
        {
            RhysMenu.SetActive(true);
            dialogueText.text = "Rhys: Choose an Action.";

            fastball = false;
            slider = false;
            changeup = false;
            curveball = false;
        }
    }

    void JameelTurn()
    {
        //    Camera.transform.position = .transform.position;
        Camera.transform.LookAt(enemyCamTarget);
        //    GameManager.Instance.DebugBall.transform.position = MiddleReliever.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (RhysDead || !GameManager.RhysInParty)
        {
            NextTurn();

        }
        if (!RhysDead)
        {
            JameelMenu.SetActive(true);
            dialogueText.text = "Rhys: Choose an Action.";

            fastball = false;
            slider = false;
            changeup = false;
            curveball = false;
        }
    }

    void HarperTurn()
    {
        //    Camera.transform.position = .transform.position;
        Camera.transform.LookAt(enemyCamTarget);
        //    GameManager.Instance.DebugBall.transform.position = MiddleReliever.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (HarperDead || !GameManager.HarperInParty)
        {
            NextTurn();

        }
        if (!HarperDead)
        {
            HarperMenu.SetActive(true);
            dialogueText.text = "Harper: Choose an Action.";

            fastball = false;
            slider = false;
            changeup = false;
            curveball = false;
        }
    }

    void SkyeTurn()
    {
        //    Camera.transform.position = .transform.position;
        Camera.transform.LookAt(enemyCamTarget);
        //    GameManager.Instance.DebugBall.transform.position = MiddleReliever.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (SkyeDead || !GameManager.SkyeInParty)
        {
            NextTurn();

        }
        if (!SkyeDead)
        {
            SkyeMenu.SetActive(true);
            dialogueText.text = "Skye: Choose an Action.";

            fastball = false;
            slider = false;
            changeup = false;
            curveball = false;
        }
    }

    void SullivanTurn()
    {
        //    Camera.transform.position = .transform.position;
        Camera.transform.LookAt(enemyCamTarget);
        //    GameManager.Instance.DebugBall.transform.position = MiddleReliever.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (SullivanDead || !GameManager.SullivanInParty)
        {
            NextTurn();

        }
        if (!SullivanDead)
        {
            SullivanMenu.SetActive(true);
            dialogueText.text = "Sullivan: Choose an Action.";

            fastball = false;
            slider = false;
            changeup = false;
            curveball = false;
        }
    }
    #endregion

    public void OnPlayerTurnButton()
    {
        // if (state != BattleStateMultiple.PLAYERTURN)
        //     return;
        if (state == BattleState.MCTURN)
        {
            MCSpells.SetActive(true);
            MCMenu.SetActive(false);
        }

        if (state == BattleState.RHYSTURN)
        {
            RhysSpells.SetActive(true);
            RhysMenu.SetActive(false);
        }

        if (state == BattleState.JAMEELTURN)
        {
            JameelSpells.SetActive(true);
            JameelMenu.SetActive(false);
        }

        if (state == BattleState.HARPERTURN)
        {
            HarperSpells.SetActive(true);
            HarperMenu.SetActive(false);
        }

        if (state == BattleState.SKYETURN)
        {
            SkyeSpells.SetActive(true);
            SkyeMenu.SetActive(false);
        }

        if (state == BattleState.SULLIVANTURN)
        {
            SullivanSpells.SetActive(true);
            SullivanMenu.SetActive(false);
        }
    }

    #region Player Pitch Selection (opens up confirm menu)
    
    //Clean this up when you know what spells and who is casting what
    public void OnSpell1Button()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.Spell1MagicConsumed <= GameManager.MCMagic)
            {
                fastball = true;

                MCMenu.SetActive(true);
                MCSpells.SetActive(false);
                enemySelect = true;
                MCConfirmMenu.SetActive(true);
                MCSpells.SetActive(false);
                MCMenu.SetActive(false);
            }
            else
                dialogueText.text = "Not enough energy!";
        }

        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.Spell1MagicConsumed <= GameManager.RhysMagic)
            {
                fastball = true;

                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
                enemySelect = true;
                RhysConfirmMenu.SetActive(true);
                RhysSpells.SetActive(false);
                RhysMenu.SetActive(false);
            }
            else
                dialogueText.text = "Not enough energy!";
        }

        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.Spell1MagicConsumed <= GameManager.JameelMagic)
            {
                fastball = true;

                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
                enemySelect = true;
                JameelConfirmMenu.SetActive(true);
                JameelSpells.SetActive(false);
                JameelMenu.SetActive(false);
            }
            else
                dialogueText.text = "Not enough energy!";
        }

        if (state == BattleState.HARPERTURN)
        {
            if (Harper.Spell1MagicConsumed <= GameManager.HarperMagic)
            {
                fastball = true;

                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
                enemySelect = true;
                HarperConfirmMenu.SetActive(true);
                HarperSpells.SetActive(false);
                HarperMenu.SetActive(false);
            }
            else
                dialogueText.text = "Not enough energy!";
        }

        if (state == BattleState.SKYETURN)
        {
            if (Skye.Spell1MagicConsumed <= GameManager.SkyeMagic)
            {
                fastball = true;

                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
                enemySelect = true;
                SkyeConfirmMenu.SetActive(true);
                SkyeSpells.SetActive(false);
                SkyeMenu.SetActive(false);
            }
            else
                dialogueText.text = "Not enough energy!";
        }
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.Spell1MagicConsumed <= GameManager.SullivanMagic)
            {
                fastball = true;

                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
                enemySelect = true;
                SullivanConfirmMenu.SetActive(true);
                SullivanSpells.SetActive(false);
                SullivanMenu.SetActive(false);
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }

    public void OnSliderButton()
    {
       //Figure These out once you know spells

    }

    public void OnCurveballButton()
    {
        
    }

    public void OnChangeUpButton()
    {
        

    }

    public void OnCancelButton()
    {
        MCMenu.SetActive(true);
        MCSpells.SetActive(false);
    }
    #endregion

    #region End of Battle States
    void EndBattle()
    {
        Camera.transform.position = battleCam.transform.position;
        Camera.transform.LookAt(enemyCamTarget);
        if (state == BattleState.WON)
        {
            /* if (If this is a boss fight, put them here)
              {
                  mark the bool here
                  HOEGameManager.UmpireDefeated = true;
              }
            */


        //Animations at the end of the fight
        /*
            if (!MCDead)
            {
                MCAnim.Play("Armature|Victory");
            }
            if (!RhysDead && GameManager.RhysInParty)
            {
                RhysAnim.Play("Armature|Victory");
            }
            if (!RhysDead && GameManager.RhysInParty)
            {
                RhysAnim.Play("Armature|Victory");
            }
            if (!RhysDead && GameManager.RhysInParty)
            {
                RhysAnim.Play("Armature|Victory");
            }
            if (!RhysDead && GameManager.RhysInParty)
            {
                RhysAnim.Play("Armature|Victory");
            }
            if (!RhysDead && GameManager.RhysInParty)
            {
                RhysAnim.Play("Armature|Victory");
            }
        */
            dialogueText.text = "You won the Battle!";
            EndingMenu.SetActive(true);
            MCSpells.SetActive(false);
            MCMenu.SetActive(false);

            if (!isOver && !preventingAddXPDup)
            {
                AddXP();
                isOver = true;
            }

            isOver = true;

        }
        else if (state == BattleState.LOST)
        {
            if (!gameOverToPreventDuplicates)
            {
                dialogueText.text = "You lost the battle...";
                GameManager.isGameOver = true;
                StartCoroutine(LosingScreenWaiting());
                MCDead = false;
                RhysDead = false;
                JameelDead = false;
                HarperDead = false;
                SkyeDead = false;
                SullivanDead = false;
            }
        }
        gameOverToPreventDuplicates = true;
    }
    #endregion

    public void AddXP()
    {
        preventingAddXPDup = true;

        for (int i = 0; i < enemyUnit.Count; i++)
        {
            GameManager.Money += enemyUnit[i].MoneyToDistribute;
            MoneyText.text = GameManager.Money.ToString();
        }
        /*
        if (!MCDead)
        {
            MCExp.text = "   +" + (totalExp / 4).ToString("F0");
            GameManager.StarterExp = totalExp / 4 + GameManager.StarterExp;

            StarterExp(totalExp / 4);
        }
        if (!middleDead)
        {
            MRExpGain.text = "   +" + (totalExp / 4).ToString("F0");
            GameManager.MRExp = totalExp / 4 + GameManager.MRExp;

            MidExp(totalExp / 4);
        }
        if (!setupDead)
        {
            SetUpExpGain.text = "   +" + (totalExp / 4).ToString("F0");
            GameManager.SetUpExp = totalExp / 4 + GameManager.SetUpExp;

            SetUpExp(totalExp / 4);
        }
        if (!closerDead)
        {
            CloserExpGain.text = "   +" + (totalExp / 4).ToString("F0");
            GameManager.CloserExp = totalExp / 4 + GameManager.CloserExp;

            CloserExp(totalExp / 4);
        }
        if (starterDead)
        {
            StarterExpGain.text = "0";
            StarterExpToNext.text = GameManager.StarterTargetExp.ToString("F0");
            StartTotalExp.text = GameManager.StarterLevel.ToString("F0");
        }
        if (middleDead)
        {
            MRExpGain.text = "0";
            MRExpToNext.text = GameManager.MRTargetExp.ToString("F0");
            MRTotalExp.text = GameManager.MRLevel.ToString("F0");
        }
        if (setupDead)
        {
            SetUpExpGain.text = "0";
            SetUpExpToNext.text = GameManager.SetupTargetExp.ToString("F0");
            SetUpTotalExp.text = GameManager.SetUpLevel.ToString("F0");
        }
        if (closerDead)
        {
            CloserExpGain.text = "0";
            CloserExpToNext.text = GameManager.CloserTargetExp.ToString("F0");
            CloserTotalExp.text = GameManager.CloserLevel.ToString("F0");
        }
        */
        ChooseItem();

    }

    void ChooseItem()
    {
        int RandInt = Random.Range(0, 100);
        /*
        if (RandInt < 30)
        {
            InventoryItemPostBattle.text = "No Item Reward".ToString();
        }
        else if (RandInt < 50)
        {
            InventoryManage.GetComponent<InventoryManager>().StamUp20();
            InventoryItemPostBattle.text = "Sports Drink".ToString();
        }
        else if (RandInt < 65)
        {
            InventoryManage.GetComponent<InventoryManager>().EnUp10();
            InventoryItemPostBattle.text = "Granola Bar".ToString();
        }
        else if (RandInt < 75)
        {
            InventoryManage.GetComponent<InventoryManager>().EnUpAll10();
            InventoryItemPostBattle.text = "Sunflower Seeds".ToString();
        }
        else if (RandInt < 83)
        {
            InventoryManage.GetComponent<InventoryManager>().StamUpAll20();
            InventoryItemPostBattle.text = "Grandma's Cookies".ToString();
        }
        else if (RandInt < 90)
        {
            InventoryManage.GetComponent<InventoryManager>().EnemyHealthDown20();
            InventoryItemPostBattle.text = "Scouting Report".ToString();
        }
        else if (RandInt < 100)
        {
            InventoryManage.GetComponent<InventoryManager>().EnemyHealthDownAll20();
            InventoryItemPostBattle.text = "Defensive Shift".ToString();
        }
        */
    }

    void StarterExp(int xp)
    {
      /*  if (!starterDead)
        {
            xp = (totalExp / 4);
            int OldLevelS = GameManager.StarterLevel;

            while (GameManager.StarterExp >= GameManager.StarterTargetExp)
            {
                GameManager.StarterExp = GameManager.StarterExp - GameManager.StarterTargetExp;
                GameManager.StarterLevel++;

                GameManager.StarterEnergyMax += 5;
                GameManager.StarterMoraleMax += 5;
                GameManager.StarterEnergy += 5;
                GameManager.StarterMorale += 5;

                SLevel = true;
                SLevelUp.SetActive(true);
                GameManager.StarterTargetExp *= 1.25f;
                //add training points
                StarterExpToNext.text = (GameManager.StarterTargetExp - GameManager.StarterExp).ToString("F0");
                int NewLevelS = GameManager.StarterLevel;
                int Difference = NewLevelS - OldLevelS;
                SPointsToGive = (Difference * 3);

                GameManager.StarterMorale = GameManager.StarterMoraleMax;
                GameManager.StarterEnergy = GameManager.StarterEnergyMax;
            }
            StarterExpToNext.text = (GameManager.StarterTargetExp - GameManager.StarterExp).ToString("F0");
            StartTotalExp.text = GameManager.StarterLevel.ToString("F0");
        }
        else
        {
            MidExp(totalExp / 4);
        }*/
    }

    void MidExp(int xp)
    {
     /*   if (!middleDead)
        {
            xp = (totalExp / 4);
            int OldLevelM = GameManager.MRLevel;

            while (GameManager.MRExp >= GameManager.MRTargetExp)
            {
                GameManager.MRExp = GameManager.MRExp - GameManager.MRTargetExp;
                GameManager.MRLevel++;

                GameManager.MidRelievEnergyMax += 5;
                GameManager.MidRelivMoraleMax += 5;
                GameManager.MidRelivEnergy += 5;
                GameManager.MidRelivMorale += 5;

                MLevel = true;
                MLevelUp.SetActive(true);
                GameManager.MRTargetExp *= 1.5f;
                //add training points
                MRExpToNext.text = (GameManager.MRTargetExp - GameManager.MRExp).ToString("F0");
                int NewLevelM = GameManager.MRLevel;
                int Difference = NewLevelM - OldLevelM;
                MPointsToGive = (Difference * 3) + 1;
            }
            MRExpToNext.text = (GameManager.MRTargetExp - GameManager.MRExp).ToString("F0");
            MRTotalExp.text = GameManager.MRLevel.ToString("F0");
        }
        else
        {
            SetUpExp(totalExp / 4);
        }*/
    }

    void SetUpExp(int xp)
    {
      /*  if (!setupDead)
        {
            xp = (totalExp / 4);
            int OldLevelSe = GameManager.SetUpLevel;

            while (GameManager.SetUpExp >= GameManager.SetupTargetExp)
            {
                GameManager.SetUpExp = GameManager.SetUpExp - GameManager.SetupTargetExp;
                GameManager.SetUpLevel++;

                GameManager.SetUpEnergyMax += 5;
                GameManager.SetUpMoraleMax += 5;
                GameManager.SetUpMorale += 5;
                GameManager.SetUpEnergy += 5;

                SeLevel = true;
                SetUpLevelUp.SetActive(true);
                GameManager.SetupTargetExp *= 1.75f;
                //add training points
                SetUpExpToNext.text = (GameManager.SetupTargetExp - GameManager.SetUpExp).ToString("F0");
                int NewLevelSe = GameManager.SetUpLevel;
                int Difference = NewLevelSe - OldLevelSe;
                SePointsToGive = (Difference * 3) + 1;
            }
            SetUpExpToNext.text = (GameManager.SetupTargetExp - GameManager.SetUpExp).ToString("F0");
            SetUpTotalExp.text = GameManager.SetUpLevel.ToString("F0");
        }
        else
        {
            CloserExp(totalExp / 4);
        }*/
    }

    void CloserExp(int xp)
    {
       /* if (!closerDead)
        {
            xp = (totalExp / 4);
            int OldLevelC = GameManager.CloserLevel;

            while (GameManager.CloserExp >= GameManager.CloserTargetExp)
            {
                GameManager.CloserExp = GameManager.CloserExp - GameManager.CloserTargetExp;
                GameManager.CloserLevel++;

                GameManager.CloserEnergyMax += 5;
                GameManager.CloserMoraleMax += 5;
                GameManager.CloserMorale += 5;
                GameManager.CloserEnergy += 5;

                CLevel = true;
                CloserLevelUp.SetActive(true);
                GameManager.CloserTargetExp *= 2f;
                //add training points
                CloserExpToNext.text = (GameManager.CloserTargetExp - GameManager.CloserExp).ToString("F0");
                int NewLevelC = GameManager.CloserLevel;
                int Difference = NewLevelC - OldLevelC;
                CPointsToGive = (Difference * 3) + 1;
            }
            CloserExpToNext.text = (GameManager.CloserTargetExp - GameManager.CloserExp).ToString("F0");
            CloserTotalExp.text = GameManager.CloserLevel.ToString("F0");
        }
        else
        {
            StartCoroutine(WaitingAtEndOfBattle());
        }*/
    }

    void CheatToInstantlyWin()
    {

        for (int i = 0; i < enemyUnit.Count; i++)
        {
            enemyUnit[i].TakeDamage(10000);
            //    Debug.Log("Cheat Activated");
        }
        state = BattleState.WON;
        EndBattle();
        //  Debug.Log("Attempted To Cheat To Win");
    }


    public void BattleFinished()
    {
        if (isOver)
        {
            /*
            print(SPointsToGive + "   " + MPointsToGive + "   " + SePointsToGive + "   " + CPointsToGive);

            Macro.SetActive(true);

            PlayerStatsScreen.SetActive(true);
            SFSlider.value = GameManager.StarterFast;
            SSSlider.value = GameManager.StarterSlid;
            SCSlider.value = GameManager.StarterCurve;
            SChSlider.value = GameManager.StarterChange;
            SASlider.value = GameManager.StarterAgil;

            MFSlider.value = GameManager.MiddleFast;
            MSSlider.value = GameManager.MiddleSlid;
            MCSlider.value = GameManager.MiddleCurve;
            MChSlider.value = GameManager.MiddleChange;
            MASlider.value = GameManager.MiddleAgil;

            SeFSlider.value = GameManager.SetUpFast;
            SeSSlider.value = GameManager.SetUpSlid;
            SeCSlider.value = GameManager.SetUpCurve;
            SeChSlider.value = GameManager.SetUpChange;
            SeASlider.value = GameManager.SetUpAgil;

            CFSlider.value = GameManager.CloserFast;
            CSSlider.value = GameManager.CloserSlid;
            CCSlider.value = GameManager.CloserCurve;
            CChSlider.value = GameManager.CloserChange;
            CASlider.value = GameManager.CloserAgil;

            SPoints.text = SPointsToGive.ToString();

            if (SLevel)
            {
                PlayerStatsScreen.SetActive(true);
                SLevelUpScreen.SetActive(true);
                starterLevel = true;
                // StarterLevelUp();

                FastballButton.SetActive(true);
                SliderButton.SetActive(true);
                CurveballButton.SetActive(true);
                ChangeUpButton.SetActive(true);
                AgilityButton.SetActive(true);
            }
            if (!SLevel && MLevel)
            {
                middleLevel = true;
                MLevelUpScreen.SetActive(true);
                // MidRelieverLevelUp();

                FastballButton.SetActive(true);
                SliderButton.SetActive(true);
                CurveballButton.SetActive(true);
                ChangeUpButton.SetActive(true);
                AgilityButton.SetActive(true);
            }
            if (!SLevel && !MLevel && SeLevel)
            {
                setUpLevel = true;
                SeLevelUpScreen.SetActive(true);
                // SetLevelUp();

                FastballButton.SetActive(true);
                SliderButton.SetActive(true);
                CurveballButton.SetActive(true);
                ChangeUpButton.SetActive(true);
                AgilityButton.SetActive(true);
            }
            if (!SLevel && !MLevel && !SeLevel && CLevel)
            {
                closerLevel = true;
                CLevelUpScreen.SetActive(true);
                //  CloseLevelUp();

                FastballButton.SetActive(true);
                SliderButton.SetActive(true);
                CurveballButton.SetActive(true);
                ChangeUpButton.SetActive(true);
                AgilityButton.SetActive(true);
            }
            EndingMenu.SetActive(false);
            if (!SLevel && !MLevel && !SeLevel && !CLevel)
            {
                StartCoroutine(WaitingAtEndOfBattle());
            }
            */
        }
    }
    /*
    void StarterLevelUp()
    {
        GameManager.StarterMorale = GameManager.StarterMoraleMax;
        GameManager.StarterEnergy = GameManager.StarterEnergyMax;

        if (MLevel)
        {
            starterLevel = false;
            middleLevel = true;
            MLevelUpScreen.SetActive(true);
            SLevelUpScreen.SetActive(false);
        }
        if (!MLevel && SeLevel)
        {
            starterLevel = false;
            setUpLevel = true;
            SeLevelUpScreen.SetActive(true);
            MLevelUpScreen.SetActive(false);
        }
        if (!SeLevel && CLevel)
        {
            starterLevel = false;
            closerLevel = true;
            CLevelUpScreen.SetActive(true);
            SeLevelUpScreen.SetActive(false);
        }
        if (!MLevel && !SeLevel && !CLevel)
        {
            starterLevel = false;
            StartCoroutine(WaitingAtEndOfBattle());
        }
    }

    void MidRelieverLevelUp()
    {
        GameManager.MidRelivMorale = GameManager.MidRelivMoraleMax;
        GameManager.MidRelivEnergy = GameManager.MidRelievEnergyMax;
        MPoints.text = MPointsToGive.ToString();

        if (MLevel)
        {
            middleLevel = true;
            SLevelUpScreen.SetActive(false);
            MLevelUpScreen.SetActive(true);
        }
        if (!MLevel && SeLevel)
        {
            middleLevel = false;
            setUpLevel = true;
            SeLevelUpScreen.SetActive(true);
            MLevelUpScreen.SetActive(false);
            SLevelUpScreen.SetActive(false);
        }
        if (!MLevel && !SeLevel && CLevel)
        {
            middleLevel = false;
            closerLevel = true;
            SLevelUpScreen.SetActive(false);
            MLevelUpScreen.SetActive(false);
            CLevelUpScreen.SetActive(true);
        }
        if (!SeLevel && !CLevel)
        {
            middleLevel = false;
            StartCoroutine(WaitingAtEndOfBattle());
        }
    }

    void SetLevelUp()
    {
        GameManager.SetUpMorale = GameManager.SetUpMoraleMax;
        GameManager.SetUpEnergy = GameManager.SetUpEnergyMax;
        SePoints.text = SePointsToGive.ToString();

        if (SeLevel)
        {
            setUpLevel = true;
            SLevelUpScreen.SetActive(false);
            MLevelUpScreen.SetActive(false);
            SeLevelUpScreen.SetActive(true);
        }
        if (!SeLevel && CLevel)
        {
            setUpLevel = false;
            closerLevel = true;
            CLevelUpScreen.SetActive(true);
            SeLevelUpScreen.SetActive(false);
            MLevelUpScreen.SetActive(false);
            SLevelUpScreen.SetActive(false);
            CloseLevelUp();
        }

        if (!SeLevel && !CLevel)
        {
            StartCoroutine(WaitingAtEndOfBattle());
        }
    }

    void CloseLevelUp()
    {
        GameManager.CloserMorale = GameManager.CloserMoraleMax;
        GameManager.CloserEnergy = GameManager.CloserEnergyMax;
        CPoints.text = CPointsToGive.ToString();

        CLevelUpScreen.SetActive(true);
        SLevelUpScreen.SetActive(false);
        MLevelUpScreen.SetActive(false);
        SeLevelUpScreen.SetActive(false);

        if (CLevel)
        {
            setUpLevel = false;
            closerLevel = true;
        }
        if (!CLevel)
        {
            closerLevel = false;
            StartCoroutine(WaitingAtEndOfBattle());
        }
    }
    */


    IEnumerator WaitingAtEndOfBattle()
    {
        GameManager.enemyAttackedPlayer = false;

        yield return new WaitForSeconds(1.5f);
        state = BattleState.START;
        //Return to Main Menu

        if (state == BattleState.MCTURN || state == BattleState.RHYSTURN || state == BattleState.JAMEELTURN || state == BattleState.HARPERTURN || state == BattleState.SKYETURN || state == BattleState.SULLIVANTURN)
        {
            SceneManager.LoadScene(DungeonRoomToLoad);
        }
    }

    IEnumerator WaitingForCall()
    {
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Please choose an action.";
    }


    #region Losing Screen Menus

    IEnumerator LosingScreenWaiting()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(LosingScreenToLoad);
    }
    #endregion
}
