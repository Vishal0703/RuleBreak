using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatResponse : MonoBehaviour
{
    public void StopFloat()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
    }
}
