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

    public Vector3 LocationToSpawnInRoomYoureGoingTo;
    public Quaternion RotationToSpawnInRoomYoureGoingTo;

    public GameObject UIForRoomChange;

    GameObject player; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = GameManager.playerSpawn;
        player.transform.rotation = GameManager.playerRotation;
    }

    private void Update()
    {
        if (inRange)
        {
            UIForRoomChange.SetActive(true);
            RoomText.text = RoomName;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.playerRotation = RotationToSpawnInRoomYoureGoingTo;
                GameManager.playerSpawn = LocationToSpawnInRoomYoureGoingTo;
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
