using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnableDisable : MonoBehaviour
{
    public GameObject laserToActivate;
    public void DestroyLaser()
    {
        GameManager.gm.GetComponent<AudioSource>().clip = GameManager.gm.ruleBreakClip;
        GameManager.gm.GetComponent<AudioSource>().Play();

        laserToActivate.SetActive(true);
        Destroy(gameObject);
    }

}
