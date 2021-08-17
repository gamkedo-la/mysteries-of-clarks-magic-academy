using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    public GameObject[] students;
    public Animator[] studentAnim;
    public bool isIdle, isCheer, isNo, isYes, isSitting;
    private void Start()
    {
        if (isIdle)
        {
            for (int i = 0; i < students.Length; i++)
            {
                studentAnim[i].SetBool("isIdle", true);
                studentAnim[i].SetBool("isCheer", false);
                studentAnim[i].SetBool("isNo", false);
                studentAnim[i].SetBool("isYes", false);
                studentAnim[i].SetBool("isSitting", false);

                studentAnim[i].GetComponent<Animator>().speed *= Random.Range(0.5f, 1.5f);
            }
        }

        else if (isCheer)
        {
            for (int i = 0; i < students.Length; i++)
            {
                studentAnim[i].SetBool("isIdle", false);
                studentAnim[i].SetBool("isCheer", true);
                studentAnim[i].SetBool("isNo", false);
                studentAnim[i].SetBool("isYes", false);
                studentAnim[i].SetBool("isSitting", false);

                studentAnim[i].GetComponent<Animator>().speed *= Random.Range(0.5f, 1.5f);
            }
        }

        else if(isNo)
        {
            for (int i = 0; i < students.Length; i++)
            {
                studentAnim[i].SetBool("isIdle", false);
                studentAnim[i].SetBool("isCheer", false);
                studentAnim[i].SetBool("isNo", true);
                studentAnim[i].SetBool("isYes", false);
                studentAnim[i].SetBool("isSitting", false);

                studentAnim[i].GetComponent<Animator>().speed *= Random.Range(0.5f, 1.5f);
            }
        }

        else if(isYes)
        {
            for (int i = 0; i < students.Length; i++)
            {
                studentAnim[i].SetBool("isIdle", false);
                studentAnim[i].SetBool("isCheer", false);
                studentAnim[i].SetBool("isNo", false);
                studentAnim[i].SetBool("isYes", true);
                studentAnim[i].SetBool("isSitting", false);

                studentAnim[i].GetComponent<Animator>().speed *= Random.Range(0.5f, 1.5f);
            }
        }

        else if (isSitting)
        {
            for (int i = 0; i < students.Length; i++)
            {
                studentAnim[i].SetBool("isIdle", false);
                studentAnim[i].SetBool("isCheer", false);
                studentAnim[i].SetBool("isNo", false);
                studentAnim[i].SetBool("isYes", false);
                studentAnim[i].SetBool("isSitting", true);

                studentAnim[i].GetComponent<Animator>().speed *= Random.Range(0.5f, 1.5f);
            }
        }


    }
}
