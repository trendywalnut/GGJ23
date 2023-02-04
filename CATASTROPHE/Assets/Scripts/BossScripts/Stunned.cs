using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned : BaseState
{
    private BossMovementSM sm;
    public Stunned(BossMovementSM stateMachine) : base("Stunned", stateMachine) 
    {
        sm = stateMachine;
    }
}
