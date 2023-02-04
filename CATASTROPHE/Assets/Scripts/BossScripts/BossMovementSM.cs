using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementSM : StateMachine
{
    // Add states here
    public Moving movingState;
    public Stunned stunnedState;

    private void Awake()
    {
        //Construct states here
        movingState = new Moving(this);
        stunnedState = new Stunned(this);
    }

    protected override BaseState GetInitialState()
    {
        return movingState;
    }
}
