using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chupacabra_SFX : MonoBehaviour
{
    public void PlayChupacabraAttackSFXFromFMOD () //Calls the Enemy_Chupacabra_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Chupacabra_Attack");
    }

    public void PlayChupacabraDeathSFXFromFMOD () //Calls the Enemy_Chupacabra_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Chupacabra_Death");
    }

    public void PlayChupacabraDamageSFXFromFMOD () //Calls the Enemy_Chupacabra_Damage event in FMOD that plays one of three damage SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Chupacabra_Damage");
    }

    public void PlayChupacabraPowerupSFXFromFMOD () //Calls the Enemy_Chupacabra_Powerup event in FMOD that plays one of three powerup SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Chupacabra_Powerup");
    }
}