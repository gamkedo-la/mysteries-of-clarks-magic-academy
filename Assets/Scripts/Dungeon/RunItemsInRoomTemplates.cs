using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunItemsInRoomTemplates : MonoBehaviour
{
    GameObject roomTemplates;
    private void Start()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        roomTemplates = GameObject.Find("RoomTemplates");
        roomTemplates.GetComponent<RoomTemplates>()?.RunStartOfScene();
    }
}
