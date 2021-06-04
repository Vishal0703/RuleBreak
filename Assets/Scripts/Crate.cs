using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public void CrateLight()
    {
        GetComponent<Rigidbody2D>().mass = 5f;
        GameManager.gm.GetComponent<AudioSource>().clip = GameManager.gm.ruleBreakClip;
        GameManager.gm.GetComponent<AudioSource>().Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Spike"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
