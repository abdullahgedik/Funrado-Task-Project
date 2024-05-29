using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform hitCenter;
    [SerializeField] private LayerMask hitLayer;

    [Header("Settings")]
    [SerializeField] private float attackCooldownDuration = 1f;

    private bool canAttack = true;

    public void AttackObject(Collider col)
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

    public LevelSystem GetLevelSystem()
    {
        return levelSystem;
    }
    public Transform GetHitCenter()
    {
        return hitCenter;
    }
    public LayerMask GetHitLayer()
    {
        return hitLayer;
    }

    public bool GetCanAttack()
    {
        return canAttack;
    }
}
