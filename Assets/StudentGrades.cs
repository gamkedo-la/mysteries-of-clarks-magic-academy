using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentGrades : MonoBehaviour
{
    public Text Score, Percent, Message;

    private void Start()
    {
        if ((GameManager.FinalsScore + GameManager.IntelligenceLevel) > 8)
        {
            Percent.text = "A+++";
            Message.text = "You are in the top of your class";
        }
        else if ((GameManager.FinalsScore + GameManager.IntelligenceLevel) == 8)
        {
            Percent.text = "A+";
            Message.text = "You have aced your finals";
        }
        else if ((GameManager.FinalsScore + GameManager.IntelligenceLevel) == 7)
        {
            Percent.text = "B+";
            Message.text = "You are in the top quartile of your class";
        }
        else if ((GameManager.FinalsScore + GameManager.IntelligenceLevel) == 6)
        {
            Percent.text = "C";
            Message.text = "You are in the middle of your class";
        }
        else if ((GameManager.FinalsScore + GameManager.IntelligenceLevel) == 5)
        {
            Percent.text = "D";
            Message.text = "You are barely passed your classes";
        }
        else if ((GameManager.FinalsScore + GameManager.IntelligenceLevel) == 4)
        {
            Percent.text = "F";
            Message.text = "You failed and be taking the year again";
        }
        else if ((GameManager.FinalsScore + GameManager.IntelligenceLevel) == 3)
        {
            Percent.text = "F";
            Message.text = "You failed and be taking the year again";
        }
        else if ((GameManager.FinalsScore + GameManager.IntelligenceLevel) == 2)
        {
            Percent.text = "F";
            Message.text = "You failed and be taking the year again";
        }
        else if ((GameManager.FinalsScore + GameManager.IntelligenceLevel) == 1)
        {
            Percent.text = "F";
            Message.text = "You failed and be taking the year again";
        }
        else 
        {
            Percent.text = "F";
            Message.text = "You failed and be taking the year again";
        }

        Score.text = GameManager.FinalsScore + " / 8";
    }
}
