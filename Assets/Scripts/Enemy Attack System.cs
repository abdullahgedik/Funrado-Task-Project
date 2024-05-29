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
                AttackToPlayer(collider);
            }
        }
    }

    public void AttackToPlayer(Collider col)
    {
        if (col.GetComponent<LevelSystem>().GetLevel() < this.GetLevelSystem().GetLevel() && this.GetCanAttack())
        {
            enemyPatrol.StopPatrol();
            col.GetComponent<PlayerController>().StopPlayer();
            transform.LookAt(col.transform.position);
            this.AttackObject(col);
            col.GetComponent<Rigidbody>().useGravity = false;
            Destroy(col);
        }
    }
}
