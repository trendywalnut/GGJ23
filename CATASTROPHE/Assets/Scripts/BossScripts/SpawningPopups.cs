using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
        stateMachine.ChangeState(sm.idleState);
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
