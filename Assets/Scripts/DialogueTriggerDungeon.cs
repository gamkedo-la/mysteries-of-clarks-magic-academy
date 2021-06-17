using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTriggerDungeon : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> names;
    private Queue<string> sentences;

    public float WaitTimeSec;
    public DungeonAutoDialogue dialogue;

    bool conversationStarted;

    public GameObject mainCam;
    public GameObject cutSceneCam;

    public Camera main, cut;
    public Canvas canvas;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartDialogue(dialogue);
            conversationStarted = true;
        }
    }

    IEnumerator InitialWaiting()
    {
        yield return new WaitForSeconds(WaitTimeSec);
        StartDialogue(dialogue);
    }

    public void StartDialogue(DungeonAutoDialogue dialogue)
    {
        if (cutSceneCam != null)
        {
            mainCam.SetActive(false);
            cutSceneCam.SetActive(true);

            canvas.worldCamera = cut;
        }

        animator.SetBool("isOpen", true);

        sentences.Clear();
        names.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 && names.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        dialogueText.text = sentence;
        nameText.text = name;

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
        if (cutSceneCam != null)
        {
            mainCam.SetActive(true);
            cutSceneCam.SetActive(false);

            canvas.worldCamera = main;
        }

        animator.SetBool("isOpen", false);
        conversationStarted = false;

        Destroy(this.gameObject);
    }
}