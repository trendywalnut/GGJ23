using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class MeleeAI : MonoBehaviour
{

    //[SerializeField]
    //float moveSpeed;

    [SerializeField]
    float attackPunchIntensity;

    [SerializeField]
    float attackPunchTime;

    bool isAttacking;
    bool hitPlayerDuringAttack;

    [SerializeField]
    float health = 10f;

    [SerializeField]
    float attackPower = 1f;

    [SerializeField]
    float attackDistance = 1f;

    [SerializeField]
    float attackSpeed = 2f;

    [SerializeField]
    float moveRadius = 4f;

    //[SerializeField]
    //List<Transform> patrolPoints;
    //private int destPoint = 0;

    [SerializeField]
    float vision = 10f;

    [SerializeField]
    float aggroTime = 2.0f;

    float aggroTimeDelta;

    [SerializeField]
    GameObject target;

    NavMeshAgent agent;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoBraking = false;

        target = GameObject.FindGameObjectWithTag("Player");

        aggroTimeDelta = 0;
        StartCoroutine(StartBehavior());
    }

    IEnumerator StartBehavior()
    {
        while (true)
        {
            yield return StartCoroutine(Behavior());
        }
    }

    IEnumerator Behavior()
    {

        // if is already aggroed
        if (aggroTimeDelta > 0f)
        {
            aggroTimeDelta -= Time.deltaTime;
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= attackDistance)
            {
                yield return DoAttack();
            }
            else
            {
                Follow();
            }
        }
        else
        {
            // if player is visible
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if ( distance < vision)
            {
                aggroTimeDelta = aggroTime;

                if (distance <= attackDistance)
                {
                    yield return DoAttack();
                }
                else
                {
                    Follow();
                }
            }
            else
            {
                DoPatrol();
            }


        }

        void Follow()
        {
            agent.SetDestination(target.transform.position);
        }

        void DoPatrol()
        {
            //if (patrolPoints.Count == 0)
            //    return;

            //agent.destination = patrolPoints[destPoint].position;
            //destPoint = (destPoint + 1) % patrolPoints.Count;

            agent.destination = RandomNavmeshLocation(moveRadius);

            if (Vector3.Distance(transform.position, agent.destination) < Mathf.Epsilon)
            {
                agent.destination = RandomNavmeshLocation(moveRadius);
            }
        }

        //TODO
        IEnumerator DoAttack()
        {
            isAttacking = true;
            transform.DOPunchPosition((target.transform.position - transform.position) * attackPunchIntensity, attackPunchTime, 1);

            yield return new WaitForSeconds(attackPunchTime);
            isAttacking = false;
            if (hitPlayerDuringAttack)
            {
                PlayerHealth.Instance.TakeDamage((int)attackPower);
                hitPlayerDuringAttack = false;
            }

            yield return new WaitForSeconds(attackSpeed - attackPunchTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking)
        {
            if (collision.tag == "Player" && !target.GetComponent<PlayerMovement>().isDashing)
            {
                Debug.Log("Hit Player - Melee Enemy");
                hitPlayerDuringAttack = true;
            }
        }
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;

        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }
}

