using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfObjectByDegrees : MonoBehaviour
{
    public GameObject ObjToRotate;
    public float xAxis, yAxis, zAxis;
    // Start is called before the first frame update
    void Start()
    {
        ObjToRotate.transform.rotation = Quaternion.Euler(xAxis, yAxis, zAxis);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
