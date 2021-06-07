using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBattle : MonoBehaviour
{
    public string LoadBattleScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Play Sound Effect
            //Play Animation to Battle
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(LoadBattleScene);
    }
}
