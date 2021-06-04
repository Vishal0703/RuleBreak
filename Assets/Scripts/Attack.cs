using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRadius;
    PlayerInputController playerInputController;
    Animator animator;
    bool attack;

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
            animator.SetTrigger("hammerAttack");
            Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)attackPoint.position, attackRadius);
            foreach (var collider in colliders)
            {
                if (collider.gameObject.CompareTag("Rule"))
                {
                    var damage = collider.gameObject.GetComponent<Damage>();
                    if (damage == null)
                        Debug.LogWarning("Rule Doesn't have Damage Component, won't be damaged");
                    else
                        damage.TakeDamage();
                }
            }
            playerInputController.meleeattack = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
