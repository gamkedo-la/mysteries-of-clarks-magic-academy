using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessie_SFX : MonoBehaviour
{
      public void PlayChessieAttackSFXFromFMOD () //Calls the Enemy_Chessie_Attack event in FMOD that plays one of three attack SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Chessie_Attack");
    }

    public void PlayChessieDeathSFXFromFMOD () //Calls the Enemy_Chessie_Death event in FMOD that plays one of three death SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Chessie_Death");
    }

    public void PlayChessieDamageSFXFromFMOD () //Calls the Enemy_Chessie_Damage event in FMOD that plays one of three damage SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Chessie_Damage");
    }

    public void PlayChessiePowerupSFXFromFMOD () //Calls the Enemy_Chessie_Powerup event in FMOD that plays one of three powerup SFX randomly.
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Chessie_Powerup");
    }
}
