using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RuleDamage : Damage
{
    [SerializeField] float cameraShakeAmplitude = 5f;
    [SerializeField] float cameraShakeTime = 0.1f;
    [SerializeField] GameEvent ruleBreakEvent;
    public override void TakeDamage(bool destroyOnDeath, bool fullDamage)
    {
        base.TakeDamage(destroyOnDeath, fullDamage);
        CinemachineShake.cm.ShakeCamera(cameraShakeAmplitude, cameraShakeTime);
    }

    protected override void Die(bool destroyGameObject)
    {
        ruleBreakEvent.Raise();
        base.Die(destroyGameObject);
    }
}
