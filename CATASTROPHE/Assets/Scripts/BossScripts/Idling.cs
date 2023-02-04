using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idling : BaseState
{
    private BossAttackSM sm;
    public Idling(BossAttackSM stateMachine) : base("Idling", stateMachine) 
    {
        sm = stateMachine;
    }

}
