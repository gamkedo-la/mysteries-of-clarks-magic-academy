using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinFaceFlip : MonoBehaviour
{
    public GameObject mouthFlip;
    public float minTime, maxTime;
    float currentTime;
    public bool stayHappy;
    public bool fire;
    public GameObject fireball;
    bool hasStarted;

    private void Start()
    {
        currentTime = Random.Range(minTime, maxTime);
        StartCoroutine(Waiting());

    }

    public void Update()
    {
        if (hasStarted)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                if (fire)
                {
                    fireball.SetActive(true);
                    mouthFlip.SetActive(false);
                }
                if (!stayHappy)
                {
                    mouthFlip.transform.rotation = Quaternion.Euler(90, 0, 90);
                }
            }
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.5f);
        mouthFlip.transform.rotation = Quaternion.Euler(-90, 0, 90);
        hasStarted = true;
    }
}
