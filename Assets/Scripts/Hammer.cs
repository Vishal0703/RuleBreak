using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRadius;
    public AudioClip damageClip;
    public GameObject screenBreak;

    public void DoAttack()
    {
        Debug.Log("Attack Initiaited");
        var audioSource = GetComponent<AudioSource>();
        if(audioSource)
            audioSource.PlayOneShot(damageClip);
        Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)attackPoint.position, attackRadius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Rule"))
            {
                if(screenBreak)
                {
                    Instantiate(screenBreak, collider.gameObject.transform.position + new Vector3(Random.Range(-1f, 1f), 0f, 0f), Quaternion.identity);
                }
                var damage = collider.gameObject.GetComponent<Damage>();
                if (damage == null)
                    Debug.LogWarning("Rule Doesn't have Damage Component, won't be damaged");
                else
                    damage.TakeDamage(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
