using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Transition")]
public class Transitions : ScriptableObject
{
    public Decision decision;
    public BaseState trueState;
    public BaseState falseState;
    public void Execute(StateMechineBase mechine)
    {
        mechine.CurrentState=decision.Decide(mechine)?trueState:falseState;
    }
}
