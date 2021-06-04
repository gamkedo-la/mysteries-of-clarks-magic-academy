using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator animator;
    public string setBoolToPlay;
    public bool toBePlayed;

    private void Start()
    {
        animator.SetBool(setBoolToPlay, toBePlayed);
    }
}
