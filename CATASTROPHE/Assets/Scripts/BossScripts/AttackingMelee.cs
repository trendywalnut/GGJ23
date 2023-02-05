using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackingMelee : BaseState
{
    private BossAttackSM sm;

    private float timer;

    public AttackingMelee(BossAttackSM stateMachine) : base("AttackingMelee", stateMachine) 
    {
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        sm.meleeAttack.SetActive(true);
        sm.meleeAttack.GetComponent<MeleeAttack>().Expand();
        timer = sm.timeToMeleeAttack;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            sm.meleeAttack.GetComponent<MeleeAttack>().AttackPlayer(sm.meleeDamage);
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

        sm.meleeAttack.SetActive(false);
    }

}
