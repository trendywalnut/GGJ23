using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{
    private BossMovementSM sm;
    public Moving(BossMovementSM stateMachine) : base("Moving", stateMachine)
    {
        sm = stateMachine;
    }

}
