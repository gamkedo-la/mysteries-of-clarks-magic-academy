using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Camera miniMapCam;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            miniMapCam.rect = new Rect(.1f,0.05f, .8f, .9f);
            miniMapCam.orthographicSize = 100;
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            miniMapCam.rect = new Rect(.7f, 0.05f, .25f, .25f);
            miniMapCam.orthographicSize = 30;
        }
    }
}
