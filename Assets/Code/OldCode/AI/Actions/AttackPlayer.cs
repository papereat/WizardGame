using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Actions/Attack Player")]
public class AttackPlayer : Actions
{
    EnemyAI enemyAI;
    public float AttackCooldown;
    public float damage;
    float attackCD;


    public override void Execute(StateMechineBase mechine)
    {
        enemyAI=mechine.GetComponent<EnemyAI>();

        attackCD-=Time.deltaTime;

        if(attackCD<=0)
        {
            enemyAI.player.GetComponent<Entitiy>().Damage(damage);
            attackCD=AttackCooldown;
        }
        
    }
}
