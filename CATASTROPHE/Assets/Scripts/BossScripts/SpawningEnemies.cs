using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawningEnemies : BaseState
{
    private BossAttackSM sm;
    public SpawningEnemies(BossAttackSM stateMachine) : base("SpawningEnemies", stateMachine) 
    {
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        if (sm.isHalfHealth)
        {
            sm.bossEnemyManager.GetComponent<EnemyManager>().waveList[0].meleeEnemiesToSpawn *= 2;
            sm.bossEnemyManager.GetComponent<EnemyManager>().waveList[0].rangedEnemiesToSpawn *= 2;
        }


        sm.bossEnemyManager.SetActive(true);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (sm.bossEnemyManager.GetComponent<EnemyManager>().allWavesFinished)
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
    }

}
