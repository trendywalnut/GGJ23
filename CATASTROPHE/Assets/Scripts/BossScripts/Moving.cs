using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Moving : BaseState
{
    private BossMovementSM sm;

    private bool movingLeft = true;

    public Moving(BossMovementSM stateMachine) : base("Moving", stateMachine)
    {
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Vector2.Distance(sm.bossTransform.position, sm.leftMoveBound.position) <= 0.1f)
        {
            movingLeft = false;
        }
        
        if (Vector2.Distance(sm.bossTransform.position, sm.rightMoveBound.position) <= 0.1f)
        {
            movingLeft = true;
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (movingLeft)
        {
            sm.bossRb.velocity = Vector2.left * sm.moveSpeed;
        }
        else
        {
            sm.bossRb.velocity = Vector2.right * sm.moveSpeed;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
