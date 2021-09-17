using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecallSaveFile : MonoBehaviour
{
    private void Start()
    {
        //Play rewind animation
        print("Loading Fail State");
        StartCoroutine(RewindTime());
    }

    IEnumerator RewindTime()
    {
        yield return new WaitForSeconds(4f);
        GameManager.instance.SoftLoadGame();
    }
}
