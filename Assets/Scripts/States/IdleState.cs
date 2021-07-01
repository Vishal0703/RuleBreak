using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public NonStaticEnemy enemy;

    public IdleState(NonStaticEnemy _enemy)
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
        Debug.Log("Idle State Enter");
        enemy.animator.SetBool("idling", true);
        enemy.idleStartTime = Time.time;
        enemy.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void OnStateExit()
    {
        enemy.animator.SetBool("idling", false);
    }
}
