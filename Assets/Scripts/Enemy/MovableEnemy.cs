using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEnemy : Enemy
{
    // Start is called before the first frame update
    public Transform[] wayPoints;
    public Transform leftBound;
    public Transform rightBound;

    StateMachine stateMachine;
    public float viewAngle = 80f;
    public float chaseRadius = 3f;
    public float attackRadius = 2f;
    public float chaseSpeed = 200f;
    public float moveSpeed = 100f;

    public float nextWayPointDistanceChaseState = 3f;
    public float nextWayPointDistanceMoveState = 1f;
    public float turnThresholdDistance = 0.2f; // To check if (waypoint - enemy)'s x distance is greater than threshold - to avoid jitter
    public float idleTimeOutTime = 2f;
    public float idleStartTime = Mathf.Infinity;
    public float stopTimeOutTime = 1f;
    public float stopStartTime = Mathf.Infinity;
    public bool reachedWayPoint = false;

    public FieldOfView chaseFieldOfView;
    public FieldOfView attackFieldOfView;

    new void Awake()
    {
        base.Awake();
        var fieldOfViews = GetComponentsInChildren<FieldOfView>();
        chaseFieldOfView = fieldOfViews[0];
        attackFieldOfView = fieldOfViews[1];
        chaseFieldOfView.viewAngle = attackFieldOfView.viewAngle = viewAngle;
        chaseFieldOfView.viewRadius = chaseRadius;
        attackFieldOfView.viewRadius = attackRadius;
        stateMachine = new StateMachine();

        var idleState = new IdleState(this);
        var moveState = new MoveState(this);
        var chaseState = new ChaseState(this);
        var attackState = new AttackState(this);
        var stopState = new StopState(this);

        Transit(idleState, moveState, IdleTimeOut());
        Transit(idleState, chaseState, InChaseRange());
        Transit(moveState, chaseState, InChaseRange());
        Transit(moveState, idleState, ReachedWayPoint());
        Transit(chaseState, moveState, OutChaseRange());
        Transit(chaseState, attackState, InAttackRange());
        Transit(attackState, chaseState, OutAttackRange());
        Transit(chaseState, stopState, OutOfBounds());
        Transit(moveState, stopState, OutOfBounds());
        Transit(attackState, stopState, OutOfBounds());
        Transit(stopState, idleState, StopTimeOut());
        //stateMachine.AddAnyTransition(stopState, OutOfBounds());

        stateMachine.SetState(moveState);
        
        void Transit(IState from, IState to, Func<bool> Predicate)
        {
            stateMachine.AddTransition(from, to, Predicate);
        }

        Func<bool> InChaseRange() => () => chaseFieldOfView.visibleTargets.Count != 0; 
        Func<bool> OutChaseRange() => () => chaseFieldOfView.visibleTargets.Count == 0;
        Func<bool> InAttackRange() => () => attackFieldOfView.visibleTargets.Count != 0;
        Func<bool> OutAttackRange() => () => attackFieldOfView.visibleTargets.Count == 0;
        Func<bool> ReachedWayPoint() => () => reachedWayPoint;
        Func<bool> IdleTimeOut() => () => Time.time >= idleStartTime + idleTimeOutTime;
        Func<bool> StopTimeOut() => () => Time.time >= stopStartTime + stopTimeOutTime;
        Func<bool> OutOfBounds() => () => (transform.position.x < leftBound.position.x - 0.05f|| transform.position.x > rightBound.position.x + 0.05f) ;
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
        chaseFieldOfView.viewAngle = attackFieldOfView.viewAngle = viewAngle;
        chaseFieldOfView.viewRadius = chaseRadius;
        attackFieldOfView.viewRadius = attackRadius;
        chaseFieldOfView.isFacingRight = isSpriteRightFacing;
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    public override void Die()
    {
        GetComponent<Seeker>().enabled = false;
        base.Die();
    }
}
