using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatResponse : MonoBehaviour
{
    public void StopFloat()
    {
        GameManager.gm.GetComponent<AudioSource>().clip = GameManager.gm.ruleBreakClip;
        GameManager.gm.GetComponent<AudioSource>().Play();


        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(DestroyAfterTimeout());
    }

    IEnumerator DestroyAfterTimeout()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        Destroy(gameObject);
    }
}
