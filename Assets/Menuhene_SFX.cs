using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menuhene_SFX : MonoBehaviour
{
       public void PlayMenuheneAttackSFXFromFMOD () //Calls the Enemy_Menuhene_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Menuhene_Attack");
    }

    public void PlayMenuheneDeathSFXFromFMOD () //Calls the Enemy_Menuhene_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Menuhene_Death");
    }

    public void PlayMenuheneDamageSFXFromFMOD () //Calls the Enemy_Menuhene_Damage event in FMOD that plays one of three damage SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Menuhene_Damage");
    }

    public void PlayMenuhenePowerupSFXFromFMOD () //Calls the Enemy_Menuhene_Powerup event in FMOD that plays one of three powerup SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Menuhene_Powerup");
    }
}
