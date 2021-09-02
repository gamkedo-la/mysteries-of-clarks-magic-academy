using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUIButtonClickSound : MonoBehaviour
{
    public void PlayUIButtonClickAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIButtonClick");
    }
}
