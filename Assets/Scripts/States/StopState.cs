using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopState : IState
{
    public MovableEnemy enemy;
    Rigidbody2D rigidBody;
    Vector3 closestBound;
    Vector3 startPosition;
    private float startTime;

    public StopState(MovableEnemy _enemy)
    {
        enemy = _enemy;
        rigidBody = enemy.gameObject.GetComponent<Rigidbody2D>();
    }
    public void Tick()
    {
        startTime += Time.deltaTime;
        enemy.transform.position = Vector2.Lerp(startPosition, closestBound, startTime);
        FaceDirection(closestBound - enemy.transform.position);
    }

    private void FaceDirection(Vector2 direction)
    {
        var currentScale = enemy.transform.localScale;
        if ((enemy.isSpriteRightFacing && direction.x < -enemy.turnThresholdDistance) || (!enemy.isSpriteRightFacing && direction.x > enemy.turnThresholdDistance))
        {
            enemy.transform.localScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);
            enemy.isSpriteRightFacing = !enemy.isSpriteRightFacing;
        }
    }

    public void LateTick()
    {
    }

    public void FixedTick()
    {

    }
    public void OnStateEnter()
    {
        Debug.Log("Stop State Enter");
        enemy.animator.SetBool("walking", true);
        enemy.stopStartTime = Time.time;
        Debug.Log($"Enter {enemy.stopStartTime}");
        startPosition = enemy.transform.position;
        startTime = 0f;
        closestBound = GetClosestBound(enemy);
    }

    private Vector3 GetClosestBound(MovableEnemy enemy)
    {
        var leftBound = enemy.leftBound;
        var rightBound = enemy.rightBound;
        if (Vector3.Distance(enemy.transform.position, leftBound.position) <= Vector3.Distance(enemy.transform.position, rightBound.position))
        {
            return leftBound.position;
        }
        else
            return rightBound.position;
    }

    public void OnStateExit()
    {
        Debug.Log($"Stop State Exit {enemy.stopStartTime}, {Time.time}, {enemy.stopStartTime + enemy.stopTimeOutTime}");
        enemy.animator.SetBool("walking", false);
        rigidBody.velocity = Vector2.zero;
        enemy.transform.position = closestBound;
    }
}
