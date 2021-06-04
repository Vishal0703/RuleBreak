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
    public AudioClip damageClip;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage()
    {
        Debug.Log("Damage taken");
        var audioSource = GetComponent<AudioSource>();
        if (audioSource)
            audioSource.PlayOneShot(damageClip);
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
            Die();
    }

    public virtual void Die(bool destroyGameObject = true)
    {
        Debug.Log($"Died {destroyGameObject}");
        if(destroyGameObject)
            Destroy(gameObject);
    }
}
