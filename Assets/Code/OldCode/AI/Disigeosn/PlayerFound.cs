using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Disigeon/Player Found")]
public class PlayerFound : Decision
{
    public override bool Decide(StateMechineBase mechine)
    {
        return mechine.GetComponent<EnemyAI>().PlayerSpotted;
    }
}
