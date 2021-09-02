﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClassroomDialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;
    private Queue<bool> isCalledOn;
    private Queue<bool> isWandMotion;
    public Animator player;
    public bool isWriting;

    public float WaitTimeSec;
    public ClassroomDialogue dialogue;

    public bool toBeContinued;
    public bool isChoice;
    public bool isFinished;

    public GameObject thisConversation, nextConversation;
    public GameObject choicesMenu;

    public string RoomToGoTo;

    Animator datePlay;

    public int EndOfLessonLearning;

    public bool isTransfigurationDemonstration;
    public GameObject TransfiguredDemonstration;

    public bool isFinal;
    public bool isMorningFinal, isEveningFinal;

    public Vector3 LocationToSpawnInRoomYoureGoingTo;
    public Quaternion RotationToSpawnInRoomYoureGoingTo;

    public bool isGreatHall;

    private FMOD.Studio.EventInstance professorWahSound;

    private void Start()
    {
        if (isMorningFinal)
        {
            GameManager.timeOfDay = 1;
        }

        sentences = new Queue<string>();
        isCalledOn = new Queue<bool>();
        isWandMotion = new Queue<bool>();

        if (isFinal)
        {
            GameManager.isFinal = true;
        }

        if (isWriting)
        {
            player.SetBool("isWriting", true);
        }

        StartCoroutine(InitialWaiting());

        datePlay = GameObject.Find("CanvasForDate").GetComponent<Animator>();

        professorWahSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/ProfessorWahs");
    }

    IEnumerator InitialWaiting()
    {
        yield return new WaitForSeconds(WaitTimeSec);
        StartDialogue(dialogue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            professorWahSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            DisplayNextSentence();
        }
    }

    public void StartDialogue(ClassroomDialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();
        isCalledOn.Clear();
        isWandMotion.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            foreach (bool called in dialogue.isCalledOn)
            {
                isCalledOn.Enqueue(called);
                foreach (bool wand in dialogue.isWandMotion)
                {
                    isWandMotion.Enqueue(wand);

                }
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        bool called = isCalledOn.Dequeue();
        bool wand = isWandMotion.Dequeue();

        //update sentence
        sentence = sentence.Replace("[MC]", "Miss " + GameManager.MCLastName);
        sentence = sentence.Replace("[MCFirst]", GameManager.MCFirstName);
        //

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        professorWahSound.start();

        if (!isWriting)
        {
            StartCoroutine(TypeBool(called));
            StartCoroutine(TypeBoolTwo(wand));
        }
    }
    IEnumerator TypeBool(bool called)
    {
        if (called)
        {
            player.SetBool("calledOn", true);
            yield return null;
        }
        else
        {
            player.SetBool("calledOn", false);
            yield return null;
        }
    }
    IEnumerator TypeBoolTwo(bool wand)
    {
        if (wand)
        {
            player.SetBool("wandMovement", true);
            yield return null;
        }
        else
        {
            player.SetBool("wandMovement", false);
            yield return null;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        Debug.Log("anything");
        professorWahSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);

        if (toBeContinued)
        {
            nextConversation.SetActive(true);
            thisConversation.SetActive(false);

            if (isTransfigurationDemonstration)
            {
                TransfiguredDemonstration.SetActive(true);
            }
        }
        if (isChoice)
        {
            choicesMenu.SetActive(true);
            thisConversation.SetActive(false);
        }
        if (isFinished)
        {
            if (isFinal)
            {
                print("here?");
                StartCoroutine(StatsWaitingFinals());
                GameManager.IncreaseStatLevel();
            }

            Debug.Log("endOfConversation");
            GameManager.Intelligence += EndOfLessonLearning ;
            //Since there is only one gamemanager, we can reference the instance of the CanvasForStats to turn on or off
            if (!isGreatHall)
            {
                GameManager.instance.CanvasForStats.SetActive(true);
            }
            if (!isFinal)
            {
                GameManager.IncreaseStatLevel();
                StartCoroutine(StatsWaiting());
            }
           // GameManager.ProgressDay();
        }
    }

    IEnumerator WaitingFinals()
    {
        yield return new WaitForSeconds(2.1f);

        if (isMorningFinal)
        {
            GameManager.timeOfDay = 2;
        }

        if (isEveningFinal)
        {
            GameManager.timeOfDay = 4;
        }
        datePlay.SetBool("ToPlay", false);
        GameManager.timeOfDay++;
        GameManager.ProgressDay();
        print("am i even here");

        StartCoroutine(LoadRoomWait());
    }
    IEnumerator StatsWaiting()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.CanvasForStats.SetActive(false);
        datePlay.SetBool("ToPlay", true);
        StartCoroutine(Waiting());
    }

    IEnumerator StatsWaitingFinals()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.CanvasForStats.SetActive(false);
        datePlay.SetBool("ToPlay", true);
        print("how about here?");
        StartCoroutine(WaitingFinals());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.1f);

        datePlay.SetBool("ToPlay", false);
        isFinal = false;
        GameManager.isFinal = false;
        if (GameManager.freePeriod)
        {
            GameManager.playerRotation = RotationToSpawnInRoomYoureGoingTo;
            GameManager.playerSpawn = LocationToSpawnInRoomYoureGoingTo;
            StartCoroutine(LoadRoomWait());
        }
    }

    IEnumerator LoadRoomWait()
    {
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(RoomToGoTo);
    }
}
