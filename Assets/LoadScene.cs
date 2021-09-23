using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject FadeOut;

    public string RoomToLoad;

    public bool isFatherTimeFight;
    private void Start()
    {
        FadeOut.SetActive(true);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);

        if (isFatherTimeFight)
        {
            GameManager.isBigBoss = true;
        }
        SceneManager.LoadScene(RoomToLoad);
    }
}
