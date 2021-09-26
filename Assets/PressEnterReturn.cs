using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEnterReturn : MonoBehaviour
{
    bool hasTurnedOff;
    public float countdown = 100f;
    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            SceneManager.LoadScene("Title");
        }

        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Title");
        }

        if (!hasTurnedOff)
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.SetActive(false);
            hasTurnedOff = true;
        }

    }
}
