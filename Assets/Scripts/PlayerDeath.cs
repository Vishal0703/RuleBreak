using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeath : Damage
{
    [SerializeField]
    GameEvent damageEvent;

    public override void TakeDamage(bool destroyOnDeath, bool fullDamage)
    {
        base.TakeDamage(destroyOnDeath, fullDamage);
        damageEvent.Raise();
    }
    protected override void Die(bool destroyGameObject)
    {
        Debug.Log($"Called fom here {destroyGameObject}");
        var colliders = GetComponents<Collider2D>();
        foreach (var collider in colliders)
            collider.enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GameManager.gm.LevelSelect(SceneManager.GetActiveScene().buildIndex, 2f);
        GetComponent<PlayerInputController>().enabled = false;
        GetComponent<Animator>().SetTrigger("death");
        Debug.Log("Player Died");
        base.Die(destroyGameObject);
    }
}
