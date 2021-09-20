using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigfoot_SFX : MonoBehaviour
{
    public void PlayBigfootAttackSFXFromFMOD () //Calls the Enemy_Bigfoot_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Bigfoot_Attack");
    }

    public void PlayBigfootDeathSFXFromFMOD () //Calls the Enemy_Bigfoot_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Bigfoot_Death");
    }

    public void PlayBigfootDamageSFXFromFMOD () //Calls the Enemy_Bigfoot_Damage event in FMOD that plays one of three damage SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Bigfoot_Damage");
    }

    public void PlayBigfootPowerupSFXFromFMOD () //Calls the Enemy_Bigfoot_Powerup event in FMOD that plays one of three powerup SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Bigfoot_Powerup");
    }
}
