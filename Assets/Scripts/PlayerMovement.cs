using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController2D))]
[RequireComponent(typeof(PlayerInputController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController2D controller;
    PlayerInputController playerInputController;
    Rigidbody2D rigidBody;
    public float runSpeed = 4f;
    public Animator animator;
    float horizontalMove = 0f;
    [SerializeField]
    bool isJumpUpwards = true;
    AudioSource audioSource;
    public AudioClip jumpClip;

    private void Start()
    {
        playerInputController = GetComponent<PlayerInputController>();
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if(animator == null)
        {
            Debug.Log("No animator found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputController.jump)
        {
            animator?.SetBool("isJumping", true);
            if (audioSource)
                audioSource.PlayOneShot(jumpClip);
        }

        horizontalMove = playerInputController.controls.Player.Move.ReadValue<float>() * runSpeed;
        animator?.SetFloat("speed", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, playerInputController.crouch, playerInputController.jump, isJumpUpwards);
        playerInputController.jump = false;
    }

    public void OnLanding()
    {
        animator?.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        //animator?.SetBool("isCrouching", isCrouching);
    }

    public void OnGravityFlip()
    {
        Debug.Log("Response Invoked");
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
        rigidBody.gravityScale = -rigidBody.gravityScale;
        isJumpUpwards = false;
    }
}
