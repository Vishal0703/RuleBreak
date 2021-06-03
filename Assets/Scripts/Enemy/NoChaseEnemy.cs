using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoChaseEnemy : Enemy
{
    // Start is called before the first frame update
    public Transform[] wayPoints;

    StateMachine stateMachine;
    public float viewAngle = 80f;
    public float attackRadius = 2f;
    public float moveSpeed = 100f;

    public float nextWayPointDistanceChaseState = 3f;
    public float nextWayPointDistanceMoveState = 1f;
    public float turnThresholdDistance = 0.2f; // To check if (waypoint - enemy)'s x distance is greater than threshold - to avoid jitter
    public float idleTimeOutTime = 2f;
    public float idleStartTime = Mathf.Infinity;
    public float stopTimeOutTime = 1f;
    public float stopStartTime = Mathf.Infinity;
    public bool reachedWayPoint = false;

    public FieldOfView attackFieldOfView;

    new void Awake()
    {
        base.Awake();
        var fieldOfViews = GetComponentsInChildren<FieldOfView>();
        attackFieldOfView = fieldOfViews[0];
        attackFieldOfView.viewAngle = viewAngle;
        attackFieldOfView.viewRadius = attackRadius;
        stateMachine = new StateMachine();

        var idleState = new NoChaseIdleState(this);
        var moveState = new NoChaseMoveState(this);
        var attackState = new NoChaseAttackState(this);

        Transit(idleState, moveState, IdleTimeOut());
        Transit(idleState, attackState, InAttackRange());
        Transit(moveState, idleState, ReachedWayPoint());
        Transit(moveState, attackState, InAttackRange());
        Transit(attackState, moveState, OutAttackRange());

        stateMachine.SetState(moveState);

        void Transit(IState from, IState to, Func<bool> Predicate)
        {
            stateMachine.AddTransition(from, to, Predicate);
        }

        Func<bool> InAttackRange() => () => attackFieldOfView.visibleTargets.Count != 0;
        Func<bool> OutAttackRange() => () => attackFieldOfView.visibleTargets.Count == 0;
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
        attackFieldOfView.viewAngle = viewAngle;
        attackFieldOfView.viewRadius = attackRadius;
        attackFieldOfView.isFacingRight = isSpriteRightFacing;
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
    }

    public override void Die()
    {
        GetComponent<Seeker>().enabled = false;
        base.Die();
    }
}
