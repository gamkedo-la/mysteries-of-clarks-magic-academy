using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorToNextArea : MonoBehaviour
{
    bool inRange;
    public string RoomToGoTo;
    public string RoomName;
    public Text RoomText;

    public GameObject UIForRoomChange;

    private void Update()
    {
        if (inRange)
        {
            UIForRoomChange.SetActive(true);
            RoomText.text = RoomName;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(RoomToGoTo);
            }
        }
        else
        {
            UIForRoomChange.SetActive(false);
            RoomText.text = "";

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
            RoomText.text = "";
        }
    }
}
