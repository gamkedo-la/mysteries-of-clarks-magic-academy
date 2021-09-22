using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pukwudgie_SFX : MonoBehaviour
{
    public void PlayPukwudgieAttackSFXFromFMOD () //Calls the Enemy_Pukwudgie_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Pukwudgie_Attack");
    }

    public void PlayPukwudgieDeathSFXFromFMOD () //Calls the Enemy_Pukwudgie_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Pukwudgie_Death");
    }

    public void PlayPukwudgieDamageSFXFromFMOD () //Calls the Enemy_Pukwudgie_Damage event in FMOD that plays one of three damage SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Pukwudgie_Damage");
    }

    public void PlayPukwudgiePowerupSFXFromFMOD () //Calls the Enemy_Pukwudgie_Powerup event in FMOD that plays one of three powerup SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Pukwudgie_Powerup");
    }
}
