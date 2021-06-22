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
    #region MCAttacks
    bool throwRock;
    bool flippendo;
    bool pulsateSunt;
    bool stupefaciunt;
    bool incendio;
    bool incendioMaxima;
    bool avis;
    bool avisMaxima;
    bool glacies;
    bool minorCura;
    bool impetumSubsisto;
    bool augamenti;
    bool mothsDeorsum;
    bool mothsInteriore;
    bool internaCombustione;
    bool bombarda;
    bool bombardaMaxima;
    bool bombardaUltima;
    bool minusSanaCoetus;
    bool chorusPedes;
    bool criticaFocus;
    bool diffindo;
    bool diffindoMaxima;
    #endregion

    #region RhysAttacks
    bool rhysThrowRock;
    bool rhysFlippendo;
    bool rhysCorpusLiget;
    bool rhysMothsDeorsum;
    bool rhysMothInteriore;
    bool rhysInternumCombustione;
    bool rhysTenuiLabor;
    bool rhysIncendio;
    bool rhysFumos;
    bool rhysWaddiwasi;
    bool rhysConjurePugione;
    bool rhysImpetumSubsisto;
    bool rhysUolueris;

    #endregion

    #region JameelAttacks
    bool jameelThrowRock;
    bool jameelFlippendo;
    bool jameelMinusSanaCoetus;
    bool jameelMinorCura;
    bool jameelMaiorCura;
    bool jameelPartumNix;
    bool jameelHiemsImpetus;
    bool jameelBombarda;
    bool jameelBombardaMaxima;
    bool jameelBombardaUltima;
    bool jameelRepellere;
    bool jameelDiffindo;
    bool jameelDiffindoMaxima;
    bool jameelImpetumSubsisto;
    bool jameelChorusPedes;
    #endregion

    #region HarperAttacks
    bool harperThrowRock;
    bool harperFlippendo;
    bool harperDeflectorImpetum;
    bool harperMinorFortitudinem;
    bool harperMoserateFortitudinem;
    bool harperMaiorFortitudinem;
    bool harperInternumCombustione;
    bool harperLaedo;
    bool harperLociPraesidium;
    bool harperPerturbo;
    bool harperPulsateSunt;
    bool harperFumes;
    bool harperDiminuendo;

    #endregion

    #region SkyeAttacks
    bool skyeThrowRock;
    bool skyeFlippendo;
    bool skyeMinorCura;
    bool skyeMaiorCura;
    bool skyeSenaPlenaPotion;
    bool skyeReanimatePotion;
    bool skyeSanaCoetusPotion;
    bool skyeAntidoteToCommonPoisons;
    bool skyeStrengthPotion;
    bool skyeConfundus;
    bool skyeIraUolueris;

    #endregion

    #region SullivanAttacks
    bool sullivanRockThrow;
    bool sullivanFlippendo;
    bool sullivanExiling;
    bool sullivanProtego;
    bool sullivanIgnusMagnum;
    bool sullivanSagittaIecit;
    bool sullivanMonstrumSella;
    bool sullivanIncarcerous;
    bool sullivanUltimumChao;
    bool sullivanMutareStatum;
    bool sullivanEngorgement;
    bool sullivanStatuamLocomotion;
    bool sullivanCriticaFocus;
    #endregion

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
        if (GameObject.Find("GameManager") == null)
        {
            Debug.LogWarning("The GameManager needs to be in this scene for everything to work");
        }
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

        MCHealth.maxValue = GameManager.MCMaxHealth;
        RhysHealth.maxValue = GameManager.RhysMaxHealth;
        JameelHealth.maxValue = GameManager.JameelMaxHealth;
        HarperHealth.maxValue = GameManager.HarperMaxHealth;
        SkyeHealth.maxValue = GameManager.SkyeMaxHealth;
        SullivanHealth.maxValue = GameManager.SullivanMaxHealth;

        MCMagic.maxValue = GameManager.MCMaxMagic;
        RhysMagic.maxValue = GameManager.RhysMaxMagic;
        JameelMagic.maxValue = GameManager.JameelMaxMagic;
        HarperMagic.maxValue = GameManager.HarperMaxMagic;
        SkyeMagic.maxValue =  GameManager.SkyeMaxMagic;
        SullivanMagic.maxValue =  GameManager.SullivanMaxMagic;

        MCHealth.value = GameManager.MCHealth ;
        RhysHealth.value = GameManager.RhysHealth ;
        JameelHealth.value = GameManager.JameelHealth ;
        HarperHealth.value = GameManager.HarperHealth ;
        SkyeHealth.value = GameManager.SkyeHealth ;
        SullivanHealth.value = GameManager.SullivanHealth;

        MCMagic.value = GameManager.MCMagic ;
        RhysMagic.value = GameManager.RhysMagic ;
        JameelMagic.value = GameManager.JameelMagic ;
        HarperMagic.value = GameManager.HarperMagic;
        SkyeMagic.value = GameManager.SkyeMagic ;
        SullivanMagic.value = GameManager.SullivanMagic;

    //    ItemMenu = GameObject.Find("Inventory");
        GameManagerObject = GameObject.Find("GameManager");

        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        #region This places all the UI and assigns the player and enemy values from the Unit Script
        playerGO1 = Instantiate(MCPrefab, MCBattleStation);
        MC = playerGO1.GetComponent<Unit>();
        MCAnim = playerGO1.GetComponentInChildren<Animator>();
        //I don't think this is structured correctly. Come back to this later.
        #region Determining Second Player Battle Station
        if (GameManager.RhysInParty)
        {
            playerGO2 = Instantiate(RhysPrefab, SecondBattleStation);
            Rhys = playerGO2.GetComponent<Unit>();
            RhysAnim = playerGO2.GetComponentInChildren<Animator>();
        }
        if (!GameManager.RhysInParty && GameManager.JameelInParty)
        {
            playerGO2 = Instantiate(JameelPrefab, SecondBattleStation);
            Jameel = playerGO2.GetComponent<Unit>();
            JameelAnim = playerGO2.GetComponentInChildren<Animator>();
        }
        if (!GameManager.RhysInParty && !GameManager.JameelInParty && GameManager.HarperInParty)
        {
            playerGO2 = Instantiate(HarperPrefab, SecondBattleStation);
            Harper = playerGO2.GetComponent<Unit>();
            HarperAnim = playerGO2.GetComponentInChildren<Animator>();
        }
        if (GameManager.PartyCount == 2 && GameManager.SkyeInParty)
        {
            playerGO2 = Instantiate(SkyePrefab, SecondBattleStation);
            Skye = playerGO2.GetComponent<Unit>();
            SkyeAnim = playerGO2.GetComponentInChildren<Animator>();
        }
        if (GameManager.PartyCount == 2 && GameManager.SullivanInParty)
        {
            playerGO2 = Instantiate(SullivanPrefab, SecondBattleStation);
            Sullivan = playerGO2.GetComponent<Unit>();
            SullivanAnim = playerGO2.GetComponentInChildren<Animator>();
        }
        #endregion
        # region Determining Third Player Battle Station
        if (GameManager.RhysInParty && GameManager.JameelInParty)
        {
            playerGO3 = Instantiate(JameelPrefab, ThirdBattleStation);
            Jameel = playerGO3.GetComponent<Unit>();
            JameelAnim = playerGO3.GetComponentInChildren<Animator>();
        }
        if (GameManager.PartyCount == 3 && (GameManager.RhysInParty || GameManager.JameelInParty) && GameManager.HarperInParty)
        {
            playerGO3 = Instantiate(HarperPrefab, ThirdBattleStation);
            Harper = playerGO3.GetComponent<Unit>();
            HarperAnim = playerGO3.GetComponentInChildren<Animator>();
        }
        if (GameManager.SkyeInParty && !GameManager.SullivanInParty)
        {
            playerGO3 = Instantiate(SkyePrefab, ThirdBattleStation);
            Skye = playerGO3.GetComponent<Unit>();
            SkyeAnim = playerGO3.GetComponentInChildren<Animator>();
        }
        if (GameManager.PartyCount == 3 && GameManager.SullivanInParty)
        {
            playerGO3 = Instantiate(SullivanPrefab, ThirdBattleStation);
            Sullivan = playerGO3.GetComponent<Unit>();
            SullivanAnim = playerGO3.GetComponentInChildren<Animator>();
        }
        #endregion
        #region Determining Fourth Player Battle Station
        if (GameManager.RhysInParty && GameManager.JameelInParty && GameManager.HarperInParty)
        {
            playerGO4 = Instantiate(HarperPrefab, FourthBattleStation);
            Harper = playerGO4.GetComponent<Unit>();
            HarperAnim = playerGO4.GetComponentInChildren<Animator>();
        }
        if (GameManager.PartyCount == 4 && GameManager.SkyeInParty && GameManager.SullivanInParty)
        {
            playerGO3 = Instantiate(SkyePrefab, ThirdBattleStation);
            Skye = playerGO3.GetComponent<Unit>();
            SkyeAnim = playerGO3.GetComponentInChildren<Animator>();
        }
        if (GameManager.PartyCount == 4 && GameManager.SkyeInParty && !GameManager.SullivanInParty)
        {
            playerGO4 = Instantiate(SkyePrefab, FourthBattleStation);
            Skye = playerGO4.GetComponent<Unit>();
            SkyeAnim = playerGO4.GetComponentInChildren<Animator>();
        }
        if (GameManager.PartyCount == 4 && GameManager.SullivanInParty)
        {
            playerGO4 = Instantiate(SullivanPrefab, FourthBattleStation);
            Sullivan = playerGO4.GetComponent<Unit>();
            SullivanAnim = playerGO4.GetComponentInChildren<Animator>();
        }
        #endregion Enemies

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

        if (MCDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }

        //Adding back into party after knockout
        if (GameManager.RhysHealth >= 0 && RhysDead)
        {
            RhysAnim.SetBool("isDead", false);
            RhysDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Rhys);
        }
        if (GameManager.JameelHealth >= 0 && JameelDead)
        {
            JameelAnim.SetBool("isDead", false);
            JameelDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Jameel);
        }
        if (GameManager.HarperHealth >= 0 && HarperDead)
        {
           HarperAnim.SetBool("isDead", false);
            HarperDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Harper);
        }
        if (GameManager.SkyeHealth >= 0 && SkyeDead)
        {
            SkyeAnim.SetBool("isDead", false);
            SkyeDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Skye);
        }
        if (GameManager.SullivanHealth >= 0 && SullivanDead)
        {
            SullivanAnim.SetBool("isDead", false);
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
                MCTurn();
                state = BattleState.MCTURN;
                break;
            case CharacterIdentifier.Rhys:
                RhysTurn();
                state = BattleState.RHYSTURN;
                break;
            case CharacterIdentifier.Jameel:
                JameelTurn();
                state = BattleState.JAMEELTURN;
                break;
            case CharacterIdentifier.Harper:
                HarperTurn();
                state = BattleState.HARPERTURN;
                break;

            case CharacterIdentifier.Skye:
                SkyeTurn();
                state = BattleState.SKYETURN;
                break;
            case CharacterIdentifier.Sullivan:
                SullivanTurn();
                state = BattleState.SULLIVANTURN;
                break;
            case CharacterIdentifier.Enemy1:
                state = BattleState.ENEMYTURN;
                StartCoroutine("EnemyTurn", 0);
                break;
            case CharacterIdentifier.Enemy2:
                state = BattleState.ENEMYTURN;
                StartCoroutine("EnemyTurn", 1);
                break;
            case CharacterIdentifier.Enemy3:
                state = BattleState.ENEMYTURN;
                StartCoroutine("EnemyTurn", 2);
                break;
            case CharacterIdentifier.Enemy4:
                state = BattleState.ENEMYTURN;
                StartCoroutine("EnemyTurn", 3);
                break;
            case CharacterIdentifier.Enemy5:
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

        MCHealth.value = GameManager.MCHealth ;
        RhysHealth.value = GameManager.RhysHealth ;
        JameelHealth.value = GameManager.JameelHealth;
        HarperHealth.value = GameManager.HarperHealth ;
        SkyeHealth.value = GameManager.SkyeHealth;
        SullivanHealth.value = GameManager.SullivanHealth ;

        MCMagic.value = GameManager.MCMagic ;
        RhysMagic.value = GameManager.RhysMagic ;
        JameelMagic.value = GameManager.JameelMagic ;
        HarperMagic.value = GameManager.HarperMagic ;
        SkyeMagic.value = GameManager.SkyeMagic ;
        SullivanMagic.value = GameManager.SullivanMagic ;

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
                    MCAnim.Play("Armature|Run");
                    if (GameManager.RhysInParty && !RhysDead)
                    {
                        RhysAnim.Play("Armature|Run");
                    }
                    if (GameManager.JameelInParty && !JameelDead)
                    {
                        JameelAnim.Play("Armature|Run");
                    }
                    if (GameManager.HarperInParty && !HarperDead)
                    {
                        HarperAnim.Play("Armature|Run");
                    }
                    if (GameManager.SkyeInParty && !SkyeDead)
                    {
                        SkyeAnim.Play("Armature|Run");
                    }
                    if (GameManager.SullivanInParty && !SullivanDead)
                    {
                        SullivanAnim.Play("Armature|Run");
                    }
            }
                else
                {
                    dialogueText.text = "You think you can get away";

                    MCAnim.Play("Armature|Run");
                    if (GameManager.RhysInParty && !RhysDead)
                    {
                        RhysAnim.Play("Armature|Run");
                    }
                    if (GameManager.JameelInParty && !JameelDead)
                    {
                        JameelAnim.Play("Armature|Run");
                    }
                    if (GameManager.HarperInParty && !HarperDead)
                    {
                        HarperAnim.Play("Armature|Run");
                    }
                    if (GameManager.SkyeInParty && !SkyeDead)
                    {
                        SkyeAnim.Play("Armature|Run");
                    }
                    if (GameManager.SullivanInParty && !SullivanDead)
                    {
                        SullivanAnim.Play("Armature|Run");
                    }

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
    #endregion
    #region MCAttacks

    IEnumerator MCAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        //Modify the Spell1Damage and Spell1Magic used based on the player, the spell, and their level 
        if (state == BattleState.MCTURN)
        {
            if (flippendo)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    flippendo = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell2MagicConsumed;
                    MCMagic.value = GameManager.MCMagic ;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].Flippendo(MC.MCSpell2Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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

            if (pulsateSunt)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    pulsateSunt = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell3MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].PulsateSunt(MC.MCSpell3Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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

            if (stupefaciunt)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    stupefaciunt = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell4MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].Stupefaciunt(MC.MCSpell4Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (incendio)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    incendio = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell5MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].Incendio(MC.MCSpell5Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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



            if (incendioMaxima)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    incendioMaxima = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell6MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].IncendioMaxima(MC.MCSpell6Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (avis)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    avis = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell7MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].Avis(MC.MCSpell7Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (avisMaxima)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    avisMaxima = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell8MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].AvisMaxima(MC.MCSpell8Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (glacies)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    glacies = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell9MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].Glacius(MC.MCSpell9Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (minorCura)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    minorCura = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell10MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].MinorCura(MC.MCSpell10Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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

            if (impetumSubsisto)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    impetumSubsisto = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell11MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].ImpetumSubsisto(MC.MCSpell11Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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

            if (augamenti)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    augamenti = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell12MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].Augamenti(MC.MCSpell12Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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

            if (mothsDeorsum)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    mothsDeorsum = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell13MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].MothsDeorsum(MC.MCSpell13Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (mothsInteriore)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    mothsInteriore = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell14MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].MothsInteriore(MC.MCSpell14Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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

            if (internaCombustione)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    internaCombustione = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell15MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].InternaCombustione(MC.MCSpell15Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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



            if (bombarda)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    bombarda = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell16MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].Bombarda(MC.MCSpell16Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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



            if (bombardaMaxima)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    bombardaMaxima = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell17MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].BombardaMaxima(MC.MCSpell17Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (bombardaUltima)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    bombardaUltima = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell18MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].BombardaUltima(MC.MCSpell18Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (minusSanaCoetus)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    minusSanaCoetus = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell19MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].MinusSanaCoetus(MC.MCSpell19Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (chorusPedes)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    chorusPedes = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell20MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].ChorusPedes(MC.MCSpell20Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (criticaFocus)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    criticaFocus = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell21MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].CriticaFocus(MC.MCSpell21Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (diffindo)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    diffindo = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell22MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].Diffindo(MC.MCSpell22Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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


            if (diffindoMaxima)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    flippendo = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell23MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);
                    isDead = enemyUnit[enemyUnitSelected].DiffindoMaxima(MC.MCSpell23Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                    throwRock = false;
                    flippendo = false;
                    pulsateSunt = false;
                    stupefaciunt = false;
                    incendio = false;
                    incendioMaxima = false;
                    avis = false;
                    avisMaxima = false;
                    glacies = false;
                    minorCura = false;
                    impetumSubsisto = false;
                    augamenti = false;
                    mothsDeorsum = false;
                    mothsInteriore = false;
                    internaCombustione = false;
                    bombarda = false;
                    bombardaMaxima = false;
                    bombardaUltima = false;
                    minusSanaCoetus = false;
                    chorusPedes = false;
                    criticaFocus = false;
                    diffindo = false;
                    diffindoMaxima = false;
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

    #endregion

    #region RhysAttacks
    IEnumerator RhysAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        if (rhysFlippendo)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysFlippendo = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell2MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysFlippendo(Rhys.RhysSpell2Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysCorpusLiget)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysCorpusLiget = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell3MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysCorpusLiget(Rhys.RhysSpell3Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysMothsDeorsum)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysMothsDeorsum = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell4MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysMothsDeorsum(Rhys.RhysSpell4Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysMothInteriore)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysMothInteriore = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell5MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysMothsInteriore(Rhys.RhysSpell5Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysInternumCombustione)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysInternumCombustione = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell6MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysInternumCombustione(Rhys.RhysSpell6Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysTenuiLabor)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysTenuiLabor = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell7MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysTenuiLabor(Rhys.RhysSpell7Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysIncendio)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysIncendio = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell8MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysFlippendo(Rhys.RhysSpell8Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysFumos)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysFumos = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell9MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysFumos(Rhys.RhysSpell9Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysWaddiwasi)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysWaddiwasi = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell10MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysWaddiwasi(Rhys.RhysSpell10Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysConjurePugione)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysConjurePugione = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell11MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysConjurePugione(Rhys.RhysSpell11Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysImpetumSubsisto)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysImpetumSubsisto = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell12MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysImpetumSubsisto(Rhys.RhysSpell12Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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

        if (rhysUolueris)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                rhysUolueris = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell13MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].RhysIraUolueris(Rhys.RhysSpell13Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);


                rhysThrowRock = false;
                rhysFlippendo = false;
                rhysCorpusLiget = false;
                rhysMothsDeorsum = false;
                rhysMothInteriore = false;
                rhysInternumCombustione = false;
                rhysTenuiLabor = false;
                rhysIncendio = false;
                rhysFumos = false;
                rhysWaddiwasi = false;
                rhysConjurePugione = false;
                rhysImpetumSubsisto = false;
                rhysUolueris = false;
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
    #endregion

    #region Jameel Attacks
    IEnumerator JameelAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        if (jameelFlippendo)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelFlippendo = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell2MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell2Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelMinusSanaCoetus)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelMinusSanaCoetus = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell3MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell3Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelMinorCura)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelMinorCura = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell4MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell4Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelMaiorCura)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelMaiorCura = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell5MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell5Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelPartumNix)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelPartumNix = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell6MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell6Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelHiemsImpetus)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelHiemsImpetus = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell7MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell7Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelBombarda)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelBombarda = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell8MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell8Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelBombardaMaxima)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelBombardaMaxima = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell9MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell9Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelBombardaUltima)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelBombardaUltima = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell10MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell10Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelRepellere)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelRepellere = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell11MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell11Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelDiffindo)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelDiffindo = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell12MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell12Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelDiffindoMaxima)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelDiffindoMaxima = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell13MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell13Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelImpetumSubsisto)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelImpetumSubsisto = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell14MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell14Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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

        if (jameelChorusPedes)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                jameelChorusPedes = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell15MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell15Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                jameelFlippendo = false;
                jameelMinusSanaCoetus = false;
                jameelMinorCura = false;
                jameelMaiorCura = false;
                jameelPartumNix = false;
                jameelHiemsImpetus = false;
                jameelBombarda = false;
                jameelBombardaMaxima = false;
                jameelBombardaUltima = false;
                jameelRepellere = false;
                jameelDiffindo = false;
                jameelDiffindoMaxima = false;
                jameelImpetumSubsisto = false;
                jameelChorusPedes = false;
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
    #endregion
    #region HarperAttacks
    IEnumerator HarperAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        if (harperFlippendo)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperFlippendo = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell2MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperFlippendo(Harper.HarperSpell2Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperDeflectorImpetum)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperDeflectorImpetum = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell3MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperDeflectorImpetum(Harper.HarperSpell3Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        
        if (harperMinorFortitudinem)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperMinorFortitudinem = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell4MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperMinorFortitudinem(Harper.HarperSpell4Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperMoserateFortitudinem)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperMoserateFortitudinem = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell5MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperMoserateFortitudinem(Harper.HarperSpell5Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperMaiorFortitudinem)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperMaiorFortitudinem = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell6MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperMaiorFortitudinem(Harper.HarperSpell6Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperInternumCombustione)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperInternumCombustione = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell7MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperInternumCombustione(Harper.HarperSpell7Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperLaedo)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperLaedo = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell8MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperLaedo(Harper.HarperSpell8Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperLociPraesidium)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperLociPraesidium = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell9MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperLociPraesidium(Harper.HarperSpell9Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperPerturbo)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperPerturbo = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell10MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperPerturbo(Harper.HarperSpell10Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperPulsateSunt)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperPulsateSunt = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell11MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperPulsateSunt(Harper.HarperSpell11Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperFumes)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperFumes = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell12MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperFumes(Harper.HarperSpell12Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

        if (harperDiminuendo)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                harperDiminuendo = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell13MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].HarperDiminuendo(Harper.HarperSpell13Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                harperThrowRock = false;
                harperFlippendo = false;
                harperDeflectorImpetum = false;
                harperMinorFortitudinem = false;
                harperMoserateFortitudinem = false;
                harperMaiorFortitudinem = false;
                harperInternumCombustione = false;
                harperLaedo = false;
                harperLociPraesidium = false;
                harperPerturbo = false;
                harperPulsateSunt = false;
                harperFumes = false;
                harperDiminuendo = false;
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

    #endregion

    #region SkyeAttacks
    IEnumerator SkyeAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        if (skyeFlippendo)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeFlippendo = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell2MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeFlippendo(Skye.SkyeSpell2Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

        if (skyeMinorCura)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeMinorCura = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell3MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeMinorCura(Skye.SkyeSpell3Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

        if (skyeMaiorCura)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeMaiorCura = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell4MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeMaiorCura(Skye.SkyeSpell4Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

        if (skyeSenaPlenaPotion)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeSenaPlenaPotion = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell5MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeSenaPlenaPotion(Skye.SkyeSpell5Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

        if (skyeReanimatePotion)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeReanimatePotion = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell6MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeReanimatePotion(Skye.SkyeSpell6Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

        if (skyeSanaCoetusPotion)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeSanaCoetusPotion = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell7MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeSanaCoetusPotion(Skye.SkyeSpell7Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

        if (skyeAntidoteToCommonPoisons)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeAntidoteToCommonPoisons = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell8MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeAntidoteToCommonPoisons(Skye.SkyeSpell8Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

        if (skyeStrengthPotion)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeStrengthPotion = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell9MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeStrengthPotion(Skye.SkyeSpell9Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

        if (skyeConfundus)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeConfundus = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell10MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeConfundus(Skye.SkyeSpell10Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

        if (skyeIraUolueris)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                skyeIraUolueris = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell11MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SkyeIraUolueris(Skye.SkyeSpell11Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                skyeThrowRock = false;
                skyeFlippendo = false;
                skyeMinorCura = false;
                skyeMaiorCura = false;
                skyeSenaPlenaPotion = false;
                skyeReanimatePotion = false;
                skyeSanaCoetusPotion = false;
                skyeAntidoteToCommonPoisons = false;
                skyeStrengthPotion = false;
                skyeConfundus = false;
                skyeIraUolueris = false;
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

    #endregion

    #region Sullivan Attacks
    IEnumerator SullivanAttack()
    {
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        if (sullivanFlippendo)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanFlippendo = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell2MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanFlippendo(Sullivan.SullivanSpell2Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanExiling)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanExiling = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell3MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanExiling(Sullivan.SullivanSpell3Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanProtego)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanProtego = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell4MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanProtego(Sullivan.SullivanSpell4Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanIgnusMagnum)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanIgnusMagnum = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell5MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanIgnusMagnum(Sullivan.SullivanSpell5Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanSagittaIecit)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanSagittaIecit = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell6MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanSagittaLecit(Sullivan.SullivanSpell6Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanMonstrumSella)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanMonstrumSella = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell7MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanMonstrumSella(Sullivan.SullivanSpell7Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanIncarcerous)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanIncarcerous = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell8MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanIncarcerous(Sullivan.SullivanSpell8Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanUltimumChao)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanUltimumChao = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell9MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanUltimumChao(Sullivan.SullivanSpell9Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanMutareStatum)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanMutareStatum = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell10MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanMutareStatum(Sullivan.SullivanSpell10Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanEngorgement)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanEngorgement = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell11MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanEngorgement(Sullivan.SullivanSpell11Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanStatuamLocomotion)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanStatuamLocomotion = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell12MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanStatuamLocomotion(Sullivan.SullivanSpell12Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

        if (sullivanCriticaFocus)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                sullivanCriticaFocus = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell13MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                isDead = enemyUnit[enemyUnitSelected].SullivanCriticaFocus(Sullivan.SullivanSpell13Damage); //This is the modifier for damage based on player level - add this when spells are determined //+ GameManager.StarterFast);

                sullivanRockThrow = false;
                sullivanFlippendo = false;
                sullivanExiling = false;
                sullivanProtego = false;
                sullivanIgnusMagnum = false;
                sullivanSagittaIecit = false;
                sullivanMonstrumSella = false;
                sullivanIncarcerous = false;
                sullivanUltimumChao = false;
                sullivanMutareStatum = false;
                sullivanEngorgement = false;
                sullivanStatuamLocomotion = false;
                sullivanCriticaFocus = false;
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

    #endregion

    #region Enemy Attack
    IEnumerator EnemyTurn(int enemyIndex)
        {
            
            Camera.transform.position = enemyCam.transform.position;
            Camera.transform.LookAt(MC.transform.position);
        // GameManager.Instance.DebugBall.transform.position = enemyUnit[enemyIndex].transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        //           if (enemyUnit[enemyIndex].currentHP <= 0)
        //           {
        // NextPlayerTurnAfterEnemyTurn(enemyIndex);
        //           }
        //           else
        //           {
        if (MCDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        { 
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
                WhoToAttack = Random.Range(0, 6);
                if (safteyCounter-- < 0)
                {
                    Debug.LogError("Couldn't find a living WhoToAttack, is the Whole Team Dead?");
                    break;
                    //bails us out of the do while
                }

            } while (isPlayerIndexDead(WhoToAttack));

            //This is broken and will make it look like it is the player's turn when the enemy is just choosing a new target
            if (WhoToAttack == 1 && !GameManager.RhysInParty || RhysDead)
            {
                //  StartCoroutine(EnemyDamageStep(enemyIndex));
                StartCoroutine(EnemyTurn(enemyIndex));
            }
            else if (WhoToAttack == 2 && !GameManager.JameelInParty || JameelDead)
            {
                //  StartCoroutine(EnemyDamageStep(enemyIndex));
                StartCoroutine(EnemyTurn(enemyIndex));
            }
            else if (WhoToAttack == 3 && !GameManager.HarperInParty || HarperDead)
            {
                // StartCoroutine(EnemyDamageStep(enemyIndex));
                StartCoroutine(EnemyTurn(enemyIndex));
            }
            else if (WhoToAttack == 4 && !GameManager.SkyeInParty || SkyeDead)
            {
                // StartCoroutine(EnemyDamageStep(enemyIndex));
                StartCoroutine(EnemyTurn(enemyIndex));
            }
            else if (WhoToAttack == 5 && !GameManager.SullivanInParty || SullivanDead)
            {
                // StartCoroutine(EnemyDamageStep(enemyIndex));
                StartCoroutine(EnemyTurn(enemyIndex));
            }

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
                    MCAnim.Play("Armature|Dodge");
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
                        MCHealth.value = GameManager.MCHealth;
                        MCDead = true;
                        MCAnim.SetBool("isDead", true);
                        Debug.Log("Game Over because Main Character died");
                        state = BattleState.LOST;
                        yield return new WaitForSeconds(3f);
                        EndBattle();
                    }

                    else
                    {
                        yield return new WaitForSeconds(.5f);
                        MCAnim.Play("Armature|TakeDamage");
                        MCDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                        GameManager.MCHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                        MCHealth.value = GameManager.MCHealth;
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
                    RhysAnim.Play("Armature|Dodge");
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
                        RhysHealth.value = GameManager.RhysHealth;
                        playerTurnOrder.Remove(CharacterIdentifier.Rhys);

                        //   Debug.Log("Removing Middle");
                        //   DebugPrintList(playerTurnOrder);

                        RhysAnim.SetBool("isDead", true);
                        print("Rhys Dead" + GameManager.RhysHealth + "/" + GameManager.RhysMaxHealth);
                        RhysDead = true;
                        yield return new WaitForSeconds(3f);

                    }

                    else
                    {
                        yield return new WaitForSeconds(.5f);
                        RhysAnim.Play("Armature|TakeDamage");
                        RhysDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                        GameManager.RhysHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                        RhysHealth.value = GameManager.RhysHealth;
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
                    JameelAnim.Play("Armature|Dodge");
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
                        JameelHealth.value = GameManager.JameelHealth;
                        JameelDead = true;

                        playerTurnOrder.Remove(CharacterIdentifier.Jameel);

                        //   Debug.Log("Removing Middle");
                        //   DebugPrintList(playerTurnOrder);

                        JameelAnim.SetBool("isDead", true);
                        yield return new WaitForSeconds(3f);

                    }

                    else
                    {
                        yield return new WaitForSeconds(.5f);
                        JameelAnim.Play("Armature|TakeDamage");
                        JameelDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                        GameManager.JameelHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                        JameelHealth.value = GameManager.JameelHealth;
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
                    HarperAnim.Play("Armature|Dodge");
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
                        HarperHealth.value = GameManager.HarperHealth;
                        HarperDead = true;

                        playerTurnOrder.Remove(CharacterIdentifier.Harper);

                        //   Debug.Log("Removing Middle");
                        //   DebugPrintList(playerTurnOrder);

                        HarperAnim.SetBool("isDead", true);
                        yield return new WaitForSeconds(3f);

                    }

                    else
                    {
                        yield return new WaitForSeconds(.5f);
                        HarperAnim.Play("Armature|TakeDamage");
                        HarperDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                        GameManager.HarperHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                        HarperHealth.value = GameManager.HarperHealth;
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
                    SkyeAnim.Play("Armature|Dodge");
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
                        SkyeHealth.value = GameManager.SkyeHealth;
                        SkyeDead = true;

                        playerTurnOrder.Remove(CharacterIdentifier.Skye);

                        //   Debug.Log("Removing Middle");
                        //   DebugPrintList(playerTurnOrder);

                        SkyeAnim.SetBool("isDead", true);
                        yield return new WaitForSeconds(3f);

                    }

                    else
                    {
                        yield return new WaitForSeconds(.5f);
                        SkyeAnim.Play("Armature|TakeDamage");
                        SkyeDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                        GameManager.SkyeHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                        SkyeHealth.value = GameManager.SkyeHealth;
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
                    SullivanAnim.Play("Armature|Dodge");
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
                        SullivanHealth.value = GameManager.SullivanHealth;
                        SullivanDead = true;

                        playerTurnOrder.Remove(CharacterIdentifier.Sullivan);

                        //   Debug.Log("Removing Middle");
                        //   DebugPrintList(playerTurnOrder);

                        SullivanAnim.SetBool("isDead", true);
                        yield return new WaitForSeconds(3f);

                    }

                    else
                    {
                        yield return new WaitForSeconds(.5f);
                        SullivanAnim.Play("Armature|TakeDamage");
                        SullivanDamageUI.text = "-" + enemyUnit[enemyUnitSelected].enemyDamage.ToString();
                        GameManager.SullivanHealth -= enemyUnit[enemyUnitSelected].enemyDamage;
                        SullivanHealth.value = GameManager.SullivanHealth;
                        yield return new WaitForSeconds(2f);

                    }
                }

                yield return new WaitForSeconds(.5f);
                StartCoroutine(TurnOffDamageUI());
            }
        print(WhoToAttack);
        // }
         }
        NextTurn();
        }

  /*  IEnumerator EnemyDamageStep(int enemyIndex)
    {
        yield return new WaitForSeconds(.1f);
    
    
    
    
    
    
    
    }
  */
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
            state = BattleState.LOST;
            EndBattle();
        }
        if (!MCDead)
        {
            MCMenu.SetActive(true);
            dialogueText.text = "[Player Name]: Choose an Action.";

            throwRock = false;
            flippendo = false;
            pulsateSunt = false;
            stupefaciunt = false;
            incendio = false;
            incendioMaxima = false;
            avis = false;
            avisMaxima = false;
            glacies = false;
            minorCura = false;
            impetumSubsisto = false;
            augamenti = false;
            mothsDeorsum = false;
            mothsInteriore = false;
            internaCombustione = false;
            bombarda = false;
            bombardaMaxima = false;
            bombardaUltima = false;
            minusSanaCoetus = false;
            chorusPedes = false;
            criticaFocus = false;
            diffindo = false;
            diffindoMaxima = false;
        }
    }

    void RhysTurn()
    {
        //    Camera.transform.position = .transform.position;
        Camera.transform.position = player2Cam.transform.position;
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

            rhysThrowRock = false ;
            rhysFlippendo = false;
            rhysCorpusLiget = false;
            rhysMothsDeorsum = false;
            rhysMothInteriore = false;
            rhysInternumCombustione = false;
            rhysTenuiLabor = false;
            rhysIncendio = false;
            rhysFumos = false;
            rhysWaddiwasi = false;
            rhysConjurePugione = false;
            rhysImpetumSubsisto = false;
            rhysUolueris = false;
        }
    }
    
    void JameelTurn()
    {
        //    Camera.transform.position = .transform.position;
        if (!GameManager.RhysInParty && GameManager.JameelInParty)
        {
            Camera.transform.position = player2Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }
        if (GameManager.RhysInParty && GameManager.JameelInParty)
        {
            Camera.transform.position = player3Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }
        //    GameManager.Instance.DebugBall.transform.position = MiddleReliever.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (JameelDead || !GameManager.JameelInParty)
        {
            NextTurn();

        }
        if (!JameelDead)
        {
            JameelMenu.SetActive(true);
            dialogueText.text = "Jameel: Choose an Action.";

            jameelThrowRock = false;
            jameelFlippendo = false;
            jameelMinusSanaCoetus = false;
            jameelMinorCura = false;
            jameelMaiorCura = false;
            jameelPartumNix = false;
            jameelHiemsImpetus = false;
            jameelBombarda = false;
            jameelBombardaMaxima = false;
            jameelBombardaUltima = false;
            jameelRepellere = false;
            jameelDiffindo = false;
            jameelDiffindoMaxima = false;
            jameelImpetumSubsisto = false;
            jameelChorusPedes = false;
        }
    }
    
    void HarperTurn()
    {
        //    Camera.transform.position = .transform.position;
        if (!GameManager.RhysInParty && !GameManager.JameelInParty && GameManager.HarperInParty)
        {
            Camera.transform.position = player2Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }

        if (GameManager.RhysInParty || GameManager.JameelInParty && GameManager.HarperInParty)
        {
            Camera.transform.position = player3Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }

        if (GameManager.RhysInParty && GameManager.JameelInParty && GameManager.HarperInParty)
        {
            Camera.transform.position = player4Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }
        //    GameManager.Instance.DebugBall.transform.position = MiddleReliever.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (HarperDead || !GameManager.HarperInParty)
        {
            NextTurn();

        }
        if (!HarperDead)
        {
            HarperMenu.SetActive(true);
            dialogueText.text = "Harper: Choose an Action.";

            harperThrowRock = false ;
            harperFlippendo = false;
            harperDeflectorImpetum = false;
            harperMinorFortitudinem = false;
            harperMoserateFortitudinem = false;
            harperMaiorFortitudinem = false;
            harperInternumCombustione = false;
            harperLaedo = false;
            harperLociPraesidium = false;
            harperPerturbo = false;
            harperPulsateSunt = false;
            harperFumes = false;
            harperDiminuendo = false;
        }
    }

    void SkyeTurn()
    {
        //    Camera.transform.position = .transform.position;
        if (GameManager.PartyCount == 2 && GameManager.SkyeInParty)
        {
            Camera.transform.position = player2Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }

        if (GameManager.PartyCount == 3 && GameManager.SkyeInParty && !GameManager.SullivanInParty)
        {
            Camera.transform.position = player3Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }

        if (GameManager.PartyCount == 4 && GameManager.SkyeInParty && GameManager.SullivanInParty)
        {
            Camera.transform.position = player3Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }

        if (GameManager.PartyCount == 4 && GameManager.SkyeInParty && !GameManager.SullivanInParty)
        {
            Camera.transform.position = player4Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }
        //    GameManager.Instance.DebugBall.transform.position = MiddleReliever.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (SkyeDead || !GameManager.SkyeInParty)
        {
            NextTurn();

        }
        if (!SkyeDead)
        {
            SkyeMenu.SetActive(true);
            dialogueText.text = "Skye: Choose an Action.";

            skyeThrowRock = false;
            skyeFlippendo = false;
            skyeMinorCura = false;
            skyeMaiorCura = false;
            skyeSenaPlenaPotion = false;
            skyeReanimatePotion = false;
            skyeSanaCoetusPotion = false;
            skyeAntidoteToCommonPoisons = false;
            skyeStrengthPotion = false;
            skyeConfundus = false;
            skyeIraUolueris = false;
        }
    }

    void SullivanTurn()
    {
        //    Camera.transform.position = .transform.position;
        if (GameManager.PartyCount == 2 && GameManager.SullivanInParty)
        {
            Camera.transform.position = player2Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }

        if (GameManager.PartyCount == 3 && GameManager.SullivanInParty)
        {
            Camera.transform.position = player3Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }

        if (GameManager.PartyCount == 4 && GameManager.SullivanInParty)
        {
            Camera.transform.position = player4Cam.transform.position;
            Camera.transform.LookAt(enemyCamTarget);
        }
        //    GameManager.Instance.DebugBall.transform.position = MiddleReliever.transform.position + Vector3.up * GameManager.Instance.DebugBallHeight;
        if (SullivanDead || !GameManager.SullivanInParty)
        {
            NextTurn();

        }
        if (!SullivanDead)
        {
            SullivanMenu.SetActive(true);
            dialogueText.text = "Sullivan: Choose an Action.";

            #region SullivanAttacks
            sullivanRockThrow = false;
            sullivanFlippendo = false;
            sullivanExiling = false;
            sullivanProtego = false;
            sullivanIgnusMagnum = false;
            sullivanSagittaIecit = false;
            sullivanMonstrumSella = false;
            sullivanIncarcerous = false;
            sullivanUltimumChao = false;
            sullivanMutareStatum = false;
            sullivanEngorgement = false;
            sullivanStatuamLocomotion = false;
            sullivanCriticaFocus = false;
            #endregion
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
    #region MC Attack UI Buttons

    public void MCFlippendo()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell2MagicConsumed <= GameManager.MCMagic)
            {
                flippendo = true;

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
    }

    public void MCPulsateSunt()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell3MagicConsumed <= GameManager.MCMagic)
            {
                pulsateSunt = true;

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
    }

    public void MCStupefaciunt()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell3MagicConsumed <= GameManager.MCMagic)
            {
                stupefaciunt = true;

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
    }

    public void MCIncendio()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell5MagicConsumed <= GameManager.MCMagic)
            {
                incendio = true;

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
    }

    public void MCIncendioMaxima()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell6MagicConsumed <= GameManager.MCMagic)
            {
                incendioMaxima = true;

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
    }

    public void MCAvis()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell7MagicConsumed <= GameManager.MCMagic)
            {
                avis = true;

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
    }

    public void MCAvisMaxima()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell8MagicConsumed <= GameManager.MCMagic)
            {
                avisMaxima = true;

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
    }

    public void MCGlacies()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell9MagicConsumed <= GameManager.MCMagic)
            {
                glacies = true;

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
    }

    public void MCMinorCura()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell10MagicConsumed <= GameManager.MCMagic)
            {
                minorCura = true;

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
    }

    public void MCImpetumSubsisto()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell11MagicConsumed <= GameManager.MCMagic)
            {
                impetumSubsisto = true;

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
    }

    public void MCAugamenti()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell12MagicConsumed <= GameManager.MCMagic)
            {
                augamenti = true;

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
    }

    public void MCMothsDeorsum()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell13MagicConsumed <= GameManager.MCMagic)
            {
                mothsDeorsum = true;

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
    }

    public void MCMothsInteriore()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell14MagicConsumed <= GameManager.MCMagic)
            {
                mothsInteriore = true;

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
    }

    public void MCInternaCombustione()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell15MagicConsumed <= GameManager.MCMagic)
            {
                internaCombustione = true;

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
    }

    public void MCBombarda()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell16MagicConsumed <= GameManager.MCMagic)
            {
                bombarda = true;

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
    }

    public void MCBombardaMaxima()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell17MagicConsumed <= GameManager.MCMagic)
            {
                bombardaMaxima = true;

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
    }

    public void MCBombardaUltima()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell18MagicConsumed <= GameManager.MCMagic)
            {
                bombardaUltima = true;

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
    }

    public void MCMinusSanaCoetus()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell19MagicConsumed <= GameManager.MCMagic)
            {
                minusSanaCoetus = true;

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
    }

    public void MCChorusPedes()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell20MagicConsumed <= GameManager.MCMagic)
            {
                chorusPedes = true;

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
    }

    public void MCCriticaFocus()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell21MagicConsumed <= GameManager.MCMagic)
            {
                criticaFocus = true;

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
    }

    public void MCDiffindo()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell22MagicConsumed <= GameManager.MCMagic)
            {
                diffindo = true;

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
    }

    public void MCDiffindoMaxima()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell23MagicConsumed <= GameManager.MCMagic)
            {
                flippendo = true;

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
    }

    #endregion

    #region Rhys Attack UI Buttons
    public void RhysFlippendo()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell2MagicConsumed <= GameManager.RhysMagic)
            {
                rhysFlippendo = true;

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
    }
    public void RhysCorpusLiget()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell3MagicConsumed <= GameManager.RhysMagic)
            {
                rhysCorpusLiget = true;

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
    }
    public void RhysMothsDeorsum()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell4MagicConsumed <= GameManager.RhysMagic)
            {
                rhysMothsDeorsum = true;

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
    }
    public void RhysMothIntiore()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell5MagicConsumed <= GameManager.RhysMagic)
            {
                rhysMothInteriore = true;

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
    }

    public void RhysInternumCombustione()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell6MagicConsumed <= GameManager.RhysMagic)
            {
                rhysInternumCombustione = true;

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
    }
    public void RhysTenuiLabor()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell7MagicConsumed <= GameManager.RhysMagic)
            {
                rhysTenuiLabor = true;

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
    }
    public void RhysIncendio()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell8MagicConsumed <= GameManager.RhysMagic)
            {
                rhysIncendio = true;

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
    }
    public void RhysFumos()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell9MagicConsumed <= GameManager.RhysMagic)
            {
                rhysFumos = true;

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
    }
    public void RhysWaddiwasi()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell10MagicConsumed <= GameManager.RhysMagic)
            {
                rhysWaddiwasi = true;

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
    }
    public void RhysConjurePugione()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell11MagicConsumed <= GameManager.RhysMagic)
            {
                rhysConjurePugione = true;

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
    }
    public void RhysImpetumSubsisto()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell12MagicConsumed <= GameManager.RhysMagic)
            {
                rhysImpetumSubsisto = true;

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
    }
    public void RhysIraUolueris()
    {
        if (state == BattleState.RHYSTURN)
        {
            if (Rhys.RhysSpell13MagicConsumed <= GameManager.RhysMagic)
            {
                rhysUolueris = true;

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
    }


    #endregion

    #region Jameel Attack UI Buttons

    public void JameelFlippendo()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell2MagicConsumed <= GameManager.JameelMagic)
            {
                jameelFlippendo = true;

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
    }

    public void JameelMinusSanaCoetus()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell3MagicConsumed <= GameManager.JameelMagic)
            {
                jameelMinusSanaCoetus = true;

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
    }

    public void JameelMinorCura()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell4MagicConsumed <= GameManager.JameelMagic)
            {
                jameelMinorCura = true;

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
    }

    public void JameelMaiorCura()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell5MagicConsumed <= GameManager.JameelMagic)
            {
                jameelMaiorCura = true;

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
    }

    public void JameelPartumNix()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell6MagicConsumed <= GameManager.JameelMagic)
            {
                jameelPartumNix = true;

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
    }

    public void JameelHiemsImpetus()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell7MagicConsumed <= GameManager.JameelMagic)
            {
                jameelHiemsImpetus = true;

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
    }

    public void JameelBombarda()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell8MagicConsumed <= GameManager.JameelMagic)
            {
                jameelBombarda = true;

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
    }

    public void JameelBombardaMaxima()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell9MagicConsumed <= GameManager.JameelMagic)
            {
                jameelBombardaMaxima = true;

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
    }

    public void JameelBombardaUltima()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell10MagicConsumed <= GameManager.JameelMagic)
            {
                jameelBombardaUltima = true;

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
    }

    public void JameelRepellere()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell11MagicConsumed <= GameManager.JameelMagic)
            {
                jameelRepellere = true;

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
    }

    public void JameelDiffindo()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell12MagicConsumed <= GameManager.JameelMagic)
            {
                jameelDiffindo = true;

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
    }

    public void JameelDiffindoMaxima()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell13MagicConsumed <= GameManager.JameelMagic)
            {
                jameelDiffindoMaxima = true;

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
    }

    public void JameelImpetumSubsisto()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell14MagicConsumed <= GameManager.JameelMagic)
            {
                jameelImpetumSubsisto = true;

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
    }

    public void JameelChorusPedes()
    {
        if (state == BattleState.JAMEELTURN)
        {
            if (Jameel.JameelSpell15MagicConsumed <= GameManager.JameelMagic)
            {
                jameelChorusPedes = true;

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
    }

    #endregion

    #region Harper Attack UI Buttons
    public void HarperFlippendo()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell2MagicConsumed <= GameManager.HarperMagic)
            {
                harperFlippendo = true;

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
    }

    public void HarperDeflectorImpetum()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell3MagicConsumed <= GameManager.HarperMagic)
            {
                harperDeflectorImpetum = true;

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
    }

    public void HarperMinorFortitudinem()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell4MagicConsumed <= GameManager.HarperMagic)
            {
                harperMinorFortitudinem = true;

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
    }

    public void HarperMoserateFortitudinem()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell5MagicConsumed <= GameManager.HarperMagic)
            {
                harperMoserateFortitudinem = true;

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
    }

    public void HarperMaiorFortitudinem()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell6MagicConsumed <= GameManager.HarperMagic)
            {
                harperMaiorFortitudinem = true;

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
    }

    public void HarperInternumCombustione()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell7MagicConsumed <= GameManager.HarperMagic)
            {
                harperInternumCombustione = true;

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
    }

    public void HarperLaedo ()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell8MagicConsumed <= GameManager.HarperMagic)
            {
                harperLaedo = true;

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
    }

    public void HarperLociPraesidium()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell9MagicConsumed <= GameManager.HarperMagic)
            {
                harperLociPraesidium = true;

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
    }

    public void HarperPerturbo()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell10MagicConsumed <= GameManager.HarperMagic)
            {
                harperPerturbo = true;

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
    }

    public void HarperPulsateSunt()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell11MagicConsumed <= GameManager.HarperMagic)
            {
                harperPulsateSunt = true;

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
    }

    public void HarperFumes()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell12MagicConsumed <= GameManager.HarperMagic)
            {
                harperFumes = true;

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
    }

    public void HarperDiminuendo()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell13MagicConsumed <= GameManager.HarperMagic)
            {
                harperDiminuendo = true;

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
    }
    #endregion

    #region Skye Attack UI Buttons
    public void SkyeFlippendo()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell2MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeFlippendo = true;

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
    }

    public void SkyeMinorCura()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell3MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeMinorCura = true;

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
    }

    public void SkyeMaiorCura()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell4MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeMaiorCura = true;

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
    }

    public void SkyeSenaPlenaPotion()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell5MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeSenaPlenaPotion = true;

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
    }

    public void SkyeReanimatePotion()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell6MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeReanimatePotion = true;

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
    }

    public void SkyeSanaCoetusPotion()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell7MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeSanaCoetusPotion = true;

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
    }

    public void SkyeAntidotetoCommonPoisons()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell8MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeAntidoteToCommonPoisons = true;

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
    }

    public void SkyeStrengthPotion()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell9MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeStrengthPotion = true;

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
    }

    public void SkyeConfundus()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell10MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeConfundus = true;

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
    }
    public void SkyeIraUolueris()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell11MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeIraUolueris = true;

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
    }
    #endregion

    #region Sullivan Attack UI Buttons
 
    public void SullivanFlippendo()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell2MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanFlippendo = true;

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

    public void SullivanExiling()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell3MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanExiling = true;

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

    public void SullivanProtego()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell4MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanProtego = true;

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

    public void SullivanIgnusMagnum()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell5MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanIgnusMagnum = true;

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

    public void SullivanSagittaIecit()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell6MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanSagittaIecit = true;

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

    public void SullivanMonstrumSella()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell7MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanMonstrumSella = true;

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

    public void SullivanIncarcerous()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell8MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanIncarcerous = true;

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

    public void SullivanUltimumChao()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell9MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanUltimumChao = true;

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

    public void SullivanMutareStatum()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell10MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanMutareStatum = true;

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

    public void SullivanEngorgement()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell11MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanEngorgement = true;

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

    public void SullivanStatuamLocomotion()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell12MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanStatuamLocomotion = true;

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

    public void SullivanCriticaFocus()
    {
        if (state == BattleState.SULLIVANTURN)
        {
            if (Sullivan.SullivanSpell13MagicConsumed <= GameManager.SullivanMagic)
            {
                sullivanCriticaFocus = true;

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
    #endregion
    /*

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
    */
    public void OnCancelButton()
    {
        if (state == BattleState.MCTURN)
        {
            MCMenu.SetActive(true);
            MCSpells.SetActive(false);
        }

        if (state == BattleState.RHYSTURN)
        {
            RhysMenu.SetActive(true);
            RhysSpells.SetActive(false);
        }

        if (state == BattleState.JAMEELTURN)
        {
            JameelMenu.SetActive(true);
            JameelSpells.SetActive(false);
        }

        if (state == BattleState.HARPERTURN)
        {
            HarperMenu.SetActive(true);
            HarperSpells.SetActive(false);
        }

        if (state == BattleState.SKYETURN)
        {
            SkyeMenu.SetActive(true);
            SkyeSpells.SetActive(false);
        }

        if (state == BattleState.SULLIVANTURN)
        {
            SullivanMenu.SetActive(true);
            SullivanSpells.SetActive(false);
        }
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
        if (state == BattleState.LOST)
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
          //  MoneyText.text = GameManager.Money.ToString();
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

    public void WinningScreen()
    {
        SceneManager.LoadScene(DungeonRoomToLoad);
        Debug.Log(DungeonRoomToLoad);
    }


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
