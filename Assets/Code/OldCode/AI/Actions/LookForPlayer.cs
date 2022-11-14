using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Actions/Idle")]
public class LookForPlayer : Actions
{
    public LayerMask lm;
    public float forgetRate;
    public int rayCountPerSide;
    public float raySeperationDistance;
    public float viewDistance;
    public override void Execute(StateMechineBase mechine)
    {
        mechine.GetComponent<EnemyAI>().ForgetTime-=forgetRate*Time.deltaTime;
        
        Vector2 direction= mechine.transform.right;

        mechine.GetComponent<Rigidbody2D>().velocity=new Vector2();


        int x=-rayCountPerSide;
        while (x<=rayCountPerSide)
        {
            Vector3 dir=new Vector3(Mathf.Sin(Mathf.Asin(direction.x)+x*raySeperationDistance),Mathf.Cos(Mathf.Acos(direction.y)+x*raySeperationDistance));
            RaycastHit2D hit=Physics2D.Raycast(mechine.transform.position,dir,viewDistance,lm);

            if(hit.collider!=null)
            {
                mechine.GetComponent<EnemyAI>().PlayerSpotted=true;
                mechine.GetComponent<EnemyAI>().ForgetTime=1;
                
                Debug.DrawLine(mechine.transform.position,hit.point,Color.green);
            }
            else
            {

                Debug.DrawLine(mechine.transform.position,dir*viewDistance+mechine.transform.position,Color.red);
            }
            
            

            x++;
        }
        if(mechine.GetComponent<EnemyAI>().ForgetTime<=0)
        {
            mechine.GetComponent<EnemyAI>().PlayerSpotted=false;
        }
    }
}
