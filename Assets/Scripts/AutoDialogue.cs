using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogue : MonoBehaviour
{
    public float minRandomStart, maxRandomStart, currentTime;
    public GameObject[] possibleConversations;

    private void Start()
    {
        currentTime = Random.Range(minRandomStart, maxRandomStart);
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            int rand = Random.Range(0, possibleConversations.Length);
            possibleConversations[rand].SetActive(true);
            currentTime = 9999;
        }
    }

    public void ChooseAConvo()
    {
        currentTime = Random.Range(minRandomStart, maxRandomStart);
    }
}
