using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : Damage
{
    public override void Die(bool destroyGameObject = false)
    {
        Debug.Log($"Called fom here {destroyGameObject}");
        base.Die(destroyGameObject);
        Debug.Log("Player Died");
    }
}
