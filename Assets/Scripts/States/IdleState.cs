using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public MovableEnemy enemy;

    public IdleState(MovableEnemy _enemy)
    {
        enemy = _enemy;
    }
    public void Tick()
    {
        
    }

    public void LateTick()
    {

    }

    public void FixedTick()
    {

    }
    public void OnStateEnter()
    {
        enemy.animator.SetBool("idling", true);
        enemy.idleStartTime = Time.time;
    }

    public void OnStateExit()
    {
        enemy.animator.SetBool("idling", false);
    }
}
