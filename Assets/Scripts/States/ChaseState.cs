using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChaseState : IState
{
    public MovableEnemy enemy;

    public ChaseState(MovableEnemy _enemy)
    {
        enemy = _enemy;
    }
    public void Tick()
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, new Vector2(enemy.target.position.x,enemy.transform.position.y), enemy.chaseSpeed * Time.deltaTime);
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
    }

    public void FixedTick()
    {
        
    }

    

    public void OnStateEnter()
    {
        Debug.Log("Chase State Enter");
        enemy.animator.SetBool("chasing", true);
    }

    public void OnStateExit()
    {
        enemy.animator.SetBool("chasing", false);
    }
}
