using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWandSFX : MonoBehaviour
{
    public void PlayWandSFXFromFMOD()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/WandSFX");
    }
}
