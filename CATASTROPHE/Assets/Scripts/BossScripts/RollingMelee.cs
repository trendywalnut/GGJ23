using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMelee : BaseState
{
    private BossAttackSM sm;

    public RollingMelee (BossAttackSM stateMachine) : base("RollingMelee", stateMachine)
    {
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        sm.rollingMeleeManager.SetActive(true);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (sm.rollingMeleeManager.GetComponent<RollingMeleeManager>().finishedAllAttacks)
        {
            stateMachine.ChangeState(sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();

        sm.rollingMeleeManager.GetComponent<RollingMeleeManager>().finishedAllAttacks = false;
        sm.rollingMeleeManager.SetActive(false);
    }
}
