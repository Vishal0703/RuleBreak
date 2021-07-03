using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerInputController playerInputController;
    Animator animator;
    bool attack;
    public GameObject hammer;
    bool previousAttackComplete = true;

    // Start is called before the first frame update
    void Start()
    {
        playerInputController = GetComponent<PlayerInputController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attack = playerInputController.meleeattack;
        if (attack && previousAttackComplete)
        {
            hammer.SetActive(true);
            animator.SetTrigger("hammerAttack");
            playerInputController.meleeattack = false;
            previousAttackComplete = false;
        }
    }

    public void HammerDeactivate()
    {
        hammer.SetActive(false);
        previousAttackComplete = true;
    }

    private void FixedUpdate()
    {
        
    }
}
