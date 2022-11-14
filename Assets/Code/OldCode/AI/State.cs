using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/State")]
public sealed class State : BaseState
{
    public List<Actions> actions;
    public List<Transitions> transitions;
    public override void Execute(StateMechineBase mechine)
    {
        foreach (var item in actions)
        {
            item.Execute(mechine);
        }
        foreach (var item in transitions)
        {
            item.Execute(mechine);
        }
    }
}
