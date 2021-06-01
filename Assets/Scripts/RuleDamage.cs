using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RuleDamage : Damage
{
    [SerializeField] float cameraShakeAmplitude = 5f;
    [SerializeField] float cameraShakeTime = 0.1f;
    public override void TakeDamage()
    {
        base.TakeDamage();
        CinemachineShake.cm.ShakeCamera(cameraShakeAmplitude, cameraShakeTime);
    }
}
