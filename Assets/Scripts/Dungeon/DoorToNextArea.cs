using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;

public class DoorToNextArea : MonoBehaviour
{
    bool inRange;
    public string RoomToGoTo;
    public string RoomName;
    public Text RoomText;

    public bool isPortal;

    public Vector3 LocationToSpawnInRoomYoureGoingTo;
    public Quaternion RotationToSpawnInRoomYoureGoingTo;

    public GameObject UIForRoomChange;

    GameObject player; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (GameManager.playerSpawn == new Vector3(0, 0, 0))
        {
            print("first iteration");
        }

        else
        {
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.transform.position = GameManager.playerSpawn;
            player.transform.rotation = GameManager.playerRotation;
            player.GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    private void Update()
    {
        if (inRange)
        {
            UIForRoomChange.SetActive(true);
            if (isPortal)
            {
                RoomText.text = "Portal Room";
            }

            else
            {
                RoomText.text = RoomName;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isPortal)
                {
                    GameManager.playerRotation = player.transform.rotation;
                    GameManager.playerSpawn = player.transform.position;
                    SceneManager.LoadScene("HoldingRoom");
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/DoorOpenShut");
                }

                else
                {
                    GameManager.playerRotation = RotationToSpawnInRoomYoureGoingTo;
                    GameManager.playerSpawn = LocationToSpawnInRoomYoureGoingTo;
                    SceneManager.LoadScene(RoomToGoTo);
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/DoorOpenShut");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("here");
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
