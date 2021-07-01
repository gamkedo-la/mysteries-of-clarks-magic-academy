using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoiceForClassroom : MonoBehaviour
{
    public float delayedResults;

    public float CharmIncrease, IntelligenceIncrease, BoldnessIncrease, ProficiencyIncrease;
    public float HousePointsToIncrease;

    public GameObject choicesToTurnOff, conversationToTurnOn;

    public bool isPractical;
    public Animator player;
    public void ChoiceSelected()
    {
        conversationToTurnOn.SetActive(true);

        if (isPractical)
        {
            player.SetBool("wandMovement", true);
        }

        StartCoroutine(Waiting());
    }
     
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(delayedResults);
        CharmIncrease++;
        IntelligenceIncrease++;
        BoldnessIncrease++;
        ProficiencyIncrease++;
        HousePointsToIncrease++;
        choicesToTurnOff.SetActive(false);
    }
}
