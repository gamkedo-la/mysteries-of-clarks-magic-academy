using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomDialogueTrigger : MonoBehaviour
{
    public float WaitTimeSec;
    public ClassroomDialogue dialogue;

    private void Start()
    {
        StartCoroutine(InitialWaiting());
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<ClassroomDialogueManager>().StartDialogue(dialogue);
    }

    IEnumerator InitialWaiting()
    {
        yield return new WaitForSeconds(WaitTimeSec);
        TriggerDialogue();
    }
}
