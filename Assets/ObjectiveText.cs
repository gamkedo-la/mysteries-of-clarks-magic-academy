using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveText : MonoBehaviour
{
    public Text ObjText;

    private void Update()
    {
        if (GameManager.month == 4 && (GameManager.day >= 18 && GameManager.day <= 20))
        {
            ObjText.text = "Explore the castle and don't forget to study. Finals are coming soon.";
        }
        if (GameManager.month == 4 && (GameManager.day >= 21 && GameManager.day <= 25))
        {
            ObjText.text = "Find the missing student in the mystery dungeon on the 4th floor.";
        }
        if (GameManager.month == 4 && (GameManager.day >= 26 && GameManager.day <= 27))
        {
            ObjText.text = "After the last couple of days, you need a bit of a break. Hang out with friends, catch up on your studies or work.";
        }
        if (GameManager.month == 4 && (GameManager.day >= 28 && GameManager.day <= 30))
        {
            ObjText.text = "Locate the missing student in the mystery dungeon on the 3rd floor.";
        }
        if (GameManager.month == 5 && (GameManager.day >= 1 && GameManager.day <= 2))
        {
            ObjText.text = "Locate the missing student in the mystery dungeon on the 3rd floor.";
        }
        if (GameManager.month == 5 && (GameManager.day >= 3 && GameManager.day <= 4))
        {
            ObjText.text = "After the last couple of days, you need a bit of a break. Hang out with friends, catch up on your studies or work.";
        }
        if (GameManager.month == 5 && (GameManager.day >= 5 && GameManager.day <= 9))
        {
            ObjText.text = "There was a strange disturbance on the 2nd floor. Investigate it and find the missing student.";
        }
        if (GameManager.month == 5 && (GameManager.day >= 10 && GameManager.day <= 16))
        {
            ObjText.text = "Rumors circulated of a student missing on the Ground Floor. Please rescue them.";
        }
        if (GameManager.month == 5 && GameManager.day == 17)
        {
            ObjText.text = "Take a breathe. These incidents keep happening, but for now you're fine. Go hang out with friends, catch up on your studies or work.";
        }
        if (GameManager.month == 5 && (GameManager.day >= 18 && GameManager.day <= 22))
        {
            ObjText.text = "Per the Headmaster's request, we must save Sullivan in the dungeons.";
        }
        if (GameManager.month == 5 && (GameManager.day >= 23 && GameManager.day <= 27))
        {
            ObjText.text = "Focus and do your best with your final exams.";
        }
        if (GameManager.month == 5 && (GameManager.day >= 28 && GameManager.day <= 29))
        {
            ObjText.text = "Exams are finished. Enjoy the last couple of days of term before the semester is over.";
        }
        if (GameManager.month == 5 && (GameManager.day >= 30 && GameManager.day <= 31))
        {
            ObjText.text = "A professor has gone missing. Ready yourself and take on the one who has been opening these portals.";
        }
        if (GameManager.month == 6 )
        {
            ObjText.text = "The last day of term. You did it. You saved the school. Savor the moment and say your goodbyes for this term.";
        }
    }
}
