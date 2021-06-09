using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextArea : MonoBehaviour
{
    bool inRange;
    public string RoomToGoTo;

    public GameObject UIForRoomChange;

    private void Update()
    {
        if (inRange)
        {
            UIForRoomChange.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(RoomToGoTo);
            }
        }
        else
        {
            UIForRoomChange.SetActive(false);
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
        }
    }
}
