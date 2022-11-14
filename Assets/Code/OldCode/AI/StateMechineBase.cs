using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMechineBase : MonoBehaviour
{
    public BaseState _initialState;

    [SerializeField]
    public BaseState CurrentState;

    private void Awake()
    {
        CurrentState = _initialState;
    }

   

    private void Update()
    {
        CurrentState.Execute(this);
    }
}
