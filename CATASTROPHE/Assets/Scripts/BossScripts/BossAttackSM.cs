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
    public Blocking blockingState;

    public List<BaseState> attackStates = new List<BaseState>();

    public Transform bossTransform;
    public float idleTime;
    public float timeBetweenRangeAttacks;

    public int numberOfBullets;

    public bool isHalfHealth;

    private void Awake()
    {
        //Construct states here
        idleState = new Idling(this);
        attackingRangedState = new AttackingRanged(this);
        attackingMeleeState = new AttackingMelee(this);
        spawningEnemiesState = new SpawningEnemies(this);
        spawningPopupsState = new SpawningPopups(this);
        blockingState = new Blocking(this);

        //Add all attack states to attackStates list
        attackStates.Add(attackingRangedState);
        attackStates.Add(attackingMeleeState);
        attackStates.Add(spawningEnemiesState);
        attackStates.Add(spawningPopupsState);
    }

    public override void Update()
    {
        base.Update();

        if ((BossHealth.Instance.currentHealth / BossHealth.Instance.maxHealth) <= 0.5f)
        {
            isHalfHealth = true;
        }
    }

    protected override BaseState GetInitialState()
    {
        return attackingRangedState;
    }
}
