using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapVisionCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
