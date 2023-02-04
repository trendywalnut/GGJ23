using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : BaseState
{
    private BossAttackSM sm;
    public SpawningEnemies(BossAttackSM stateMachine) : base("SpawningEnemies", stateMachine) 
    {
        sm = stateMachine;
    }

}
