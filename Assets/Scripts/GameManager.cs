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
        print("i am here ");
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
