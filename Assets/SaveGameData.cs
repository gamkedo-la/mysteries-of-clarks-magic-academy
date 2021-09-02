using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveGameData 
{
    //Save Player Name
    public string MCFirstName, MCLastName;

    //Save date, time
    public int month, day, dayOfWeek, timeOfDay;

    //Save unlocked party members
    public bool RhysAvailable, JameelAvailable, GracieMayAvailable, HarperAvailable, SkyeAvailable, SullivanAvailable;
    public bool RhysInParty, JameelInParty, HarperInParty, SkyeInParty, SullivanInParty;
    public int PartyCount;

    //Items/Money
    public  int Money;

    //Friendship levels
    public  int RhysFriendship, JameelFriendship, HarperFriendship, SullivanFriendship, SkyeFriendship, GracieMayFriendship, AtornFriendship, ManrajFriendship, SpecterFriendship;

    //Player stats
    public  int Intelligence, Charisma, Courage, Proficiency;
    public  int IntelligenceLevel, CharismaLevel, CourageLevel, ProficiencyLevel;

    //Party levels
    public  int MCTrans = 3, MCCharms = 3, MCPotions = 3, MCDADA = 3, MCDodge = 3;
    public  int RhysTrans = 3, RhysCharms = 3, RhysPotions = 3, RhysDADA = 3, RhysDodge = 3;
    public  int JameelTrans = 3, JameelCharms = 3, JameelPotions = 3, JameelDADA = 3, JameelDodge = 3;
    public  int HarperTrans = 3, HarperCharms = 3, HarperPotions = 3, HarperDADA = 3, HarperDodge = 3;
    public  int SkyeTrans = 3, SkyeCharms = 3, SkyePotions = 3, SkyeDADA = 3, SkyeDodge = 3;
    public  int SullivanTrans = 3, SullivanCharms = 3, SullivanPotions = 3, SullivanDADA = 3, SullivanDodge = 3;
    public  int GracieMayTrans = 3, GracieMayCharms = 3, GracieMayPotions = 3, GracieMayDADA = 3, GracieMayDodge = 3;

    //Experience in battle - level, amount to next level
    public  float MCExp, RhysExp, JameelExp, HarperExp, SkyeExp, SullivanExp, GracieMayExp;
    public  float MCTargetExp, RhysTargetExp, JameelTargetExp, HarperTargetExp, SkyeTargetExp, SullivanTargetExp, GracieMayTargetExp;
    public  int MCLevel = 1, RhysLevel = 1, JameelLevel = 1, HarperLevel = 1, SkyeLevel = 1, SullivanLevel = 1, GracieMayLevel = 1;

    //Health and Mana for each party member (current, max)
    public  float MCHealth, RhysHealth, JameelHealth, HarperHealth, SkyeHealth, SullivanHealth;
    public  float MCMagic, RhysMagic, JameelMagic, HarperMagic, SkyeMagic, SullivanMagic;

    public  float MCMaxHealth, RhysMaxHealth, JameelMaxHealth, HarperMaxHealth, SkyeMaxHealth, SullivanMaxHealth;
    public  float MCMaxMagic, RhysMaxMagic, JameelMaxMagic, HarperMaxMagic, SkyeMaxMagic, SullivanMaxMagic;

    //Floor Saved in
    public int floorCountName;

    public SaveGameData(GameManager gameManager)
    {
        //Save Player name
        MCFirstName = GameManager.MCFirstName;
        MCLastName = GameManager.MCLastName;

        //Save date, time
        month = GameManager.month;
        day = GameManager.day;
        dayOfWeek = GameManager.dayOfWeek;
        timeOfDay = GameManager.timeOfDay;

        //Save unlocked party members
        RhysAvailable = GameManager.RhysAvailable;
        JameelAvailable = GameManager.JameelAvailable;
        GracieMayAvailable = GameManager.GracieMayAvailable;
        HarperAvailable = GameManager.HarperAvailable;
        SkyeAvailable = GameManager.SkyeAvailable;
        SullivanAvailable = GameManager.SullivanAvailable;

        RhysInParty = GameManager.RhysInParty;
        JameelInParty = GameManager.JameelInParty;
        HarperInParty = GameManager.HarperInParty;
        SkyeInParty = GameManager.SkyeInParty;
        SullivanInParty = GameManager.SullivanInParty;
        PartyCount = GameManager.PartyCount;

        //Items/Money
        Money = GameManager.Money;

        //Friendship levels
        RhysFriendship = GameManager.RhysFriendship;
        JameelFriendship = GameManager.JameelFriendship;
        HarperFriendship = GameManager.HarperFriendship;
        SullivanFriendship = GameManager.SullivanFriendship;
        SkyeFriendship = GameManager.SkyeFriendship;
        GracieMayFriendship = GameManager.GracieMayFriendship;
        AtornFriendship = GameManager.AtornFriendship;
        ManrajFriendship = GameManager.ManrajFriendship;
        SpecterFriendship = GameManager.SpecterFriendship;

        //Player stats
        Intelligence = GameManager.Intelligence;
        Charisma = GameManager.Charisma;
        Courage = GameManager.Courage;
        Proficiency = GameManager.Proficiency;
        IntelligenceLevel = GameManager.IntelligenceLevel;
        CharismaLevel = GameManager.CharismaLevel;
        CourageLevel = GameManager.CourageLevel;
        ProficiencyLevel = GameManager.ProficiencyLevel;

        //Party levels
        MCTrans = GameManager.MCTrans;
        MCCharms = GameManager.MCCharms;
        MCPotions = GameManager.MCPotions;
        MCDADA = GameManager.MCDADA;
        MCDodge = GameManager.MCDodge;

        RhysTrans = GameManager.RhysTrans;
        RhysCharms = GameManager.RhysCharms;
        RhysPotions = GameManager.RhysPotions;
        RhysDADA = GameManager.RhysDADA;
        RhysDodge = GameManager.RhysDodge;

        JameelTrans = GameManager.JameelTrans;
        JameelCharms = GameManager.JameelCharms;
        JameelPotions = GameManager.JameelPotions;
        JameelDADA = GameManager.JameelDADA;
        JameelDodge = GameManager.JameelDodge;

        HarperTrans = GameManager.HarperTrans;
        HarperCharms = GameManager.HarperCharms;
        HarperPotions = GameManager.HarperPotions;
        HarperDADA = GameManager.HarperDADA;
        HarperDodge = GameManager.HarperDodge;

        SkyeTrans = GameManager.SkyeTrans;
        SkyeCharms = GameManager.SkyeCharms;
        SkyePotions = GameManager.SkyePotions;
        SkyeDADA = GameManager.SkyeDADA;
        SkyeDodge = GameManager.SkyeDodge;

        SullivanTrans = GameManager.SullivanTrans;
        SullivanCharms = GameManager.SullivanCharms;
        SullivanPotions = GameManager.SullivanPotions;
        SullivanDADA = GameManager.SullivanDADA;
        SullivanDodge = GameManager.SullivanDodge;

        GracieMayTrans = GameManager.GracieMayTrans;
        GracieMayCharms = GameManager.GracieMayCharms;
        GracieMayPotions = GameManager.GracieMayPotions;
        GracieMayDADA = GameManager.GracieMayDADA;
        GracieMayDodge = GameManager.GracieMayDodge;

        //Experience in battle - level, amount to next level
        MCExp = GameManager.MCExp;
        RhysExp = GameManager.RhysExp;
        JameelExp = GameManager.JameelExp;
        HarperExp = GameManager.HarperExp;
        SkyeExp = GameManager.SkyeExp;
        SullivanExp = GameManager.SullivanExp;
        GracieMayExp = GameManager.GracieMayExp;

        MCTargetExp = GameManager.MCTargetExp;
        RhysTargetExp = GameManager.RhysTargetExp;
        JameelTargetExp = GameManager.JameelTargetExp;
        HarperTargetExp = GameManager.HarperTargetExp;
        SkyeTargetExp = GameManager.SkyeTargetExp;
        SullivanTargetExp = GameManager.SullivanTargetExp;
        GracieMayTargetExp = GameManager.GracieMayTargetExp;

        MCLevel = GameManager.MCLevel;
        RhysLevel = GameManager.RhysLevel;
        JameelLevel = GameManager.JameelLevel;
        HarperLevel = GameManager.HarperLevel;
        SkyeLevel = GameManager.SkyeLevel;
        SullivanLevel = GameManager.SullivanLevel;
        GracieMayLevel = GameManager.GracieMayLevel;

        //Health and Mana for each party member (current, max)
        MCHealth = GameManager.MCHealth;
        RhysHealth = GameManager.RhysHealth;
        JameelHealth = GameManager.JameelHealth;
        HarperHealth = GameManager.HarperHealth;
        SkyeHealth = GameManager.SkyeHealth;
        SullivanHealth = GameManager.SullivanHealth;

        MCMagic = GameManager.MCMagic;
        RhysMagic = GameManager.RhysMagic;
        JameelMagic = GameManager.JameelMagic;
        HarperMagic = GameManager.HarperMagic;
        SkyeMagic = GameManager.SkyeMagic;
        SullivanMagic = GameManager.SullivanMagic;

        MCMaxHealth = GameManager.MCMaxHealth;
        RhysMaxHealth = GameManager.RhysMaxHealth;
        JameelMaxHealth = GameManager.JameelMaxHealth;
        HarperMaxHealth = GameManager.HarperMaxHealth;
        SkyeMaxHealth = GameManager.SkyeMaxHealth;
        SullivanMaxHealth = GameManager.SullivanMaxHealth;

        MCMaxMagic = GameManager.MCMaxMagic;
        RhysMaxMagic = GameManager.RhysMaxMagic;
        JameelMaxMagic = GameManager.JameelMaxMagic;
        HarperMaxMagic = GameManager.HarperMaxMagic;
        SkyeMaxMagic = GameManager.SkyeMaxMagic;
        SullivanMaxMagic = GameManager.SullivanMaxMagic;

        floorCountName = SceneManager.GetActiveScene().buildIndex;
    }
}
