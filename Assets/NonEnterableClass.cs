using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NonEnterableClass : MonoBehaviour
{
    bool inRange;
    public string RoomName;
    public Text RoomText;

    public GameObject UIForRoomChange;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (inRange)
        {
            UIForRoomChange.SetActive(true);
            RoomText.text = RoomName;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            UIForRoomChange.SetActive(false);
            RoomText.text = "";
        }
    }
}
