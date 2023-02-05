using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Idling : BaseState
{
    private BossAttackSM sm;
    private float timer;
    private BaseState chosenAttack;

    public Idling(BossAttackSM stateMachine) : base("Idling", stateMachine) 
    {
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        timer = sm.idleTime;
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
            if (sm.lastAttack != null)
            {
                List<BaseState> otherAttacks = new List<BaseState>();
                foreach(var attack in sm.attackStates)
                {
                    if (attack != sm.lastAttack)
                        otherAttacks.Add(attack);
                }
                int numPossibleStates = otherAttacks.Count;
                chosenAttack = otherAttacks[Random.Range(0, numPossibleStates)];
            }
            else
            {
                int numPossibleStates = sm.attackStates.Count;
                chosenAttack = sm.attackStates[Random.Range(0, numPossibleStates)];
            }
            sm.ChangeState(chosenAttack);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        //Debug.Log(timer);
    }

    public override void Exit()
    {
        base.Exit();

        sm.lastAttack = chosenAttack;
    }

}
