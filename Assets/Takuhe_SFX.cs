using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takuhe_SFX : MonoBehaviour
{
    public void PlayTakuheAttackSFXFromFMOD () //Calls the Enemy_Takuhe_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Takuhe_Attack");
    }

    public void PlayTakuheDeathSFXFromFMOD () //Calls the Enemy_Takuhe_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Takuhe_Death");
    }
}