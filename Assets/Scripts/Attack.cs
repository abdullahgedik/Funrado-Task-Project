using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform hitCenter;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private string hitTag;

    [Header("Settings")]
    [SerializeField] private float attackCooldownDuration = 1f;

    private bool canAttack = true;
    private Collider[] hitColliders;

    private void Update()
    {
        hitColliders = Physics.OverlapSphere(hitCenter.position, 1f, hitLayer);

        foreach (Collider collider in hitColliders)
        {
            if(collider.GetComponent<LevelSystem>().GetLevel() < levelSystem.GetLevel() && canAttack)
            {
                AttackObject(collider);
            }
        }
    }

    private void AttackObject(Collider col)
    {
        canAttack = false;
        animator.SetTrigger("Attack");
        col.gameObject.GetComponent<LevelSystem>().Die();
        StartCoroutine(AttackCooldown(attackCooldownDuration));
    }

    IEnumerator AttackCooldown(float duration)
    {
        yield return new WaitForSeconds(duration);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitCenter.position, 1f);
        canAttack = true;
    }
}
