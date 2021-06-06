using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FriendshipDialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> names;
    private Queue<string> sentences;
  //  private Queue<GameObject> cameras;
    //private Queue<Animator> animations;

    public float WaitTimeSec;
    public FriendshipDialogue dialogue;

    bool conversationStarted;

    Animator datePlay;

    public GameObject thisConversation, nextConversation;
    public GameObject choicesMenu;

    public string RoomToGoTo;

    //need experience/friendship leveling up menu

    public bool toBeContinued;
    public bool isChoice;
    public bool isFinished;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();

        StartCoroutine(InitialWaiting());

        datePlay = GameObject.Find("CanvasForDate").GetComponent<Animator>();
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

    public void StartDialogue(FriendshipDialogue dialogue)
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

      /*  foreach (GameObject cam in dialogue.cameras)
        {
            cameras.Enqueue(cam);
        }
      */
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 && names.Count == 0 /*&& cameras.Count == 0*/)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

     //   GameObject camera = cameras.Dequeue();

        dialogueText.text = sentence;
        nameText.text = name;

     //   camera.SetActive(true);

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
        conversationStarted = false;

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
            datePlay.SetBool("ToPlay", true);
            Debug.Log("This is where you'd level up the relationship.");
            // GameManager.ProgressDay();
            StartCoroutine(Waiting());
        }
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.1f);
        datePlay.SetBool("ToPlay", false);
        StartCoroutine(LoadRoomWait());
    }

    IEnumerator LoadRoomWait()
    {
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(RoomToGoTo);
    }
}