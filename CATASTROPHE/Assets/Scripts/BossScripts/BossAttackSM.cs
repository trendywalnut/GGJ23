using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackSM : StateMachine
{

    // Add states here
    public Idling idleState;
    public AttackingRanged attackingRangedState;
    public AttackingMelee attackingMeleeState;
    public SpawningEnemies spawningEnemiesState;
    public SpawningPopups spawningPopupsState;

    private void Awake()
    {
        //Construct states here
        idleState = new Idling(this);
        attackingRangedState = new AttackingRanged(this);
        attackingMeleeState = new AttackingMelee(this);
        spawningEnemiesState = new SpawningEnemies(this);
        spawningPopupsState = new SpawningPopups(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

}
