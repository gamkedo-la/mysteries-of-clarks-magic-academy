using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForFriends : MonoBehaviour
{
    public float delayedResults;

    public bool Friend1;
    public float PointsToIncreaseBasedOnResponse;

    public GameObject choicesToTurnOff, conversationToTurnOn;

    public void ChoiceSelected()
    {
        conversationToTurnOn.SetActive(true);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(delayedResults);
        if (Friend1)
        {
            Debug.Log("In the game manager, you will add " + PointsToIncreaseBasedOnResponse + " to their score based on your answer");
        }
        choicesToTurnOff.SetActive(false);
    }
}
