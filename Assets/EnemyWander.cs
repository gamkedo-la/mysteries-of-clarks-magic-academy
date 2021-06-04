using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    public float speed;
    public float timeMin, timeMax, currentTime;
    public float timeToWaitMin, timeToWaitMax, currentWaitTime;
    bool isNavigating;
    bool isRotating;
    float angle;
    bool collided;


    Rigidbody rb;

    private void Start()
    {
        PickTimes();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isNavigating)
        {
            currentTime -= Time.deltaTime;

            rb.velocity = transform.forward * speed; 

            if (currentTime <= 0)
            {
                isNavigating = false;
                PickTimes();
                isRotating = false;
            }
        }

        if (!isNavigating && !isRotating)
        {
            rb.velocity = transform.forward * 0;
            PickRotation();
            // transform.rotation = Quaternion.Euler(0, angle, 0);
            if (!collided)
            {
                this.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
            }
            if (collided)
            {
                this.transform.Rotate(0,transform.rotation.y + 180, 0);
                collided = false;
            }
        }
    }

    void PickTimes()
    {
        currentTime = Random.Range(timeMin, timeMax);
        currentWaitTime = Random.Range(timeToWaitMin, timeToWaitMax);
        StartCoroutine(Waiting());
    }

    void PickRotation()
    {
        isRotating = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wall")
        {
            currentTime = 0;
            collided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Wall")
        {
            collided = false;
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(currentWaitTime);
        isNavigating = true;
    }
}
