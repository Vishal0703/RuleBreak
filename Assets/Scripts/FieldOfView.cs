using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public bool isFacingRight = true;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    
    public List<VisibleTarget> visibleTargets = new List<VisibleTarget>();

    private void Start()
    {
        InvokeRepeating("FindVisibleTargets", 0.2f, 0.2f);
    }


    private void Update()
    {
       
    }

    private void LateUpdate()
    {
        
    }

    public void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        for(int i = 0; i < colliders.Length; i++)
        {
            Transform target = colliders[i].transform;
            Vector3 directionToTarget;
            float distanceToTarget;

            directionToTarget = (target.position - transform.position).normalized;
            if(isFacingRight)
            {
                if (Vector3.Angle(directionToTarget, transform.right) < viewAngle / 2)
                {
                    distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics2D.Raycast(transform.position, target.position, distanceToTarget, obstacleMask))
                    {
                        if(TargetNotInList(target))
                            visibleTargets.Add(new VisibleTarget(target, target.position));
                    }
                }
            }
            else
            {
                if (Vector3.Angle(directionToTarget, -transform.right) < viewAngle / 2)
                {
                    distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics2D.Raycast(transform.position, target.position, distanceToTarget, obstacleMask))
                    {
                        if (TargetNotInList(target))
                            visibleTargets.Add(new VisibleTarget(target, target.position));
                    }
                }
            }
            
        }
    }

    private bool TargetNotInList(Transform target)
    {
        foreach(var visibleTarget in visibleTargets)
        {
            if (visibleTarget.target.gameObject == target.gameObject)
                return false;
        }
        return true;
    }

    [System.Serializable]
    public struct VisibleTarget
    {
        public Transform target;
        public Vector3 anchorPoint;

        public VisibleTarget(Transform _target, Vector3 _anchorPoint)
        {
            target = _target;
            anchorPoint = _anchorPoint;
        }
    }


    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal = false)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        var angleInRadians = angleInDegrees * Mathf.Deg2Rad;
        if(isFacingRight)
            return new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0f); 
        else
            return new Vector3(-Mathf.Cos(angleInRadians), -Mathf.Sin(angleInRadians), 0f);
    }
}
