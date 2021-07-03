using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeath : Damage
{
    public override void Die(bool destroyGameObject)
    {
        Debug.Log($"Called fom here {destroyGameObject}");
        var colliders = GetComponents<Collider2D>();
        foreach (var collider in colliders)
            collider.enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GameManager.gm.LevelSelect(SceneManager.GetActiveScene().buildIndex, 2f);
        GetComponent<PlayerInputController>().enabled = false;
        GetComponent<Animator>().SetTrigger("death");
        base.Die(destroyGameObject);
        Debug.Log("Player Died");
    }
}
