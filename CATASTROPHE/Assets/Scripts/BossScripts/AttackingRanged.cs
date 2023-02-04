using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingRanged : BaseState
{
    private BossAttackSM sm;
    public AttackingRanged(BossAttackSM stateMachine) : base("AttackingRanged", stateMachine) 
    {
        sm = stateMachine;
    }

}
