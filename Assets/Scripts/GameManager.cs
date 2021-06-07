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

        timeOfDay = 2;

        displayDayOfWeek = GameObject.Find("DayOfWeek").GetComponent<Text>();
        displayTimeOfDay = GameObject.Find("TimeOfDay").GetComponent<Text>();
        monthAndDay = GameObject.Find("CalendarDay").GetComponent<Text>();

        CanvasAnimator = GameObject.Find("CanvasForDate").GetComponent<Animator>();

        CalculateDayOfWeek();
        CalculateCalendarDay();
        CalculateTimeOfDay();

        //This is for testing for multiple battle system - please turn this off when you can identify the party count
        //MC is always in the party
        PartyCount++;
        RhysInParty = true;
        PartyCount++;
        JameelInParty = true;
        PartyCount++;
        HarperInParty = true;
        PartyCount++;
        if (PartyCount > 4)
        {
            Debug.LogError("The party contains more than 4 people");
        }
        //

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
        if (Input.GetKeyDown(KeyCode.M))
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
}
