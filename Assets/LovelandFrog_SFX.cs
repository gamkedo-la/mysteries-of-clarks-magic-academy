using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LovelandFrog_SFX : MonoBehaviour
{
    public void PlayLovelandFrogAttackSFXFromFMOD () //Calls the Enemy_LovelandFrog_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_LovelandFrog_Attack");
    }

    public void PlayLovelandFrogDeathSFXFromFMOD () //Calls the Enemy_LovelandFrog_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_LovelandFrog_Death");
    }

    public void PlayLovelandFrogDamageSFXFromFMOD () //Calls the Enemy_LovelandFrog_Damage event in FMOD that plays one of three damage SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_LovelandFrog_Damage");
    }

    public void PlayLovelandFrogPowerupSFXFromFMOD () //Calls the Enemy_LovelandFrog_Powerup event in FMOD that plays one of three powerup SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_LovelandFrog_Powerup");
    }
}
