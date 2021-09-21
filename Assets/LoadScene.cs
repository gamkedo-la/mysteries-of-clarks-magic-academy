using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject FadeOut;

    public string RoomToLoad;

    private void Start()
    {
        FadeOut.SetActive(true);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(RoomToLoad);
    }
}
