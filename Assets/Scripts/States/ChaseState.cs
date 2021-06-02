using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class ChaseState : IState
{
    public MovableEnemy enemy;
    Seeker seeker;

    Path path;
    int currentWayPoint = 0;
    private float startPathCalcTime;
    Vector2 direction;

    public ChaseState(MovableEnemy _enemy)
    {
        enemy = _enemy;
        seeker = _enemy.GetComponent<Seeker>();
    }
    public void Tick()
    {
        if (Time.time >= startPathCalcTime + 0.5f)
            UpdatePath();

        if (path == null)
            return;

        if (currentWayPoint >= path.vectorPath.Count)
        {
            return;
        }

        direction = path.vectorPath[currentWayPoint] - enemy.transform.position;

        FaceTarget(direction);

        float distance = Vector2.Distance(enemy.transform.position, path.vectorPath[currentWayPoint]);

        if (distance < enemy.nextWayPointDistanceChaseState)
        {
            currentWayPoint++;
        }
    }

    private void FaceTarget(Vector2 direction)
    {
        var currentScale = enemy.transform.localScale;
        if ((enemy.isSpriteRightFacing && direction.x < -enemy.turnThresholdDistance) || ((!enemy.isSpriteRightFacing) && direction.x > enemy.turnThresholdDistance))
        {
            enemy.transform.localScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);
            enemy.isSpriteRightFacing = !enemy.isSpriteRightFacing;
        }
    }

    public void LateTick()
    {
        //FaceTarget(enemy.GetComponent<Rigidbody2D>().velocity);
    }

    public void FixedTick()
    {
        Vector2 normalizedDirection = direction.normalized;
        //Vector2 force = new Vector2(normalizedDirection.x * enemy.chaseSpeed * Time.deltaTime, 0f); // only allowing horizontal movement
        //enemy.GetComponent<Rigidbody2D>().AddForce(force);
        Vector2 velocity = new Vector2(normalizedDirection.x * enemy.chaseSpeed /100f, 0f); // only allowing horizontal movement
        enemy.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void UpdatePath()
    {
        startPathCalcTime = Time.time;
        if (seeker.IsDone())
        {
            seeker.StartPath(enemy.transform.position, enemy.target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    public void OnStateEnter()
    {
        Debug.Log("Chase State Enter");
        UpdatePath();
        enemy.animator.SetBool("chasing", true);
    }

    public void OnStateExit()
    {
        enemy.animator.SetBool("chasing", false);
    }
}
