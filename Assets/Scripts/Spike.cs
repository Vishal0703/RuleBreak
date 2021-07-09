using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playeDeath = collision.gameObject.GetComponent<PlayerDeath>();
            if (playeDeath != null)
                playeDeath.TakeDamage(false, true);
        }
    }
}
