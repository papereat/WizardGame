using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    #region  Public Var
    [Header("Refrences")]
    public Entitiy entitiy;
    public Rigidbody2D rb;
    #endregion


    #region  Public func
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }
    #endregion 

    #region  Private Func
    void Movement()
    {
        Vector2 mov=new Vector2();

        if(Input.GetKey(KeyCode.W))
        {
            mov.x+=1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            mov.x-=1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            mov.y+=1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            mov.y-=1;
        }

        rb.velocity=mov*entitiy.CurrentSpeed;
    }

    void Abilitie()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            Bullet();
        }
        if(Input.GetKey(KeyCode.E))
        {
            Slice();
        }
        if(Input.GetKey(KeyCode.Alpha1))
        {
            Radiate();
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            Heal();    
        }
        if(Input.GetKey(KeyCode.Alpha3))
        {
            Shield();
        }
    }

    void Shield(){}
    void Slice(){}
    void Bullet(){}
    void Radiate(){}
    void Heal(){}
    #endregion
}
