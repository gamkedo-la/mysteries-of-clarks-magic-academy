using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStudents : MonoBehaviour
{
    public int MorningCount, LunchCount, AfternoonCount, EveningCount, NightCount;
    int CurrentCount;
    public GameObject RandomStudent;

    private void Start()
    {
        CreateStudents();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            CreateStudents();
        }
    }

    void CreateStudents()
    {
        if (GameManager.timeOfDay == 0)
        {
            CurrentCount = MorningCount;
        }

        else if (GameManager.timeOfDay == 1)
        {
            CurrentCount = LunchCount;
        }

        else if (GameManager.timeOfDay == 2)
        {
            CurrentCount = AfternoonCount;
        }

        else if (GameManager.timeOfDay == 3)
        {
            CurrentCount = EveningCount;
        }

        else if (GameManager.timeOfDay == 4)
        {
            CurrentCount = NightCount;
        }
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);

        print(GameManager.timeOfDay + " " + CurrentCount);

        for (int i = 0; i < CurrentCount; i++)
        {
            Instantiate(RandomStudent, transform.position, transform.rotation);
            CurrentCount--;
        }
    }
}
