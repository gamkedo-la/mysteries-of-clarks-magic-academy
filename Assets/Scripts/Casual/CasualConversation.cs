using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasualConversation : MonoBehaviour
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

    bool hasEnteredCircle;
    bool conversationStarted;
    public GameObject conversationStarter;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (hasEnteredCircle && !conversationStarted)
        {
            conversationStarter.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(InitialWaiting());
                conversationStarter.SetActive(false);
                conversationStarted = true;
            }
        }

        if (conversationStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DisplayNextSentence();
            }
        }
    }

    IEnumerator InitialWaiting()
    {
        yield return new WaitForSeconds(WaitTimeSec);
        StartDialogue(dialogue);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hasEnteredCircle = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            conversationStarter.SetActive(false);
            hasEnteredCircle = false;
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
            Debug.Log("endOfConversation");
            conversationStarter.SetActive(false);
            conversationStarted = false;
            //can moveAgain
        }
    }
}
