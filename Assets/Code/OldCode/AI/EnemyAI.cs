using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : StateMechineBase
{
    [Header("Refrences")]
    public Entitiy entitiy;
    [Header("Controlers")]
    public bool PlayerSpotted;
    public float ForgetTime;
    public Transform player;


    

    private void Awake()
    {
        CurrentState = _initialState;
    }

   

    private void Update()
    {
        CurrentState.Execute(this);
    }
}
