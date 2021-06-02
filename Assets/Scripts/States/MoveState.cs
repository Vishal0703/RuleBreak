using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    public MovableEnemy enemy;
    private int currentIndex = 0;

    public MoveState(MovableEnemy _enemy)
    {
        enemy = _enemy;
    }
    public void Tick()
    {
        enemy.reachedWayPoint = false;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.wayPoints[currentIndex].position, enemy.moveSpeed * Time.deltaTime);
        FaceDirection(enemy.wayPoints[currentIndex].position - enemy.transform.position);
        if (Vector2.Distance(enemy.transform.position, enemy.wayPoints[currentIndex].position) <= enemy.nextWayPointDistanceMoveState)
        {
            enemy.reachedWayPoint = true;
            currentIndex++;
            if (currentIndex >= enemy.wayPoints.Length)
                currentIndex = 0;
        }
    }

    public void LateTick()
    {
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

    public void FixedTick()
    {

    }
    public void OnStateEnter()
    {
        enemy.animator.SetBool("walking", true);
    }

    public void OnStateExit()
    {
        enemy.animator.SetBool("walking", false);
    }
}
