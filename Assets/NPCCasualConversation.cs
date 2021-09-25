using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCasualConversation : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public float WaitTimeSec;
    public ClassroomDialogue dialogue;

    Animator datePlay;

    public GameObject conversationIndicator;
    bool inRange;
    bool convoStarted;

    public Text characterName;
    public string CharacterNameForConvo;

    private void Start()
    {
        sentences = new Queue<string>();
    }


    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                conversationIndicator.SetActive(false);
                StartCoroutine(InitialWaiting());
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            characterName.text = "Talk to " + CharacterNameForConvo;
            conversationIndicator.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            conversationIndicator.SetActive(false);
            inRange = false;
        }
    }

    IEnumerator InitialWaiting()
    {
        yield return new WaitForSeconds(WaitTimeSec);
        StartDialogue(dialogue);
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
        sentence = sentence.Replace("[MC]", GameManager.MCFirstName);
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
        conversationIndicator.SetActive(false);
        inRange = false;
        convoStarted = false;
    }
}

