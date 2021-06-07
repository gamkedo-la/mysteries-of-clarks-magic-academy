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

    bool movingToward;

    public Animator genericMonsterAnimator;

    GameObject player;


    Rigidbody rb;

    private void Start()
    {
        PickTimes();
        rb = GetComponent<Rigidbody>();

        StartCoroutine(InitialWait());
    }

    private void Update()
    {
        if (!movingToward)
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
                    this.transform.Rotate(0, transform.rotation.y + 180, 0);
                    collided = false;
                }
            }
        }
        if (movingToward)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            Vector3 lookDir = player.transform.position - transform.position;

            if (dist < 10 && dist >= 3)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(lookDir), 50 * Time.deltaTime);
                genericMonsterAnimator.SetBool("inRange", false);

                if (dist < 3)
                {
                    genericMonsterAnimator.SetBool("inRange", false);
                    transform.position += transform.forward * speed * Time.deltaTime * 2;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed * 1.5f);
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

        if (other.tag == "Player")
        {
            movingToward = true;
            genericMonsterAnimator.SetBool("isFollowing", true);
            transform.LookAt(player.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Wall")
        {
            collided = false;
        }
        if (other.tag == "Player")
        {
            movingToward = false;
            genericMonsterAnimator.SetBool("isFollowing", false);
           // transform.LookAt(player.transform);
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(currentWaitTime);
        isNavigating = true;
    }

    IEnumerator InitialWait()
    {
        yield return new WaitForSeconds(3);
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
