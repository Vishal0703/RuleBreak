using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeath : Damage
{
    public override void Die(bool destroyGameObject = false)
    {
        Debug.Log($"Called fom here {destroyGameObject}");
        GameManager.gm.LevelSelect(SceneManager.GetActiveScene().buildIndex, 2f);
        GetComponent<PlayerInputController>().enabled = false;
        GetComponent<Animator>().SetTrigger("death");
        base.Die(destroyGameObject);
        Debug.Log("Player Died");
    }
}
