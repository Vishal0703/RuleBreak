using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    HealthData healthData;
    float currentHealth;
    public AudioClip damageClip;

    void Start()
    {
        currentHealth = healthData.maxHealth;
    }

    public virtual void TakeDamage(bool destroyOnDeath)
    {
        Debug.Log("Damage taken");
        var audioSource = GetComponent<AudioSource>();
        if (audioSource)
            audioSource.PlayOneShot(damageClip);
        currentHealth -= healthData.damageAmount;
        if (currentHealth <= 0)
            Die(destroyOnDeath);
    }

    public virtual void Die(bool destroyGameObject)
    {
        var audioSource = GetComponent<AudioSource>();
        if (audioSource)
            audioSource.PlayOneShot(damageClip);
        Debug.Log($"Died {destroyGameObject}");
        if(destroyGameObject)
            Destroy(gameObject);
    }
}
