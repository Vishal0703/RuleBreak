using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnableDisable : MonoBehaviour
{
    public GameObject laserToActivate;
    public void DestroyLaser()
    {
        laserToActivate.SetActive(true);
        Destroy(gameObject);
    }

}
