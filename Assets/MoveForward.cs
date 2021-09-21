using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        this.transform.position += (transform.forward * Time.deltaTime * Speed);
    }
}
