using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkablePillars : MonoBehaviour
{
    public int walkableMask;
    public void MakeWalkable()
    {
        gameObject.layer = walkableMask;
    }
}
