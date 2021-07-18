using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnObjectOnOnCollision : MonoBehaviour
{
    public GameObject icon;
    public string battleSceneToLoad;
    bool canEnterBattle;
    public GameObject BattleTransition;
    public Animator transition;

    private void Start()
    {
        canEnterBattle = false;
    }

    private void Update()
    {
        if (canEnterBattle)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BattleTransition.SetActive(true);
                transition.SetTrigger("Start");
                StartCoroutine(Waiting());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canEnterBattle = true;
            icon.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canEnterBattle = false;
            icon.SetActive(false);
        }
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(battleSceneToLoad);
        transition.SetTrigger("End");
        BattleTransition.SetActive(false);
        Destroy(this.gameObject);
    }
}
