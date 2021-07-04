using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static GameObject directionalLight;
    public Material[] skyBox;

    public static int month, day;
    public static Text monthAndDay;

    public static int dayOfWeek;
    public static Text displayDayOfWeek;

    public static int timeOfDay;
    public static Text displayTimeOfDay;

    public static Animator CanvasAnimator;

    public static int Friend1Experience, Friend1Level;

    public static bool isInFriendConversation;

    public static int Dungeon1FloorCount;
    public static int Dungeon1MiniBossFloor = 2;
    public static int Dungeon1FinalBossFloor = 4;

    //Determining if the Party Member is available (story timeline wise)
    public static bool RhysAvailable, JameelAvailable, GracieMayAvailable, HarperAvailable, SkyeAvailable, SullivanAvailable;
    //

    //This is determining party count size
    public static bool RhysInParty, JameelInParty, HarperInParty, SkyeInParty, SullivanInParty;
    public static int PartyCount;
    //

    //Health and Magic of Party
    public static int MCHealth, RhysHealth, JameelHealth, HarperHealth, SkyeHealth, SullivanHealth;
    public static int MCMagic, RhysMagic, JameelMagic, HarperMagic, SkyeMagic, SullivanMagic;

    public static int MCMaxHealth, RhysMaxHealth, JameelMaxHealth, HarperMaxHealth, SkyeMaxHealth, SullivanMaxHealth;
    public static int MCMaxMagic, RhysMaxMagic, JameelMaxMagic, HarperMaxMagic, SkyeMaxMagic, SullivanMaxMagic;
    //

    //PlayerMagicStats
    public static int MCTrans = 3, MCCharms = 3, MCPotions = 3, MCDADA = 3, MCDodge = 3;
    public static int RhysTrans = 3, RhysCharms = 3, RhysPotions = 3, RhysDADA = 3, RhysDodge = 3;
    public static int JameelTrans = 3, JameelCharms = 3, JameelPotions = 3, JameelDADA = 3, JameelDodge = 3;
    public static int HarperTrans = 3, HarperCharms = 3, HarperPotions = 3, HarperDADA = 3, HarperDodge = 3;
    public static int SkyeTrans = 3, SkyeCharms = 3, SkyePotions = 3, SkyeDADA = 3, SkyeDodge = 3;
    public static int SullivanTrans = 3, SullivanCharms = 3, SullivanPotions = 3, SullivanDADA = 3, SullivanDodge = 3;
    public static int GracieMayTrans = 3, GracieMayCharms = 3, GracieMayPotions = 3, GracieMayDADA = 3, GracieMayDodge = 3;
    //

    // Experience System
    public static float MCExp, RhysExp, JameelExp, HarperExp, SkyeExp, SullivanExp, GracieMayExp;
    public static float MCTargetExp, RhysTargetExp, JameelTargetExp, HarperTargetExp, SkyeTargetExp, SullivanTargetExp, GracieMayTargetExp;
    public static int MCLevel = 1, RhysLevel = 1, JameelLevel = 1, HarperLevel = 1, SkyeLevel = 1, SullivanLevel = 1, GracieMayLevel = 1;
    //

    //ToDetermine the Current Floor of the Dungeon you are in
    public static int CurrentFloor;
    //

    //To determine if the Enemy Attacked the player in the Dungeon
    public static bool enemyAttackedPlayer;
    //

    //If the main character dies in battle
    public static bool isGameOver;
    //

    //Money that the player has collected and can spend
    public static int Money;
    public InventoryObject inventory;
    public static PauseMenu pauseMenu;
    //

    //Player Stats
    public GameObject CanvasForStats;
    public static int Intelligence, Charisma, Courage, Proficiency;
    public static int IntelligenceLevel, CharismaLevel, CourageLevel, ProficiencyLevel;
    public static Slider IntelligenceUI, CharismaUI, CourageUI, ProficiencyUI;
    //
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        dayOfWeek = 1;
        month = 4;
        day = 15;

        directionalLight = GameObject.Find("Sun");

        timeOfDay = 2;
        displayDayOfWeek = GameObject.Find("DayOfWeek").GetComponent<Text>();
        displayTimeOfDay = GameObject.Find("TimeOfDay").GetComponent<Text>();
        monthAndDay = GameObject.Find("CalendarDay").GetComponent<Text>();
        pauseMenu = GetComponentInChildren<PauseMenu>();


        CanvasAnimator = GameObject.Find("CanvasForDate").GetComponent<Animator>();
        IntelligenceUI = GameObject.Find("IntelligenceSlider").GetComponent<Slider>();
        CharismaUI = GameObject.Find("CharismaSlider").GetComponent<Slider>();
        CourageUI = GameObject.Find("CourageSlider").GetComponent<Slider>();
        ProficiencyUI = GameObject.Find("ProficiencySlider").GetComponent<Slider>();
        Intelligence = 0;
        Charisma = 0;
        Courage = 0;
        Proficiency = 0;
        IncreaseStatLevel();

        CanvasForStats = GameObject.Find("CanvasForStats");
        CanvasForStats.SetActive(false);


        CalculateDayOfWeek();
        CalculateCalendarDay();
        CalculateTimeOfDay();

        //MC is always in the party
        PartyCount++;
      //  SkyeInParty = true;
      //  RhysInParty = true;
      //  SullivanInParty = true;
      //  PartyCount++;
      //  PartyCount++;
      //  PartyCount++;

        if (PartyCount > 4)
        {
            Debug.LogError("The party contains more than 4 people");
        }
        //

        MCMaxHealth = 20;
        RhysMaxHealth = 20;
        JameelMaxHealth = 20;
        HarperMaxHealth = 20;
        SkyeMaxHealth = 20;
        SullivanMaxHealth = 20;

        MCHealth = 20;
        RhysHealth = 20;
        JameelHealth = 20;
        HarperHealth = 20;
        SkyeHealth = 20;
        SullivanHealth = 20;

        MCMaxMagic = 20;
        RhysMaxMagic = 20;
        JameelMaxMagic = 20;
        HarperMaxMagic = 20;
        SkyeMaxMagic = 20;
        SullivanMaxMagic = 20;

        MCMagic = 20;
        RhysMagic = 20;
        JameelMagic = 20;
        HarperMagic = 20;
        SkyeMagic = 20;
        SullivanMagic = 20;
    }

    public static void CalculateDayOfWeek()
    {
        if (dayOfWeek == 0)
        {
            displayDayOfWeek.text = "Sunday";
        }
        if (dayOfWeek == 1)
        {
            displayDayOfWeek.text = "Monday";
        }
        if (dayOfWeek == 2)
        {
            displayDayOfWeek.text = "Tuesday";
        }
        if (dayOfWeek == 3)
        {
            displayDayOfWeek.text = "Wednesday";
        }
        if (dayOfWeek == 4)
        {
            displayDayOfWeek.text = "Thursday";
        }
        if (dayOfWeek == 5)
        {
            displayDayOfWeek.text = "Friday";
        }
        if (dayOfWeek == 6)
        {
            displayDayOfWeek.text = "Saturday";
        }
    }

    public static void CalculateCalendarDay()
    {
        if (month == 4 && day > 30)
        {
            month = 5;
            day = 1;
        }

        if (month == 5 && day > 31)
        {
            month = 6;
            day = 1;
        }
        monthAndDay.text = month + "/" + day;
    }

    public static void CalculateTimeOfDay()
    {
        if (timeOfDay == 0)
        {
            displayTimeOfDay.text = "Morning";
            directionalLight.transform.rotation = Quaternion.Euler(17, -30, 17);
        }
        if (timeOfDay == 1)
        {
            displayTimeOfDay.text = "Lunch";
            directionalLight.transform.rotation = Quaternion.Euler(70,0,7);
        }
        if (timeOfDay == 2)
        {
            displayTimeOfDay.text = "Afternoon";
            directionalLight.transform.rotation = Quaternion.Euler(70,0,7);
        }
        if (timeOfDay == 3)
        {
            displayTimeOfDay.text = "Evening";
            directionalLight.transform.rotation = Quaternion.Euler(6,-150,-150);
        }
        if (timeOfDay == 4)
        {
            displayTimeOfDay.text = "Night";
            directionalLight.transform.rotation = Quaternion.Euler(58,-112,-90);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("ClassroomDialogueTest");
        }

        if (timeOfDay == 0)
        {
            RenderSettings.skybox = skyBox[0];
        }
        if (timeOfDay == 1)
        {
            RenderSettings.skybox = skyBox[1];
        }
        if (timeOfDay == 2)
        {
            RenderSettings.skybox = skyBox[1];
        }
        if (timeOfDay == 3)
        {
            RenderSettings.skybox = skyBox[2];
        }
        if (timeOfDay == 4)
        {
            RenderSettings.skybox = skyBox[3];
        }
    }

    public static void ProgressDay()
    {
        timeOfDay++;
        CalculateTimeOfDay();
        if (timeOfDay > 4)
        {
            day++;
            dayOfWeek++;
            if (dayOfWeek > 6)
            {
                dayOfWeek = 0;
            }
            timeOfDay = 0;
            CalculateTimeOfDay();
            CalculateDayOfWeek();
            CalculateCalendarDay();
        }
    }

    public static void IncreaseStatLevel()
    {
        if (Intelligence < 5)
        {
            IntelligenceLevel = 1;
        }
        else if (Intelligence >= 5 && Intelligence < 10)
        {
            IntelligenceLevel = 2;
        }
        else if (Intelligence >= 10 && Intelligence < 15)
        {
            IntelligenceLevel = 3;
        }
        else if (Intelligence >= 15 && Intelligence < 20)
        {
            IntelligenceLevel = 4;
        }
        else if (Intelligence >= 20)
        {
            IntelligenceLevel = 5;
        }

        if (Charisma < 5)
        {
            CharismaLevel = 1;
        }
        else if (Charisma >= 5 && Charisma < 10)
        {
            CharismaLevel = 2;
        }
        else if (Charisma >= 10 && Charisma < 15)
        {
            CharismaLevel = 3;
        }
        else if (Charisma >= 15 && Charisma < 20)
        {
            CharismaLevel = 4;
        }
        else if (Charisma >= 20)
        {
            CharismaLevel = 5;
        }

        if (Courage < 5)
        {
            CourageLevel = 1;
        }
        else if (Courage >= 5 && Courage < 10)
        {
            CourageLevel = 2;
        }
        else if (Courage >= 10 && Courage < 15)
        {
            CourageLevel = 3;
        }
        else if (Courage >= 15 && Courage < 20)
        {
            CourageLevel = 4;
        }
        else if (Courage >= 20)
        {
            CourageLevel = 5;
        }

        if (Proficiency < 5)
        {
            ProficiencyLevel = 1;
        }
        else if (Proficiency >= 5 && Proficiency < 10)
        {
            ProficiencyLevel = 2;
        }
        else if (Proficiency >= 10 && Proficiency < 15)
        {
            ProficiencyLevel = 3;
        }
        else if (Proficiency >= 15 && Proficiency < 20)
        {
            ProficiencyLevel = 4;
        }
        else if (Proficiency >= 20)
        {
            ProficiencyLevel = 5;
        }

        IntelligenceUI.value = IntelligenceLevel;
        CharismaUI.value = CharismaLevel;
        CourageUI.value = CourageLevel;
        ProficiencyUI.value = ProficiencyLevel;
    }

    public void UseItem(ItemObject item, string target){
        SupportItem sItem = (SupportItem) item;
        switch (sItem.property)
        {
            case SupportProperty.Health:
                Debug.Log("Add Health");
                ModifyHealth(sItem.itemUseValue, target);
                break;
            case SupportProperty.Magic:
                Debug.Log("Add Magic");
                ModifyHealth(sItem.itemUseValue, target);
                break;
        }
    }

    public void ModifyHealth (int amount, string target) {
        switch (target)
        {
            case "all":
                MCHealth = MCHealth + amount > MCMaxHealth ? MCMaxHealth : MCHealth + amount;
                RhysHealth = RhysHealth + amount > RhysMaxHealth ? RhysMaxHealth : RhysHealth + amount;
                JameelHealth = JameelHealth + amount > JameelMaxHealth ? JameelMaxHealth : JameelHealth + amount;
                HarperHealth = HarperHealth + amount > HarperMaxHealth ? HarperMaxHealth : HarperHealth + amount;
                SkyeHealth = SkyeHealth + amount > SkyeMaxHealth ? SkyeMaxHealth : SkyeHealth + amount;
                SullivanHealth = SullivanHealth + amount > SullivanMaxHealth ? SullivanMaxHealth : SullivanHealth + amount;
                break;
            case "MC":
                MCHealth = MCHealth + amount > MCMaxHealth ? MCMaxHealth : MCHealth + amount;
                break;
            case "Rhys":
                RhysHealth = RhysHealth + amount > RhysMaxHealth ? RhysMaxHealth : RhysHealth + amount;
                break;
            case "Jameel":
                JameelHealth = JameelHealth + amount > JameelMaxHealth ? JameelMaxHealth : JameelHealth + amount;
                break;
            case "Harper":
                HarperHealth = HarperHealth + amount > HarperMaxHealth ? HarperMaxHealth : HarperHealth + amount;
                break;
            case "Skye":
                SkyeHealth = SkyeHealth + amount > SkyeMaxHealth ? SkyeMaxHealth : SkyeHealth + amount;
                break;
            case "Sullivan":
                SullivanHealth = SullivanHealth + amount > SullivanMaxHealth ? SullivanMaxHealth : SullivanHealth + amount;
                break;
        }
    }

    public void ModifyMagic (int amount, string target) {
        switch (target)
        {
            case "all":
                MCMagic = MCMagic + amount > MCMaxMagic ? MCMaxMagic : MCMagic + amount;
                RhysMagic = RhysMagic + amount > RhysMaxMagic ? RhysMaxMagic : RhysMagic + amount;
                JameelMagic = JameelMagic + amount > JameelMaxMagic ? JameelMaxMagic : JameelMagic + amount;
                HarperMagic = HarperMagic + amount > HarperMaxMagic ? HarperMaxMagic : HarperMagic + amount;
                SkyeMagic = SkyeMagic + amount > SkyeMaxMagic ? SkyeMaxMagic : SkyeMagic + amount;
                SullivanMagic = SullivanMagic + amount > SullivanMaxMagic ? SullivanMaxMagic : SullivanMagic + amount;
                break;
            case "MC":
                MCMagic = MCMagic + amount > MCMaxMagic ? MCMaxMagic : MCMagic + amount;
                break;
            case "Rhys":
                RhysMagic = RhysMagic + amount > RhysMaxMagic ? RhysMaxMagic : RhysMagic + amount;
                break;
            case "Jameel":
                JameelMagic = JameelMagic + amount > JameelMaxMagic ? JameelMaxMagic : JameelMagic + amount;
                break;
            case "Harper":
                HarperMagic = HarperMagic + amount > HarperMaxMagic ? HarperMaxMagic : HarperMagic + amount;
                break;
            case "Skye":
                SkyeMagic = SkyeMagic + amount > SkyeMaxMagic ? SkyeMaxMagic : SkyeMagic + amount;
                break;
            case "Sullivan":
                SullivanMagic = SullivanMagic + amount > SullivanMaxMagic ? SullivanMaxMagic : SullivanMagic + amount;
                break;
        }
    }
}
