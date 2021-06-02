using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth = 0;

    public bool isSpriteRightFacing = true;
    public Animator animator;
    public Transform target;
    protected void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.Log("No animator on this GameObject, trying in children");
            animator = GetComponentInChildren<Animator>();
            if (animator == null)
                Debug.Log("No animator on Children");
            else
                Debug.Log("Found animator on Children");
        }
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
    protected void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    protected void LateUpdate()
    {

    }

    protected void FixedUpdate()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Play Hurt Anim
        animator?.SetTrigger("hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die Anim
        // Disable enemy
        animator?.SetBool("isDead", true);
        Debug.Log($"{transform.name} died");

        //Collider2D[] colliders = GetComponents<Collider2D>();
        //foreach (var collider in colliders)
        //    collider.enabled = false;
        gameObject.layer = 12; //Dead Layer -> so that player can't collide with it
        this.enabled = false;

    }
}
