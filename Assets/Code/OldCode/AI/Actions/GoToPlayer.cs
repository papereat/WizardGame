using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Actions/Fallow Player")]
public class GoToPlayer : Actions
{
    EnemyAI enemyAI;
    public float MovementSpeed;
    public float distanceFromPlayer;
    public override void Execute(StateMechineBase mechine)
    {
        enemyAI=mechine.GetComponent<EnemyAI>();
        mechine.transform.LookAt(enemyAI.player);
        mechine.transform.rotation=new Quaternion(0,0,mechine.transform.rotation.z,mechine.transform.rotation.w);
        
        if(Vector3.Distance(mechine.transform.position,enemyAI.player.position)>distanceFromPlayer)
        {
            mechine.transform.position=Vector3.Lerp(mechine.transform.position,enemyAI.player.position,enemyAI.entitiy.CurrentSpeed*Time.deltaTime);
        }
        
    }
}
