using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    HealthData healthData;
    public AudioClip damageClip;

    void Start()
    {
        healthData.currentHealth = healthData.maxHealth;
    }

    public virtual void TakeDamage(bool destroyOnDeath, bool fullDamage)
    {
        Debug.Log("Damage taken");
        var audioSource = GetComponent<AudioSource>();
        if (audioSource)
            audioSource.PlayOneShot(damageClip);
        
        var damageAmount = fullDamage ? healthData.currentHealth : healthData.damageAmount;
        healthData.currentHealth -= damageAmount;
        
        if (healthData.currentHealth <= 0)
            Die(destroyOnDeath);
    }

    protected virtual void Die(bool destroyGameObject)
    {
        healthData.currentHealth = 0;
        var audioSource = GetComponent<AudioSource>();
        if (audioSource)
            audioSource.PlayOneShot(damageClip);
        Debug.Log($"Died {destroyGameObject}");
        if(destroyGameObject)
            Destroy(gameObject);
    }
}
