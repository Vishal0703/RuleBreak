using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public bool jump = false;
    public bool crouch = false;
    public bool meleeattack = false;


    public Controls controls;

    void Awake()
    {
        controls = new Controls();
        controls.Player.Jump.performed += _ => Jump();
        controls.Player.Crouch.performed += _ => Crouch(true);
        controls.Player.Crouch.canceled += _ => Crouch(false);
        controls.Player.MeleeAttack.performed += _ => MeleeAttackSet(true);
        //controls.Player.Attack.canceled += _ => Attack(false);
    }

    

    void Jump()
    {
        jump = true;
    }

    void Crouch(bool isCrouching)
    {
        crouch = isCrouching;
    }

    
    void MeleeAttackSet(bool isAttacking)
    {
        meleeattack = isAttacking;
    }


    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
