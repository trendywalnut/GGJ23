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

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
    }

}
