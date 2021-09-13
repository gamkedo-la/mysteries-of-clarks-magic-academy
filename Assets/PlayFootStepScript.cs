using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepScript : MonoBehaviour
{
    
    public void PlayFootstepSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/StoneSteps");
    }

    public void PlayWandSFXFromFMOD()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/WandSFX");
    }
}
