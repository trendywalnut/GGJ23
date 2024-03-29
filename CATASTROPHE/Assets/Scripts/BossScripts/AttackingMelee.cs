using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

        sm.meleeAttack.SetActive(true);
        sm.meleeAttack.GetComponent<MeleeAttack>().Expand();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (sm.meleeAttack.GetComponent<MeleeAttack>().doneAttacking)
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

        //sm.meleeAttack.SetActive(false);
    }

}
