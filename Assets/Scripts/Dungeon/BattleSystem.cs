using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState {START, MCTURN, GRACIEMAY, RHYSTURN, JAMEELTURN, HARPERTURN, SKYETURN, SULLIVANTURN, ENEMYTURN, WON, LOST }

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
    public GameObject Inventory;
    public InventoryObject InventoryContainer;
    public int InventorySelectedItem;
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


    public Text MCTrans, MCCharms, MCPotions, MCDADA, MCDodge;
    public Text RhysTrans, RhysCharms, RhysPotions, RhysDADA, RhysDodge;
    public Text JameelTrans, JameelCharms, JameelPotions, JameelDADA, JameelDodge;
    public Text HarperTrans, HarperCharms, HarperPotions, HarperDADA, HarperDodge;
    public Text SkyeTrans, SkyeCharms, SkyePotions, SkyeDADA, SkyeDodge;
    public Text SullivanTrans, SullivanCharms, SullivanPotions, SullivanDADA, SullivanDodge;
    public Text GracieMayTrans, GracieMayCharms, GracieMayPotions, GracieMayDADA, GracieMayDodge;
    int MCPointsToGive, RhysPointsToGive, JameelPointsToGive, HarperPointsToGive, SkyePointsToGive, SullivanPointsToGive, GracieMayPointsToGive;


    // public Text MCExpGain, RhysExpGain, JameelExpGain, HarperExpGain, SkyeExpGain, SullivanExpGain, GracieMayExpGain;
    //   public Text MCExpToNext, RhysExpToNext, JameelExpToNext, HarperExpToNext, SkyeExpToNext, SullivanExpToNext, GracieMayExpToNext;
    //   public Text MCTotalExp, RhysTotalExp, JameelTotalExp, HarperTotalExp, SkyeTotalExp, SullivanTotalExp, GracieMayTotalExp;
    bool MCLevel, RhysLevel, JameelLevel, HarperLevel, SkyeLevel, SullivanLevel, GracieMayLevel;
    // public GameObject MCLevelUp, RhysLevelUp, JameelLevelUp, HarperLevelUp, SkyeLevelUp, SullivanLevelUp;


    #endregion

    public Text MoneyText;
    //Particle System for selection
    public GameObject enemySelectionParticle;
    public GameObject playerSelectionParticle;

    //determining enemySelection
    public int enemyUnitSelected;
    public int playerUnitSelected;
    public List<Transform> playerBattleStationLocations;
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
    bool mcUsingItem;
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
    bool rhysUsingItem;

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
    bool jameelUsingItem;
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
    bool harperUsingItem;

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
    bool skyeUsingItem;

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
    bool sullivanUsingItem;
    #endregion

    //Enemy
    bool isDead;
    bool hasBeenStunned;
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
    bool playerSelect;
    bool isOver;
    float totalExp;

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

    //Damage UI against players
    public Text MCDamageUI, RhysDamageUI, JameelDamageUI, HarperDamageUI, SkyeDamageUI, SullivanDamageUI;

    public enum CharacterIdentifier
    { MC, Rhys, Jameel, Harper, Skye, Sullivan, GracieMay, Enemy1, Enemy2, Enemy3, Enemy4, Enemy5 };

    public List<CharacterIdentifier> playerTurnOrder = new List<CharacterIdentifier>();
    public List<CharacterIdentifier> enemyTurnOrder = new List<CharacterIdentifier>();

    public bool isPlayerTurn;

    //Turn Order Display
    public Text Next;

    //We'll deal with this when im doing the experience system
    bool gameOverToPreventDuplicates;
    bool preventingAddXPDup;

    public string DungeonRoomToLoad, LosingScreenToLoad;

    public GameObject gracieMaySet;
    public Animator gracieMayAnim;

    int AttackModifierTurnCount = 0;
    int DefenseModifierTurnCount = 0;
    int EvasionTurnCount = 0;
    float AttackModifier = 1.0f;
    float DefenseModifier = 1.0f;
    float EvasionModifier = 1.0f;

    float DefenseMC = 1, DefenseRhys = 1, DefenseJameel = 1, DefenseSkye = 1, DefenseHarper = 1, DefenseSullivan = 1;
    int DefenseMCTurn, DefenseRhysTurn, DefenseJameelTurn, DefenseSkyeTurn, DefenseHarperTurn, DefenseSullivanTurn;

    bool enemyStunned;
    public static bool repelAttack;
    string playerName;

    public GameObject GracieMaySpell1, GracieMaySpell2, GracieMaySpell3, GracieMaySpell4;

    string stunnedName;

    bool isConfused;
    bool isSkyeConfused;
    string EnemyThatIsConfusedHarper, EnemyThatIsConfusedSkye, EnemyThatIsConfusedMC, EnemyThatIsConfusedRhys;

    bool singleBlock;
    string playerToBlock;

    public static bool secondaryAttack;
    public static bool MCConfused, RhysConfused, JameelConfused, HarperConfused, SkyeConfused, SullivanConfused;
    public static bool confusionChance;
    private void Start()
    {
        if (GameObject.Find("GameManager") == null)
        {
            Debug.LogWarning("The GameManager needs to be in this scene for everything to work");
        }

        if (GameManager.HarperFriendship > 3)
        {
            harperDeflectorImpetum = true;
        }

        MCDamageUI.text = "".ToString();
        RhysDamageUI.text = "".ToString();
        JameelDamageUI.text = "".ToString();
        HarperDamageUI.text = "".ToString();
        SkyeDamageUI.text = "".ToString();
        SullivanDamageUI.text = "".ToString();

        InventoryContainer = GameManager.instance.inventory;

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

        if (GameManager.GracieMayAvailable)
        {
            playerTurnOrder.Add(CharacterIdentifier.GracieMay);
        }


        Camera.transform.position = battleCam.transform.position;
        Camera.transform.LookAt(enemyCamTarget.transform.position);

        state = BattleState.START;

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

        enemyStartCount = 2;

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
        SkyeMagic.maxValue = GameManager.SkyeMaxMagic;
        SullivanMagic.maxValue = GameManager.SullivanMaxMagic;

        UpdateLifeUI();
        UpdateMagicUI();

        GameManagerObject = GameObject.Find("GameManager");
        InventorySelectedItem = -1;

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
        if (GameManager.PartyCount == 3 && GameManager.SkyeInParty && !GameManager.SullivanInParty)
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
            enemyUnit[i].transform.rotation = Quaternion.Euler(0, 180, 0);
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
        Camera.SetActive(true);

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
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheatToInstantlyWin();
            }
        }

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

        if (GameManager.MCHealth <= 0)
        {
            state = BattleState.LOST;
            EndBattle();
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

        #region Select Team Member
        if ((state == BattleState.MCTURN || state == BattleState.RHYSTURN || state == BattleState.JAMEELTURN || state == BattleState.HARPERTURN || state == BattleState.SKYETURN || state == BattleState.SULLIVANTURN) && playerSelect)
        {
            //SelectionProcess
            playerSelectionParticle.SetActive(true);

            int membersInParty = playerTurnOrder.Count;

            playerSelectionParticle.transform.position = playerBattleStationLocations[playerUnitSelected].transform.position;

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (playerUnitSelected <= 0)
                {
                    playerUnitSelected = membersInParty - 1;
                }
                playerUnitSelected--;           
                playerSelectionParticle.transform.position = playerBattleStationLocations[playerUnitSelected].transform.position;
                Camera.transform.LookAt(playerBattleStationLocations[playerUnitSelected]);
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                playerUnitSelected++;
                if (playerUnitSelected >= membersInParty -1)
                {
                    playerUnitSelected = 0;
                }

                playerSelectionParticle.transform.position = playerBattleStationLocations[playerUnitSelected].transform.position;
                Camera.transform.LookAt(playerBattleStationLocations[playerUnitSelected]);
            }
        }
        #endregion
    }

    void NextTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        CharacterIdentifier upRightNow;
        if (isPlayerTurn)
        {
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
            case CharacterIdentifier.GracieMay:
                GracieMay();
                state = BattleState.GRACIEMAY;
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
            if (playerTurnOrder[0].ToString() == "MC")
            {
                Next.text = "Up Next:  " + GameManager.MCFirstName.ToString();
            }
            if (playerTurnOrder[0].ToString() == "GracieMay")
            {
                if (playerTurnOrder[1].ToString() == "MC")
                {
                    Next.text = "Up Next:  " + GameManager.MCFirstName.ToString();
                }
                else
                {
                    Next.text = "Up Next:  " + playerTurnOrder[1].ToString();
                }
            }
            else
            {
                Next.text = "Up Next:  " + playerTurnOrder[0].ToString();
            }
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
        #endregion
    }

    #region ItemManagement

    public void ToggleInventory() {
        Inventory.SetActive(!Inventory.activeInHierarchy);
    }

    #endregion
    public void AdvanceTurn()
    {
        backButtonItem.SetActive(false);
        MCMenu.SetActive(false);
        MCSpells.SetActive(false);
        ItemMenu.transform.localPosition = new Vector3(233, -900, 0);

        MCHealth.value = GameManager.MCHealth;
        RhysHealth.value = GameManager.RhysHealth;
        JameelHealth.value = GameManager.JameelHealth;
        HarperHealth.value = GameManager.HarperHealth;
        SkyeHealth.value = GameManager.SkyeHealth;
        SullivanHealth.value = GameManager.SullivanHealth;

        MCMagic.value = GameManager.MCMagic;
        RhysMagic.value = GameManager.RhysMagic;
        JameelMagic.value = GameManager.JameelMagic;
        HarperMagic.value = GameManager.HarperMagic;
        SkyeMagic.value = GameManager.SkyeMagic;
        SullivanMagic.value = GameManager.SullivanMagic;

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
        //Build into this system a little - add their Dodge score
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

        playerSelectionParticle.SetActive(false);
        playerSelect = false;
    }

    public void CancelAttack()
    {
        if (state == BattleState.MCTURN)
        {
            MCMenu.SetActive(true);
            MCSpells.SetActive(false);
            MCConfirmMenu.SetActive(false);
        }

        if (state == BattleState.RHYSTURN)
        {
            RhysMenu.SetActive(true);
            RhysSpells.SetActive(false);
            RhysConfirmMenu.SetActive(false);
        }

        if (state == BattleState.JAMEELTURN)
        {
            JameelMenu.SetActive(true);
            JameelSpells.SetActive(false);
            JameelConfirmMenu.SetActive(false);
        }

        if (state == BattleState.HARPERTURN)
        {
            HarperMenu.SetActive(true);
            HarperSpells.SetActive(false);
            HarperConfirmMenu.SetActive(false);
        }

        if (state == BattleState.SKYETURN)
        {
            SkyeMenu.SetActive(true);
            SkyeSpells.SetActive(false);
            SkyeConfirmMenu.SetActive(false);
        }

        if (state == BattleState.SULLIVANTURN)
        {
            SullivanMenu.SetActive(true);
            SullivanSpells.SetActive(false);
            SullivanConfirmMenu.SetActive(false);
        }

        GameManager.isRed = false;
        GameManager.isBlue = false;
        GameManager.isYellow = false;
        GameManager.isGreen = false;
        GameManager.isPhysical = false;

        enemySelectionParticle.SetActive(false);
        enemySelect = false;
    }

    void RemoveCurrentEnemy()
    {
        enemyTurnOrder.Remove(enemyUnit[enemyUnitSelected].myEnumValue);
        totalExp += enemyUnit[enemyUnitSelected].ExperienceToDistribute;
        totalExp += enemyUnit[enemyUnitSelected].ExperienceToDistribute;
        enemyCount--;

        enemySelectionParticle.transform.position = enemyBattleStationLocations[enemyUnitSelected].transform.position;
    }

    void AddCurrentEnemy()
    {
        enemyTurnOrder.Add(enemyUnit[enemyUnitSelected].myEnumValue);
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

        AdvanceTurn();
    }
    #endregion
    #region MCAttacks

    IEnumerator MCAttack()
    {
        //Attack and Defense up tracking
        if (AttackModifierTurnCount > 0)
        {
            AttackModifierTurnCount--;
        }
        if (DefenseModifierTurnCount > 0)
        {
            DefenseModifierTurnCount--;
        }
        if (AttackModifierTurnCount <= 0)
        {
            AttackModifier = 1.0f;
        }
        if (DefenseModifierTurnCount <= 0)
        {
            DefenseModifier = 1.0f;
        }
        //Evasion up tracking
        if (EvasionTurnCount > 0)
        {
            EvasionTurnCount--;
        }
        if (EvasionTurnCount <= 0)
        {
            EvasionModifier = 1.0f;
        }
        //Individual Defense Up
        if (DefenseMCTurn > 0)
        {
            DefenseMCTurn--;
        }
        if (DefenseMCTurn <= 0)
        {
            DefenseMC = 1;
        }

        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);
        //Modify the Spell1Damage and Spell1Magic used based on the player, the spell, and their level 
        if (state == BattleState.MCTURN)
        {
            if (throwRock)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    throwRock = false;
                    dialogueText.text = "Enemy is knocked out, select another target.";
                    yield return new WaitForSeconds(1f);
                    dialogueText.text = "Select someone to attack!";
                    MCMenu.SetActive(true);
                    MCSpells.SetActive(false);
                }
                else
                {
                    GameManager.MCMagic -= MC.MCSpell1MagicConsumed;
                    MCMagic.value = GameManager.MCMagic;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);

                    GameManager.isPhysical = true;
                    isDead = enemyUnit[enemyUnitSelected].ThrowRock(MC.MCSpell1Damage * AttackModifier + GameManager.MCDodge);

                    EnemyAnim();
                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();
                    }
                    NextTurn();
                }
            }

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
                    GameManager.MCHealth -= MC.MCSpell2MagicConsumed;
                    MCHealth.value = GameManager.MCHealth;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);

                    GameManager.isPhysical = true;
                    isDead = enemyUnit[enemyUnitSelected].Flippendo(MC.MCSpell2Damage * AttackModifier + GameManager.MCDodge);

                    EnemyAnim();
                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();
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
                    GameManager.isYellow = true;

                    float randChance = Random.Range(0, 100);

                    if ((randChance + GameManager.MCDADA) > 70)
                    {
                        hasBeenStunned = true;
                    }
                    if (hasBeenStunned)
                    {
                        stunnedName = enemyUnit[enemyUnitSelected].name;
                        EnemyAnim();
                        TurnOffAttackBools();
                    }
                    else
                    {
                        dialogueText.text = "The attack missed!";
                    }
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
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
                    GameManager.isYellow = true;

                    float randChance = Random.Range(0, 100);

                    if ((randChance + GameManager.MCDADA) > 10)
                    {
                        hasBeenStunned = true;
                    }
                    if (hasBeenStunned)
                    {
                        stunnedName = enemyUnit[enemyUnitSelected].name;
                        EnemyAnim();
                        TurnOffAttackBools();
                    }
                    else
                    {
                        dialogueText.text = "The attack missed!";
                    }
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
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
                    GameManager.isYellow = true;
                    isDead = enemyUnit[enemyUnitSelected].Incendio(MC.MCSpell5Damage * AttackModifier + GameManager.MCDADA);

                    EnemyAnim();

                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();
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
                    GameManager.isYellow = true;
                    isDead = enemyUnit[enemyUnitSelected].IncendioMaxima(MC.MCSpell6Damage * AttackModifier + GameManager.MCDADA);

                    EnemyAnim();
                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        RemoveCurrentEnemy();
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
                    GameManager.isRed = true;
                    isDead = enemyUnit[enemyUnitSelected].Avis(MC.MCSpell7Damage * AttackModifier + GameManager.MCTrans);

                    EnemyAnim();
                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        RemoveCurrentEnemy();
                    }
                    NextTurn();
                }
            }


            if (avisMaxima)
            {
                MCAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                MCMagic.value = GameManager.MCMagic;
                GameManager.MCMagic -= MC.MCSpell8MagicConsumed;
                GameManager.isRed = true;

                for (int i = 0; i < enemyUnit.Count; i++)
                {
                    isDead = enemyUnit[i].AvisMaxima(MC.MCSpell8Damage * AttackModifier + GameManager.MCTrans);

                    if (!isDead)
                    {
                        enemyAnim[i].Play("Armature|TakeDamage");
                    }
                    if (isDead)
                    {
                        yield return new WaitForSeconds(1.5f);
                        enemyAnim[i].SetBool("isDead", true);
                        enemyTurnOrder.Remove(enemyUnit[i].myEnumValue);
                        totalExp += enemyUnit[i].ExperienceToDistribute;
                        totalExp += enemyUnit[i].ExperienceToDistribute;
                        enemyCount--;
                    }
                }
                yield return new WaitForSeconds(2f);
                TurnOffAttackBools();
                
                NextTurn(); 
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

                    GameManager.isBlue = true;
                    isDead = enemyUnit[enemyUnitSelected].Glacius(MC.MCSpell9Damage * AttackModifier + GameManager.MCCharms);

                    EnemyAnim();

                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        RemoveCurrentEnemy();
                    }
                    NextTurn();
                }
            }


            if (minorCura)
            {
                GameManager.MCMagic -= MC.MCSpell10MagicConsumed;
                MCMagic.value = GameManager.MCMagic;
                MCAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Rhys")
                {
                    GameManager.RhysHealth += GameManager.RhysMaxHealth * .2f +GameManager.MCPotions;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Skye")
                {
                    GameManager.SkyeHealth += GameManager.SkyeMaxHealth * .2f + GameManager.MCPotions;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Harper")
                {
                    GameManager.HarperHealth += GameManager.HarperMaxHealth * .2f + GameManager.MCPotions;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Sullivan")
                {
                    GameManager.SullivanHealth += GameManager.SullivanMaxHealth * .2f + GameManager.MCPotions;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Jameel")
                {
                    GameManager.JameelHealth += GameManager.JameelMaxHealth * .2f + GameManager.MCPotions;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "MC")
                {
                    GameManager.MCHealth += GameManager.MCMaxHealth * .2f + GameManager.MCPotions;
                    
                }
                UpdateLifeUI();
                TurnOffAttackBools();
                NextTurn();
            }

            if (impetumSubsisto)
            {
                GameManager.MCMagic -= MC.MCSpell11MagicConsumed;
                MCMagic.value = GameManager.MCMagic;
                MCAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Rhys")
                {
                    DefenseRhys = .5f;
                    DefenseRhysTurn = 3;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Skye")
                {
                    DefenseSkye = .5f;
                    DefenseSkyeTurn = 3;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Harper")
                {
                    DefenseHarper = .5f;
                    DefenseHarperTurn = 3;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Sullivan")
                {
                    DefenseSullivan = .5f;
                    DefenseSullivanTurn = 3;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Jameel")
                {
                    DefenseJameel = .5f;
                    DefenseJameelTurn = 3;
                }

                if (playerTurnOrder[playerUnitSelected - 1].ToString() == "MC")
                {
                    DefenseMC = .5f;
                    DefenseMCTurn = 3;

                }
                UpdateLifeUI();
                TurnOffAttackBools();
                NextTurn();
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

                    GameManager.isBlue = true;
                    isDead = enemyUnit[enemyUnitSelected].Augamenti(MC.MCSpell12Damage * AttackModifier + GameManager.MCCharms);

                    EnemyAnim();

                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        RemoveCurrentEnemy();
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
                    GameManager.MCHealth -= MC.MCSpell13MagicConsumed;
                    MCHealth.value = GameManager.MCHealth;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);

                    GameManager.isPhysical = true;
                    isDead = enemyUnit[enemyUnitSelected].MothsDeorsum(MC.MCSpell13Damage * AttackModifier + GameManager.MCDodge);

                    EnemyAnim();

                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();
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
                    GameManager.MCHealth -= MC.MCSpell14MagicConsumed;
                    MCHealth.value = GameManager.MCHealth;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);

                    GameManager.isPhysical = true;
                    isDead = enemyUnit[enemyUnitSelected].MothsInteriore(MC.MCSpell14Damage * AttackModifier + GameManager.MCDodge);

                    EnemyAnim();

                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        RemoveCurrentEnemy();
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
                    GameManager.MCHealth -= MC.MCSpell15MagicConsumed;
                    MCHealth.value = GameManager.MCHealth;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);

                    GameManager.isPhysical = true;
                    isDead = enemyUnit[enemyUnitSelected].InternaCombustione(MC.MCSpell15Damage * AttackModifier + GameManager.MCDodge);


                    float randChance = Random.Range(0, 100);

                    if ((randChance + GameManager.MCDodge) > 50)
                    {
                        dialogueText.text = enemyUnit[enemyUnitSelected].name + " has been confused!";
                        EnemyThatIsConfusedMC = enemyUnit[enemyUnitSelected].name;
                        isConfused = true;
                    }

                    EnemyAnim();

                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        RemoveCurrentEnemy();
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
                    GameManager.MCHealth -= MC.MCSpell16MagicConsumed;
                    MCHealth.value = GameManager.MCHealth;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);

                    GameManager.isPhysical = true;
                    isDead = enemyUnit[enemyUnitSelected].Bombarda(MC.MCSpell16Damage * AttackModifier + GameManager.MCDodge);

                    EnemyAnim();

                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        RemoveCurrentEnemy();
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
                    GameManager.MCHealth -= MC.MCSpell17MagicConsumed;
                    MCHealth.value = GameManager.MCHealth;
                    MCAnim.Play("Armature|Attack");
                    yield return new WaitForSeconds(2f);

                    GameManager.isPhysical = true;
                    isDead = enemyUnit[enemyUnitSelected].BombardaMaxima(MC.MCSpell17Damage * AttackModifier + GameManager.MCDodge);

                    EnemyAnim();

                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        RemoveCurrentEnemy();
                    }
                    NextTurn();
                }
            }


            if (bombardaUltima)
            {
                MCAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                MCMagic.value = GameManager.MCMagic;
                GameManager.MCMagic -= MC.MCSpell21MagicConsumed;
                GameManager.isPhysical = true;

                for (int i = 0; i < enemyUnit.Count; i++)
                {
                    isDead = enemyUnit[i].AvisMaxima(MC.MCSpell21Damage * AttackModifier + GameManager.MCDodge);

                    if (!isDead)
                    {
                        enemyAnim[i].Play("Armature|TakeDamage");
                    }
                    if (isDead)
                    {
                        yield return new WaitForSeconds(1.5f);
                        enemyAnim[i].SetBool("isDead", true);
                        enemyTurnOrder.Remove(enemyUnit[i].myEnumValue);
                        totalExp += enemyUnit[i].ExperienceToDistribute;
                        totalExp += enemyUnit[i].ExperienceToDistribute;
                        enemyCount--;
                    }
                }
                yield return new WaitForSeconds(2f);
                TurnOffAttackBools();

                NextTurn();
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

                    GameManager.isBlue = true;
                    isDead = enemyUnit[enemyUnitSelected].Diffindo(MC.MCSpell22Damage * AttackModifier + GameManager.MCCharms);

                    EnemyAnim();

                    TurnOffAttackBools();
                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();
                    }
                    NextTurn();
                }
            }


            if (diffindoMaxima)
            {
                if (enemyUnit[enemyUnitSelected].currentHP <= 0)
                {
                    diffindoMaxima = false;
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

                    GameManager.isBlue = true;
                    isDead = enemyUnit[enemyUnitSelected].DiffindoMaxima(MC.MCSpell23Damage * AttackModifier + GameManager.MCCharms);

                    EnemyAnim();

                    TurnOffAttackBools();

                    yield return new WaitForSeconds(2f);

                    //This checks to see if the Enemy is Dead or has HP remaining
                    if (isDead)
                    {
                        RemoveCurrentEnemy();
                    }
                    NextTurn();
                }
            }

            if (mcUsingItem) {
                ItemObject item = InventoryContainer.Container[InventorySelectedItem].item;
                if (item.type == ItemType.Support) {
                    if (item.multiTarget == true) {
                        GameManager.instance.UseItem(item, "all");
                    } else {
                        GameManager.instance.UseItem(item, "MC");
                    }
                } else if (item.type == ItemType.Offensive) {
                    OffensiveItem oItem = (OffensiveItem)item;
                    if (item.multiTarget == true) {
                        // TODO: code to hit all enemies
                    } else {
                        enemySelect = true;
                        // TODO: Code to hit a specific enemy
                    }
                }

                UpdateLifeUI();
                UpdateMagicUI();

                bool outOfStock = InventoryContainer.Container[InventorySelectedItem].RemoveAmount(1);
                if (outOfStock) {
                    Inventory.GetComponent<BattleInventory>().RemoveItem(InventorySelectedItem);
                } else {
                    Inventory.GetComponent<BattleInventory>().UpdateItem(InventorySelectedItem);
                }
                NextTurn();
            }

        }
    }

    void TurnOffAttackBools()
    {
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

        GameManager.isRed = false;
        GameManager.isBlue = false;
        GameManager.isGreen = false;
        GameManager.isYellow = false;
        GameManager.isPhysical = false;

        dialogueText.text = "The attack is successful!";
    }

    #endregion

    #region RhysAttacks
    IEnumerator RhysAttack()
    {
        //Individual Defense Up
        if (DefenseRhysTurn > 0)
        {
            DefenseRhysTurn--;
        }
        if (DefenseRhysTurn <= 0)
        {
            DefenseRhys = 1;
        }
        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);

        if (rhysThrowRock)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                throwRock = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                RhysMenu.SetActive(true);
                RhysSpells.SetActive(false);
            }
            else
            {
                GameManager.RhysMagic -= Rhys.RhysSpell1MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].ThrowRock(Rhys.RhysSpell1Damage * AttackModifier + GameManager.RhysDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }

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
                GameManager.RhysHealth -= Rhys.RhysSpell2MagicConsumed;
                RhysHealth.value = GameManager.RhysHealth;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].RhysFlippendo(Rhys.RhysSpell2Damage * AttackModifier + GameManager.RhysDodge);

                EnemyAnim();

                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    RemoveCurrentEnemy();
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
                GameManager.isYellow = true;

                float randChance = Random.Range(0, 100);

                if ((randChance + GameManager.RhysDADA) > 60)
                {
                    hasBeenStunned = true;
                }
                if (hasBeenStunned)
                {
                    stunnedName = enemyUnit[enemyUnitSelected].name;
                    EnemyAnim();
                    TurnOffAttackBools();
                }
                else
                {
                    dialogueText.text = "The attack missed!";
                }
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
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
                GameManager.RhysHealth -= Rhys.RhysSpell4MagicConsumed;
                RhysHealth.value = GameManager.RhysHealth;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].RhysMothsDeorsum(Rhys.RhysSpell4Damage * AttackModifier + GameManager.RhysDodge);

                EnemyAnim();

                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    RemoveCurrentEnemy();
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
                GameManager.RhysHealth -= Rhys.RhysSpell5MagicConsumed;
                RhysHealth.value = GameManager.RhysHealth;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].RhysMothsInteriore(Rhys.RhysSpell5Damage * AttackModifier + GameManager.RhysDodge);

                EnemyAnim();

                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    RemoveCurrentEnemy();
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
                GameManager.RhysHealth -= Rhys.RhysSpell6MagicConsumed;
                RhysHealth.value = GameManager.RhysHealth;
                RhysAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].RhysInternumCombustione(Rhys.RhysSpell6Damage * AttackModifier + GameManager.RhysDodge);


                float randChance = Random.Range(0, 100);

                if ((randChance + GameManager.RhysDodge) > 50)
                {
                    dialogueText.text = enemyUnit[enemyUnitSelected].name + " has been confused!";
                    EnemyThatIsConfusedRhys = enemyUnit[enemyUnitSelected].name;
                    isConfused = true;
                }

                EnemyAnim();

                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isYellow = true;
                isDead = enemyUnit[enemyUnitSelected].RhysFlippendo(Rhys.RhysSpell8Damage * AttackModifier + GameManager.RhysDADA);

                EnemyAnim();

                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isRed = true;
                isDead = enemyUnit[enemyUnitSelected].RhysWaddiwasi(Rhys.RhysSpell10Damage * AttackModifier + GameManager.RhysTrans);

                EnemyAnim();

                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isRed = true;
                isDead = enemyUnit[enemyUnitSelected].RhysConjurePugione(Rhys.RhysSpell11Damage * AttackModifier + GameManager.RhysTrans);

                EnemyAnim();

                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }

        if (rhysImpetumSubsisto)
        {
            GameManager.RhysMagic -= Rhys.RhysSpell12MagicConsumed;
            RhysMagic.value = GameManager.RhysMagic;
            RhysAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Rhys")
            {
                DefenseRhys = .5f;
                DefenseRhysTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Skye")
            {
                DefenseSkye = .5f;
                DefenseSkyeTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Harper")
            {
                DefenseHarper = .5f;
                DefenseHarperTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Sullivan")
            {
                DefenseSullivan = .5f;
                DefenseSullivanTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Jameel")
            {
                DefenseJameel = .5f;
                DefenseJameelTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "MC")
            {
                DefenseMC = .5f;
                DefenseMCTurn = 3;

            }
            UpdateLifeUI();
            TurnOffAttackBools();
            NextTurn();
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

                GameManager.isYellow = true;
                isDead = enemyUnit[enemyUnitSelected].RhysIraUolueris(Rhys.RhysSpell13Damage * AttackModifier + GameManager.RhysDADA);

                EnemyAnim();

                yield return new WaitForSeconds(1f);

                isDead = enemyUnit[enemyUnitSelected].RhysIraUolueris(Rhys.RhysSpell13Damage * AttackModifier + GameManager.RhysDADA);

                EnemyAnim();

                yield return new WaitForSeconds(1f);

                if (isDead)
                {
                    RemoveCurrentEnemy();
                }

                TurnOffAttackBools();
                NextTurn();
            }
        }
    }
    #endregion

    #region Jameel Attacks
    IEnumerator JameelAttack()
    {
        //Individual Defense Up
        if (DefenseJameelTurn > 0)
        {
            DefenseJameelTurn--;
        }
        if (DefenseJameelTurn <= 0)
        {
            DefenseJameel = 1;
        }

        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);

        if (jameelThrowRock)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                throwRock = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                JameelMenu.SetActive(true);
                JameelSpells.SetActive(false);
            }
            else
            {
                GameManager.JameelMagic -= Jameel.JameelSpell1MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].ThrowRock(Jameel.JameelSpell1Damage * AttackModifier + GameManager.JameelDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }
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
                GameManager.JameelHealth -= Jameel.JameelSpell2MagicConsumed;
                JameelHealth.value = GameManager.JameelHealth;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].JameelFlippendo(Jameel.JameelSpell2Damage * AttackModifier + GameManager.JameelDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }

        if (jameelMinorCura)
        {
            GameManager.JameelMagic -= Jameel.JameelSpell4MagicConsumed;
            JameelMagic.value = GameManager.JameelMagic;
            JameelAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Rhys")
            {
                GameManager.RhysHealth += GameManager.RhysMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Skye")
            {
                GameManager.SkyeHealth += GameManager.SkyeMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Harper")
            {
                GameManager.HarperHealth += GameManager.HarperMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Sullivan")
            {
                GameManager.SullivanHealth += GameManager.SullivanMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Jameel")
            {
                GameManager.JameelHealth += GameManager.JameelMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "MC")
            {
                GameManager.MCHealth += GameManager.MCMaxHealth * .2f;

            }
            UpdateLifeUI();
            TurnOffAttackBools();
            NextTurn();
        }

        if (jameelMaiorCura)
        {
            GameManager.JameelMagic -= Jameel.JameelSpell5MagicConsumed;
            JameelMagic.value = GameManager.JameelMagic;
            JameelAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Rhys")
            {
                GameManager.RhysHealth += GameManager.RhysMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Skye")
            {
                GameManager.SkyeHealth += GameManager.SkyeMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Harper")
            {
                GameManager.HarperHealth += GameManager.HarperMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Sullivan")
            {
                GameManager.SullivanHealth += GameManager.SullivanMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Jameel")
            {
                GameManager.JameelHealth += GameManager.JameelMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "MC")
            {
                GameManager.MCHealth += GameManager.MCMaxHealth * .6f;

            }
            UpdateLifeUI();
            TurnOffAttackBools();
            NextTurn();
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

                GameManager.isBlue = true;
                isDead = enemyUnit[enemyUnitSelected].JameelPartumNix(Jameel.JameelSpell6Damage * AttackModifier + GameManager.JameelCharms);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }

        if (jameelHiemsImpetus)
        {
            JameelAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);
            JameelMagic.value = GameManager.JameelMagic;
            GameManager.JameelMagic -= Jameel.JameelSpell7MagicConsumed;
            GameManager.isBlue = true;

            for (int i = 0; i < enemyUnit.Count; i++)
            {
                isDead = enemyUnit[i].JameelHiemsImpetus(Jameel.JameelSpell7Damage * AttackModifier + GameManager.JameelCharms);

                if (!isDead)
                {
                    enemyAnim[i].Play("Armature|TakeDamage");
                }
                if (isDead)
                {
                    yield return new WaitForSeconds(1f);
                    enemyAnim[i].SetBool("isDead", true);
                    enemyTurnOrder.Remove(enemyUnit[i].myEnumValue);
                    totalExp += enemyUnit[i].ExperienceToDistribute;
                    totalExp += enemyUnit[i].ExperienceToDistribute;
                    enemyCount--;
                }
            }
            yield return new WaitForSeconds(2f);
            TurnOffAttackBools();

            NextTurn();
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
                GameManager.JameelHealth -= Jameel.JameelSpell8MagicConsumed;
                JameelHealth.value = GameManager.JameelHealth;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].JameelBombarda(Jameel.JameelSpell8Damage * AttackModifier + GameManager.JameelDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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
                GameManager.JameelHealth -= Jameel.JameelSpell9MagicConsumed;
                JameelHealth.value = GameManager.JameelHealth;
                JameelAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].JameelBombardaMaxima(Jameel.JameelSpell9Damage * AttackModifier + GameManager.JameelDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }

        if (jameelBombardaUltima)
        {
            JameelAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);
            JameelMagic.value = GameManager.JameelMagic;
            GameManager.JameelMagic -= Jameel.JameelSpell9MagicConsumed;
            GameManager.isPhysical = true;

            for (int i = 0; i < enemyUnit.Count; i++)
            {
                isDead = enemyUnit[i].JameelBombardaMaxima(Jameel.JameelSpell9Damage * AttackModifier + GameManager.MCDodge);

                if (!isDead)
                {
                    enemyAnim[i].Play("Armature|TakeDamage");
                }
                if (isDead)
                {
                    yield return new WaitForSeconds(1.5f);
                    enemyAnim[i].SetBool("isDead", true);
                    enemyTurnOrder.Remove(enemyUnit[i].myEnumValue);
                    totalExp += enemyUnit[i].ExperienceToDistribute;
                    totalExp += enemyUnit[i].ExperienceToDistribute;
                    enemyCount--;
                }
            }
            yield return new WaitForSeconds(2f);
            TurnOffAttackBools();

            NextTurn();
        }

        if (jameelRepellere)
        {
            GameManager.JameelMagic -= Jameel.JameelSpell10MagicConsumed;
            JameelMagic.value = GameManager.JameelMagic;
            JameelAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);

            if (playerTurnOrder[playerUnitSelected+1].ToString() == "Rhys")
            {
                playerName = "Rhys";
            }

            if (playerTurnOrder[playerUnitSelected+1].ToString() == "Skye")
            {
                playerName = "Skye";
            }

            if (playerTurnOrder[playerUnitSelected+1].ToString() == "Harper")
            {
                playerName = "Harper";
            }

            if (playerTurnOrder[playerUnitSelected+1].ToString() == "Sullivan")
            {
                playerName = "Sullivan";
            }

            if (playerTurnOrder[playerUnitSelected+1].ToString() == "Jameel")
            {
                playerName = "Jameel";
            }

            if (playerTurnOrder[playerUnitSelected+1].ToString() == "MC")
            {
                playerName = GameManager.MCFirstName;
            }
            repelAttack = true;
            UpdateLifeUI();
            TurnOffAttackBools();
            NextTurn();
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

                GameManager.isBlue = true;
                isDead = enemyUnit[enemyUnitSelected].JameelDiffindo(Jameel.JameelSpell12Damage * AttackModifier + GameManager.JameelCharms);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isBlue = true;
                isDead = enemyUnit[enemyUnitSelected].JameelDiffindoMaxima(Jameel.JameelSpell13Damage * AttackModifier + GameManager.JameelCharms);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }

        if (jameelImpetumSubsisto)
        {
            GameManager.JameelMagic -= Jameel.JameelSpell14MagicConsumed;
            JameelMagic.value = GameManager.JameelMagic;
            JameelAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Rhys")
            {
                DefenseRhys = .5f;
                DefenseRhysTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Skye")
            {
                DefenseSkye = .5f;
                DefenseSkyeTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Harper")
            {
                DefenseHarper = .5f;
                DefenseHarperTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Sullivan")
            {
                DefenseSullivan = .5f;
                DefenseSullivanTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Jameel")
            {
                DefenseJameel = .5f;
                DefenseJameelTurn = 3;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "MC")
            {
                DefenseMC = .5f;
                DefenseMCTurn = 3;

            }
            UpdateLifeUI();
            TurnOffAttackBools();
            NextTurn();
        }
    }
    #endregion

    #region HarperAttacks
    IEnumerator HarperAttack()
    {
        //Individual Defense Up
        if (DefenseHarperTurn > 0)
        {
            DefenseHarperTurn--;
        }
        if (DefenseHarperTurn <= 0)
        {
            DefenseHarper = 1;
        }

        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);

        if (harperThrowRock)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                throwRock = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
            }
            else
            {
                GameManager.HarperMagic -= Harper.HarperSpell1MagicConsumed;
                HarperMagic.value = GameManager.HarperMagic;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].ThrowRock(Harper.HarperSpell1Damage * AttackModifier + GameManager.HarperDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }
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
                GameManager.HarperHealth -= Harper.HarperSpell2MagicConsumed;
                HarperHealth.value = GameManager.HarperHealth;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].HarperFlippendo(Harper.HarperSpell2Damage * AttackModifier + GameManager.HarperDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isYellow = true;
                isDead = enemyUnit[enemyUnitSelected].HarperMinorFortitudinem(Harper.HarperSpell4Damage * AttackModifier + GameManager.HarperDADA);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isYellow = true;
                isDead = enemyUnit[enemyUnitSelected].HarperMoserateFortitudinem(Harper.HarperSpell5Damage * AttackModifier + GameManager.HarperDADA);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isYellow = true;
                isDead = enemyUnit[enemyUnitSelected].HarperMaiorFortitudinem(Harper.HarperSpell6Damage * AttackModifier + GameManager.HarperDADA);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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
                GameManager.HarperHealth -= Harper.HarperSpell7MagicConsumed;
                HarperHealth.value = GameManager.HarperHealth;
                HarperAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].HarperInternumCombustione(Harper.HarperSpell7Damage * AttackModifier + GameManager.HarperDodge);

                float randChance = Random.Range(0, 100);

                if ((randChance + GameManager.HarperDodge) > 50)
                {
                    dialogueText.text = enemyUnit[enemyUnitSelected].name + " has been confused!";
                    EnemyThatIsConfusedHarper = enemyUnit[enemyUnitSelected].name;
                    isConfused = true;
                }

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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
                GameManager.isPhysical = true;

                float randChance = Random.Range(0, 100);

                if ((randChance + GameManager.HarperDodge) > 40)
                {
                    hasBeenStunned = true;
                }
                if (hasBeenStunned)
                {
                    stunnedName = enemyUnit[enemyUnitSelected].name;
                    EnemyAnim();
                    TurnOffAttackBools();
                }
                else
                {
                    dialogueText.text = "The attack missed!";
                }
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                NextTurn();
            }
        }

        if (harperLociPraesidium)
        {
            GameManager.HarperHealth -= Harper.HarperSpell9MagicConsumed;
            HarperHealth.value = GameManager.HarperHealth;
            HarperAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);

            if (playerTurnOrder[playerUnitSelected +1].ToString() == "Rhys")
            {
                    
                playerToBlock = "Rhys";
            }

            if (playerTurnOrder[playerUnitSelected +1].ToString() == "Skye")
            {
                playerToBlock = "Skye";
            }

            if (playerTurnOrder[playerUnitSelected +1].ToString() == "Harper")
            {
                playerToBlock = "Harper";
            }

            if (playerTurnOrder[playerUnitSelected +1].ToString() == "Sullivan")
            {
                playerToBlock = "Sullivan";
            }

            if (playerTurnOrder[playerUnitSelected +1].ToString() == "Jameel")
            {
                playerToBlock = "Jameel";
            }

            if (playerTurnOrder[playerUnitSelected +1].ToString() == "MC")
            {
                playerToBlock = "MC";

            }
            singleBlock = true;

            UpdateLifeUI();
            TurnOffAttackBools();
            NextTurn();
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

                GameManager.isYellow = true;

                int ConfusedRandom = Random.Range(0, 100);
                ConfusedRandom = 100;

                if (ConfusedRandom > 50 || enemyUnit[enemyUnitSelected].weakYellow)
                {
                    isConfused = true;
                    EnemyThatIsConfusedHarper = enemyUnit[enemyUnitSelected].name;
                }

                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                NextTurn();
            }
        }

        if (harperPulsateSunt)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                pulsateSunt = false;
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
                GameManager.isYellow = true;

                float randChance = Random.Range(0, 100);

                if ((randChance + GameManager.HarperDADA) > 70)
                {
                    hasBeenStunned = true;
                }
                if (hasBeenStunned)
                {
                    stunnedName = enemyUnit[enemyUnitSelected].name;
                    EnemyAnim();
                    TurnOffAttackBools();
                }
                else
                {
                    dialogueText.text = "The attack missed!";
                }
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                NextTurn();
            }
        }

        if (harperFumes)
        {
            HarperAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);
            HarperMagic.value = GameManager.HarperMagic;
            GameManager.HarperMagic -= Harper.HarperSpell9MagicConsumed;
            GameManager.isYellow = true;

            for (int i = 0; i < enemyUnit.Count; i++)
            {
                isDead = enemyUnit[i].HarperFumes(Harper.HarperSpell12Damage * AttackModifier + GameManager.HarperDADA);

                if (!isDead)
                {
                    enemyAnim[i].Play("Armature|TakeDamage");
                }
                if (isDead)
                {
                    yield return new WaitForSeconds(1.5f);
                    enemyAnim[i].SetBool("isDead", true);
                    enemyTurnOrder.Remove(enemyUnit[i].myEnumValue);
                    totalExp += enemyUnit[i].ExperienceToDistribute;
                    totalExp += enemyUnit[i].ExperienceToDistribute;
                    enemyCount--;
                }
            }
            yield return new WaitForSeconds(2f);
            TurnOffAttackBools();

            NextTurn();
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

                GameManager.isYellow = true;
                isDead = enemyUnit[enemyUnitSelected].HarperDiminuendo(enemyUnit[enemyUnitSelected].currentHP * .5f);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }
    }

    #endregion

    #region SkyeAttacks
    IEnumerator SkyeAttack()
    {
        //Individual Defense Up
        if (DefenseSkyeTurn > 0)
        {
            DefenseSkyeTurn--;
        }
        if (DefenseSkyeTurn <= 0)
        {
            DefenseSkye = 1;
        }

        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);

        if (skyeThrowRock)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                throwRock = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SkyeMenu.SetActive(true);
                SkyeSpells.SetActive(false);
            }
            else
            {
                GameManager.SkyeMagic -= Skye.SkyeSpell1MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].ThrowRock(Skye.SkyeSpell1Damage * AttackModifier + GameManager.SkyeDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }
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
                GameManager.SkyeHealth -= Skye.SkyeSpell2MagicConsumed;
                SkyeHealth.value = GameManager.SkyeHealth;
                SkyeAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].SkyeFlippendo(Skye.SkyeSpell2Damage * AttackModifier + GameManager.SkyeDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }

        if (skyeMinorCura)
        {
            GameManager.SkyeMagic -= Skye.SkyeSpell3MagicConsumed;
            SkyeMagic.value = GameManager.SkyeMagic;
            SkyeAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Rhys")
            {
                GameManager.RhysHealth += GameManager.RhysMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Skye")
            {
                GameManager.SkyeHealth += GameManager.SkyeMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Harper")
            {
                GameManager.HarperHealth += GameManager.HarperMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Sullivan")
            {
                GameManager.SullivanHealth += GameManager.SullivanMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Jameel")
            {
                GameManager.JameelHealth += GameManager.JameelMaxHealth * .2f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "MC")
            {
                GameManager.MCHealth += GameManager.MCMaxHealth * .2f;

            }
            UpdateLifeUI();
            TurnOffAttackBools();
            NextTurn();
        }

        if (skyeMaiorCura)
        {
            GameManager.SkyeMagic -= Skye.SkyeSpell4MagicConsumed;
            SkyeMagic.value = GameManager.SkyeMagic;
            SkyeAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Rhys")
            {
                GameManager.RhysHealth += GameManager.RhysMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Skye")
            {
                GameManager.SkyeHealth += GameManager.SkyeMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Harper")
            {
                GameManager.HarperHealth += GameManager.HarperMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Sullivan")
            {
                GameManager.SullivanHealth += GameManager.SullivanMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "Jameel")
            {
                GameManager.JameelHealth += GameManager.JameelMaxHealth * .6f;
            }

            if (playerTurnOrder[playerUnitSelected - 1].ToString() == "MC")
            {
                GameManager.MCHealth += GameManager.MCMaxHealth * .6f;

            }
            UpdateLifeUI();
            TurnOffAttackBools();
            NextTurn();
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

                GameManager.isGreen = true;
                isDead = enemyUnit[enemyUnitSelected].SkyeAntidoteToCommonPoisons(Skye.SkyeSpell8Damage * AttackModifier + GameManager.SkyePotions);
                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isBlue = true;

                int ConfusedRandom = Random.Range(0, 100);
                ConfusedRandom = 100;

                if (ConfusedRandom > 50 || enemyUnit[enemyUnitSelected].weakBlue)
                {
                    isSkyeConfused = true;
                    EnemyThatIsConfusedSkye = enemyUnit[enemyUnitSelected].name;
                }

                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

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

                GameManager.isYellow = true;
                isDead = enemyUnit[enemyUnitSelected].SkyeIraUolueris(Skye.SkyeSpell11Damage * AttackModifier + GameManager.SkyeDADA);
                EnemyAnim();

                yield return new WaitForSeconds(1f);

                isDead = enemyUnit[enemyUnitSelected].SkyeIraUolueris(Skye.SkyeSpell11Damage * AttackModifier + GameManager.SkyeDADA);
                EnemyAnim();

                yield return new WaitForSeconds(1f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                TurnOffAttackBools();
                NextTurn();
            }
        }
    }

    #endregion

    #region Sullivan Attacks
    IEnumerator SullivanAttack()
    {
        //Individual Defense Up
        if (DefenseSullivanTurn > 0)
        {
            DefenseSullivanTurn--;
        }
        if (DefenseSullivanTurn <= 0)
        {
            DefenseSullivan = 1;
        }

        //To Do Damage Enemy
        yield return new WaitForSeconds(1f);

        if (sullivanRockThrow)
        {
            if (enemyUnit[enemyUnitSelected].currentHP <= 0)
            {
                throwRock = false;
                dialogueText.text = "Enemy is knocked out, select another target.";
                yield return new WaitForSeconds(1f);
                dialogueText.text = "Select someone to attack!";
                SullivanMenu.SetActive(true);
                SullivanSpells.SetActive(false);
            }
            else
            {
                GameManager.SullivanMagic -= Sullivan.SullivanSpell1MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].ThrowRock(Sullivan.SullivanSpell1Damage * AttackModifier + GameManager.SullivanDodge);

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }

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
                GameManager.SullivanHealth -= Sullivan.SullivanSpell2MagicConsumed;
                SullivanHealth.value = GameManager.SullivanHealth;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);

                GameManager.isPhysical = true;
                isDead = enemyUnit[enemyUnitSelected].SullivanFlippendo(Sullivan.SullivanSpell2Damage * AttackModifier + GameManager.SullivanDodge);
                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                int chanceToInstaKill = Random.Range(0, 100);

                GameManager.isRed = true;
                if (!Boss && (chanceToInstaKill + GameManager.SullivanLevel + GameManager.SullivanTrans) > 65)
                {
                    float SullivanSpell3ModifiedDamage = enemyUnit[enemyUnitSelected].currentHP;
                    isDead = enemyUnit[enemyUnitSelected].SullivanExiling(SullivanSpell3ModifiedDamage * AttackModifier + GameManager.SullivanTrans);
                    EnemyAnim();
                }
                else
                {
                    float SullivanSpell3ModifiedDamage = 0;
                    isDead = enemyUnit[enemyUnitSelected].SullivanExiling(SullivanSpell3ModifiedDamage * AttackModifier + GameManager.SullivanTrans);
                    dialogueText.text = "Miss!";
                }
                
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isRed = true;
                isDead = enemyUnit[enemyUnitSelected].SullivanIgnusMagnum(Sullivan.SullivanSpell5Damage * AttackModifier + GameManager.SullivanTrans);
                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isRed = true;
                isDead = enemyUnit[enemyUnitSelected].SullivanSagittaLecit(Sullivan.SullivanSpell6Damage * AttackModifier + GameManager.SullivanTrans);
                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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

                GameManager.isRed = true;
                isDead = enemyUnit[enemyUnitSelected].SullivanMonstrumSella(Sullivan.SullivanSpell7Damage * AttackModifier + GameManager.SullivanTrans);


                float randChance = Random.Range(0, 100);

                if ((randChance + GameManager.SullivanTrans) > 50)
                {
                    dialogueText.text = enemyUnit[enemyUnitSelected].name + " has been stunned!";
                    hasBeenStunned = true;
                }
                if (hasBeenStunned)
                {
                    stunnedName = enemyUnit[enemyUnitSelected].name;
                    EnemyAnim();
                    TurnOffAttackBools();
                }

                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
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
                GameManager.SullivanMagic -= Sullivan.SullivanSpell6MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                SullivanAnim.Play("Armature|Attack");
                yield return new WaitForSeconds(2f);
                GameManager.isRed = true;

                hasBeenStunned = true;

                stunnedName = enemyUnit[enemyUnitSelected].name;
                EnemyAnim();
                TurnOffAttackBools();

                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                NextTurn();
            }
        }

        if (sullivanUltimumChao)
        {
            SullivanAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);
            SullivanMagic.value = GameManager.SullivanMagic;
            GameManager.SullivanMagic -= Sullivan.SullivanSpell7MagicConsumed;
            GameManager.isPhysical = true;

            for (int i = 0; i < enemyUnit.Count; i++)
            {
                isDead = enemyUnit[i].SullivanUltimumChao(Sullivan.SullivanSpell9Damage * AttackModifier + GameManager.SullivanDodge);

                if (!isDead)
                {
                    enemyAnim[i].Play("Armature|TakeDamage");
                }
                if (isDead)
                {
                    yield return new WaitForSeconds(1f);
                    enemyAnim[i].SetBool("isDead", true);
                    enemyTurnOrder.Remove(enemyUnit[i].myEnumValue);
                    totalExp += enemyUnit[i].ExperienceToDistribute;
                    totalExp += enemyUnit[i].ExperienceToDistribute;
                    enemyCount--;
                }
            }
            yield return new WaitForSeconds(2f);
            TurnOffAttackBools();

            NextTurn();
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

                GameManager.isRed = true;
                if (!Boss)
                {
                    float currentEnemyHP = enemyUnit[enemyUnitSelected].currentHP;
                    float currentSullivanHP = GameManager.SullivanHealth;

                    if (currentEnemyHP >= GameManager.SullivanMaxHealth)
                    {
                        currentEnemyHP = GameManager.SullivanMaxHealth;
                    }

                    GameManager.SullivanHealth = currentEnemyHP;
                    enemyUnit[enemyUnitSelected].currentHP = currentSullivanHP;
                }
                else
                {
                    dialogueText.text = "... The target appears immune to the transfer.";
                }
                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }

        if (sullivanEngorgement)
        {
            GameManager.SullivanMagic -= Sullivan.SullivanSpell11MagicConsumed;
            SullivanMagic.value = GameManager.SullivanMagic;
            SullivanAnim.Play("Armature|Attack");
            yield return new WaitForSeconds(2f);

            if (playerTurnOrder[playerUnitSelected + 1].ToString() == "Rhys")
            {
                GameManager.RhysHealth *= 2;
                if (GameManager.RhysHealth > GameManager.RhysMaxHealth)
                {
                    GameManager.RhysHealth = GameManager.RhysMaxHealth;
                }
            }

            if (playerTurnOrder[playerUnitSelected + 1].ToString() == "Skye")
            {
                GameManager.SkyeHealth *= 2;
                if (GameManager.SkyeHealth > GameManager.SkyeMaxHealth)
                {
                    GameManager.SkyeHealth = GameManager.SkyeMaxHealth;
                }
            }

            if (playerTurnOrder[playerUnitSelected + 1].ToString() == "Harper")
            {
                GameManager.HarperHealth *= 2;
                if (GameManager.HarperHealth > GameManager.HarperMaxHealth)
                {
                    GameManager.HarperHealth = GameManager.HarperMaxHealth;
                }
            }

            if (playerTurnOrder[playerUnitSelected + 1].ToString() == "Sullivan")
            {
                print(GameManager.SullivanHealth);
                GameManager.SullivanHealth *= 2;
                if (GameManager.SullivanHealth > GameManager.SullivanMaxHealth)
                {
                    GameManager.SullivanHealth = GameManager.SullivanMaxHealth;
                }
                print(GameManager.SullivanHealth);
            }

            if (playerTurnOrder[playerUnitSelected + 1].ToString() == "Jameel")
            {
                GameManager.JameelHealth *= 2;
                if (GameManager.JameelHealth > GameManager.JameelMaxHealth)
                {
                    GameManager.JameelHealth = GameManager.JameelMaxHealth;
                }
            }

            if (playerTurnOrder[playerUnitSelected + 1].ToString() == "MC")
            {
                GameManager.MCHealth *= 2;
                if (GameManager.MCHealth > GameManager.MCMaxHealth)
                {
                    GameManager.MCHealth = GameManager.MCMaxHealth;
                }
            }

            UpdateLifeUI();
            TurnOffAttackBools();
            NextTurn();
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

                GameManager.isRed = true;
                isDead = enemyUnit[enemyUnitSelected].SullivanStatuamLocomotion(Sullivan.SullivanSpell12Damage * AttackModifier + GameManager.SullivanTrans);
                EnemyAnim();
                TurnOffAttackBools();
                yield return new WaitForSeconds(2f);

                //This checks to see if the Enemy is Dead or has HP remaining
                if (isDead)
                {
                    RemoveCurrentEnemy();
                }
                NextTurn();
            }
        }
    }

    void EnemyAnim()
    {
        if (!isDead)
        {
            enemyAnim[enemyUnitSelected].Play("Armature|TakeDamage");
        }
        if (isDead)
        {
            enemyAnim[enemyUnitSelected].SetBool("isDead", true);
        }
    }

    #endregion

    #region Enemy Attack
    IEnumerator EnemyTurn(int enemyIndex)
    {
        GameManager.isRed = false;
        GameManager.isBlue = false;
        GameManager.isYellow = false;
        GameManager.isGreen = false;
        GameManager.isPhysical = false;

        Camera.transform.position = enemyCam.transform.position;
        Camera.transform.LookAt(MC.transform.position);

        if (MCDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            if (stunnedName == enemyUnit[enemyIndex].name)
            {
                dialogueText.text = enemyUnit[enemyIndex].unitName + " is stunned!";
                yield return new WaitForSeconds(2f);
                // NextTurn();
                stunnedName = "";
            }
            else
            {
                enemyUnit[enemyUnitSelected].DetermineAttack();
                if (isConfused || isSkyeConfused)
                {
                    if (EnemyThatIsConfusedHarper == enemyUnit[enemyIndex].name)
                    {
                        int WhatEnemyDoing = Random.Range(0, 100);

                        if (WhatEnemyDoing < 34)
                        {
                            int moneyAmount = Random.Range(20, 40);
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " has given" + GameManager.MCFirstName + " W$" + moneyAmount + "!";
                            yield return new WaitForSeconds(3f);
                            //Give player money
                        }

                        else if (WhatEnemyDoing > 67)
                        {
                            //Do nothing
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " is looking confused!";
                            yield return new WaitForSeconds(3f);
                        }

                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " has hurt itself in confusion!";
                            yield return new WaitForSeconds(1.5f);
                            //Attack enemy

                            //ChooseWho To Attack
                            enemyAnim[enemyIndex].Play("Armature|Attack");
                            yield return new WaitForSeconds(2f);

                            bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                            enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);

                            if (isDead)
                            {
                                RemoveCurrentEnemy();
                            }
                            yield return new WaitForSeconds(2f);
                        }
                        isConfused = false;
                        EnemyThatIsConfusedHarper = "";
                    }

                    if (EnemyThatIsConfusedSkye == enemyUnit[enemyIndex].name)
                    {
                        int WhatEnemyDoing = Random.Range(0, 100);

                        if (WhatEnemyDoing < 34)
                        {
                            int moneyAmount = Random.Range(20, 40);
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " has given" + GameManager.MCFirstName + " W$" + moneyAmount + "!";
                            yield return new WaitForSeconds(3f);
                            //Give player money
                        }

                        else if (WhatEnemyDoing > 67)
                        {
                            //Do nothing
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " is looking confused!";
                            yield return new WaitForSeconds(3f);
                        }

                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " has hurt itself in confusion!";
                            yield return new WaitForSeconds(1.5f);
                            //Attack enemy

                            //ChooseWho To Attack
                            enemyAnim[enemyIndex].Play("Armature|Attack");
                            yield return new WaitForSeconds(2f);

                            bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                            enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);

                            if (isDead)
                            {
                                RemoveCurrentEnemy();
                            }
                            yield return new WaitForSeconds(2f);
                        }
                        isSkyeConfused = false;
                        EnemyThatIsConfusedSkye = "";
                    }

                    if (EnemyThatIsConfusedMC == enemyUnit[enemyIndex].name)
                    {
                        int WhatEnemyDoing = Random.Range(0, 100);

                        if (WhatEnemyDoing < 34)
                        {
                            int moneyAmount = Random.Range(20, 40);
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " has given" + GameManager.MCFirstName + " W$" + moneyAmount + "!";
                            yield return new WaitForSeconds(3f);
                            //Give player money
                        }

                        else if (WhatEnemyDoing > 67)
                        {
                            //Do nothing
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " is looking confused!";
                            yield return new WaitForSeconds(3f);
                        }

                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " has hurt itself in confusion!";
                            yield return new WaitForSeconds(1.5f);
                            //Attack enemy

                            //ChooseWho To Attack
                            enemyAnim[enemyIndex].Play("Armature|Attack");
                            yield return new WaitForSeconds(2f);

                            bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                            enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);

                            if (isDead)
                            {
                                RemoveCurrentEnemy();
                            }
                            yield return new WaitForSeconds(2f);
                        }
                        isConfused = false;
                        EnemyThatIsConfusedMC = "";
                    }

                    if (EnemyThatIsConfusedRhys == enemyUnit[enemyIndex].name)
                    {
                        int WhatEnemyDoing = Random.Range(0, 100);

                        if (WhatEnemyDoing < 34)
                        {
                            int moneyAmount = Random.Range(20, 40);
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " has given" + GameManager.MCFirstName + " W$" + moneyAmount + "!";
                            yield return new WaitForSeconds(3f);
                            //Give player money
                        }

                        else if (WhatEnemyDoing > 67)
                        {
                            //Do nothing
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " is looking confused!";
                            yield return new WaitForSeconds(3f);
                        }

                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " has hurt itself in confusion!";
                            yield return new WaitForSeconds(1.5f);
                            //Attack enemy

                            //ChooseWho To Attack
                            enemyAnim[enemyIndex].Play("Armature|Attack");
                            yield return new WaitForSeconds(2f);

                            bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                            enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);

                            if (isDead)
                            {
                                RemoveCurrentEnemy();
                            }
                            yield return new WaitForSeconds(2f);
                        }
                        isConfused = false;
                        EnemyThatIsConfusedRhys = "";
                    }
                }

                else
                {
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

                            bool isDead1 = Starter.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier);
                            bool isDead2 = MiddleReliever.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier);
                            bool isDead3 = SetUp.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier);
                            bool isDead4 = Closer.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier);

                            if (isDead1 && GameManager.StarterAgil < RandomAttack)
                            {
                                GameManager.StarterMorale -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                StarterMorale.value = (GameManager.StarterMorale / GameManager.StarterMoraleMax);
                                starterDead = true;
                                StarterDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();
                                //
                                playerTurnOrder.Remove(CharacterIdentifier.Starter);
                                //   Debug.Log("Removing Starter");

                                //
                                StarterAnim.SetBool("isDead", true);
                            }
                            if (isDead2 && GameManager.MiddleAgil < RandomAttack)
                            {
                                GameManager.MidRelivMorale -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                MiddleMorale.value = (GameManager.MidRelivMorale / GameManager.MidRelivMoraleMax);
                                middleDead = true;
                                MiddleDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();

                                playerTurnOrder.Remove(CharacterIdentifier.Middle);
                                //  Debug.Log("Removing Middle");


                                MidRelAnim.SetBool("isDead", true);

                            }
                            if (isDead3 && GameManager.SetUpAgil < RandomAttack)
                            {
                                GameManager.SetUpMorale -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                SetUpMorale.value = (GameManager.SetUpMorale / GameManager.SetUpMoraleMax);
                                setupDead = true;
                                SetUpDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();

                                playerTurnOrder.Remove(CharacterIdentifier.SetUp);
                                //   Debug.Log("Removing SetUp");


                                SetUpAnim.SetBool("isDead", true);
                            }
                            if (isDead4 && GameManager.CloserAgil < RandomAttack)
                            {
                                GameManager.CloserMorale -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                CloserMorale.value = (GameManager.CloserMorale / GameManager.CloserMoraleMax);
                                closerDead = true;
                                CloserDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();

                                playerTurnOrder.Remove(CharacterIdentifier.Closer);
                                //    Debug.Log("Removing Closer");


                                CloserAnim.SetBool("isDead", true);

                            }

                            if (!isDead1 && GameManager.StarterAgil < RandomAttack)
                            {
                                yield return new WaitForSeconds(.5f);
                                StarterAnim.Play("Armature|Oof");

                                GameManager.StarterMorale -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                StarterDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();
                                StarterMorale.value = (GameManager.StarterMorale / GameManager.StarterMoraleMax);
                            }

                            if (!isDead2 && GameManager.MiddleAgil < RandomAttack)
                            {
                                yield return new WaitForSeconds(.5f);
                                MidRelAnim.Play("Armature|Oof");

                                GameManager.MidRelivMorale -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                MiddleDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();
                                MiddleMorale.value = (GameManager.MidRelivMorale / GameManager.MidRelivMoraleMax);
                            }

                            if (!isDead3 && GameManager.SetUpAgil < RandomAttack)
                            {
                                yield return new WaitForSeconds(.5f);
                                SetUpAnim.Play("Armature|Oof");

                                GameManager.SetUpMorale -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                SetUpDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();
                                SetUpMorale.value = (GameManager.SetUpMorale / GameManager.SetUpMoraleMax);
                            }

                            if (!isDead4 && GameManager.CloserAgil < RandomAttack)
                            {
                                yield return new WaitForSeconds(.5f);
                                CloserAnim.Play("Armature|Oof");

                                GameManager.CloserMorale -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                CloserDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();
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

                            bool isDead1 = Starter.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier);
                            bool isDead2 = MiddleReliever.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier);
                            bool isDead3 = SetUp.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier);
                            bool isDead4 = Closer.TakeDamage(enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier);

                            if (!isDead1)
                            {
                                yield return new WaitForSeconds(.5f);
                                StarterAnim.Play("Armature|Oof");

                                GameManager.StarterEnergy -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                StarterDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();
                                StarterEnergy.value = (GameManager.StarterEnergy / GameManager.StarterEnergyMax);
                            }

                            if (!isDead2)
                            {
                                yield return new WaitForSeconds(.5f);
                                MidRelAnim.Play("Armature|Oof");

                                GameManager.MidRelivEnergy -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                MiddleDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();
                                MiddleEnergy.value = (GameManager.MidRelivEnergy / GameManager.MidRelievEnergyMax);
                            }

                            if (!isDead3)
                            {
                                yield return new WaitForSeconds(.5f);
                                SetUpAnim.Play("Armature|Oof");

                                GameManager.SetUpEnergy -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                SetUpDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();
                                SetUpEnergy.value = (GameManager.SetUpEnergy / GameManager.SetUpEnergyMax);
                            }

                            if (!isDead4)
                            {
                                yield return new WaitForSeconds(.5f);
                                CloserAnim.Play("Armature|Oof");

                                GameManager.CloserEnergy -= enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier;
                                CloserDamageUI.text = "-" + (enemyUnit[enemyUnitSelected].enemyDamage * DefenseModifier).ToString();
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

                    bool viableTarget = false;

                    do
                    {
                        WhoToAttack = Random.Range(0, 6);
                        if (safteyCounter-- < 0)
                        {
                            Debug.LogError("Couldn't find a living WhoToAttack, is the Whole Team Dead?");
                            break;
                            //bails us out of the do while
                        }
                        if (isPlayerIndexDead(WhoToAttack) == false)
                        {
                            if (WhoToAttack == 0 && !MCDead)
                            {
                                viableTarget = true;
                            }

                            else if (WhoToAttack == 1 && GameManager.RhysInParty && !RhysDead)
                            {
                                viableTarget = true;
                            }
                            else if (WhoToAttack == 2 && GameManager.JameelInParty && !JameelDead)
                            {
                                viableTarget = true;
                            }
                            else if (WhoToAttack == 3 && GameManager.HarperInParty && !HarperDead)
                            {
                                viableTarget = true;
                            }
                            else if (WhoToAttack == 4 && GameManager.SkyeInParty && !SkyeDead)
                            {
                                viableTarget = true;
                            }
                            else if (WhoToAttack == 5 && GameManager.SullivanInParty && !SullivanDead)
                            {
                                viableTarget = true;
                            }
                        }//Player not dead
                    } while (viableTarget == false);

                    yield return new WaitForSeconds(1.5f);

                    enemyAnim[enemyIndex].Play("Armature|Attack");

                    yield return new WaitForSeconds(.5f);

                    if (WhoToAttack == 0 && !MCDead)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(MC.transform.position);

                        Camera.transform.LookAt(MC.transform.position);
                        //Block
                        if (singleBlock && playerToBlock == "MC")
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks " + GameManager.MCFirstName + " with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(2f);
                            dialogueText.text = "The attack was blocked!";
                            yield return new WaitForSeconds(2f);
                            singleBlock = false;
                            playerToBlock = "";
                        }
                        //Dodge
                        else if ((GameManager.MCDodge * EvasionModifier) >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks " + GameManager.MCFirstName + " with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            dialogueText.text = GameManager.MCFirstName + " Dodges!";
                            MCAnim.Play("Armature|Dodge");
                            yield return new WaitForSeconds(1f);

                        }
                        //Attack
                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks " + GameManager.MCFirstName + " with " + enemyUnit[enemyIndex].attackName + "!";

                            yield return new WaitForSeconds(2f);

                            MCDamageUI.text = "".ToString();

                            //reflect attack
                            if (repelAttack && playerName == "MC")
                            {
                                bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                dialogueText.text = "The attack is reflected!";
                                EnemyAnim();
                                yield return new WaitForSeconds(2f);

                                //This checks to see if the Enemy is Dead or has HP remaining
                                if (isDead)
                                {
                                    RemoveCurrentEnemy();
                                }
                                repelAttack = false;
                                playerName = "";
                            }

                            else
                            {
                                bool isDead = MC.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseMC);
                                //Dead
                                if (isDead)
                                {
                                    GameManager.MCHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseMC;
                                    MCDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseMC).ToString();
                                    MCHealth.value = GameManager.MCHealth;
                                    MCDead = true;
                                    MCAnim.SetBool("isDead", true);
                                    Debug.Log("Game Over because Main Character died");
                                    state = BattleState.LOST;
                                    yield return new WaitForSeconds(3f);
                                    EndBattle();
                                }
                                //Not dead, but hurt
                                else
                                {
                                    if (confusionChance)
                                    {
                                        MCConfused = true;
                                        confusionChance = false;
                                        dialogueText.text = GameManager.MCFirstName + " is confused!";
                                        yield return new WaitForSeconds(1.5f);
                                    }

                                    if (secondaryAttack)
                                    {
                                        yield return new WaitForSeconds(.5f);
                                        MCAnim.Play("Armature|TakeDamage");
                                        MCDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseMC).ToString();
                                        GameManager.MCHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseMC;
                                        MCHealth.value = GameManager.MCHealth;
                                        yield return new WaitForSeconds(.5f);
                                        MCDamageUI.text = "";
                                        if (isDead)
                                        {
                                            MCDead = true;
                                            MCAnim.SetBool("isDead", true);
                                            Debug.Log("Game Over because Main Character died");
                                            state = BattleState.LOST;
                                            yield return new WaitForSeconds(3f);
                                            EndBattle();
                                        }
                                        secondaryAttack = false;
                                    }

                                    yield return new WaitForSeconds(.5f);
                                    MCAnim.Play("Armature|TakeDamage");
                                    MCDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseMC).ToString();
                                    GameManager.MCHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseMC;
                                    MCHealth.value = GameManager.MCHealth;
                                    yield return new WaitForSeconds(2f);

                                }
                            }
                        }
                        StartCoroutine(TurnOffDamageUI());
                    }

                    else if (WhoToAttack == 1 && !RhysDead && GameManager.RhysInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Rhys.transform.position);

                        Camera.transform.LookAt(Rhys.transform.position);

                        //Block
                        if (singleBlock && playerToBlock == "Rhys")
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Rhys with " + " with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(2f);
                            dialogueText.text = "The attack was blocked!";
                            yield return new WaitForSeconds(2f);
                            singleBlock = false;
                            playerToBlock = "";
                        }
                        //Dodge
                        else if ((GameManager.RhysDodge * EvasionModifier) >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Rhys with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            RhysAnim.Play("Armature|Dodge");
                            dialogueText.text = "Rhys Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Rhys with " + enemyUnit[enemyIndex].attackName + "!";

                            yield return new WaitForSeconds(1f);

                            RhysDamageUI.text = "".ToString();

                            //reflect attack
                            if (repelAttack && playerName == "Rhys")
                            {
                                bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                dialogueText.text = "The attack is reflected!";
                                EnemyAnim();
                                yield return new WaitForSeconds(2f);

                                //This checks to see if the Enemy is Dead or has HP remaining
                                if (isDead)
                                {
                                    RemoveCurrentEnemy();
                                }
                                repelAttack = false;
                                playerName = "";
                            }

                            else
                            {
                                bool isDead = Rhys.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseRhys);
                                if (isDead)
                                {
                                    RhysDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.RhysHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseRhys;
                                    RhysHealth.value = GameManager.RhysHealth;
                                    RhysDead = true;

                                    playerTurnOrder.Remove(CharacterIdentifier.Rhys);

                                    RhysAnim.SetBool("isDead", true);
                                    yield return new WaitForSeconds(3f);

                                }

                                else
                                {
                                    yield return new WaitForSeconds(.5f);
                                    RhysAnim.Play("Armature|TakeDamage");
                                    RhysDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.RhysHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseRhys;
                                    RhysHealth.value = GameManager.RhysHealth;

                                    if (confusionChance)
                                    {
                                        RhysConfused = true;
                                        confusionChance = false;
                                        dialogueText.text = "Rhys is confused!";
                                        yield return new WaitForSeconds(1.5f);
                                    }

                                    if (secondaryAttack)
                                    {
                                        bool isDead2 = Rhys.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseRhys);
                                        if (isDead2 || Rhys.currentHP <= 0)
                                        {
                                            RhysDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.RhysHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseRhys;
                                            RhysHealth.value = GameManager.RhysHealth;
                                            RhysDead = true;
                                            playerTurnOrder.Remove(CharacterIdentifier.Rhys);
                                            RhysAnim.Play("Armature|Dead");
                                            RhysAnim.SetBool("isDead", true);
                                            yield return new WaitForSeconds(2.5f);
                                        }
                                        else
                                        {
                                            yield return new WaitForSeconds(.5f);
                                            RhysAnim.Play("Armature|TakeDamage");
                                            RhysDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.RhysHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseRhys;
                                            RhysHealth.value = GameManager.RhysHealth;
                                            yield return new WaitForSeconds(.5f);
                                            RhysDamageUI.text = "";
                                        }
                                        secondaryAttack = false;
                                    }

                                    yield return new WaitForSeconds(2f);
                                }
                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                    }
                    else if (WhoToAttack == 2 && !JameelDead && GameManager.JameelInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Jameel.transform.position);

                        Camera.transform.LookAt(Jameel.transform.position);

                        //Block
                        if (singleBlock && playerToBlock == "Jameel")
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Jameel with " + " with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(2f);
                            dialogueText.text = "The attack was blocked!";
                            yield return new WaitForSeconds(2f);
                            singleBlock = false;
                            playerToBlock = "";
                        }
                        //Dodge
                        else if ((GameManager.JameelDodge * EvasionModifier) >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Jameel with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            JameelAnim.Play("Armature|Dodge");
                            dialogueText.text = "Jameel Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Jameel with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(1f);


                            JameelDamageUI.text = "".ToString();

                            //reflect attack
                            if (repelAttack && playerName == "Jameel")
                            {
                                bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                dialogueText.text = "The attack is reflected!";
                                yield return new WaitForSeconds(2f);

                                //This checks to see if the Enemy is Dead or has HP remaining
                                if (isDead)
                                {
                                    RemoveCurrentEnemy();
                                }
                                repelAttack = false;
                                playerName = "";
                            }

                            else
                            {
                                bool isDead = Jameel.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseJameel);
                                if (isDead)
                                {
                                    JameelDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.JameelHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseJameel;
                                    JameelHealth.value = GameManager.JameelHealth;
                                    JameelDead = true;

                                    playerTurnOrder.Remove(CharacterIdentifier.Jameel);

                                    JameelAnim.SetBool("isDead", true);
                                    yield return new WaitForSeconds(3f);

                                }

                                else
                                {
                                    yield return new WaitForSeconds(.5f);
                                    JameelAnim.Play("Armature|TakeDamage");
                                    JameelDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.JameelHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseJameel;
                                    JameelHealth.value = GameManager.JameelHealth;

                                    if (confusionChance)
                                    {
                                        JameelConfused = true;
                                        confusionChance = false;
                                        dialogueText.text = "Jameel is confused!";
                                        yield return new WaitForSeconds(1.5f);
                                    }

                                    if (secondaryAttack)
                                    {

                                        Jameel.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseJameel);
                                        print("here");
                                        print(Jameel.currentHP);
                                        if (Jameel.currentHP <= 0)
                                        {
                                           
                                            JameelDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.JameelHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseJameel;
                                            JameelHealth.value = GameManager.JameelHealth;
                                            JameelDead = true;
                                            playerTurnOrder.Remove(CharacterIdentifier.Jameel);
                                            JameelAnim.Play("Armature|Dead");
                                            JameelAnim.SetBool("isDead", true);
                                            yield return new WaitForSeconds(2.5f);
                                        }
                                        else
                                        {
                                            yield return new WaitForSeconds(.5f);
                                            JameelAnim.Play("Armature|TakeDamage");
                                            JameelDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.JameelHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseJameel;
                                            JameelHealth.value = GameManager.JameelHealth;
                                            yield return new WaitForSeconds(.5f);
                                            JameelDamageUI.text = "";
                                        }
                                        secondaryAttack = false;
                                    }

                                    yield return new WaitForSeconds(2f);
                                }
                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                    }
                    else if (WhoToAttack == 3 && !HarperDead && GameManager.HarperInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Harper.transform.position);

                        Camera.transform.LookAt(Harper.transform.position);

                        //Block
                        if (singleBlock && playerToBlock == "Harper")
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Harper with " + " with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(2f);
                            dialogueText.text = "The attack was blocked!";
                            yield return new WaitForSeconds(2f);
                            singleBlock = false;
                            playerToBlock = "";
                        }
                        //Dodge
                        else if ((GameManager.HarperDodge * EvasionModifier) >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Harper with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            HarperAnim.Play("Armature|Dodge");
                            dialogueText.text = "Harper Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Harper with " + enemyUnit[enemyIndex].attackName + "!";

                            yield return new WaitForSeconds(1f);


                            HarperDamageUI.text = "".ToString();

                            //reflect attack
                            if (repelAttack && playerName == "Harper")
                            {
                                bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                dialogueText.text = "The attack is reflected!";
                                EnemyAnim();
                                yield return new WaitForSeconds(2f);

                                //This checks to see if the Enemy is Dead or has HP remaining
                                if (isDead)
                                {
                                    RemoveCurrentEnemy();
                                }
                                repelAttack = false;
                                playerName = "";
                            }

                            else
                            {
                                bool isDead = Harper.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseHarper);
                                if (isDead)
                                {
                                    HarperDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.HarperHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseHarper;
                                    HarperHealth.value = GameManager.HarperHealth;
                                    HarperDead = true;

                                    playerTurnOrder.Remove(CharacterIdentifier.Harper);

                                    HarperAnim.SetBool("isDead", true);
                                    yield return new WaitForSeconds(3f);

                                }

                                else
                                {
                                    yield return new WaitForSeconds(.5f);
                                    HarperAnim.Play("Armature|TakeDamage");
                                    HarperDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.HarperHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseHarper;
                                    HarperHealth.value = GameManager.HarperHealth;

                                    if (confusionChance)
                                    {
                                        HarperConfused = true;
                                        confusionChance = false;
                                        dialogueText.text = "Harper is confused!";
                                        yield return new WaitForSeconds(1.5f);
                                    }

                                    if (secondaryAttack)
                                    {
                                        bool isDead2 = Harper.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseHarper);
                                        if (isDead2 || Harper.currentHP <= 0)
                                        {
                                            HarperDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.HarperHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseHarper;
                                            HarperHealth.value = GameManager.HarperHealth;
                                            HarperDead = true;
                                            playerTurnOrder.Remove(CharacterIdentifier.Harper);
                                            HarperAnim.Play("Armature|Dead");
                                            HarperAnim.SetBool("isDead", true);
                                            yield return new WaitForSeconds(2.5f);
                                        }
                                        else
                                        {
                                            yield return new WaitForSeconds(.5f);
                                            HarperAnim.Play("Armature|TakeDamage");
                                            HarperDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.HarperHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseHarper;
                                            HarperHealth.value = GameManager.HarperHealth;
                                            yield return new WaitForSeconds(.5f);
                                            HarperDamageUI.text = "";
                                        }
                                        secondaryAttack = false;
                                    }

                                    yield return new WaitForSeconds(2f);
                                }
                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                    }
                    else if (WhoToAttack == 4 && !SkyeDead && GameManager.SkyeInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Skye.transform.position);

                        Camera.transform.LookAt(Skye.transform.position);

                        //Block
                        if (singleBlock && playerToBlock == "Skye")
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Skye with " + " with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(2f);
                            dialogueText.text = "The attack was blocked!";
                            yield return new WaitForSeconds(2f);
                            singleBlock = false;
                            playerToBlock = "";
                        }
                        //Dodge
                        else if ((GameManager.SkyeDodge * EvasionModifier) >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Skye with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            SkyeAnim.Play("Armature|Dodge");
                            dialogueText.text = "Skye Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Skye with " + enemyUnit[enemyIndex].attackName + "!";

                            yield return new WaitForSeconds(1f);

                            SkyeDamageUI.text = "".ToString();

                            //reflect attack
                            if (repelAttack && playerName == "Skye")
                            {
                                bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                dialogueText.text = "The attack is reflected!";
                                EnemyAnim();
                                yield return new WaitForSeconds(2f);

                                //This checks to see if the Enemy is Dead or has HP remaining
                                if (isDead)
                                {
                                    RemoveCurrentEnemy();
                                }
                                repelAttack = false;
                                playerName = "";
                            }

                            else
                            {
                                bool isDead = Skye.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSkye);
                                if (isDead)
                                {
                                    SkyeDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.SkyeHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSkye;
                                    SkyeHealth.value = GameManager.SkyeHealth;
                                    SkyeDead = true;

                                    playerTurnOrder.Remove(CharacterIdentifier.Skye);

                                    SkyeAnim.SetBool("isDead", true);
                                    yield return new WaitForSeconds(3f);

                                }

                                else
                                {
                                    yield return new WaitForSeconds(.5f);
                                    SkyeAnim.Play("Armature|TakeDamage");
                                    SkyeDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.SkyeHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSkye;
                                    SkyeHealth.value = GameManager.SkyeHealth;

                                    if (confusionChance)
                                    {
                                        SkyeConfused = true;
                                        confusionChance = false;
                                        dialogueText.text = "Skye is confused!";
                                        yield return new WaitForSeconds(1.5f);
                                    }

                                    if (secondaryAttack)
                                    {
                                        bool isDead2 = Skye.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSkye);
                                        if (isDead2 || Skye.currentHP <= 0)
                                        {
                                            SkyeDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.SkyeHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSkye;
                                            SkyeHealth.value = GameManager.SkyeHealth;
                                            SkyeDead = true;
                                            playerTurnOrder.Remove(CharacterIdentifier.Skye);
                                            SkyeAnim.Play("Armature|Dead");
                                            SkyeAnim.SetBool("isDead", true);
                                            yield return new WaitForSeconds(2.5f);
                                        }
                                        else
                                        {
                                            yield return new WaitForSeconds(.5f);
                                            SkyeAnim.Play("Armature|TakeDamage");
                                            SkyeDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.SkyeHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSkye;
                                            SkyeHealth.value = GameManager.SkyeHealth;
                                            yield return new WaitForSeconds(.5f);
                                            SkyeDamageUI.text = "";
                                        }
                                        secondaryAttack = false;
                                    }

                                    yield return new WaitForSeconds(2f);
                                }
                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                    }
                    else if (WhoToAttack == 5 && !SullivanDead && GameManager.SullivanInParty)
                    {
                        enemyUnit[enemyIndex].transform.LookAt(Sullivan.transform.position);

                        Camera.transform.LookAt(Sullivan.transform.position);

                        //Block
                        if (singleBlock && playerToBlock == "Sullivan")
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Sullivan with " + " with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(2f);
                            dialogueText.text = "The attack was blocked!";
                            yield return new WaitForSeconds(2f);
                            singleBlock = false;
                            playerToBlock = "";
                        }
                        //Dodge
                        else if ((GameManager.SullivanDodge * EvasionModifier) >= RandomAttack)
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Sullivan with " + enemyUnit[enemyIndex].attackName + "!";
                            yield return new WaitForSeconds(.5f);
                            SullivanAnim.Play("Armature|Dodge");
                            dialogueText.text = "Sullivan Dodges!";
                            yield return new WaitForSeconds(1f);

                        }
                        else
                        {
                            dialogueText.text = enemyUnit[enemyIndex].unitName + " attacks Sullivan with " + enemyUnit[enemyIndex].attackName + "!";

                            yield return new WaitForSeconds(1f);

                            SullivanDamageUI.text = "".ToString();

                            //reflect attack
                            if (repelAttack && playerName == "Sullivan")
                            {
                                bool isDead = enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                enemyUnit[enemyIndex].TakeDamageReflected(enemyUnit[enemyIndex].enemyDamage);
                                dialogueText.text = "The attack is reflected!";
                                EnemyAnim();
                                yield return new WaitForSeconds(2f);

                                //This checks to see if the Enemy is Dead or has HP remaining
                                if (isDead)
                                {
                                    RemoveCurrentEnemy();
                                }
                                repelAttack = false;
                                playerName = "";
                            }

                            else
                            {
                                bool isDead = Sullivan.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSullivan);
                                if (isDead)
                                {
                                    SullivanDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.SullivanHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSullivan;
                                    SullivanHealth.value = GameManager.SullivanHealth;
                                    SullivanDead = true;

                                    playerTurnOrder.Remove(CharacterIdentifier.Sullivan);

                                    SullivanAnim.SetBool("isDead", true);
                                    yield return new WaitForSeconds(3f);

                                }

                                else
                                {
                                    yield return new WaitForSeconds(.5f);
                                    SullivanAnim.Play("Armature|TakeDamage");
                                    SullivanDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                    GameManager.SullivanHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSullivan;
                                    SullivanHealth.value = GameManager.SullivanHealth;

                                    if (confusionChance)
                                    {
                                        SullivanConfused = true;
                                        confusionChance = false;
                                        dialogueText.text = "Sullivan is confused!";
                                        yield return new WaitForSeconds(1.5f);
                                    }

                                    if (secondaryAttack)
                                    {
                                        bool isDead2 = Sullivan.TakeDamage(enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSullivan);
                                        if (isDead2 || Sullivan.currentHP <= 0)
                                        {
                                            print(Sullivan.currentHP);
                                            SullivanDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.SullivanHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSullivan;
                                            SullivanHealth.value = GameManager.SullivanHealth;
                                            SullivanDead = true;
                                            playerTurnOrder.Remove(CharacterIdentifier.Sullivan);
                                            SullivanAnim.Play("Armature|Dead");
                                            SullivanAnim.SetBool("isDead", true);
                                            yield return new WaitForSeconds(2.5f);
                                        }
                                        else
                                        {
                                            yield return new WaitForSeconds(.5f);
                                            SullivanAnim.Play("Armature|TakeDamage");
                                            SullivanDamageUI.text = "-" + (enemyUnit[enemyIndex].enemyDamage * DefenseModifier).ToString();
                                            GameManager.SullivanHealth -= enemyUnit[enemyIndex].enemyDamage * DefenseModifier * DefenseSullivan;
                                            SullivanHealth.value = GameManager.SullivanHealth;
                                            yield return new WaitForSeconds(.5f);
                                            SullivanDamageUI.text = "";
                                        }
                                        secondaryAttack = false;
                                    }

                                    yield return new WaitForSeconds(2f);
                                }
                            }
                        }

                        yield return new WaitForSeconds(.5f);
                        StartCoroutine(TurnOffDamageUI());
                    }
                }
            }
        }
        NextTurn();
        UpdateLifeUI();
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
    IEnumerator WaitingForConfusion()
    {
        yield return new WaitForSeconds(2.5f);
        NextTurn();
    }

    void MCTurn()
    {
        Camera.transform.position = player1Cam.transform.position;
        Camera.transform.LookAt(enemyCamTarget);

        if (MCDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        if (!MCDead)
        {
            if (MCConfused)
            {
                dialogueText.text = GameManager.MCFirstName + ": is confused!";

                int RandOptions = Random.Range(0, 100);
                if (RandOptions < 40)
                {
                    dialogueText.text = GameManager.MCFirstName + " is staring off into space!";
                }

                if (RandOptions > 60)
                {
                    dialogueText.text = GameManager.MCFirstName + " hurts themself in confusion!";
                    MC.currentHP -= GameManager.MCDodge;
                    if (MC.currentHP <= 0)
                    {
                        MCDamageUI.text = "-" + (GameManager.MCLevel * DefenseModifier).ToString();
                        GameManager.MCHealth -= GameManager.MCLevel * DefenseModifier * DefenseMC;
                        MCHealth.value = GameManager.MCHealth;
                        EndBattle();
                        MCAnim.SetBool("isDead", true);
                    }

                    else
                    {
                        MCAnim.Play("Armature|TakeDamage");
                        MCDamageUI.text = "-" + (GameManager.MCLevel * DefenseModifier).ToString();
                        GameManager.MCHealth -= GameManager.MCLevel * DefenseModifier * DefenseMC;
                        MCHealth.value = GameManager.MCHealth;
                    }
                }

                else
                {
                    int MoneyThrown = Random.Range(20, 40);
                    GameManager.Money -= MoneyThrown;
                    dialogueText.text = GameManager.MCFirstName + " threw away W$" + MoneyThrown;
                }

                MCConfused = false;
                StartCoroutine(WaitingForConfusion());
            }

            else
            {
                MCMenu.SetActive(true);
                dialogueText.text = GameManager.MCFirstName + ": Choose an Action.";

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
    }

    void GracieMay()
    {
        float chance = Random.Range(0, 100);

        float gracieSpawnChance = (GameManager.GracieMayFriendship / 10) * chance;

        chance = 100f;

        if (chance > .5f)
        {
            int spell = Random.Range(0, 5);
            if (spell == 0)
            {
                GameManager.MCHealth *= 1.5f;
                if (GameManager.MCHealth > GameManager.MCMaxHealth)
                {
                    GameManager.MCHealth = GameManager.MCMaxHealth;
                }

                if (GameManager.RhysInParty && !RhysDead)
                {
                    GameManager.RhysHealth *= 1.5f;
                    if (GameManager.RhysHealth > GameManager.RhysMaxHealth)
                    {
                        GameManager.RhysHealth = GameManager.RhysMaxHealth;
                    }
                }

                if (GameManager.JameelInParty && !JameelDead)
                {
                    GameManager.JameelHealth *= 1.5f;
                    if (GameManager.JameelHealth > GameManager.JameelMaxHealth)
                    {
                        GameManager.JameelHealth = GameManager.JameelMaxHealth;
                    }
                }

                if (GameManager.HarperInParty && !HarperDead)
                {
                    GameManager.HarperHealth *= 1.5f;
                    if (GameManager.HarperHealth > GameManager.HarperMaxHealth)
                    {
                        GameManager.HarperHealth = GameManager.HarperMaxHealth;
                    }
                }

                if (GameManager.SkyeInParty && !SkyeDead)
                {
                    GameManager.SkyeHealth *= 1.5f;
                    if (GameManager.SkyeHealth > GameManager.SkyeMaxHealth)
                    {
                        GameManager.SkyeHealth = GameManager.SkyeMaxHealth;
                    }
                }

                if (GameManager.SullivanInParty && !SullivanDead)
                {
                    GameManager.SullivanHealth *= 1.5f;
                    if (GameManager.SullivanHealth > GameManager.SullivanMaxHealth)
                    {
                        GameManager.SullivanHealth = GameManager.SullivanMaxHealth;
                    }
                }
                dialogueText.text = "Gracie May: Here is a little health for you!";
                GracieMaySpell1.SetActive(true);
                UpdateLifeUI();
            }

            if (spell == 1)
            {
                GameManager.MCMagic += Mathf.RoundToInt(GameManager.MCMaxMagic * .3f);
                GameManager.RhysMagic += Mathf.RoundToInt(GameManager.RhysMaxMagic * .3f);
                GameManager.JameelMagic += Mathf.RoundToInt(GameManager.JameelMaxMagic * .3f);
                GameManager.HarperMagic += Mathf.RoundToInt(GameManager.HarperMaxMagic * .3f);
                GameManager.SkyeMagic += Mathf.RoundToInt(GameManager.SkyeMaxMagic * .3f);
                GameManager.SullivanMagic += Mathf.RoundToInt(GameManager.SullivanMaxMagic * .3f);
                dialogueText.text = "Gracie May: Here is a little stamina for you!";
                GracieMaySpell2.SetActive(true);
                UpdateMagicUI();
            }

            if (spell == 2)
            {
                IncreaseAttack();
                dialogueText.text = "Attack up!";
                GracieMaySpell3.SetActive(true);
            }

            if (spell == 3)
            {
                IncreaseDefense();
                dialogueText.text = "Defense up!";
                GracieMaySpell4.SetActive(true);
            }

            if (spell == 4)
            {
                EvasionGroup();
                dialogueText.text = "Evasion Rase up!";
            }

        }
        else
        {
            NextTurn();
        }
        gracieMaySet.SetActive(true);
        gracieMayAnim.SetBool("isAttack", true);

        StartCoroutine(GracieWaiting());
    }

    IEnumerator GracieWaiting()
    {
        yield return new WaitForSeconds(6);
        GracieMaySpell1.SetActive(false);
        GracieMaySpell2.SetActive(false);
        GracieMaySpell3.SetActive(false);
        GracieMaySpell4.SetActive(false);
        gracieMaySet.SetActive(false);
        print("end spell here");
        gracieMayAnim.SetBool("isAttack", false);

        NextTurn();
    }

    void RhysTurn()
    {
        Camera.transform.position = player2Cam.transform.position;
        Camera.transform.LookAt(enemyCamTarget);

        if (RhysConfused)
        {
            dialogueText.text = "Rhys: is confused!";

            int RandOptions = Random.Range(0, 100);

            if (RandOptions < 40)
            {
                dialogueText.text = "Rhys is staring off into space!";
            }

            if (RandOptions > 60)
            {
                dialogueText.text = "Rhys hurts themself in confusion!";
                Rhys.currentHP -= GameManager.RhysDodge;
                if (Rhys.currentHP <= 0)
                {
                    RhysDamageUI.text = "-" + (GameManager.RhysLevel * DefenseModifier).ToString();
                    GameManager.RhysHealth -= GameManager.RhysLevel * DefenseModifier * DefenseRhys;
                    RhysHealth.value = GameManager.RhysHealth;
                    EndBattle();
                    RhysAnim.SetBool("isDead", true);
                }

                else
                {
                    RhysAnim.Play("Armature|TakeDamage");
                    RhysDamageUI.text = "-" + (GameManager.RhysLevel * DefenseModifier).ToString();
                    GameManager.RhysHealth -= GameManager.RhysLevel * DefenseModifier * DefenseRhys;
                    RhysHealth.value = GameManager.RhysHealth;
                }
            }

            else
            {
                int MoneyThrown = Random.Range(20, 40);
                GameManager.Money -= MoneyThrown;
                dialogueText.text = "Rhys threw away W$" + MoneyThrown;
            }

            RhysConfused = false;
            StartCoroutine(WaitingForConfusion());
        }

        else
        {

            if (RhysDead || !GameManager.RhysInParty)
            {
                NextTurn();

            }
            if (!RhysDead)
            {
                RhysMenu.SetActive(true);
                dialogueText.text = "Rhys: Choose an Action.";

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
            }
        }
    }

    void JameelTurn()
    {
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

        if (JameelDead || !GameManager.JameelInParty)
        {
            NextTurn();

        }

        if (JameelConfused)
        {
            dialogueText.text = "Jameel: is confused!";

            int RandOptions = Random.Range(0, 100);

            if (RandOptions < 40)
            {
                dialogueText.text = "Jameel is staring off into space!";
            }

            if (RandOptions > 60)
            {
                dialogueText.text = "Jameel hurts themself in confusion!";
                 Jameel.currentHP -= GameManager.JameelDodge;
                 if (Jameel.currentHP <= 0)
                 {
                    JameelDamageUI.text = "-" + (GameManager.JameelLevel * DefenseModifier).ToString();
                    GameManager.JameelHealth -= GameManager.JameelLevel * DefenseModifier * DefenseJameel;
                    JameelHealth.value = GameManager.JameelHealth;
                    EndBattle();
                    JameelAnim.SetBool("isDead", true);
                }

                else
                {
                    JameelAnim.Play("Armature|TakeDamage");
                    JameelDamageUI.text = "-" + (GameManager.JameelLevel * DefenseModifier).ToString();
                    GameManager.JameelHealth -= GameManager.JameelLevel * DefenseModifier * DefenseJameel;
                    JameelHealth.value = GameManager.JameelHealth;
                }
            }

            else
            {
                int MoneyThrown = Random.Range(20, 40);
                GameManager.Money -= MoneyThrown;
                dialogueText.text = "Jameel threw away W$" + MoneyThrown;
            }

            JameelConfused = false;
            StartCoroutine(WaitingForConfusion());
        }

        else
        {
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
    }

    void HarperTurn()
    {
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

        if (HarperDead || !GameManager.HarperInParty)
        {
            NextTurn();

        }

        if (HarperConfused)
        {
            dialogueText.text = "Harper: is confused!";

            int RandOptions = Random.Range(0, 100);

            if (RandOptions < 40)
            {
                dialogueText.text = "Harper is staring off into space!";
            }

            if (RandOptions > 60)
            {
                dialogueText.text = "Harper hurts themself in confusion!";
                Harper.currentHP -= GameManager.HarperDodge;
                if (Harper.currentHP <= 0)
                {
                    HarperDamageUI.text = "-" + (GameManager.HarperLevel * DefenseModifier).ToString();
                    GameManager.HarperHealth -= GameManager.HarperLevel * DefenseModifier * DefenseHarper;
                    HarperHealth.value = GameManager.HarperHealth;
                    EndBattle();
                    HarperAnim.SetBool("isDead", true);
                }

                else
                {
                    HarperAnim.Play("Armature|TakeDamage");
                    HarperDamageUI.text = "-" + (GameManager.HarperLevel * DefenseModifier).ToString();
                    GameManager.HarperHealth -= GameManager.HarperLevel * DefenseModifier * DefenseHarper;
                    HarperHealth.value = GameManager.HarperHealth;
                }
            }

            else
            {
                int MoneyThrown = Random.Range(20, 40);
                GameManager.Money -= MoneyThrown;
                dialogueText.text = "Harper threw away W$" + MoneyThrown;
            }

            HarperConfused = false;
            StartCoroutine(WaitingForConfusion());
        }

        else
        {
            if (!HarperDead)
            {
                HarperMenu.SetActive(true);
                dialogueText.text = "Harper: Choose an Action.";

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
            }
        }
    }

    void SkyeTurn()
    {
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

        if (SkyeDead || !GameManager.SkyeInParty)
        {
            NextTurn();

        }

        if (SkyeConfused)
        {
            dialogueText.text = "Skye: is confused!";

            int RandOptions = Random.Range(0, 100);

            if (RandOptions < 40)
            {
                dialogueText.text = "Skye is staring off into space!";
            }

            if (RandOptions > 60)
            {
                dialogueText.text = "Skye hurts themself in confusion!";
                Skye.currentHP -= GameManager.SkyeDodge;
                if (Skye.currentHP <= 0)
                {
                    SkyeDamageUI.text = "-" + (GameManager.SkyeLevel * DefenseModifier).ToString();
                    GameManager.SkyeHealth -= GameManager.SkyeLevel * DefenseModifier * DefenseSkye;
                    SkyeHealth.value = GameManager.SkyeHealth;
                    EndBattle();
                    SkyeAnim.SetBool("isDead", true);
                }

                else
                {
                    SkyeAnim.Play("Armature|TakeDamage");
                    SkyeDamageUI.text = "-" + (GameManager.SkyeLevel * DefenseModifier).ToString();
                    GameManager.SkyeHealth -= GameManager.SkyeLevel * DefenseModifier * DefenseSkye;
                    SkyeHealth.value = GameManager.SkyeHealth;
                }
            }

            else
            {
                int MoneyThrown = Random.Range(20, 40);
                GameManager.Money -= MoneyThrown;
                dialogueText.text = "Skye threw away W$" + MoneyThrown;
            }

            SkyeConfused = false;
            StartCoroutine(WaitingForConfusion());
        }

        else
        {

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
        if (SullivanDead || !GameManager.SullivanInParty)
        {
            NextTurn();

        }

        if (SullivanConfused)
        {
            dialogueText.text = "Sullivan: is confused!";

            int RandOptions = Random.Range(0, 100);

            if (RandOptions < 40)
            {
                dialogueText.text = "Sullivan is staring off into space!";
            }

            if (RandOptions > 60)
            {
                dialogueText.text = "Sullivan hurts themself in confusion!";
                Sullivan.currentHP -= GameManager.SullivanDodge;
                if (Sullivan.currentHP <= 0)
                {
                    SullivanDamageUI.text = "-" + (GameManager.SullivanLevel * DefenseModifier).ToString();
                    GameManager.SullivanHealth -= GameManager.SullivanLevel * DefenseModifier * DefenseSullivan;
                    SullivanHealth.value = GameManager.SullivanHealth;
                    EndBattle();
                    SullivanAnim.SetBool("isDead", true);
                }

                else
                {
                    SullivanAnim.Play("Armature|TakeDamage");
                    SullivanDamageUI.text = "-" + (GameManager.SullivanLevel * DefenseModifier).ToString();
                    GameManager.SullivanHealth -= GameManager.SullivanLevel * DefenseModifier * DefenseSullivan;
                    SullivanHealth.value = GameManager.SullivanHealth;
                }
            }

            else
            {
                int MoneyThrown = Random.Range(20, 40);
                GameManager.Money -= MoneyThrown;
                dialogueText.text = "Sullivan threw away W$" + MoneyThrown;
            }

            SullivanConfused = false;
            StartCoroutine(WaitingForConfusion());
        }

        else
        {
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
    }

    #endregion

    public void OnPlayerTurnButton()
    {
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


    public void RockThrow()
    {
        if (state == BattleState.MCTURN)
        {
            throwRock = true;

            MCMenu.SetActive(true);
            MCSpells.SetActive(false);
            enemySelect = true;
            MCConfirmMenu.SetActive(true);
            MCSpells.SetActive(false);
            MCMenu.SetActive(false);
        }

        if (state == BattleState.RHYSTURN)
        {
            rhysThrowRock = true;

            RhysMenu.SetActive(true);
            RhysSpells.SetActive(false);
            enemySelect = true;
            RhysConfirmMenu.SetActive(true);
            RhysSpells.SetActive(false);
            RhysMenu.SetActive(false);
        }

        if (state == BattleState.JAMEELTURN)
        {
            jameelThrowRock = true;

            JameelMenu.SetActive(true);
            JameelSpells.SetActive(false);
            enemySelect = true;
            JameelConfirmMenu.SetActive(true);
            JameelSpells.SetActive(false);
            JameelMenu.SetActive(false);
        }

        if (state == BattleState.HARPERTURN)
        {
            harperThrowRock = true;

            HarperMenu.SetActive(true);
            HarperSpells.SetActive(false);
            enemySelect = true;
            HarperConfirmMenu.SetActive(true);
            HarperSpells.SetActive(false);
            HarperMenu.SetActive(false);
        }

        if (state == BattleState.SKYETURN)
        {
            skyeThrowRock = true;

            SkyeMenu.SetActive(true);
            SkyeSpells.SetActive(false);
            enemySelect = true;
            SkyeConfirmMenu.SetActive(true);
            SkyeSpells.SetActive(false);
            SkyeMenu.SetActive(false);
        }

        if (state == BattleState.SULLIVANTURN)
        {
            sullivanRockThrow = true;

            SullivanMenu.SetActive(true);
            SullivanSpells.SetActive(false);
            enemySelect = true;
            SullivanConfirmMenu.SetActive(true);
            SullivanSpells.SetActive(false);
            SullivanMenu.SetActive(false);
        }
    }

    public void AttemptItemUse(int index) {
        ItemObject item = GameManager.instance.inventory.Container[index].item;
        Inventory.SetActive(false);
        InventorySelectedItem = index;

        if (state == BattleState.MCTURN)
        {
            mcUsingItem = true;
            MCMenu.SetActive(true);
            MCConfirmMenu.SetActive(true);
            MCMenu.SetActive(false);
        }

        if (state == BattleState.RHYSTURN)
        {
            rhysUsingItem = true;
            RhysMenu.SetActive(true);
            RhysConfirmMenu.SetActive(true);
            RhysMenu.SetActive(false);
        }

        if (state == BattleState.JAMEELTURN)
        {
            jameelUsingItem = true;
            JameelMenu.SetActive(true);
            JameelConfirmMenu.SetActive(true);
            JameelMenu.SetActive(false);
        }

        if (state == BattleState.HARPERTURN)
        {
            harperUsingItem = true;
            HarperMenu.SetActive(true);
            HarperConfirmMenu.SetActive(true);
            HarperMenu.SetActive(false);
        }

        if (state == BattleState.SKYETURN)
        {
            skyeUsingItem = true;
            SkyeMenu.SetActive(true);
            SkyeConfirmMenu.SetActive(true);
            SkyeMenu.SetActive(false);
        }

        if (state == BattleState.SULLIVANTURN)
        {
            sullivanUsingItem = true;
            SullivanMenu.SetActive(true);
            SullivanConfirmMenu.SetActive(true);
            SullivanMenu.SetActive(false);
        }
        if (item.type == ItemType.Offensive && !item.multiTarget) { // if using single target offensive item
            enemySelect = true;
        }
    }

    //Clean this up when you know what spells and who is casting what
    #region MC Attack UI Buttons

    public void MCFlippendo()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell2MagicConsumed <= GameManager.MCHealth)
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
                playerSelect = true;
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
                playerSelect = true;
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
            if (MC.MCSpell13MagicConsumed <= GameManager.MCHealth)
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
            if (MC.MCSpell14MagicConsumed <= GameManager.MCHealth)
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
            if (MC.MCSpell15MagicConsumed <= GameManager.MCHealth)
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
            if (MC.MCSpell16MagicConsumed <= GameManager.MCHealth)
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
            if (MC.MCSpell17MagicConsumed <= GameManager.MCHealth)
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
            if (MC.MCSpell18MagicConsumed <= GameManager.MCHealth)
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

                MCConfirmMenu.SetActive(false);
                MCSpells.SetActive(false);
                MCMenu.SetActive(false);

                GameManager.MCMagic -= MC.MCSpell19MagicConsumed;
                MCMagic.value = GameManager.MCMagic;
                dialogueText.text = "Small health increase for everyone!";

                MCAnim.Play("Armature|Attack");
                StartCoroutine(MinusSanaCoetus());
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator MinusSanaCoetus()
    {
        GameManager.MCHealth *= 1.25f;
        if (GameManager.MCHealth > GameManager.MCMaxHealth)
        {
            GameManager.MCHealth = GameManager.MCMaxHealth;
        }

        if (GameManager.RhysInParty && !RhysDead)
        {
            GameManager.RhysHealth *= 1.25f;
            if (GameManager.RhysHealth > GameManager.RhysMaxHealth)
            {
                GameManager.RhysHealth = GameManager.RhysMaxHealth;
            }
        }

        if (GameManager.JameelInParty && !JameelDead)
        {
            GameManager.JameelHealth *= 1.25f;
            if (GameManager.JameelHealth > GameManager.JameelMaxHealth)
            {
                GameManager.JameelHealth = GameManager.JameelMaxHealth;
            }
        }

        if (GameManager.HarperInParty && !HarperDead)
        {
            GameManager.HarperHealth *= 1.25f;
            if (GameManager.HarperHealth > GameManager.HarperMaxHealth)
            {
                GameManager.HarperHealth = GameManager.HarperMaxHealth;
            }
        }

        if (GameManager.SkyeInParty && !SkyeDead)
        {
            GameManager.SkyeHealth *= 1.25f;
            if (GameManager.SkyeHealth > GameManager.SkyeMaxHealth)
            {
                GameManager.SkyeHealth = GameManager.SkyeMaxHealth;
            }
        }

        if (GameManager.SullivanInParty && !SullivanDead)
        {
            GameManager.SullivanHealth *= 1.25f;
            if (GameManager.SullivanHealth > GameManager.SullivanMaxHealth)
            {
                GameManager.SullivanHealth = GameManager.SullivanMaxHealth;
            }
        }
        yield return new WaitForSeconds(4f);
        minusSanaCoetus = false;
        jameelMinusSanaCoetus = false;
        TurnOffAttackBools();
        NextTurn();
    }

    public void MCChorusPedes()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell20MagicConsumed <= GameManager.MCMagic)
            {
                chorusPedes = true;
                MCConfirmMenu.SetActive(false);
                MCSpells.SetActive(false);
                MCMenu.SetActive(false);

                GameManager.MCMagic -= MC.MCSpell20MagicConsumed;
                MCMagic.value = GameManager.MCMagic;
                dialogueText.text = "Evasion Rate up for the party!";
                EvasionGroup();
                MCAnim.Play("Armature|Attack");
                StartCoroutine(ChorusPedes());
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator ChorusPedes()
    {
        yield return new WaitForSeconds(4f);
        jameelChorusPedes = false;
        chorusPedes = false;
        rhysTenuiLabor = false;
        rhysFumos = false;
        TurnOffAttackBools();
        NextTurn();
    }

    public void MCCriticaFocus()
    {
        if (state == BattleState.MCTURN)
        {
            if (MC.MCSpell21MagicConsumed <= GameManager.MCMagic)
            {
                criticaFocus = true;

                MCConfirmMenu.SetActive(false);
                MCSpells.SetActive(false);
                MCMenu.SetActive(false);

                GameManager.MCMagic -= MC.MCSpell21MagicConsumed;
                MCMagic.value = GameManager.MCMagic;
                dialogueText.text = "Attack up!";
                IncreaseAttack();
                MCAnim.Play("Armature|Attack");
                StartCoroutine(CriticaFocus());
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator CriticaFocus()
    {
        yield return new WaitForSeconds(4f);
        criticaFocus = false;
        sullivanCriticaFocus = false;
        TurnOffAttackBools();
        NextTurn();
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
            if (Rhys.RhysSpell2MagicConsumed <= GameManager.RhysHealth)
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
            if (Rhys.RhysSpell4MagicConsumed <= GameManager.RhysHealth)
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
            if (Rhys.RhysSpell5MagicConsumed <= GameManager.RhysHealth)
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
            if (Rhys.RhysSpell6MagicConsumed <= GameManager.RhysHealth)
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
                RhysConfirmMenu.SetActive(false);

                GameManager.RhysMagic -= Rhys.RhysSpell7MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                dialogueText.text = "Decrease enemy attack!";
                IncreaseAttack();
                RhysAnim.Play("Armature|Attack");
                StartCoroutine(ChorusPedes());
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
                RhysConfirmMenu.SetActive(false);

                GameManager.RhysMagic -= Rhys.RhysSpell7MagicConsumed;
                RhysMagic.value = GameManager.RhysMagic;
                dialogueText.text = "Evasion Rate up for the party!";
                EvasionGroup();
                RhysAnim.Play("Armature|Attack");
                StartCoroutine(ChorusPedes());

                RhysMenu.SetActive(false);
                RhysSpells.SetActive(false);
                RhysConfirmMenu.SetActive(false);
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
                playerSelect = true;
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
            if (Jameel.JameelSpell2MagicConsumed <= GameManager.JameelHealth)
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

                JameelConfirmMenu.SetActive(false);
                JameelSpells.SetActive(false);
                JameelMenu.SetActive(false);

                GameManager.JameelMagic -= Jameel.JameelSpell3MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                dialogueText.text = "Small health increase for everyone!";

                JameelAnim.Play("Armature|Attack");
                StartCoroutine(MinusSanaCoetus());
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
                playerSelect = true;
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
                playerSelect = true;
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
            if (Jameel.JameelSpell8MagicConsumed <= GameManager.JameelHealth)
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
            if (Jameel.JameelSpell9MagicConsumed <= GameManager.JameelHealth)
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
            if (Jameel.JameelSpell10MagicConsumed <= GameManager.JameelHealth)
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
                playerSelect = true;
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
                playerSelect = true;
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
                JameelConfirmMenu.SetActive(false);
                JameelSpells.SetActive(false);
                JameelMenu.SetActive(false);

                GameManager.JameelMagic -= Jameel.JameelSpell15MagicConsumed;
                JameelMagic.value = GameManager.JameelMagic;
                dialogueText.text = "Evasion Rate up for the party!";
                EvasionGroup();
                JameelAnim.Play("Armature|Attack");
                StartCoroutine(ChorusPedes());
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
            if (Harper.HarperSpell2MagicConsumed <= GameManager.HarperHealth)
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
            if (Harper.HarperSpell7MagicConsumed <= GameManager.HarperHealth)
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

    public void HarperLaedo()
    {
        if (state == BattleState.HARPERTURN)
        {
            if (Harper.HarperSpell8MagicConsumed <= GameManager.HarperHealth)
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
            if (Harper.HarperSpell9MagicConsumed <= GameManager.HarperHealth)
            {
                harperLociPraesidium = true;

                HarperMenu.SetActive(true);
                HarperSpells.SetActive(false);
                playerSelect = true;
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
            if (Skye.SkyeSpell2MagicConsumed <= GameManager.SkyeHealth)
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
                playerSelect = true;
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
                playerSelect = true;
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

                SkyeConfirmMenu.SetActive(false);
                SkyeSpells.SetActive(false);
                SkyeMenu.SetActive(false);

                GameManager.SkyeMagic -= Skye.SkyeSpell5MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                dialogueText.text = "Skye heals everyone completely!";
                SkyeAnim.Play("Armature|Attack");

                GameManager.MCHealth = GameManager.MCMaxHealth;

                if (GameManager.RhysInParty && !RhysDead)
                {
                    GameManager.RhysHealth = GameManager.RhysMaxHealth;
                }

                if (GameManager.JameelInParty && !JameelDead)
                {
                    GameManager.JameelHealth = GameManager.JameelMaxHealth;
                }

                if (GameManager.HarperInParty && !HarperDead)
                {
                    GameManager.HarperHealth = GameManager.HarperMaxHealth;
                }

                if (GameManager.SkyeInParty && !SkyeDead)
                {
                    GameManager.SkyeHealth = GameManager.SkyeMaxHealth;
                }

                if (GameManager.SullivanInParty && !SullivanDead)
                {
                    GameManager.SullivanHealth = GameManager.SullivanMaxHealth;
                }

                StartCoroutine(SenaPlena());
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator SenaPlena()
    {
        yield return new WaitForSeconds(4f);
        skyeSenaPlenaPotion = false;
        TurnOffAttackBools();
        NextTurn();
    }

    public void SkyeReanimatePotion()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell6MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeReanimatePotion = true;

                SkyeMenu.SetActive(false);
                SkyeSpells.SetActive(false);
                SkyeConfirmMenu.SetActive(false);
                GameManager.SkyeMagic -= Skye.SkyeSpell5MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                SkyeAnim.Play("Armature|Attack");
                StartCoroutine(Reanimate());
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator Reanimate()
    {
        yield return new WaitForSeconds(2f);

        if (GameManager.RhysInParty && RhysDead)
        {
            GameManager.RhysHealth = GameManager.RhysMaxHealth * .5f;
            RhysDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Rhys);

        }
        if (GameManager.JameelInParty && JameelDead)
        {
            GameManager.JameelHealth = GameManager.JameelMaxHealth * .5f;
            JameelDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Rhys);
        }
        if (GameManager.HarperInParty && HarperDead)
        {
            GameManager.HarperHealth = GameManager.HarperMaxHealth * .5f;
            HarperDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Rhys);
        }
        if (GameManager.SullivanInParty && SullivanDead)
        {
            GameManager.SullivanHealth = GameManager.SullivanMaxHealth * .5f;
            SullivanDead = false;
            playerTurnOrder.Add(CharacterIdentifier.Sullivan);
        }

        UpdateLifeUI();
        TurnOffAttackBools();
        NextTurn();
    }

    public void SkyeSanaCoetusPotion()
    {
        if (state == BattleState.SKYETURN)
        {
            if (Skye.SkyeSpell5MagicConsumed <= GameManager.SkyeMagic)
            {
                skyeSanaCoetusPotion = true;

                SkyeConfirmMenu.SetActive(false);
                SkyeSpells.SetActive(false);
                SkyeMenu.SetActive(false);

                GameManager.SkyeMagic -= Skye.SkyeSpell5MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                dialogueText.text = "Skye heals everyone a moderate amount!";
                SkyeAnim.Play("Armature|Attack");

                GameManager.MCHealth *= 1.5f;
                if (GameManager.MCHealth > GameManager.MCMaxHealth)
                {
                    GameManager.MCHealth = GameManager.MCMaxHealth;
                }

                if (GameManager.RhysInParty && !RhysDead)
                {
                    GameManager.RhysHealth *= 1.5f;
                    if (GameManager.RhysHealth > GameManager.RhysMaxHealth)
                    {
                        GameManager.RhysHealth = GameManager.RhysMaxHealth;
                    }
                }

                if (GameManager.JameelInParty && !JameelDead)
                {
                    GameManager.JameelHealth *= 1.5f;
                    if (GameManager.JameelHealth > GameManager.JameelMaxHealth)
                    {
                        GameManager.JameelHealth = GameManager.JameelMaxHealth;
                    }
                }

                if (GameManager.HarperInParty && !HarperDead)
                {
                    GameManager.HarperHealth *= 1.5f;
                    if (GameManager.HarperHealth > GameManager.HarperMaxHealth)
                    {
                        GameManager.HarperHealth = GameManager.HarperMaxHealth;
                    }
                }

                if (GameManager.SkyeInParty && !SkyeDead)
                {
                    GameManager.SkyeHealth *= 1.5f;
                    if (GameManager.SkyeHealth > GameManager.SkyeMaxHealth)
                    {
                        GameManager.SkyeHealth = GameManager.SkyeMaxHealth;
                    }
                }

                if (GameManager.SullivanInParty && !SullivanDead)
                {
                    GameManager.SullivanHealth *= 1.5f;
                    if (GameManager.SullivanHealth > GameManager.SullivanMaxHealth)
                    {
                        GameManager.SullivanHealth = GameManager.SullivanMaxHealth;
                    }
                }

                StartCoroutine(SanaCoetus());
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator SanaCoetus()
    {
        yield return new WaitForSeconds(4f);
        skyeSanaCoetusPotion = false;
        TurnOffAttackBools();
        NextTurn();
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

                SkyeConfirmMenu.SetActive(false);
                SkyeSpells.SetActive(false);
                SkyeMenu.SetActive(false);

                GameManager.SkyeMagic -= Skye.SkyeSpell9MagicConsumed;
                SkyeMagic.value = GameManager.SkyeMagic;
                dialogueText.text = "Strength and Defense up for the party!";

                IncreaseAttack();
                IncreaseDefense();

                SkyeAnim.Play("Armature|Attack");
                StartCoroutine(SkyeStrength());
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator SkyeStrength()
    {
        yield return new WaitForSeconds(4f);
        skyeStrengthPotion = false;
        TurnOffAttackBools();
        NextTurn();
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
            if (Sullivan.SullivanSpell2MagicConsumed <= GameManager.SullivanHealth)
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

                SullivanConfirmMenu.SetActive(false);
                SullivanSpells.SetActive(false);
                SullivanMenu.SetActive(false);

                GameManager.SullivanMagic -= Sullivan.SullivanSpell4MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                dialogueText.text = "Sullivan casts a protective charm over the group for 1 full turn!";
                DefenseModifier = 0;
                DefenseModifierTurnCount = 2;
                SullivanAnim.Play("Armature|Attack");
                StartCoroutine(Protego());
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator Protego()
    {
        yield return new WaitForSeconds(4f);
        sullivanProtego = false;
        TurnOffAttackBools();
        NextTurn();
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
            if (Sullivan.SullivanSpell9MagicConsumed <= GameManager.SullivanHealth)
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
                playerSelect = true;
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

                SullivanConfirmMenu.SetActive(false);
                SullivanSpells.SetActive(false);
                SullivanMenu.SetActive(false);

                GameManager.SullivanMagic -= Sullivan.SullivanSpell13MagicConsumed;
                SullivanMagic.value = GameManager.SullivanMagic;
                dialogueText.text = "Attack up!";
                IncreaseAttack();
                SullivanAnim.Play("Armature|Attack");
                StartCoroutine(CriticaFocus());
            }
            else
                dialogueText.text = "Not enough energy!";
        }
    }
    #endregion

    void EvasionGroup()
    {
        EvasionModifier = 1.5f;
        EvasionTurnCount = 3;
    }

    void IncreaseAttack()
    {
        AttackModifierTurnCount = 3;
        AttackModifier = 1.3f;
    }

    void IncreaseDefense()
    {
        DefenseModifierTurnCount = 3;
        DefenseModifier = .7f;
    }

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
        confusionChance = false;
        MCConfused = false;
        RhysConfused = false;
        JameelConfused = false;
        HarperConfused = false;
        SkyeConfused = false;
        SullivanConfused = false;


        secondaryAttack = false;
        repelAttack = false;

        GameManager.isRed = false;
        GameManager.isBlue = false;
        GameManager.isGreen = false;
        GameManager.isYellow = false;
        GameManager.isPhysical = false;

        MCMenu.SetActive(false);
        MCSpells.SetActive(false);
        MCConfirmMenu.SetActive(false);

        RhysMenu.SetActive(false);
        RhysSpells.SetActive(false);
        RhysConfirmMenu.SetActive(false);

        JameelMenu.SetActive(false);
        JameelSpells.SetActive(false);
        JameelConfirmMenu.SetActive(false);

        HarperMenu.SetActive(false);
        HarperSpells.SetActive(false);
        HarperConfirmMenu.SetActive(false);

        SkyeMenu.SetActive(false);
        SkyeSpells.SetActive(false);
        SkyeConfirmMenu.SetActive(false);

        SullivanMenu.SetActive(false);
        SullivanSpells.SetActive(false);
        SullivanConfirmMenu.SetActive(false);

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

            dialogueText.text = "You won the Battle!";
            EndingMenu.SetActive(true);
            MCSpells.SetActive(false);
            MCMenu.SetActive(false);

            RhysSpells.SetActive(false);
            RhysMenu.SetActive(false);

            JameelSpells.SetActive(false);
            JameelMenu.SetActive(false);

            HarperSpells.SetActive(false);
            HarperMenu.SetActive(false);

            SkyeSpells.SetActive(false);
            SkyeMenu.SetActive(false);

            SullivanSpells.SetActive(false);
            SullivanMenu.SetActive(false);



            if (!isOver && !preventingAddXPDup)
            {
                AddXP();
                isOver = true;
                #region Levels UI
                MCTrans.text = GameManager.MCTrans.ToString();
                MCCharms.text = GameManager.MCCharms.ToString();
                MCPotions.text = GameManager.MCPotions.ToString();
                MCDADA.text = GameManager.MCDADA.ToString();
                MCDodge.text = GameManager.MCDodge.ToString();


                RhysTrans.text = GameManager.RhysTrans.ToString();
                RhysCharms.text = GameManager.RhysCharms.ToString();
                RhysPotions.text = GameManager.RhysPotions.ToString();
                RhysDADA.text = GameManager.RhysDADA.ToString();
                RhysDodge.text = GameManager.RhysDodge.ToString();

                JameelTrans.text = GameManager.JameelTrans.ToString();
                JameelCharms.text = GameManager.JameelCharms.ToString();
                JameelPotions.text = GameManager.JameelPotions.ToString();
                JameelDADA.text = GameManager.JameelDADA.ToString();
                JameelDodge.text = GameManager.JameelDodge.ToString();

                HarperTrans.text = GameManager.HarperTrans.ToString();
                HarperCharms.text = GameManager.HarperCharms.ToString();
                HarperPotions.text = GameManager.HarperPotions.ToString();
                HarperDADA.text = GameManager.HarperDADA.ToString();
                HarperDodge.text = GameManager.HarperDodge.ToString();

                SkyeTrans.text = GameManager.SkyeTrans.ToString();
                SkyeCharms.text = GameManager.SkyeCharms.ToString();
                SkyePotions.text = GameManager.SkyePotions.ToString();
                SkyeDADA.text = GameManager.SkyeDADA.ToString();
                SkyeDodge.text = GameManager.SkyeDodge.ToString();

                SullivanTrans.text = GameManager.SullivanTrans.ToString();
                SullivanCharms.text = GameManager.SullivanCharms.ToString();
                SullivanPotions.text = GameManager.SullivanPotions.ToString();
                SullivanDADA.text = GameManager.SullivanDADA.ToString();
                SullivanDodge.text = GameManager.SullivanDodge.ToString();

                GracieMayTrans.text = GameManager.GracieMayTrans.ToString();
                GracieMayCharms.text = GameManager.GracieMayCharms.ToString();
                GracieMayPotions.text = GameManager.GracieMayPotions.ToString();
                GracieMayDADA.text = GameManager.GracieMayDADA.ToString();
                GracieMayDodge.text = GameManager.GracieMayDodge.ToString();
                #endregion
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
            MoneyText.text = GameManager.Money.ToString();
        }
        
        if (!MCDead)
        {
           MCExp(totalExp / GameManager.PartyCount * .8f);
        }
        
       //  ChooseItem();
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

    void MCExp(float xp)
    {
        if (!MCDead)
        {
            int OldLevel = GameManager.MCLevel;

            int safetyLimit = 2000;

            GameManager.MCExp += xp;

            Debug.Log(GameManager.MCLevel);
            Debug.Log(GameManager.MCTargetExp);
            Debug.Log(GameManager.MCExp);
            Debug.Log("----");

            while (GameManager.MCExp >= GameManager.MCTargetExp && safetyLimit-- > 0)
            {
                GameManager.MCExp = GameManager.MCExp - GameManager.MCTargetExp;
                GameManager.MCLevel++;

                GameManager.MCMaxMagic += 5;
                GameManager.MCMaxHealth += 5;
                GameManager.MCMagic = GameManager.MCMaxMagic;
                GameManager.MCHealth = GameManager.MCMaxHealth;

                MCLevel = true;

                GameManager.MCTargetExp *= 1.25f;
                //add training points
                int NewLevel = GameManager.MCLevel;
                int Difference = NewLevel - OldLevel;
                MCPointsToGive = (Difference * 3);
                
                while (MCPointsToGive > 0)
                {
                    float PercentToGain = Random.Range(0f, 1f);
                    if (PercentToGain < .2f)
                    {
                        GameManager.MCTrans++;
                        MCTrans.GetComponent<Text>().color = Color.green;
                        MCPointsToGive--;
                    }
                    else if (PercentToGain < .4f && PercentToGain >= .2f)
                    {
                        GameManager.MCCharms++;
                        MCCharms.GetComponent<Text>().color = Color.green;
                        MCPointsToGive--;
                    }
                    else if (PercentToGain < .6f && PercentToGain >= .4f)
                    {
                        GameManager.MCPotions++;
                        MCPotions.GetComponent<Text>().color = Color.green;
                        MCPointsToGive--;
                    }
                    else if (PercentToGain < .8f && PercentToGain >= .6f)
                    {
                        GameManager.MCDADA++;
                        MCDADA.GetComponent<Text>().color = Color.green;
                        MCPointsToGive--;
                    }
                    else if (PercentToGain < 1 && PercentToGain >= .8f)
                    {
                        GameManager.MCDodge++;
                        MCDodge.GetComponent<Text>().color = Color.green;
                        MCPointsToGive--;
                    }
                }

                if (GameManager.RhysInParty)
                {
                    RhysExp(totalExp / GameManager.PartyCount * .8f);
                }
                else
                {
                    RhysExp(totalExp / GameManager.PartyCount * .2f);
                }
            }
            Debug.Log(GameManager.MCLevel);
            Debug.Log(GameManager.MCTargetExp);
            Debug.Log(GameManager.MCExp);

            Debug.Log(safetyLimit);

        }
        else
        {
            if (GameManager.RhysInParty)
            {
                RhysExp(totalExp / GameManager.PartyCount * .8f);
            }
            else
            {
                RhysExp(totalExp / GameManager.PartyCount * .2f);
            }
        }
    }

    void RhysExp(float xp)
    {
        if (!RhysDead)
        {
           // xp = (totalExp / GameManager.PartyCount * .8f);
            int OldLevel = GameManager.RhysLevel;

            int safteyLimit = 2000;

            GameManager.RhysExp += xp;

            while (GameManager.RhysExp >= GameManager.RhysTargetExp && safteyLimit-- > 0)
            {
                GameManager.RhysExp = GameManager.RhysExp - GameManager.RhysTargetExp;
                GameManager.RhysLevel++;

                GameManager.RhysMaxMagic += 5;
                GameManager.RhysMaxHealth += 5;
                GameManager.RhysMagic = GameManager.RhysMaxMagic;
                GameManager.RhysHealth = GameManager.RhysMaxHealth;

                RhysLevel = true;
                //SLevelUp.SetActive(true);
                GameManager.RhysTargetExp *= 1.25f;
                //add training points
                int NewLevel = GameManager.RhysLevel;
                int Difference = NewLevel - OldLevel;
                RhysPointsToGive = (Difference * 3);

                while (RhysPointsToGive > 0)
                {
                    float PercentToGain = Random.Range(0f, 1f);
                    if (PercentToGain < .2f)
                    {
                        GameManager.RhysTrans++;
                        RhysTrans.GetComponent<Text>().color = Color.green;
                        RhysPointsToGive--;
                    }
                    else if (PercentToGain < .4f && PercentToGain >= .2f)
                    {
                        GameManager.RhysCharms++;
                        RhysCharms.GetComponent<Text>().color = Color.green;
                        RhysPointsToGive--;
                    }
                    else if (PercentToGain < .6f && PercentToGain >= .4f)
                    {
                        GameManager.RhysPotions++;
                        RhysPotions.GetComponent<Text>().color = Color.green;
                        RhysPointsToGive--;
                    }
                    else if (PercentToGain < .8f && PercentToGain >= .6f)
                    {
                        GameManager.RhysDADA++;
                        RhysDADA.GetComponent<Text>().color = Color.green;
                        RhysPointsToGive--;
                    }
                    else if (PercentToGain < 1 && PercentToGain >= .8f)
                    {
                        GameManager.RhysDodge++;
                        RhysDodge.GetComponent<Text>().color = Color.green;
                        RhysPointsToGive--;
                    }
                }
            }

            if (GameManager.JameelInParty)
            {
                JameelExp(totalExp / GameManager.PartyCount * .8f);
            }
            else
            {
                JameelExp(totalExp / GameManager.PartyCount * .2f);
            }
        }
        else
        {
            if (GameManager.JameelInParty)
            {
                JameelExp(totalExp / GameManager.PartyCount * .8f);
            }
            else
            {
                JameelExp(totalExp / GameManager.PartyCount * .2f);
            }
        }
    }

    void JameelExp(float xp)
    {
        if (!JameelDead)
        {
           // xp = (totalExp / GameManager.PartyCount * .8f);
            int OldLevel = GameManager.JameelLevel;

            int safteyLimit = 2000;

            GameManager.JameelExp += xp;

            while (GameManager.JameelExp >= GameManager.JameelTargetExp && safteyLimit-- > 0)
            {
                GameManager.JameelExp = GameManager.JameelExp - GameManager.JameelTargetExp;
                GameManager.JameelLevel++;

                GameManager.JameelMaxMagic += 5;
                GameManager.JameelMaxHealth += 5;
                GameManager.JameelMagic = GameManager.JameelMaxMagic;
                GameManager.JameelHealth = GameManager.JameelMaxHealth;

                JameelLevel = true;
                //SLevelUp.SetActive(true);
                GameManager.JameelTargetExp *= 1.25f;
                //add training points
                int NewLevel = GameManager.JameelLevel;
                int Difference = NewLevel - OldLevel;
                JameelPointsToGive = (Difference * 3);

                while (JameelPointsToGive > 0)
                {
                    float PercentToGain = Random.Range(0f, 1f);
                    if (PercentToGain < .2f)
                    {
                        GameManager.JameelTrans++;
                        JameelTrans.GetComponent<Text>().color = Color.green;
                        JameelPointsToGive--;
                    }
                    else if (PercentToGain < .4f && PercentToGain >= .2f)
                    {
                        GameManager.JameelCharms++;
                        JameelCharms.GetComponent<Text>().color = Color.green;
                        JameelPointsToGive--;
                    }
                    else if (PercentToGain < .6f && PercentToGain >= .4f)
                    {
                        GameManager.JameelPotions++;
                        JameelPotions.GetComponent<Text>().color = Color.green;
                        JameelPointsToGive--;
                    }
                    else if (PercentToGain < .8f && PercentToGain >= .6f)
                    {
                        GameManager.JameelDADA++;
                        JameelDADA.GetComponent<Text>().color = Color.green;
                        JameelPointsToGive--;
                    }
                    else if (PercentToGain < 1 && PercentToGain >= .8f)
                    {
                        GameManager.JameelDodge++;
                        JameelDodge.GetComponent<Text>().color = Color.green;
                        JameelPointsToGive--;
                    }
                }
              
                if (GameManager.HarperInParty)
                {
                    HarperExp(totalExp / GameManager.PartyCount * .8f);
                }
                else
                {
                    HarperExp(totalExp / GameManager.PartyCount * .2f);
                }
            }
        }
        else
        {
            if (GameManager.HarperInParty)
            {
                HarperExp(totalExp / GameManager.PartyCount * .8f);
            }
            else
            {
                HarperExp(totalExp / GameManager.PartyCount * .2f);
            }
        }
    }

    void HarperExp(float xp)
    {
        if (!HarperDead)
        {
           // xp = (totalExp / GameManager.PartyCount * .8f);
            int OldLevel = GameManager.HarperLevel;

            int safteyLimit = 2000;

            GameManager.HarperExp += xp;

            while (GameManager.HarperExp >= GameManager.HarperTargetExp && safteyLimit-- > 0)
            {
                GameManager.HarperExp = GameManager.HarperExp - GameManager.HarperTargetExp;
                GameManager.HarperLevel++;

                GameManager.HarperMaxMagic += 5;
                GameManager.HarperMaxHealth += 5;
                GameManager.HarperMagic = GameManager.HarperMaxMagic;
                GameManager.HarperHealth = GameManager.HarperMaxHealth;

                HarperLevel = true;
                //SLevelUp.SetActive(true);
                GameManager.HarperTargetExp *= 1.25f;
                //add training points
                int NewLevel = GameManager.HarperLevel;
                int Difference = NewLevel - OldLevel;
                HarperPointsToGive = (Difference * 3);

               while (HarperPointsToGive > 0)
                {
                    float PercentToGain = Random.Range(0f, 1f);
                    if (PercentToGain < .2f)
                    {
                        GameManager.HarperTrans++;
                        HarperTrans.GetComponent<Text>().color = Color.green;
                        HarperPointsToGive--;
                    }
                    else if (PercentToGain < .4f && PercentToGain >= .2f)
                    {
                        GameManager.HarperCharms++;
                        HarperCharms.GetComponent<Text>().color = Color.green;
                        HarperPointsToGive--;
                    }
                    else if (PercentToGain < .6f && PercentToGain >= .4f)
                    {
                        GameManager.HarperPotions++;
                        HarperPotions.GetComponent<Text>().color = Color.green;
                        HarperPointsToGive--;
                    }
                    else if (PercentToGain < .8f && PercentToGain >= .6f)
                    {
                        GameManager.HarperDADA++;
                        HarperDADA.GetComponent<Text>().color = Color.green;
                        HarperPointsToGive--;
                    }
                    else if (PercentToGain < 1 && PercentToGain >= .8f)
                    {
                        GameManager.HarperDodge++;
                        HarperDodge.GetComponent<Text>().color = Color.green;
                        HarperPointsToGive--;
                    }
                }
              
                if (GameManager.SkyeInParty)
                {
                    SkyeExp(totalExp / GameManager.PartyCount * .8f);
                }
                else
                {
                    SkyeExp(totalExp / GameManager.PartyCount * .2f);
                }
            }
        }
        else
        {
            if (GameManager.SkyeInParty)
            {
                SkyeExp(totalExp / GameManager.PartyCount * .8f);
            }
            else
            {
                SkyeExp(totalExp / GameManager.PartyCount * .2f);
            }
        }
    }

    void SkyeExp(float xp)
    {
        if (!SkyeDead)
        {
           // xp = (totalExp / GameManager.PartyCount * .8f);
            int OldLevel = GameManager.SkyeLevel;

            int safteyLimit = 2000;

            GameManager.SkyeExp += xp;

            while (GameManager.SkyeExp >= GameManager.SkyeTargetExp && safteyLimit-- > 0)
            {
                GameManager.SkyeExp = GameManager.SkyeExp - GameManager.SkyeTargetExp;
                GameManager.SkyeLevel++;

                GameManager.SkyeMaxMagic += 5;
                GameManager.SkyeMaxHealth += 5;
                GameManager.SkyeMagic = GameManager.SkyeMaxMagic;
                GameManager.SkyeHealth = GameManager.SkyeMaxHealth;

                SkyeLevel = true;
                //SLevelUp.SetActive(true);
                GameManager.SkyeTargetExp *= 1.25f;
                //add training points
                int NewLevel = GameManager.SkyeLevel;
                int Difference = NewLevel - OldLevel;
                 SkyePointsToGive = (Difference * 3);

                while (SkyePointsToGive > 0)
                {
                    float PercentToGain = Random.Range(0f, 1f);
                    if (PercentToGain < .2f)
                    {
                        GameManager.SkyeTrans++;
                        SkyeTrans.GetComponent<Text>().color = Color.green;
                        SkyePointsToGive--;
                    }
                    else if (PercentToGain < .4f && PercentToGain >= .2f)
                    {
                        GameManager.SkyeCharms++;
                        SkyeCharms.GetComponent<Text>().color = Color.green;
                        SkyePointsToGive--;
                    }
                    else if (PercentToGain < .6f && PercentToGain >= .4f)
                    {
                        GameManager.SkyePotions++;
                        SkyePotions.GetComponent<Text>().color = Color.green;
                        SkyePointsToGive--;
                    }
                    else if (PercentToGain < .8f && PercentToGain >= .6f)
                    {
                        GameManager.SkyeDADA++;
                        SkyeDADA.GetComponent<Text>().color = Color.green;
                        SkyePointsToGive--;
                    }
                    else if (PercentToGain < 1 && PercentToGain >= .8f)
                    {
                        GameManager.SkyeDodge++;
                        SkyeDodge.GetComponent<Text>().color = Color.green;
                        SkyePointsToGive--;
                    }
                }
              
                if (GameManager.SullivanInParty)
                {
                    SullivanExp(totalExp / GameManager.PartyCount * .8f);
                }
                else
                {
                    SullivanExp(totalExp / GameManager.PartyCount * .2f);
                }
            }
        }
        else
        {
            if (GameManager.SullivanInParty)
            {
                SullivanExp(totalExp / GameManager.PartyCount * .8f);
            }
            else
            {
                SullivanExp(totalExp / GameManager.PartyCount * .2f);
            }
        }
    }

    void SullivanExp(float xp)
    {
        if (!SullivanDead)
        {
          //  xp = (totalExp / GameManager.PartyCount * .8f);
            int OldLevel = GameManager.SullivanLevel;

            int safteyLimit = 2000;

            GameManager.SullivanExp += xp;

            while (GameManager.SullivanExp >= GameManager.SullivanTargetExp && safteyLimit-- > 0)
            {
                GameManager.SullivanExp = GameManager.SullivanExp - GameManager.SullivanTargetExp;
                GameManager.SullivanLevel++;

                GameManager.SullivanMaxMagic += 5;
                GameManager.SullivanMaxHealth += 5;
                GameManager.SullivanMagic = GameManager.SullivanMaxMagic;
                GameManager.SullivanHealth = GameManager.SullivanMaxHealth;

                SullivanLevel = true;
                //SLevelUp.SetActive(true);
                GameManager.SullivanTargetExp *= 1.25f;
                //add training points
                int NewLevel = GameManager.SullivanLevel;
                int Difference = NewLevel - OldLevel;
                SullivanPointsToGive = (Difference * 3);

                while (SullivanPointsToGive > 0)
                {
                    float PercentToGain = Random.Range(0f, 1f);
                    if (PercentToGain < .2f)
                    {
                        GameManager.SullivanTrans++;
                        SullivanTrans.GetComponent<Text>().color = Color.green;
                        SullivanPointsToGive--;
                    }
                    else if (PercentToGain < .4f && PercentToGain >= .2f)
                    {
                        GameManager.SullivanCharms++;
                        SullivanCharms.GetComponent<Text>().color = Color.green;
                        SullivanPointsToGive--;
                    }
                    else if (PercentToGain < .6f && PercentToGain >= .4f)
                    {
                        GameManager.SullivanPotions++;
                        SullivanPotions.GetComponent<Text>().color = Color.green;
                        SullivanPointsToGive--;
                    }
                    else if (PercentToGain < .8f && PercentToGain >= .6f)
                    {
                        GameManager.SullivanDADA++;
                        SullivanDADA.GetComponent<Text>().color = Color.green;
                        SullivanPointsToGive--;
                    }
                    else if (PercentToGain < 1 && PercentToGain >= .8f)
                    {
                        GameManager.SullivanDodge++;
                        SullivanDodge.GetComponent<Text>().color = Color.green;
                        SullivanPointsToGive--;
                    }
                }
               
                GracieMayExp(totalExp / GameManager.PartyCount * .8f);
            }
        }
        else
        {
            GracieMayExp(totalExp / GameManager.PartyCount * .8f);
        }
    }

    void GracieMayExp(float xp)
    {
        //xp = (totalExp / GameManager.PartyCount * .8f);
        int OldLevel = GameManager.GracieMayLevel;

        int safteyLimit = 2000;

        GameManager.GracieMayExp += xp;

        while (GameManager.GracieMayExp >= GameManager.GracieMayTargetExp && safteyLimit-- > 0)
        {
            GameManager.GracieMayExp = GameManager.GracieMayExp - GameManager.GracieMayTargetExp;
            GameManager.GracieMayLevel++;

            GracieMayLevel = true;
            //SLevelUp.SetActive(true);
            GameManager.GracieMayTargetExp *= 1.25f;
            //add training points
            int NewLevel = GameManager.GracieMayLevel;
            int Difference = NewLevel - OldLevel;
            GracieMayPointsToGive = (Difference * 3);

            while (GracieMayPointsToGive > 0)
            {
                float PercentToGain = Random.Range(0f, 1f);
                if (PercentToGain < .2f)
                {
                    GameManager.GracieMayTrans++;
                    GracieMayTrans.GetComponent<Text>().color = Color.green;
                    GracieMayPointsToGive--;
                }
                else if (PercentToGain < .4f && PercentToGain >= .2f)
                {
                    GameManager.GracieMayCharms++;
                    GracieMayCharms.GetComponent<Text>().color = Color.green;
                    GracieMayPointsToGive--;
                }
                else if (PercentToGain < .6f && PercentToGain >= .4f)
                {
                    GameManager.GracieMayPotions++;
                    GracieMayPotions.GetComponent<Text>().color = Color.green;
                    GracieMayPointsToGive--;
                }
                else if (PercentToGain < .8f && PercentToGain >= .6f)
                {
                    GameManager.GracieMayDADA++;
                    GracieMayDADA.GetComponent<Text>().color = Color.green;
                    GracieMayPointsToGive--;
                }
                else if (PercentToGain < 1 && PercentToGain >= .8f)
                {
                    GameManager.GracieMayDodge++;
                    GracieMayDodge.GetComponent<Text>().color = Color.green;
                    GracieMayPointsToGive--;
                }
            }
        }

        #region Levels UI
        MCTrans.text = GameManager.MCTrans.ToString();
        MCCharms.text = GameManager.MCCharms.ToString();
        MCPotions.text = GameManager.MCPotions.ToString();
        MCDADA.text = GameManager.MCDADA.ToString();
        MCDodge.text = GameManager.MCDodge.ToString();


        RhysTrans.text = GameManager.RhysTrans.ToString();
        RhysCharms.text = GameManager.RhysCharms.ToString();
        RhysPotions.text = GameManager.RhysPotions.ToString();
        RhysDADA.text = GameManager.RhysDADA.ToString();
        RhysDodge.text = GameManager.RhysDodge.ToString();

        JameelTrans.text = GameManager.JameelTrans.ToString();
        JameelCharms.text = GameManager.JameelCharms.ToString();
        JameelPotions.text = GameManager.JameelPotions.ToString();
        JameelDADA.text = GameManager.JameelDADA.ToString();
        JameelDodge.text = GameManager.JameelDodge.ToString();

        HarperTrans.text = GameManager.HarperTrans.ToString();
        HarperCharms.text = GameManager.HarperCharms.ToString();
        HarperPotions.text = GameManager.HarperPotions.ToString();
        HarperDADA.text = GameManager.HarperDADA.ToString();
        HarperDodge.text = GameManager.HarperDodge.ToString();

        SkyeTrans.text = GameManager.SkyeTrans.ToString();
        SkyeCharms.text = GameManager.SkyeCharms.ToString();
        SkyePotions.text = GameManager.SkyePotions.ToString();
        SkyeDADA.text = GameManager.SkyeDADA.ToString();
        SkyeDodge.text = GameManager.SkyeDodge.ToString();

        SullivanTrans.text = GameManager.SullivanTrans.ToString();
        SullivanCharms.text = GameManager.SullivanCharms.ToString();
        SullivanPotions.text = GameManager.SullivanPotions.ToString();
        SullivanDADA.text = GameManager.SullivanDADA.ToString();
        SullivanDodge.text = GameManager.SullivanDodge.ToString();

        GracieMayTrans.text = GameManager.GracieMayTrans.ToString();
        GracieMayCharms.text = GameManager.GracieMayCharms.ToString();
        GracieMayPotions.text = GameManager.GracieMayPotions.ToString();
        GracieMayDADA.text = GameManager.GracieMayDADA.ToString();
        GracieMayDodge.text = GameManager.GracieMayDodge.ToString();
        #endregion

        StartCoroutine(WaitingAtEndOfBattle());
    }

    void UpdateLifeUI() {
        MCHealth.value = GameManager.MCHealth ;
        RhysHealth.value = GameManager.RhysHealth ;
        JameelHealth.value = GameManager.JameelHealth ;
        HarperHealth.value = GameManager.HarperHealth ;
        SkyeHealth.value = GameManager.SkyeHealth ;
        SullivanHealth.value = GameManager.SullivanHealth;
    }

    void UpdateMagicUI() {
        MCMagic.value = GameManager.MCMagic ;
        RhysMagic.value = GameManager.RhysMagic ;
        JameelMagic.value = GameManager.JameelMagic ;
        HarperMagic.value = GameManager.HarperMagic;
        SkyeMagic.value = GameManager.SkyeMagic ;
        SullivanMagic.value = GameManager.SullivanMagic;
    }

    void CheatToInstantlyWin()
    {

        for (int i = 0; i < enemyUnit.Count; i++)
        {
            enemyUnit[i].TakeDamage(10000);
            Debug.Log("Cheat Activated");
        }
        state = BattleState.WON;
        EndBattle();
        Debug.Log("Attempted To Cheat To Win");
    }

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
