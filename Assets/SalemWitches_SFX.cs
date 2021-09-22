using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalemWitches_SFX : MonoBehaviour
{
   public void PlaySalemWitchesAttackSFXFromFMOD () //Calls the Enemy_SalemWitches_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_SalemWitches_Attack");
    }

    public void PlaySalemWitchesDeathSFXFromFMOD () //Calls the Enemy_SalemWitches_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_SalemWitches_Death");
    }

    public void PlaySalemWitchesDamageSFXFromFMOD () //Calls the Enemy_SalemWitches_Damage event in FMOD that plays one of three damage SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_SalemWitches_Damage");
    }

    public void PlaySalemWitchesPowerupSFXFromFMOD () //Calls the Enemy_SalemWitches_Powerup event in FMOD that plays one of three powerup SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_SalemWitches_Powerup");
    }
}
