using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpecter : MonoBehaviour
{
    public GameObject MaxSpecter, Other;

    private void Start()
    {
        if (GameManager.SpecterFriendship >= 4)
        {
            MaxSpecter.SetActive(true);
        }
        else
        {
            Other.SetActive(true);
        }
    }
}
