using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public bool jump = false;
    public bool crouch = false;
    public bool grapple = false;
    public bool meleeattack = false;
    public bool rangeAttackStart = false;
    public bool rangeAttackPowerUp = false;
    public bool rangeAttackShoot = false;

    public Controls controls;

    void Awake()
    {
        controls = new Controls();
        controls.Player.Jump.performed += _ => Jump();
        controls.Player.Crouch.performed += _ => Crouch(true);
        controls.Player.Crouch.canceled += _ => Crouch(false);
        controls.Player.Grapple.performed += _ => Grapple(true);
        controls.Player.Grapple.canceled += _ => Grapple(false);
        controls.Player.MeleeAttack.performed += _ => MeleeAttackSet(true);
        controls.Player.RangeAttackStart.performed += _ => RangedAttackStart(true);
        controls.Player.RangeAttackStart.canceled += _ => RangedAttackStart(false);
        controls.Player.RangeAttackShoot.performed += _ => RangedAttackPowerup(true);
        //controls.Player.RangeAttackPowerup.canceled += _ => RangedAttackShoot();
        controls.Player.RangeAttackShoot.canceled += _ => RangedAttackPowerup(false);

        controls.Player.RangeAttackShoot.canceled += _ => RangedAttackShoot();

        //controls.Player.Attack.canceled += _ => Attack(false);
    }

    private void RangedAttackPowerup(bool powerUp)
    {
        rangeAttackPowerUp = powerUp;
    }

    private void RangedAttackShoot()
    {
        rangeAttackShoot = true;
    }

    void Jump()
    {
        jump = true;
    }

    void Crouch(bool isCrouching)
    {
        crouch = isCrouching;
    }

    void Grapple(bool isGrappling)
    {
        grapple = isGrappling;
    }

    void MeleeAttackSet(bool isAttacking)
    {
        meleeattack = isAttacking;
    }

    void RangedAttackStart(bool rangeAttackStart)
    {
        this.rangeAttackStart = rangeAttackStart;
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
