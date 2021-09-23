using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniBossTrigger : MonoBehaviour
{
    public bool Mini1, Mini2, Mini3, Mini4, Mini5, Mini6; 

    public GameObject AttackMenu;
    public GameObject StartFight;

    bool isInRange;

    public string DungeonToLoad;

    public bool isBoss, isMiniBoss;

    private void Start()
    {
        if (Mini1 && GameManager.Dungeon1Mini)
        {
            this.gameObject.SetActive(false);
        }

        if (Mini2 && GameManager.Dungeon2Mini)
        {
            this.gameObject.SetActive(false);
        }

        if (Mini3 && GameManager.Dungeon3Mini)
        {
            this.gameObject.SetActive(false);
        }

        if (Mini4 && GameManager.Dungeon4Mini)
        {
            this.gameObject.SetActive(false);
        }

        if (Mini5 && GameManager.Dungeon5Mini)
        {
            this.gameObject.SetActive(false);
        }

        if (Mini6 && GameManager.Dungeon6Mini)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(isInRange)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartFight.SetActive(true);
                AttackMenu.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            AttackMenu.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            AttackMenu.SetActive(false);
        }
    }

    public void LoadBattle()
    {
        if (isBoss)
        {
            GameManager.isBigBoss = true;
        }
        if (isMiniBoss)
        {
            GameManager.isMiniBoss = true;
        }

        StartFight.SetActive(false);
        AttackMenu.SetActive(false);
        //battle Load room
        SceneManager.LoadScene(DungeonToLoad);
        //preserve this room
    }

    public void Wait()
    {
        StartFight.SetActive(false);
        AttackMenu.SetActive(false);
    }
}
