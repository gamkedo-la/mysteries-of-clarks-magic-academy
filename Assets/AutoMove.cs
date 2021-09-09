using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public int Speed;

    private void Update()
    {
        this.transform.position += (transform.right * Time.deltaTime * Speed);
    }
}
