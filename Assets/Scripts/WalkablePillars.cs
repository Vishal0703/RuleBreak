using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkablePillars : MonoBehaviour
{
    public int walkableMask;
    public void MakeWalkable()
    {
        GameManager.gm.GetComponent<AudioSource>().clip = GameManager.gm.ruleBreakClip;
        GameManager.gm.GetComponent<AudioSource>().Play();

        gameObject.layer = walkableMask;
    }
}
