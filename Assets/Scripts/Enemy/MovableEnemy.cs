using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEnemy : Enemy
{
    // Start is called before the first frame update
    public Transform[] wayPoints;
    

    StateMachine stateMachine;
    public float chaseRadius = 3f;
    public float attackRadius = 2f;
    public float chaseSpeed = 200f;
    public float moveSpeed = 100f;

    public float nextWayPointDistanceChaseState = 3f;
    public float nextWayPointDistanceMoveState = 1f;
    public float turnThresholdDistance = 0.2f; // To check if (waypoint - enemy)'s x distance is greater than threshold - to avoid jitter
    public float idleTimeOutTime = 2f;
    public float idleStartTime = Mathf.Infinity;
    public bool reachedWayPoint = false;

    new void Awake()
    {
        base.Awake();

        stateMachine = new StateMachine();

        var idleState = new IdleState(this);
        var moveState = new MoveState(this);
        var chaseState = new ChaseState(this);
        var attackState = new AttackState(this);

        Transit(idleState, moveState, IdleTimeOut());
        Transit(idleState, chaseState, InChaseRange());
        Transit(moveState, chaseState, InChaseRange());
        Transit(moveState, idleState, ReachedWayPoint());
        Transit(chaseState, moveState, OutChaseRange());
        Transit(chaseState, attackState, InAttackRange());
        Transit(attackState, chaseState, OutAttackRange());

        stateMachine.SetState(moveState);
        
        void Transit(IState from, IState to, Func<bool> Predicate)
        {
            stateMachine.AddTransition(from, to, Predicate);
        }

        Func<bool> InChaseRange() => () => Vector2.Distance(target.position, transform.position) <= chaseRadius;
        Func<bool> OutChaseRange() => () => Vector2.Distance(target.position, transform.position) > chaseRadius;
        Func<bool> InAttackRange() => () => Vector2.Distance(target.position, transform.position) <= attackRadius;
        Func<bool> OutAttackRange() => () => Vector2.Distance(target.position, transform.position) > attackRadius;
        Func<bool> ReachedWayPoint() => () => reachedWayPoint;
        Func<bool> IdleTimeOut() => () => Time.time >= idleStartTime + idleTimeOutTime;
    }
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        stateMachine.Tick();
    }

    new void LateUpdate()
    {
        base.LateUpdate();
        stateMachine.LateTick();
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        stateMachine.FixedTick();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    public override void Die()
    {
        GetComponent<Seeker>().enabled = false;
        base.Die();
    }
}
