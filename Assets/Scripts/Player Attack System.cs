using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : AttackSystem
{
    private Collider[] hitColliders;

    private void Update()
    {
        hitColliders = Physics.OverlapSphere(this.GetHitCenter().position, 1f, this.GetHitLayer());

        foreach (Collider collider in hitColliders)
        {
            AttackEnemy(collider);
        }
    }

    public void AttackEnemy(Collider col)
    {
        if(col.GetComponent<LevelSystem>() != null)
        {
            if (col.GetComponent<LevelSystem>().GetLevel() < this.GetLevelSystem().GetLevel() && this.GetCanAttack())
            {
                col.GetComponent<EnemyPatrol>().StopPatrol();
                transform.LookAt(col.transform.position);
                this.AttackObject(col);
                Destroy(col.GetComponent<EnemyLevelSystem>().GetEnemyFieldOfView());
            }
        }
    }
}
