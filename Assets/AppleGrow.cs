using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGrow : MonoBehaviour
{
    public GameObject apple;
    public float minSize, maxSize;
    float size;
    public bool fiveTime;
    public bool ten;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        size = Random.Range(minSize, maxSize);

        if (fiveTime)
        {
            apple.transform.position += new Vector3(0, .5f, 0);
            apple.transform.localScale = new Vector3(.5f, .5f, .5f);
            
        }
        else if (ten)
        {
            apple.transform.position += new Vector3(0, 2, 0);
            apple.transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            apple.transform.position += new Vector3(0, size, 0);
            apple.transform.localScale = new Vector3(size, size, size);
        }
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(.25f);
        apple.GetComponent<BoxCollider>().enabled = true;
        rb.useGravity = true;
    }
}
