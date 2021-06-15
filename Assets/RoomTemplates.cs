using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTemplates : MonoBehaviour
{
    public static RoomTemplates Instance;
    //If you want a room to have a higher % chance to get pulled, add multiple instances in the array

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRooms;

    public List<GameObject> rooms;

    public float waitTime;
    private bool exitRoom;
    public GameObject staircase;

    private bool treasurePlaced;
    public float percentChanceToSpawnTreasure = 50;
    float TreasureSpawnPercent;
    public GameObject treasure;

    private bool playerPlaced;
    Vector3 spawnHeight = new Vector3(0, 2f, 0);
    GameObject loadScreen;

    public GameObject enemy;
    public int EnemiesSpawnedPercentageMin = 10, EnemiesSpawnedPercentageMax = 50;
    int enemiesToSpawn;

    GameObject parented;
    GameObject playerSpawn;
    GameObject staircaseSpawn, enemySpawn, treasureSpawn;

    public GameObject StartingPointRoom;
    GameObject startingP;

    GameObject turnOffMenu;
    public string LevelName;

    public GameObject miniBossFloorLayout;
    public GameObject finalBossFloorLayout;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        playerSpawn = GameObject.FindGameObjectWithTag("Player");
        loadScreen = GameObject.Find("LoadingScreen");
        turnOffMenu = GameObject.Find("DialogueBoxForStairs");
        turnOffMenu.SetActive(false);
        parented = GameObject.FindGameObjectWithTag("Rooms");

        if (GameManager.Dungeon1FloorCount == GameManager.Dungeon1MiniBossFloor || GameManager.Dungeon1FloorCount == GameManager.Dungeon1FinalBossFloor)
        {
            if (GameManager.Dungeon1FloorCount == GameManager.Dungeon1MiniBossFloor)
            {
                miniBossFloorLayout.SetActive(true);
            }
            if (GameManager.Dungeon1FloorCount == GameManager.Dungeon1FinalBossFloor)
            {
                finalBossFloorLayout.SetActive(true);
            }
        }

        else
        {
            startingP = Instantiate(StartingPointRoom, transform.position, Quaternion.identity) as GameObject;
            startingP.transform.parent = parented.transform;
            StartCoroutine(Waiting());
            TreasureSpawnPercent = Random.Range(0, 100);
            //  print(TreasureSpawnPercent + " " + percentChanceToSpawnTreasure);
        }
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ClearTheRooms();
        }

        if (waitTime <= 0)
        {
            if (!playerPlaced)
            {
                if (!exitRoom)
                {
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (i == rooms.Count - 1)
                        {
                            staircaseSpawn = Instantiate(staircase, rooms[i].transform.position, Quaternion.identity) as GameObject;

                            if (!treasurePlaced && percentChanceToSpawnTreasure >= TreasureSpawnPercent)
                            {
                                treasureSpawn = Instantiate(treasure, rooms[Random.Range(1, rooms.Count - 1)].transform.position, Quaternion.identity) as GameObject;
                                treasurePlaced = true;
                            }
                            exitRoom = true;
                            playerPlaced = true;

                            staircaseSpawn.transform.parent = parented.transform;
                            treasureSpawn.transform.parent = parented.transform;

                        }
                    }
                }

                playerSpawn.transform.position = rooms[0].transform.position + spawnHeight;
                loadScreen.SetActive(false);
            }
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                if (enemiesToSpawn > 0)
                {
                    Vector3 offset = new Vector3(0, 1.25f, 0);
                    enemySpawn = Instantiate(enemy, rooms[Random.Range(1, rooms.Count - 1)].transform.position + offset, Quaternion.identity) as GameObject;
                    enemiesToSpawn--;
                    enemySpawn.transform.parent = parented.transform;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

    }

    public void RunStartOfScene()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("Player");
        loadScreen = GameObject.Find("LoadingScreen");
        loadScreen.SetActive(false);
        turnOffMenu = GameObject.Find("DialogueBoxForStairs");
        turnOffMenu.SetActive(false);
        parented = GameObject.FindGameObjectWithTag("Rooms");
    }

    public void ClearTheRooms()
    {
        for (int i = rooms.Count - 1; i >= 0; i--)
        {
            Destroy(rooms[i]);
            rooms.RemoveAt(i);
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        enemiesToSpawn = Random.Range(rooms.Count * EnemiesSpawnedPercentageMin / 100, rooms.Count  * EnemiesSpawnedPercentageMax/100);
     //   print(enemiesToSpawn);
    }

    public void AdvanceFloor()
    {
        GameManager.Dungeon1FloorCount++;
        SceneManager.LoadScene("DungeonTest");
        Destroy(this.gameObject);

        //Eventually make this public, track this through the game manager, provide bosses on various specific floors. 
    }

    public void StayOnFloor()
    {
        turnOffMenu.SetActive(false);
    }
}
