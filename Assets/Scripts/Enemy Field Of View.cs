using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFieldOfView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private LayerMask obstructionLayer;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private EnemyAttackSystem enemyAttackSys;

    [Header("Detection Settings")]
    [SerializeField] private float range = 6;
    [SerializeField] [Range(0,360)] private float angle = 60;

    [Header("Visual Settings")]
    [SerializeField] private Material coneMaterial;
    [SerializeField] private int coneResolution = 150;

    private Mesh coneMesh;
    private MeshFilter coneFilter;
    private float coneAngle;

    private void Start()
    {
        gameObject.AddComponent<MeshRenderer>().material = coneMaterial;
        coneFilter = gameObject.AddComponent<MeshFilter>();
        coneMesh = new Mesh();
        coneAngle = angle * Mathf.Deg2Rad;
    }

    private void Update()
    {
        CheckForTarget();

        DrawVisionCone();
    }

    void CheckForTarget() //Target Detection
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, range - .75f, targetLayer);

        foreach (var target in targetsInViewRadius)
        {
            Transform targetTransform = target.transform;
            Vector3 directionToTarget = (targetTransform.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                {
                    enemyAttackSys.AttackToPlayer(target.GetComponent<Collider>());
                }
            }
        }
    }

    void DrawVisionCone() //FOV Vision Cone
    {
        int[] triangles = new int[(coneResolution - 1) * 3];
        Vector3[] Vertices = new Vector3[coneResolution + 1];

        Vertices[0] = Vector3.zero;

        float Currentangle = -coneAngle / 2;
        float angleIcrement = coneAngle / (coneResolution - 1);

        float Sine;
        float Cosine;

        for (int i = 0; i < coneResolution; i++)
        {
            Sine = Mathf.Sin(Currentangle);
            Cosine = Mathf.Cos(Currentangle);
            Vector3 RaycastDirection = (transform.forward * Cosine) + (transform.right * Sine);
            Vector3 VertForward = (Vector3.forward * Cosine) + (Vector3.right * Sine);
            if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit hit, range, obstructionLayer))
            {
                Vertices[i + 1] = VertForward * hit.distance;
            }
            else
            {
                Vertices[i + 1] = VertForward * range;
            }


            Currentangle += angleIcrement;
        }
        for (int i = 0, j = 0; i < triangles.Length; i += 3, j++)
        {
            triangles[i] = 0;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
        }
        coneMesh.Clear();
        coneMesh.vertices = Vertices;
        coneMesh.triangles = triangles;
        coneFilter.mesh = coneMesh;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);

        Vector3 fovLine1 = Quaternion.AngleAxis(angle / 2, Vector3.up) * transform.forward * range;
        Vector3 fovLine2 = Quaternion.AngleAxis(-angle / 2, Vector3.up) * transform.forward * range;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + fovLine1);
        Gizmos.DrawLine(transform.position, transform.position + fovLine2);

        if (targetTransform)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, targetTransform.position);
        }
    }
}
