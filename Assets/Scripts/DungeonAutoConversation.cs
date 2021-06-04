using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonAutoConversation : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> names;
    private Queue<string> sentences;

    public float WaitTimeSec;
    public DungeonAutoDialogue dialogue;

    bool conversationStarted;

    public AutoDialogue autoDialogue;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();

        StartCoroutine(InitialWaiting());
    }

    IEnumerator InitialWaiting()
    {
        yield return new WaitForSeconds(WaitTimeSec);
        StartDialogue(dialogue);
        conversationStarted = true;
    }

    public void StartDialogue(DungeonAutoDialogue dialogue)
    {
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
        StartCoroutine(DisplayFirst());
    }

    IEnumerator DisplayFirst()
    {
        yield return new WaitForSeconds(0.1f);
        if (sentences.Count == 0 && names.Count == 0)
        {
            EndDialogue();
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        dialogueText.text = sentence;
        nameText.text = name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(DisplayNextSentence());
        print(name);
    }

    IEnumerator DisplayNextSentence()
    {
        yield return new WaitForSeconds(3f);
        if (sentences.Count == 0 && names.Count == 0)
        {
            EndDialogue();
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        dialogueText.text = sentence;
        nameText.text = name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(DisplayNextSentence());
        print(name);
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
        conversationStarted = false;

        autoDialogue.ChooseAConvo();

        this.gameObject.SetActive(false);
    }
}
