using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    [SerializeField]
    float damageAmount;
    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        Debug.Log("Damage taken");
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
            Die();
    }

    public virtual void Die(bool destroyGameObject = true)
    {
        Debug.Log("Died");
        if(destroyGameObject)
            Destroy(gameObject);
    }
}
