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

    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<bool> isCalledOn;
    private Queue<GameObject> cameras;
    private Queue<Animation> animationsToPlay;
    public Animator player;
    public GameObject friend;

    public float WaitTimeSec;
    public FriendshipDialogue dialogue;

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

    public bool TimerOnChoice;
    bool startCountdown;
    public float WaitForChoice;

    public bool LevelUp;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        isCalledOn = new Queue<bool>();
        cameras = new Queue<GameObject>();
        animationsToPlay = new Queue<Animation>();

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

        if (startCountdown)
        {
            WaitForChoice -= Time.deltaTime;

            if (WaitForChoice <= 0)
            {
                choicesMenu.SetActive(true);
                thisConversation.SetActive(false);
            }
        }
    }

    public void StartDialogue(FriendshipDialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        sentences.Clear();
        names.Clear();
        isCalledOn.Clear();
        cameras.Clear();
        animationsToPlay.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            foreach (bool called in dialogue.isCalledOn)
            {
                isCalledOn.Enqueue(called);
                foreach (GameObject camera in dialogue.cameras)
                {
                    cameras.Enqueue(camera);
                    foreach (Animation animation in dialogue.animationsToPlay)
                    {
                        animationsToPlay.Enqueue(animation);
                        foreach (string name in dialogue.names)
                        {
                            names.Enqueue(name);
                        }
                    }
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
        string name = names.Dequeue();
        bool called = isCalledOn.Dequeue();
        GameObject camera = cameras.Dequeue();
        Animation animation = animationsToPlay.Dequeue();
        //  friend.GetComponent<Animation>().Play(animationsToPlay);

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeSentence2(name));
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

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    IEnumerator TypeSentence2(string name)
    {
        nameText.text = "";
        foreach (char letter in name.ToCharArray())
        {
            nameText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);

        if (toBeContinued)
        {
            if (LevelUp)
            {
                // public static bool RhysTalk, JameelTalk, HarperTalk, SullivanTalk, SkyeTalk, GracieMayTalk, AtornTalk, ManrajTalk, SpecterTalk;
                if (GameManager.RhysTalk)
                {
                    GameManager.RhysFriendship++;
                }
                else if (GameManager.JameelTalk)
                {
                    GameManager.JameelFriendship++;
                }
                else if (GameManager.HarperTalk)
                {
                    GameManager.HarperFriendship++;
                }
                else if (GameManager.SullivanTalk)
                {
                    GameManager.SullivanFriendship++;
                }
                else if (GameManager.SkyeTalk)
                {
                    GameManager.SkyeFriendship++;
                }
                else if (GameManager.GracieMayTalk)
                {
                    GameManager.GracieMayFriendship++;
                }
                else if (GameManager.ManrajTalk)
                {
                    GameManager.ManrajFriendship++;
                }
                else if (GameManager.AtornTalk)
                {
                    GameManager.AtornFriendship++;
                }
                else if (GameManager.SpecterTalk)
                {
                    GameManager.SpecterFriendship++;
                }
                GameManager.instance.UpdateLevels();
                GameManager.instance.CanvasForFriendship.SetActive(true);
                StartCoroutine(WaitForFriendship());
            }

            else
            {
                nextConversation.SetActive(true);
                thisConversation.SetActive(false);
            }

            if (isTransfigurationDemonstration)
            {
                TransfiguredDemonstration.SetActive(true);
            }
        }
        if (isChoice)
        {
            if (TimerOnChoice)
            {
                startCountdown = true;
            }
            else
            {
                choicesMenu.SetActive(true);
                thisConversation.SetActive(false);
            }
        }
        if (isFinished)
        {
            Debug.Log("endOfConversation");
            GameManager.Intelligence += EndOfLessonLearning;
            //Since there is only one gamemanager, we can reference the instance of the CanvasForStats to turn on or off
            GameManager.instance.CanvasForStats.SetActive(true);
            GameManager.IncreaseStatLevel();
            StartCoroutine(StatsWaiting());
            // GameManager.ProgressDay();

            GameManager.RhysTalk = false;
            GameManager.JameelTalk = false;
            GameManager.HarperTalk = false;
            GameManager.SullivanTalk = false;
            GameManager.SkyeTalk = false;
            GameManager.GracieMayTalk = false;
            GameManager.AtornTalk = false;
            GameManager.ManrajTalk = false;
            GameManager.SpecterTalk = false;
        }
    }
    IEnumerator StatsWaiting()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.CanvasForStats.SetActive(false);
        datePlay.SetBool("ToPlay", true);
        StartCoroutine(Waiting());
    }

    IEnumerator WaitForFriendship()
    {
        yield return new WaitForSeconds(5);
        GameManager.instance.CanvasForFriendship.SetActive(false);
        nextConversation.SetActive(true);
        thisConversation.SetActive(false);
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