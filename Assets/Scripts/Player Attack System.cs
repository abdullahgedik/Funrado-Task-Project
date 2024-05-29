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
            if(collider.GetComponent<LevelSystem>() != null)
            {
                if (collider.GetComponent<LevelSystem>().GetLevel() < this.GetLevelSystem().GetLevel() && this.GetCanAttack())
                {
                    collider.GetComponent<EnemyPatrol>().StopPatrol();
                    transform.LookAt(collider.transform.position);
                    this.AttackObject(collider);
                    Destroy(collider.GetComponent<EnemyLevelSystem>().GetEnemyFieldOfView());
                }
            }
        }
    }
}
