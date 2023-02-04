using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPopups : BaseState
{
    private BossAttackSM sm;
    public SpawningPopups(BossAttackSM stateMachine) : base("SpawningPopups", stateMachine) 
    {
        sm = stateMachine;
    }

}
