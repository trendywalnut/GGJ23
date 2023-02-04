using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingMelee : BaseState
{
    private BossAttackSM sm;
    public AttackingMelee(BossAttackSM stateMachine) : base("AttackingMelee", stateMachine) 
    {
        sm = stateMachine;
    }

}
