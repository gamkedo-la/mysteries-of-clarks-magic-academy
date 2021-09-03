using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public bool spawnedRoomsAreStatic = true; // not allowed to move, but they draw faster
    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    //This is used to determine where to spawn the rooms.
    //If using the o,o,o,o room with a value of 1, it will spawn a room that has a bottom door and will place it in the o,o,o,o top spot. 
    //for 2, it will spawn a room that has a top door and will place it in the o,o,o,o bottom spot
    //for 3, it will spawn a room that has a left door and will place it in the o,o,o,o right spot
    //for 4, it will spawn a room that has a right door and will place it in the o,o,o,o left spot

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    public float waitTime = 2f;

    GameObject parented;
    GameObject thisCreatedGameObject, thisCreatedGameObject2;

    private void Start()
    {
        parented = GameObject.FindGameObjectWithTag("Rooms");
        //Destroy the gameObject's spawn points after 4 seconds so the level doesn't get bogged down with spawns.
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if (templates != null) Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (!spawned)
        {
            if (openingDirection == 1)
            {
                //Need to spawn a room with a BOTTOM door.
                rand = Random.Range(0, templates.bottomRooms.Length);
                thisCreatedGameObject = Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation) as GameObject;
                thisCreatedGameObject.transform.parent = parented.transform;
            }
            else if (openingDirection == 2)
            {
                //Need to spawn a room with a TOP door.
                rand = Random.Range(0, templates.topRooms.Length);
                thisCreatedGameObject = Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation) as GameObject;
                thisCreatedGameObject.transform.parent = parented.transform;
            }
            else if (openingDirection == 3)
            {
                //Need to spawn a room with a LEFT door.
                rand = Random.Range(0, templates.leftRooms.Length);
                thisCreatedGameObject = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation) as GameObject;
                thisCreatedGameObject.transform.parent = parented.transform;
            }
            else if (openingDirection == 4)
            {
                //Need to spawn a room with a RIGHT door.
                rand = Random.Range(0, templates.rightRooms.Length);
                thisCreatedGameObject =  Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation) as GameObject;
                thisCreatedGameObject.transform.parent = parented.transform;
            }
            spawned = true;

            if (spawnedRoomsAreStatic) thisCreatedGameObject.isStatic = true; // static prefabs draw faster but can't move

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpawnPoint")
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                //spawn walls blocking off any openings
                thisCreatedGameObject2 = Instantiate(templates.closedRooms, transform.position, Quaternion.identity) as GameObject;
                thisCreatedGameObject2.transform.parent = parented.transform;
                //if (spawnedRoomsAreStatic) thisCreatedGameObject2.isStatic = true; // static prefabs draw faster but can't move
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
