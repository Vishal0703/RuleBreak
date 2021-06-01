using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float waitTime = 2f;
    [SerializeField] float timeTillAwake = 3.5f;
    void Start()
    {
        InvokeRepeating("TurnLaserOn", 0f, timeTillAwake + waitTime);
        InvokeRepeating("TurnLaserOff", timeTillAwake, timeTillAwake + waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            var playeDeath = collision.gameObject.GetComponent<PlayerDeath>();
            if (playeDeath != null)
                playeDeath.Die();
        }
    }

    void TurnLaserOn()
    {
        gameObject.SetActive(true);
    }

    void TurnLaserOff()
    {
        gameObject.SetActive(false);
    }
}
