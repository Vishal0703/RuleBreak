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
            Debug.LogWarning("No animator on this GameObject");
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
}
