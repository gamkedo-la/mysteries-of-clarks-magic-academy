using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jackalope_SFX : MonoBehaviour
{
    public void PlayJackalopeAttackSFXFromFMOD () //Calls the Enemy_Jackalope_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Jackalope_Attack");
    }

    public void PlayJackalopeDeathSFXFromFMOD () //Calls the Enemy_Jackalope_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Jackalope_Death");
    }

    public void PlayJackalopeDamageSFXFromFMOD () //Calls the Enemy_Jackalope_Damage event in FMOD that plays one of three damage SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Jackalope_Damage");
    }

    public void PlayJackalopePowerupSFXFromFMOD () //Calls the Enemy_Jackalope_Powerup event in FMOD that plays one of three powerup SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Jackalope_Powerup");
    }
}
