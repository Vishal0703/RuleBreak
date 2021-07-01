using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonStaticEnemy : Enemy
{
    public Transform[] wayPoints;
    public Transform gun;
    public Transform laser;

    public float moveSpeed = 100f;
    public float viewAngle = 80f;
    public float attackRadius = 2f;
    public float attackInterval = 0.5f;

    public int firstWayPointIndex = 0;
    public float nextWayPointDistanceMoveState = 1f;
    public float turnThresholdDistance = 0.2f; // To check if (waypoint - enemy)'s x distance is greater than threshold - to avoid jitter
    public float idleTimeOutTime = 2f;
    public float idleStartTime = Mathf.Infinity;
    public float stopTimeOutTime = 1f;
    public float stopStartTime = Mathf.Infinity;
    public bool reachedWayPoint = false;
}
