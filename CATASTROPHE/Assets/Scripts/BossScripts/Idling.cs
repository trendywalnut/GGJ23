using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idling : BaseState
{
    private BossAttackSM sm;
    public Idling(BossAttackSM stateMachine) : base("Idling", stateMachine) 
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
