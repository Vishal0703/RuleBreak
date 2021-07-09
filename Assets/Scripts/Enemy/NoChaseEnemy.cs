using Pathfinding;
using System;
using UnityEngine;


public class NoChaseEnemy : NonStaticEnemy
{
    StateMachine stateMachine;
    public FieldOfView attackFieldOfView;

    new void Awake()
    {
        base.Awake();
        var fieldOfViews = GetComponentsInChildren<FieldOfView>();
        attackFieldOfView = fieldOfViews[0];
        attackFieldOfView.viewAngle = viewAngle;
        attackFieldOfView.viewRadius = attackRadius;
        stateMachine = new StateMachine();

        var idleState = new IdleState(this);
        var moveState = new MoveState(this);
        var attackState = new AttackState(this);

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

}
