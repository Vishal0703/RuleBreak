using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoChaseIdleState : IState
{
    public NoChaseEnemy enemy;

    public NoChaseIdleState(NoChaseEnemy _enemy)
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
        Debug.Log("No Chase Idle State Enter");
        enemy.animator.SetBool("idling", true);
        enemy.idleStartTime = Time.time;
        enemy.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void OnStateExit()
    {
        enemy.animator.SetBool("idling", false);
    }
}
