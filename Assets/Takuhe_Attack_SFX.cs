using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takuhe_Attack_SFX : MonoBehaviour
{
    public void PlayTakuheAttackSFXFromFMOD () 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy_Takuhe_Attack");
    }
}