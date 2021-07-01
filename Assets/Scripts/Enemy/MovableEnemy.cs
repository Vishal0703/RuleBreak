using Pathfinding;
using System;
using UnityEngine;

public class MovableEnemy : NonStaticEnemy
{
    public Transform leftBound;
    public Transform rightBound;

    public float chaseRadius = 3f;
    public float chaseSpeed = 200f;

    public FieldOfView chaseFieldOfView;
    public FieldOfView attackFieldOfView;
    
    StateMachine stateMachine;

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
