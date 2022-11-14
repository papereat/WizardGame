using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region  Public Var
    [Header("Refrences")]
    public Rigidbody2D rb;
    public Animator animator;

    [Header("Movement")]
    public bool canMove;
    public float movmenetSpeed;
    #endregion

    #region  Public Func
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Movment();
        }
    }
    #endregion

    #region  Private Func
    void Movment()
    {
        Vector2 mov=new Vector2();

        if(Input.GetKey(KeyCode.W))
        {
            mov=new Vector2(0,1);
            animator.SetInteger("Direction",3);
        }
        if(Input.GetKey(KeyCode.S))
        {
            mov= new Vector2(0,-1);
            animator.SetInteger("Direction",0);

        }
        if(Input.GetKey(KeyCode.A))
        {
            mov= new Vector2(-1,0);
            animator.SetInteger("Direction",2);

        }
        if(Input.GetKey(KeyCode.D))
        {
            mov= new Vector2(1,0);
            animator.SetInteger("Direction",1);

        }

        animator.SetBool("Running",mov!=Vector2.zero);

        rb.velocity=mov*movmenetSpeed;
    }
    #endregion


}
