using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnObjectOnOnCollision : MonoBehaviour
{
    public GameObject icon;
    public string battleSceneToLoad;
    bool canEnterBattle;

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
                //Animator To Load Into Battle Scene
                SceneManager.LoadScene(battleSceneToLoad);
                Destroy(this.gameObject);
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

}
