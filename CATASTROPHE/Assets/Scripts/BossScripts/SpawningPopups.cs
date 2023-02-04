using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPopups : BaseState
{
    private BossAttackSM sm;
    public SpawningPopups(BossAttackSM stateMachine) : base("SpawningPopups", stateMachine) 
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
