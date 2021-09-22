using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanMeterMonster_SFX : MonoBehaviour
{
    public void PlayVanMeterMonsterAttackSFXFromFMOD () //Calls the Enemy_VanMeterMonster_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_VanMeterMonster_Attack");
    }

    public void PlayVanMeterMonsterDeathSFXFromFMOD () //Calls the Enemy_VanMeterMonster_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_VanMeterMonster_Death");
    }

    public void PlayVanMeterMonsterDamageSFXFromFMOD () //Calls the Enemy_VanMeterMonster_Damage event in FMOD that plays one of three damage SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_VanMeterMonster_Damage");
    }

    public void PlayVanMeterMonsterPowerupSFXFromFMOD () //Calls the Enemy_VanMeterMonster_Powerup event in FMOD that plays one of three powerup SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_VanMeterMonster_Powerup");
    }
}
