using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardGraphicScript : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.LookAt(mainCamera.transform);

        gameObject.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 180f, 0f);
    }
}
