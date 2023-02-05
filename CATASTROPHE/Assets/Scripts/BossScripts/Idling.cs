using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Idling : BaseState
{
    private BossAttackSM sm;
    private float timer;

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
            int numPossibleStates = sm.attackStates.Count;
            sm.ChangeState(sm.attackStates[Random.Range(0, numPossibleStates + 1)]);
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
    }

}
