using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Windows;

public class EnemyPatrol : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Animator animator;

    [Header("Patrol Settings")]
    [SerializeField] private int targetPoint = 0;
    [SerializeField] private float patrolSpeed = 2f;

    private bool stop = false;

    private void Update()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetIndex();
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, patrolSpeed * Time.deltaTime);

        if(!stop)
            transform.LookAt(patrolPoints[targetPoint]);

        animator.SetFloat("xVelocity", patrolSpeed);
        animator.SetFloat("zVelocity", patrolSpeed);
    }

    private void increaseTargetIndex()
    {
        targetPoint++;
        if(targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

    public void StopPatrol()
    {
        patrolSpeed = 0;
        stop = true;
    }
}
