using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FriendIntro : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public float WaitTimeSec;
    public ClassroomDialogue dialogue;

    public bool toBeContinued;
    public bool isChoice;
    public bool isFinished;

    public GameObject startingConvo;
    public GameObject thisConversation, nextConversation;
    public GameObject choicesMenu;

    public string RoomToGoTo;

    bool isInRange, dialogueHasStarted;
    public GameObject dialogueOption;

    public bool acceptConvo;
    public bool Rhys, Jameel, Harper, Skye, Sullivan, GracieMay, Atorn, Specter, Manraj;

    private void Start()
    {
        sentences = new Queue<string>();

        if (isFinished)
        {
            StartCoroutine(InitialWaiting());
        }
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
            dialogueOption.SetActive(false);
            DisplayNextSentence();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            dialogueOption.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
            dialogueOption.SetActive(false);
        }
    }

    public void StartDialogue(ClassroomDialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);

        if (toBeContinued)
        {
            nextConversation.SetActive(true);
            thisConversation.SetActive(false);
        }
        if (isChoice)
        {
            choicesMenu.SetActive(true);
            thisConversation.SetActive(false);
        }

        if (isFinished)
        {
            if (acceptConvo)
            {
                if (Rhys)
                {
                    GameManager.RhysTalk = true;
                }

                if (Jameel)
                {
                    GameManager.JameelTalk = true;
                }

                if (Harper)
                {
                    GameManager.HarperTalk = true;
                }

                if (Skye)
                {
                    GameManager.SkyeTalk = true;
                }

                if (Sullivan)
                {
                    GameManager.SullivanTalk = true;
                }

                if (GracieMay)
                {
                    GameManager.GracieMayTalk = true;
                }

                if (Atorn)
                {
                    GameManager.AtornTalk = true;
                }

                if (Manraj)
                {
                    GameManager.ManrajTalk = true;
                }

                if (Specter)
                {
                    GameManager.SpecterTalk = true;
                }
                StartCoroutine(Waiting());
            }
            else
            {

                startingConvo.SetActive(true);
                isInRange = false;
                thisConversation.SetActive(false);
                //Player can walk again
            }
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(WaitTimeSec);
      //  datePlay.SetBool("ToPlay", false);
        SceneManager.LoadScene(RoomToGoTo);
    }
}