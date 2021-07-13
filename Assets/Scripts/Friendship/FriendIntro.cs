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

    public GameObject thisConversation, nextConversation;
    public GameObject choicesMenu;

    public string RoomToGoTo;

    Animator datePlay;

    bool isInRange, dialogueHasStarted;
    public GameObject dialogueOption;

    public bool Rhys, Jameel, Harper, Skye, Sullivan, GracieMay, Atorn, Specter, Manraj;

    private void Start()
    {
        sentences = new Queue<string>();

        datePlay = GameObject.Find("CanvasForDate").GetComponent<Animator>();

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
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isFinished)
                {
                    DisplayNextSentence();
                    dialogueHasStarted = true;
                }
                else
                {
                    if (!dialogueHasStarted)
                    {
                        StartDialogue(dialogue);
                        dialogueOption.SetActive(false);
                        dialogueHasStarted = true;
                    }

                    else
                    {
                        DisplayNextSentence();
                    }
                }
            }
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

        if (!isChoice)
        {
            Debug.Log("endOfConversation");
            print("here");
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

            if(Manraj)
            {
                GameManager.ManrajTalk = true;
            }

            if (Specter)
            {
                GameManager.SpecterTalk = true;
            }
            StartCoroutine(Waiting());

          //  datePlay.SetBool("ToPlay", true);
            // GameManager.ProgressDay();

        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(WaitTimeSec);
      //  datePlay.SetBool("ToPlay", false);
        SceneManager.LoadScene(RoomToGoTo);
    }
}