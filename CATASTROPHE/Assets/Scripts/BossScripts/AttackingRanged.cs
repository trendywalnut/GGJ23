using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackingRanged : BaseState
{
    private BossAttackSM sm;

    private float timer;
    private int currentAttack;
    private int numAttacks;
    private bool canShoot;

    public AttackingRanged(BossAttackSM stateMachine) : base("AttackingRanged", stateMachine) 
    {
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        //Debug.Log("ENTERING RANGE ATTACK");

        currentAttack = 0;
        numAttacks = 2;
        timer = sm.timeBetweenRangeAttacks;

        if (sm.isHalfHealth)
        {
            numAttacks = 4;
        }

        canShoot = true;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            if (currentAttack < numAttacks)
            {
                canShoot = true;
            }
            else
            {
                stateMachine.ChangeState(sm.idleState);
            }
        }

        if (canShoot)
        {
            RangedAttack();
            currentAttack++;
            canShoot = false;
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    private void RangedAttack()
    {
        int bullletAmount = sm.numberOfBullets;
        float startAngle = 90f, endAngle = 270f;

        float angleStep = (endAngle - startAngle) / bullletAmount;
        float angle = startAngle;

        for (int i = 0; i < bullletAmount; i++)
        {
            float bulletDirX = sm.bossTransform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = sm.bossTransform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0);
            Vector2 bulletDirection = (bulletMoveVector - sm.bossTransform.position).normalized;

            GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = sm.bossTransform.position;
                bullet.transform.rotation = sm.bossTransform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<BossBullet>().SetMoveDirection(bulletDirection);
            }

            angle += angleStep;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
