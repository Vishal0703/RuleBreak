using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRadius;
 
    public void DoAttack()
    {
        Debug.Log("Attack Initiaited");
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
