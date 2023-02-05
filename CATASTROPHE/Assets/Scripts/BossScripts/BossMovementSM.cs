using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementSM : StateMachine
{
    // Add states here
    public Moving movingState;
    public Stunned stunnedState;

    public Transform bossTransform;
    public Transform leftMoveBound;
    public Transform rightMoveBound;

    public Rigidbody2D bossRb;
    public float moveSpeed;
    public float halfHealthMoveSpeed;

    private void Awake()
    {
        //Construct states here
        movingState = new Moving(this);
        stunnedState = new Stunned(this);
        bossTransform = GetComponent<Transform>();
    }

    public override void Update()
    {
        base.Update();
        if (BossAttackSM.Instance.isHalfHealth)
        {
            moveSpeed = halfHealthMoveSpeed;
        }
    }

    protected override BaseState GetInitialState()
    {
        return movingState;
    }
}
