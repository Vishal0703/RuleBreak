using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public bool isFacingRight = true;
    public string meshName;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    
    public List<VisibleTarget> visibleTargets = new List<VisibleTarget>();

    public float meshResolution;
    public int edgeResolveIterations;
    public float edgeDstThreshold;

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;
    Transform target;
    RaycastHit2D hit;

    void Start()
    {
        viewMesh = new Mesh();
        viewMesh.name = meshName;
        viewMeshFilter.mesh = viewMesh;
        InvokeRepeating("FindVisibleTargets", 0.2f, 0.2f);
    }


    private void Update()
    {
       
    }

    private void LateUpdate()
    {
        DrawFieldOfView();
    }


    public void FindVisibleTargets()
    {
        visibleTargets.Clear();
        target = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        for(int i = 0; i < colliders.Length; i++)
        {
            Debug.Log($"detected {colliders[i].gameObject.name}");
            target = colliders[i].transform;
            Vector3 directionToTarget;
            float distanceToTarget;

            directionToTarget = (target.position - transform.position).normalized;
            if(isFacingRight)
            {
                if (Vector3.Angle(directionToTarget, transform.right) < viewAngle / 2)
                {
                    Debug.Log($"{colliders[i].gameObject.name} in view");
                    distanceToTarget = Vector3.Distance(transform.position, target.position);
                    //Gizmos.DrawLine(transform.position, target.position);
                    if (TargetNotInList(target))
                        visibleTargets.Add(new VisibleTarget(target, target.position));
                    //if (!Physics2D.Raycast(transform.position, target.position, distanceToTarget, obstacleMask))
                    //{
                    //    Debug.Log($"{colliders[i].gameObject.name} in range");
                    //    if (TargetNotInList(target))
                    //        visibleTargets.Add(new VisibleTarget(target, target.position));
                    //}
                }
            }
            else
            {
                if (Vector3.Angle(directionToTarget, -transform.right) < viewAngle / 2)
                {
                    Debug.Log($"{colliders[i].gameObject.name} in view");
                    distanceToTarget = Vector3.Distance(transform.position, target.position);
                    //Gizmos.DrawLine(transform.position, target.position);
                    if (TargetNotInList(target))
                        visibleTargets.Add(new VisibleTarget(target, target.position));
                    //hit = Physics2D.Raycast(transform.position, target.position, distanceToTarget, obstacleMask);
                    //if (hit.collider == null)
                    //{
                    //    Debug.Log($"{colliders[i].gameObject.name} in range");
                    //    if (TargetNotInList(target))
                    //        visibleTargets.Add(new VisibleTarget(target, target.position));
                    //}
                    //else
                    //{
                    //    Debug.Log($"{hit.collider.gameObject.name}");
                    //}
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

    void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        ViewCastInfo oldViewCast = new ViewCastInfo();
        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast(angle);

            if (i > 0)
            {
                bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;
                if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
                {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                    if (edge.pointA != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointA);
                    }
                    if (edge.pointB != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointB);
                    }
                }

            }


            viewPoints.Add(newViewCast.point);
            oldViewCast = newViewCast;
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        viewMesh.Clear();

        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
    {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for (int i = 0; i < edgeResolveIterations; i++)
        {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle);

            bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.dst - newViewCast.dst) > edgeDstThreshold;
            if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded)
            {
                minAngle = angle;
                minPoint = newViewCast.point;
            }
            else
            {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }

        return new EdgeInfo(minPoint, maxPoint);
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

    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirectionFromAngle(globalAngle, true);
        RaycastHit2D hit;

        if (hit = Physics2D.Raycast(transform.position, dir, viewRadius, obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }
    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }

    public struct EdgeInfo
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
        {
            pointA = _pointA;
            pointB = _pointB;
        }
    }

    private void OnDrawGizmos()
    {
        if(target != null)
            Gizmos.DrawLine(transform.position, target.position);
        Gizmos.color = Color.red;
        if (hit.collider != null)
            Gizmos.DrawLine(transform.position, hit.point);

    }
}
