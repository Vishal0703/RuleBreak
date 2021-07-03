using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float waitTime = 2f;
    [SerializeField] float timeTillAwake = 3.5f;
    public Transform target;
    public bool hitPlayer = false;
    void Start()
    {
        if(timeTillAwake >0 && waitTime > 0)
        {
            InvokeRepeating("TurnLaserOn", 0f, timeTillAwake + waitTime);
            InvokeRepeating("TurnLaserOff", timeTillAwake, timeTillAwake + waitTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Debug.Log($"{transform.position}");
        var distanceToCheck = Vector3.Distance(transform.position, target.position);
        var hits = Physics2D.RaycastAll(transform.position, target.position - transform.position, distanceToCheck);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Player") && hitPlayer)
            {
                Debug.Log($"laser {transform.position} hitting player");
                var playeDeath = hit.collider.gameObject.GetComponent<PlayerDeath>();
                if (playeDeath != null)
                    playeDeath.TakeDamage(false);
                hitPlayer = false;
            }
        }
    }
    private void OnEnable()
    {
        hitPlayer = true;
    }

    private void OnDisable()
    {
        hitPlayer = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Player"))
    //    {
    //        var playeDeath = collision.gameObject.GetComponent<PlayerDeath>();
    //        if (playeDeath != null)
    //            playeDeath.Die();
    //    }
    //}

    void TurnLaserOn()
    {
        gameObject.SetActive(true);
    }

    void TurnLaserOff()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, target.position);
    }
}
