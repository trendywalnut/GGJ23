using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned : BaseState
{
    private BossMovementSM sm;
    public Stunned(BossMovementSM stateMachine) : base("Stunned", stateMachine) 
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
