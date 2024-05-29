using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : AttackSystem
{
    [Header("References")]
    [SerializeField] private EnemyPatrol enemyPatrol;

    private Collider[] hitColliders;

    private void Update()
    {
        hitColliders = Physics.OverlapSphere(this.GetHitCenter().position, 1f, this.GetHitLayer());

        foreach (Collider collider in hitColliders)
        {
            if(collider.GetComponent<LevelSystem>() != null)
            {
                if (collider.GetComponent<LevelSystem>().GetLevel() < this.GetLevelSystem().GetLevel() && this.GetCanAttack())
                {
                    enemyPatrol.StopPatrol();
                    collider.GetComponent<PlayerController>().StopPlayer();
                    transform.LookAt(collider.transform.position);
                    this.AttackObject(collider);
                }
            }
        }
    }
}
