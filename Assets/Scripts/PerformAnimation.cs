using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformAnimation : MonoBehaviour
{
    public Animator animator;
    public string animimatorBoolToPlay;
    public float durationOfAnimation;
    float currentDuration;
    bool animStarted;

    public void AnimToPlay()
    {
        GameManager.ProgressDay();
    }

}
