using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWandSFX : MonoBehaviour
{
    //negligible commit
    public void PlayWandSFXFromFMOD()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/WandSFX");
    }
}
