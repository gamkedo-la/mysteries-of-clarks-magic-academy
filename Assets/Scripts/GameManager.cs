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

	public static int currentFloor = 0;
	public static int[] DungeonFloorCount = { 0, 0, 0, 0, 0, 0 };

    public static bool freePeriod;

	//Determining if the Party Member is available (story timeline wise)
	public static bool RhysAvailable, JameelAvailable, GracieMayAvailable, HarperAvailable, SkyeAvailable, SullivanAvailable;
    //

    //This is determining party count size
    public static bool RhysInParty, JameelInParty, HarperInParty, SkyeInParty, SullivanInParty;
    public static int PartyCount;
    //

    //Health and Magic of Party
    public static float MCHealth, RhysHealth, JameelHealth, HarperHealth, SkyeHealth, SullivanHealth;
    public static float MCMagic, RhysMagic, JameelMagic, HarperMagic, SkyeMagic, SullivanMagic;

    public static float MCMaxHealth, RhysMaxHealth, JameelMaxHealth, HarperMaxHealth, SkyeMaxHealth, SullivanMaxHealth;
    public static float MCMaxMagic, RhysMaxMagic, JameelMaxMagic, HarperMaxMagic, SkyeMaxMagic, SullivanMaxMagic;
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

    //Friendship Levels
    public static int RhysFriendship, JameelFriendship, HarperFriendship, SullivanFriendship, SkyeFriendship, GracieMayFriendship, AtornFriendship, ManrajFriendship, SpecterFriendship;
    public GameObject CanvasForFriendship, CanvasForFriendshipBackground;
    public GameObject RhysBackground, JameelBackground, SkyeBackground, HarperBackground, SullivanBackground, GracieMayBackground, AtornBackground, SpecterBackground, ManrajBackground;
    public Image[] FriendLevelUI;
    int colorCount;
    public Text LevelUpText;
    //In a friendship conversation
    public static bool RhysTalk, JameelTalk, HarperTalk, SullivanTalk, SkyeTalk, GracieMayTalk, AtornTalk, ManrajTalk, SpecterTalk;

    //Date change
    public Animator datePlay;
    //Date Slide
    public GameObject DateSlide;
    public Text monthSlide;
    public Text dateSlide;
    public Animation dateSlideAnim;

    //Finals
    public static bool isFinal;

    //Player Name
    public static string MCFirstName;
    public static string MCLastName;

    public static Vector3 playerSpawn;
    public static Quaternion playerRotation;

    // Notifications
    public GameObject notificationPanel;
    public Text notificationText;

    GameObject player;

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
        player = GameObject.FindGameObjectWithTag("Player");

        /* Test player names
        MCFirstName = "Sara";
        MCLastName = "Lee";
        */

        //Start game here
        dayOfWeek = 0;
        month = 4;
        day = 17;

        /*// Finals Testing
        dayOfWeek = 1;
        month = 5;
        day = 28;
        */
        directionalLight = GameObject.Find("Sun");

        timeOfDay = 4;
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

        GracieMayAvailable = true;

        if (PartyCount > 4)
        {
            Debug.LogError("The party contains more than 4 people");
        }
        // Friendship Level
        RhysFriendship = 0;
        JameelFriendship = 0;
        HarperFriendship = 0;
        SullivanFriendship = 0;
        SkyeFriendship = 0;
        GracieMayFriendship = 0;
        AtornFriendship = 0;
        ManrajFriendship = 0;
        SpecterFriendship = 0;
        //
        //Friendship in conversation
        RhysTalk = false;
        JameelTalk = false;
        HarperTalk = false;
        SullivanTalk = false;
        SkyeTalk = false;
        GracieMayTalk = false;
        AtornTalk = false;
        ManrajTalk = false;
        SpecterTalk = false;
        //


        // Starting Experience Level
        MCTargetExp = 5;
        RhysTargetExp = 5;
        JameelTargetExp = 5;
        SkyeTargetExp = 5;
        HarperTargetExp = 5;
        SullivanTargetExp = 5;
        GracieMayTargetExp = 5;
        //

        MCMaxHealth = 20;
        RhysMaxHealth = 20;
        JameelMaxHealth = 20;
        HarperMaxHealth = 20;
        SkyeMaxHealth = 20;
        SullivanMaxHealth = 20;

        MCHealth = 10;
        RhysHealth = 10;
        JameelHealth =10;
        HarperHealth = 10;
        SkyeHealth = 10;
        SullivanHealth = 10;

        MCMaxMagic = 20;
        RhysMaxMagic = 20;
        JameelMaxMagic = 20;
        HarperMaxMagic = 20;
        SkyeMaxMagic = 20;
        SullivanMaxMagic = 20;

        MCMagic = 10;
        RhysMagic = 10;
        JameelMagic = 10;
        HarperMagic = 10;
        SkyeMagic = 10;
        SullivanMagic = 10;
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
        //Turn this off when done testing
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("ClassroomDialogueTest");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            ProgressDay();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            UpdateLevels();
        }
        //
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
        if (!isFinal)
        {
            timeOfDay++;
        }
        CalculateTimeOfDay();
        if (timeOfDay > 4)
        {
            GameManager.instance.DateSlide.SetActive(true);
            if (GameManager.month == 4)
            {
                GameManager.instance.monthSlide.text = "April";
            }

            if (GameManager.month == 5)
            {
                GameManager.instance.monthSlide.text = "May";
            }

            if (GameManager.month == 6)
            {
                GameManager.instance.monthSlide.text = "June";
            }

            if (month == 4 && day == 26)
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + (day + 3) + "      " + "1";
            }

            else if (month == 4 && day == 27)
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + (day + 3) + "      " + "1";
            }

            else if(month == 4 && day == 28)
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + "1" + "      " + "2";
            }

            else if (month == 4 && day == 29)
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + "1" + "     " + "2" + "     " + "3";
            }

            else if (month == 4 && day == 30)
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + "1" + "     " + "2" + "     " + "3" + "     " + "4";
            }

            else if (month == 5 && day == 1)
            {
                GameManager.instance.dateSlide.text = "28" + "     " + "29" + "     " + "30" + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + (day + 3) + "     " + (day + 4);
            }

            else if (month == 5 && day == 2)
            {
                GameManager.instance.dateSlide.text = "29" + "     " + "30" + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + (day + 3) + "     " + (day + 4);
            }

            else if (month == 5 && day == 3)
            {
                GameManager.instance.dateSlide.text = "30" + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + (day + 3) + "     " + (day + 4);
            }

            else if(month == 5 && day == 28)
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + (day + 3) + "      " + "1";
            }

            else if (month == 5 && day == 29)
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + "1" + "     " + "2";
            }

            else if (month == 5 && day == 30)
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + "1" + "     " + "2" + "     " + "3";
            }

            else if (month == 5 && day == 31)
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + "1" + "     " + "2" + "     " + "3" + "     " + "4";
            }

            else if (month == 6 && day == 1)
            {
                GameManager.instance.dateSlide.text = "29" + "     " + "30" + "     " + "31" + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + (day + 3) + "     " + (day + 4);
            }

            else
            {
                GameManager.instance.dateSlide.text = (day - 3) + "     " + (day - 2) + "     " + (day - 1) + "     " + day + "     " + (day + 1) + "     " + (day + 2) + "     " + (day + 3) + "     " + (day + 4);
            }
            GameManager.instance.dateSlideAnim.Play("DateSlide");

            GameManager.instance.StartCoroutine(DateWait());
        }
        else
        {
            GameManager.instance.DetermineSchedule();
        }
    }

    public static IEnumerator DateWait()
    {
        yield return new WaitForSeconds(3f);

        GameManager.instance.DateSlide.SetActive(false);
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
        GameManager.instance.DetermineSchedule();
    }

    public static void IncreaseStatLevel()
    {
        if (Intelligence == 0)
        {
            IntelligenceLevel = 0;
        }

        else if (Intelligence < 5 && Intelligence > 0)
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


        if (Charisma == 0)
        {
            CharismaLevel = 0;
        }
        else if (Charisma < 5 && Charisma > 0)
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


        if (Courage == 0)
        {
            CourageLevel = 0;
        }

        else if (Courage < 5 && Courage > 0)
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

        if (Proficiency == 0)
        {
            ProficiencyLevel = 0;
        }

        else if (Proficiency < 5 && Proficiency > 0)
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
                ModifyMagic(sItem.itemUseValue, target);
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
    #region FriendshipLevelUp
    public void UpdateLevels()
    {
        CanvasForFriendship.SetActive(true);
        if (RhysTalk)
        {
            RhysBackground.SetActive(true);
            for (int i = 0; i < RhysFriendship; i++)
            {
                FriendLevelUI[i].GetComponent<Image>().color = Color.cyan;
                if (RhysFriendship >= 5)
                {
                    LevelUpText.text = "MAX";
                }
                else
                {
                    LevelUpText.text = "Level Up";
                }
            }
        }

        if (JameelTalk)
        {
            JameelBackground.SetActive(true);
            for (int i = 0; i < JameelFriendship; i++)
            {
                FriendLevelUI[i].GetComponent<Image>().color = Color.cyan;
                if (JameelFriendship >= 5)
                {
                    LevelUpText.text = "MAX";
                }
                else
                {
                    LevelUpText.text = "Level Up";
                }
            }
        }

        if (HarperTalk)
        {
            HarperBackground.SetActive(true);
            for (int i = 0; i < HarperFriendship; i++)
            {
                FriendLevelUI[i].GetComponent<Image>().color = Color.cyan;
                if (HarperFriendship >= 5)
                {
                    LevelUpText.text = "MAX";
                }
                else
                {
                    LevelUpText.text = "Level Up";
                }
            }
        }

        if (SkyeTalk)
        {
            SkyeBackground.SetActive(true);
            for (int i = 0; i < SkyeFriendship; i++)
            {
                FriendLevelUI[i].GetComponent<Image>().color = Color.cyan;
                if (SkyeFriendship >= 5)
                {
                    LevelUpText.text = "MAX";
                }
                else
                {
                    LevelUpText.text = "Level Up";
                }
            }
        }

        if (SullivanTalk)
        {
            SullivanBackground.SetActive(true);
            for (int i = 0; i < SullivanFriendship; i++)
            {
                FriendLevelUI[i].GetComponent<Image>().color = Color.cyan;
                if (SullivanFriendship >= 5)
                {
                    LevelUpText.text = "MAX";
                }
                else
                {
                    LevelUpText.text = "Level Up";
                }
            }
        }

        if (GracieMayTalk)
        {
            GracieMayBackground.SetActive(true);
            for (int i = 0; i < GracieMayFriendship; i++)
            {
                FriendLevelUI[i].GetComponent<Image>().color = Color.cyan;
                if (GracieMayFriendship >= 5)
                {
                    LevelUpText.text = "MAX";
                }
                else
                {
                    LevelUpText.text = "Level Up";
                }
            }
        }

        if (AtornTalk)
        {
            AtornBackground.SetActive(true);
            for (int i = 0; i < AtornFriendship; i++)
            {
                FriendLevelUI[i].GetComponent<Image>().color = Color.cyan;
                if (AtornFriendship >= 5)
                {
                    LevelUpText.text = "MAX";
                }
                else
                {
                    LevelUpText.text = "Level Up";
                }
            }
        }

        if (SpecterTalk)
        {
            SpecterBackground.SetActive(true);
            for (int i = 0; i < SpecterFriendship; i++)
            {
                FriendLevelUI[i].GetComponent<Image>().color = Color.cyan;
                if (SpecterFriendship >= 5)
                {
                    LevelUpText.text = "MAX";
                }
                else
                {
                    LevelUpText.text = "Level Up";
                }
            }
        }

        if (ManrajTalk)
        {
            ManrajBackground.SetActive(true);
            for (int i = 0; i < ManrajFriendship; i++)
            {
                FriendLevelUI[i].GetComponent<Image>().color = Color.cyan;
                if (ManrajFriendship >= 5)
                {
                    LevelUpText.text = "MAX";
                }
                else {
                    LevelUpText.text = "Level Up";
                }
            }
        }
        StartCoroutine(JostleColors());
    }

    IEnumerator JostleColors()
    {
        if (colorCount <= 2)
        {
            yield return new WaitForSeconds(.5f);
            if (RhysTalk)
            {
                FriendLevelUI[RhysFriendship - 1].GetComponent<Image>().color = Color.white;
            }

            if (JameelTalk)
            {
                FriendLevelUI[JameelFriendship - 1].GetComponent<Image>().color = Color.white;
            }

            if (HarperTalk)
            {
                FriendLevelUI[HarperFriendship - 1].GetComponent<Image>().color = Color.white;
            }

            if (SkyeTalk)
            {
                FriendLevelUI[SkyeFriendship - 1].GetComponent<Image>().color = Color.white;
            }

            if (SullivanTalk)
            {
                FriendLevelUI[SullivanFriendship - 1].GetComponent<Image>().color = Color.white;
            }

            if (GracieMayTalk)
            {
                FriendLevelUI[GracieMayFriendship - 1].GetComponent<Image>().color = Color.white;
            }

            if (AtornTalk)
            {
                FriendLevelUI[AtornFriendship - 1].GetComponent<Image>().color = Color.white;
            }

            if (SpecterTalk)
            {
                FriendLevelUI[SpecterFriendship - 1].GetComponent<Image>().color = Color.white;
            }

            if (ManrajTalk)
            {
                FriendLevelUI[ManrajFriendship - 1].GetComponent<Image>().color = Color.white;
            }

            yield return new WaitForSeconds(.5f);

            if (RhysTalk)
            {
                FriendLevelUI[RhysFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (JameelTalk)
            {
                FriendLevelUI[JameelFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (HarperTalk)
            {
                FriendLevelUI[HarperFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (SkyeTalk)
            {
                FriendLevelUI[SkyeFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (SullivanTalk)
            {
                FriendLevelUI[SullivanFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (GracieMayTalk)
            {
                FriendLevelUI[GracieMayFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (AtornTalk)
            {
                FriendLevelUI[AtornFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (SpecterTalk)
            {
                FriendLevelUI[SpecterFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (ManrajTalk)
            {
                FriendLevelUI[ManrajFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }
            colorCount++;
            StartCoroutine(JostleColors());
        }
        else
        {
            yield return new WaitForSeconds(.1f);
            if (RhysTalk)
            {
                FriendLevelUI[RhysFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (JameelTalk)
            {
                FriendLevelUI[JameelFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (HarperTalk)
            {
                FriendLevelUI[HarperFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (SkyeTalk)
            {
                FriendLevelUI[SkyeFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (SullivanTalk)
            {
                FriendLevelUI[SullivanFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (GracieMayTalk)
            {
                FriendLevelUI[GracieMayFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (AtornTalk)
            {
                FriendLevelUI[AtornFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (SpecterTalk)
            {
                FriendLevelUI[SpecterFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }

            if (ManrajTalk)
            {
                FriendLevelUI[ManrajFriendship - 1].GetComponent<Image>().color = Color.cyan;
            }
            colorCount = 0;
        }
    }
    #endregion

    public void DatePlay()
    {
        GameManager.instance.datePlay.SetBool("ToPlay", true);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.1f);
        GameManager.instance.datePlay.SetBool("ToPlay", false);
    }

    #region Determine Freedom of Schedule
    public void DetermineSchedule()
    {
        if (dayOfWeek == 1 || dayOfWeek == 2 || dayOfWeek == 3 || dayOfWeek == 4 || dayOfWeek == 5)
        {
            //Weekday mornings
            if (timeOfDay == 0)
            {
                if (month == 4 && (day == 18 || day == 25 || day == 29))
                {
                    SceneManager.LoadScene("CharmsClassroom");
                    print("Load Charms");
                }
                else if (month == 5 && (day == 9 || day == 13 || day == 17 || day == 26))
                {
                    SceneManager.LoadScene("CharmsClassroom");
                    print("Load Charms");
                }
                else if (month == 4 && (day == 21 || day == 28))
                {
                    SceneManager.LoadScene("DADAClassroom");
                    print("Load DADA");
                }
                else if (month == 5 && (day == 12 || day == 19 || day == 25))
                {
                    SceneManager.LoadScene("DADAClassroom");
                    print("Load DADA");
                }
                else if (month == 5 && day == 24)
                {
                    SceneManager.LoadScene("PotionsClassroom");
                    timeOfDay++;
                    print("Load Potions");
                }

                else if (month == 5 && day == 27)
                {
                    SceneManager.LoadScene("TransfigurationClassroom");
                    print("Load Trans");
                }

                else if (month == 4 && (day == 19 || day == 22 || day == 26))
                {
                    print("Progress Day");
                    GameManager.instance.DatePlay();
                    //Load Outside of Charms
                    SceneManager.LoadScene("SecondFloor");
                    playerSpawn = new Vector3(-9.02f, 1.58f, 22.94f);
                    playerRotation = new Quaternion(0,90,0,0);
                }

                else if (month == 5 && (day == 2 || day == 3 || day == 5 || day == 6 || day == 10 || day == 16 || day == 20))
                {
                    GameManager.instance.DatePlay();
                    if (day == 2 || day == 3 || day == 6 || day == 10 || day == 16 || day == 20)
                    {
                        //Load Outside of Charms
                        SceneManager.LoadScene("SecondFloor");
                        playerSpawn = new Vector3(-9.02f, 1.58f, 22.94f);
                        playerRotation = new Quaternion(0, 90, 0, 0);
                    }
                    else
                    {
                        //Load Outside of DADA (5)
                        SceneManager.LoadScene("FourthFloor");
                        playerSpawn = new Vector3(-22.74f, 27.21f, 81.97f);
                        playerRotation = new Quaternion(0, 0, 0, 0);
                    }
                    print("Progress Day");
                }

                else
                {
                    //Load in dorm at start of day
                    freePeriod = true;
                    playerSpawn = new Vector3(-21.18f, 31.78f, -70.54f);
                    playerRotation = new Quaternion(0, 0, 0, 0);
                    SceneManager.LoadScene("FourthFloor");
                    player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    player.transform.position = GameManager.playerSpawn;
                    player.transform.rotation = GameManager.playerRotation;
                    player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                    print("Load a dorm for free period at start of day");
                }
            }

            //Week day lunch
            if (timeOfDay == 1)
            {
                if (month == 5 && (day == 15 || day == 18 || day == 29))
                {
                    SceneManager.LoadScene("GreatHall");
                    print("Load Great Hall");
                }
                else
                {
                    freePeriod = true;
                    print("Load a generic room outside of classroom for free period");
                }
            }


            //Weekday afternoons
            if (timeOfDay == 2)
            {
                if (month == 4 && (day == 22 || day == 27))
                {
                    SceneManager.LoadScene("TransfigurationClassroom");
                    print("Load Trans");
                }

                else if (month == 5 && (day == 2 || day == 6 || day == 11 || day == 20 || day == 25))
                {
                    SceneManager.LoadScene("TransfigurationClassroom");
                    print("Load Trans");
                }

                else if (month == 5 && (day == 5 || day == 12 || day == 26))
                {
                    SceneManager.LoadScene("DADAClassroom");
                    print("Load DADA");
                }

                else if (month == 5 && day == 24)
                {
                    SceneManager.LoadScene("CharmsClassroom");
                    timeOfDay++;
                    print("Load Charms");
                }

                else if (month == 5 && day == 27)
                {
                    SceneManager.LoadScene("PotionsClassroom");
                    print("Load Potions");
                }

                else if (month == 4 && (day == 18 || day == 20 || day == 21 || day == 25 || day == 28 || day == 29))
                {
                    GameManager.instance.DatePlay();
                    print("Progress Day");                    
                    if (day == 18 || day == 20 || day == 25 || day == 29)
                    {
                        //Trans 18, 20, 25, 29
                        SceneManager.LoadScene("ThirdFloor");
                        playerSpawn = new Vector3(-47.55f, 21.15f, -11.96f);
                        playerRotation = new Quaternion(0, 270, 0, 0);
                    }
                    else
                    {
                        //Load Outside of DADA (21, 28)
                        SceneManager.LoadScene("FourthFloor");
                        playerSpawn = new Vector3(-22.74f, 27.21f, 81.97f);
                        playerRotation = new Quaternion(0, 0, 0, 0);
                    }
                 
                }

                else if (month == 5 && (day == 4 || day == 9 || day == 13 || day == 16 || day == 18 || day == 19))
                {
                    GameManager.instance.DatePlay();
                    print("Progress Day");
                    //Trans 4, 9, 13, 16, 18
                    if (day == 4 || day == 9 || day == 13 || day == 16 || day == 18)
                    {
                        //Trans 18, 20, 25, 29
                        SceneManager.LoadScene("ThirdFloor");
                        playerSpawn = new Vector3(-47.55f, 21.15f, -11.96f);
                        playerRotation = new Quaternion(0, 270, 0, 0);
                    }
                    else
                    {
                        //Load Outside of DADA (19)
                        SceneManager.LoadScene("FourthFloor");
                        playerSpawn = new Vector3(-22.74f, 27.21f, 81.97f);
                        playerRotation = new Quaternion(0, 0, 0, 0);
                    }
                }

                else
                {
                    freePeriod = true;
                    SceneManager.LoadScene("GroundFloor");
                    playerSpawn = new Vector3(-15.32f, -6.6f, 35.85f);
                    playerRotation = new Quaternion(0, 90, 0, 0);
                    print("Load outside Great Hall after lunch");
                }
            }
            //Weekday evenings
            if (timeOfDay == 3)
            {
                if (month == 4 && (day == 20 || day == 26))
                {
                    SceneManager.LoadScene("PotionsClassroom");
                    print("Load Potions");
                }

                else if (month == 5 && (day == 3 || day == 4 || day == 10 || day == 18))
                {
                    SceneManager.LoadScene("PotionsClassroom");
                    print("Load Potions");
                }

                else if (month == 4 && (day == 19 || day == 27))
                {
                    print("Progress Day");
                    GameManager.instance.DatePlay();
                    //Potions
                    SceneManager.LoadScene("Dungeons");
                    playerSpawn = new Vector3(54.09f, 1.6f, 23.76f);
                    playerRotation = new Quaternion(0, 90, 0, 0);
                }

                else if (month == 5 && (day == 11 || day == 17))
                {
                    print("Progress Day");
                    GameManager.instance.DatePlay();
                    // Potions
                    SceneManager.LoadScene("Dungeons");
                    playerSpawn = new Vector3(54.09f, 1.6f, 23.76f);
                    playerRotation = new Quaternion(0, 90, 0, 0);
                }

                else if (month == 4 && (day == 18 ||day == 25))
                {
                    SceneManager.LoadScene("GreatHall");
                    print("Load Great Hall");
                }

                else if (month == 5 && (day == 2 || day == 23))
                {
                    SceneManager.LoadScene("GreatHall");
                    print("Load Great Hall");
                }

                else if (month == 6 && day == 1 )
                {
                    SceneManager.LoadScene("GreatHall");
                    print("Load Great Hall");
                }

                //Weekday night
                if (timeOfDay == 4)
                {
                    if (month == 4 && (day == 20 || day == 27))
                    {
                        SceneManager.LoadScene("GreatHall");
                        print("Load Great Hall");
                    }

                    else
                    {
                        freePeriod = true;
                        print("Load outside of potions room or great hall for free period");
                    }
                }
            }
            else
            {
                freePeriod = true;
                print("free period");
            }
        }

        if (dayOfWeek == 0 || dayOfWeek == 6)
        {
            if (month == 5 && (day == 15 || day == 29) && timeOfDay == 1)
            {
                SceneManager.LoadScene("GreatHall");
                print("Load Great Hall");
            }

            else
            {
                if (timeOfDay == 1)
                {
                    ProgressDay();
                }
                if (timeOfDay == 2)
                {
                    ProgressDay();
                }
                playerSpawn = new Vector3(-21.18f, 31.78f, -70.54f);
                playerRotation = new Quaternion(0, 0, 0, 0);
                SceneManager.LoadScene("FourthFloor");
                player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                player.transform.position = GameManager.playerSpawn;
                player.transform.rotation = GameManager.playerRotation;
                player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                print("Load a dorm for free period at start of day");
            }
        }
    }

    public void ToggleNotificationPanel(string newText) {
        notificationText.text = newText;
        notificationPanel.SetActive(!notificationPanel.activeInHierarchy);
    }

    #endregion
}
