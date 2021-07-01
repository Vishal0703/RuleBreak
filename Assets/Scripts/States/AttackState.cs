using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    public NonStaticEnemy enemy;
    private float startTime;

    public AttackState(NonStaticEnemy _enemy)
    {
        enemy = _enemy;
    }
    public void Tick()
    {
        Vector2 direction = (enemy.target.transform.position - enemy.transform.position).normalized;
        FaceTarget(direction);
        if(enemy.laser.gameObject.activeSelf)
            LaserAttack();
        if (Time.time > startTime + enemy.attackInterval)
        {
            RevertLaserState();
            startTime = Time.time;
        }

    }

    private void RevertLaserState()
    {
        if (enemy.laser.gameObject.activeSelf)
            enemy.laser.gameObject.SetActive(false);
        else
            enemy.laser.gameObject.SetActive(true);
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
        startTime = Time.time;
        enemy.laser.gameObject.SetActive(true);
        
        Debug.Log("Attack State Enter");
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        enemy.animator.SetBool("attacking", true);
        enemy.laser.GetComponent<Laser>().target = enemy.target;
        //enemy.InvokeRepeating("LaserAttack", enemy.attackInterval, enemy.attackInterval);
    }

    public void LaserAttack()
    {
        var audioSource = enemy.gameObject.GetComponent<AudioSource>();
        if (audioSource)
            audioSource.Play();
        var lineRenderer = enemy.laser.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, enemy.laser.transform.position);
        lineRenderer.SetPosition(1, enemy.target.transform.position);
        var targetDistance = Vector3.Distance(enemy.transform.position, enemy.target.transform.position);
    }

    public void OnStateExit()
    {
        enemy.laser.gameObject.SetActive(false);
        enemy.animator.SetBool("attacking", false);
    }
}
