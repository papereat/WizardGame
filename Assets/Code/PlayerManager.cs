using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region  Public Var
    public static PlayerManager CurrentPlayerManger;
    [Header("Refrences")]
    public PlayerInputs playerInputs;
    public Rigidbody2D rb;
    public Animator animator;

    [Header("Movement")]
    public bool canMove;
    public float movmenetSpeed;
    #endregion

    #region  Public Func
    public void Awake()
    {
        CurrentPlayerManger=this;
        playerInputs= new PlayerInputs();
        playerInputs.Player_Map.Enable();
    }
    void Start()
    {
        GameEvents.Current.onGatherSaveData+=GatherPlayerSaveData;
    }
    void Update()
    {
        if(canMove)
        {
            Movment();
        }
    }
    #endregion

    #region  Private Func
    void GatherPlayerSaveData()
    {

    }
    void Movment()
    {
        Vector2 mov=new Vector2();
        //transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.y);
        mov=new Vector2(playerInputs.Player_Map.Horizontal.ReadValue<float>(),playerInputs.Player_Map.Verticle.ReadValue<float>());

        

        animator.SetBool("Running",mov!=Vector2.zero);

        rb.velocity=mov.normalized*movmenetSpeed;
    }
    #endregion


}
