using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
    //Party Agility Stats
    public static int MCAgility, RhysAgility, JameelAgility, HarperAgility, SkyeAgility, SullivanAgility;
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
    //

    //Player Stats
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
        print("here7");
        dayOfWeek = 1;
        month = 4;
        day = 15;

        timeOfDay = 2;
        print("here6");
        displayDayOfWeek = GameObject.Find("DayOfWeek").GetComponent<Text>();
        displayTimeOfDay = GameObject.Find("TimeOfDay").GetComponent<Text>();
        monthAndDay = GameObject.Find("CalendarDay").GetComponent<Text>();
/*
        CanvasAnimator = GameObject.Find("CanvasForDate").GetComponent<Animator>();
        print("here5");
        IntelligenceUI = GameObject.Find("IntelligenceSlider").GetComponent<Slider>();
        CharismaUI = GameObject.Find("CharismaSlider").GetComponent<Slider>();
        CourageUI = GameObject.Find("CourageSlider").GetComponent<Slider>();
        ProficiencyUI = GameObject.Find("ProficiencySlider").GetComponent<Slider>();
        print("here3");
        Intelligence = 15;
        Charisma = 15;
        Courage = 15;
        Proficiency = 15;
        print("here4");
        IncreaseStatLevel();
        print("here2");
*/
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
        }
        if (timeOfDay == 1)
        {
            displayTimeOfDay.text = "Lunch";
        }
        if (timeOfDay == 2)
        {
            displayTimeOfDay.text = "Afternoon";
        }
        if (timeOfDay == 3)
        {
            displayTimeOfDay.text = "Evening";
        }
        if (timeOfDay == 4)
        {
            displayTimeOfDay.text = "Night";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("ClassroomDialogueTest");
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

        print("here");
    }

}
