using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossTrigger : MonoBehaviour
{
    public GameObject AttackMenu;
    public GameObject StartFight;

    bool isInRange;

    public bool isBoss, isMiniBoss;

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
        //preserve this room
    }

    public void Wait()
    {
        StartFight.SetActive(false);
        AttackMenu.SetActive(false);
    }
}
