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

        sm.popUpManager.SetActive(true);
        BossHealth.Instance.isInvulnerable = true;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        if (sm.popUpManager.GetComponent<PopUpManager>().allPopUpsClosed)
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

        sm.popUpManager.GetComponent<PopUpManager>().allPopUpsClosed = false;
        sm.popUpManager.SetActive(false);
        BossHealth.Instance.isInvulnerable = false;
    }
}
