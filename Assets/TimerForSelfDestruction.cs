using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForSelfDestruction : MonoBehaviour
{
    public float timerDuration = 5.0f;
    public float slideInTime = 0.5f;
    public float slideOutTime = 0.5f;
    public float slideDistance = 600f;
    private float elapsedTime = 0.0f;
    private Vector3 startPos;
    private RectTransform myRectTransform;

    private void Start()
    {
        if (!GameManager.pauseMenuTutorialTipHasBeenShown)
        {
            Debug.Log("Showing tooltip!");
            //startPos = transform.position; // doesn't work for UI
            myRectTransform = GetComponent<RectTransform>();
            startPos = myRectTransform.localPosition;
            gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        
        // none of the sliding in/out works:
        // sliding in
        if (elapsedTime < slideInTime) {
            //transform.position = new Vector3(startPos.x-(slideDistance*(1f-elapsedTime/slideInTime)),startPos.y,startPos.z);
            //myRectTransform.anchoredPosition  = new Vector3(startPos.x-(slideDistance*(1f-elapsedTime/slideInTime)),startPos.y,startPos.z);
            //Debug.Log("Sliding in tooltip:"+transform.position.x);
        }
        // sliding out
        else if (elapsedTime < (timerDuration-slideOutTime)) {
            //transform.position = new Vector3(startPos.x - (slideDistance * (elapsedTime/(timerDuration-slideOutTime))),startPos.y,startPos.z);
            //myRectTransform.anchoredPosition  = new Vector3(startPos.x - (slideDistance * (elapsedTime/(timerDuration-slideOutTime))),startPos.y,startPos.z);
            //Debug.Log("Sliding out tooltip:"+transform.position.x);
        }
        // done
        if (elapsedTime >= timerDuration)
        {
            Destroy(gameObject);
            GameManager.pauseMenuTutorialTipHasBeenShown = true;
        }
    }
}
