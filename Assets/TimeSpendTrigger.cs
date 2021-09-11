using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TimeSpendTrigger : MonoBehaviour
{
    public GameObject InteractionBox, DialogueBox;
    bool inRange;

    GameObject player;

    public string RoomToLoad;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogueBox.SetActive(true);
                InteractionBox.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractionBox.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            InteractionBox.SetActive(false);
            DialogueBox.SetActive(false);
        }
    }

    public void No()
    {
        InteractionBox.SetActive(false);
        DialogueBox.SetActive(false);
    }

    public void Yes()
    {
        SceneManager.LoadScene(RoomToLoad);
    }
}
