using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFriend : MonoBehaviour
{
    //0 = Sunday, 6 = Saturday
    public int DayOfWeek1, DayOfWeek2, DayOfWeek3, DayOfWeek4;
    //0 = Morning, 1 = Lunch, 2 = Afternoon, 3 = Evening, 4 = Night
    public int TimeOfDay1, TimeOfDay2;
    public int month, day;
    public GameObject friend;

    private void Update()
    {
        if (GameManager.month >= month)
        {
            if (GameManager.day >= day)
            {
                if (GameManager.dayOfWeek == DayOfWeek1 || GameManager.dayOfWeek == DayOfWeek2 || GameManager.dayOfWeek == DayOfWeek3 || GameManager.dayOfWeek == DayOfWeek4)
                {
                    if (GameManager.timeOfDay == TimeOfDay1 ||  GameManager.timeOfDay == TimeOfDay2)
                    {
                        friend.SetActive(true);
                    }
                    else
                        friend.SetActive(false);
                }
                else
                    friend.SetActive(false);
            }

            if (GameManager.month > month && GameManager.day <= day)
            {
                if (GameManager.dayOfWeek == DayOfWeek1 || GameManager.dayOfWeek == DayOfWeek2 || GameManager.dayOfWeek == DayOfWeek3 || GameManager.dayOfWeek == DayOfWeek4)
                {
                    if (GameManager.timeOfDay == TimeOfDay1 || GameManager.timeOfDay == TimeOfDay2)
                    {
                        friend.SetActive(true);
                    }
                    else
                        friend.SetActive(false);
                }
                else
                    friend.SetActive(false);
            }
        }

        else
        {
            friend.SetActive(false);
        }
    }
}
