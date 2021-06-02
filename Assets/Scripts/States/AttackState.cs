using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    public MovableEnemy enemy;
    public AttackState(MovableEnemy _enemy)
    {
        enemy = _enemy;
    }
    public void Tick()
    {
        Vector2 direction = (enemy.target.transform.position - enemy.transform.position).normalized;
        FaceTarget(direction);
    }

    private void FaceTarget(Vector2 direction)
    {
        var currentScale = enemy.transform.localScale;
        if ((enemy.isSpriteRightFacing && direction.x < -enemy.turnThresholdDistance) || (!enemy.isSpriteRightFacing && direction.x > enemy.turnThresholdDistance))
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
        Debug.Log("Attack State Enter");
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        enemy.animator.SetBool("attacking", true);
    }

    public void OnStateExit()
    {
        enemy.animator.SetBool("attacking", false);
    }
}
