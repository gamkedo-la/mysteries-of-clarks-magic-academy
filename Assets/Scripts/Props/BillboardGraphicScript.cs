using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BillboardGraphicScript : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] bool lockXZ = true;
    [SerializeField] bool invertY = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!mainCamera)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (mainCamera)
        {
            gameObject.transform.LookAt(mainCamera.transform);
            var flip = invertY ? 180f : 0f;

            if (lockXZ)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + flip, 0f);
            }
            else if (invertY)
            {
                gameObject.transform.Rotate(Vector3.up, flip);
            }
            
        }
    }
}
