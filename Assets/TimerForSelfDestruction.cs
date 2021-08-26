using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForSelfDestruction : MonoBehaviour
{
    private float timerDuration = 5.0f;
    private float elapsedTime = 0.0f;

    private void Start()
    {
        if (!GameManager.pauseMenuTutorialTipHasBeenShown)
        {
            gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timerDuration)
        {
            Destroy(gameObject);
            GameManager.pauseMenuTutorialTipHasBeenShown = true;
        }
    }
}
