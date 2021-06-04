using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerInputController playerInputController;
    Animator animator;
    bool attack;
    public GameObject hammer;

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
        if (attack)
        {
            hammer.SetActive(true);
            animator.SetTrigger("hammerAttack");
            playerInputController.meleeattack = false;
        }
    }

    public void HammerDeactivate()
    {
        hammer.SetActive(false);
    }

    private void FixedUpdate()
    {
        
    }
}
