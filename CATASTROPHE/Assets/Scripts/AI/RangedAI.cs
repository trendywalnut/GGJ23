using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedAI : MonoBehaviour
{

    //[SerializeField]
    //float moveSpeed;

    [SerializeField]
    float health = 10f;

    [SerializeField]
    float attackPower = 1f;

    [SerializeField]
    float attackDistance = 10f;

    [SerializeField]
    float attackSpeed = 2f;

    [SerializeField]
    float bulletForce = 2f;

    [SerializeField]
    float moveRadius = 4f;

    [SerializeField]
    float backAwayDistance = 7f;

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

    [SerializeField]
    GameObject projectile;

    NavMeshAgent agent;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoBraking = false;

        target = GameObject.FindGameObjectWithTag("Player");

        aggroTimeDelta = aggroTime;
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
        if (true || aggroTimeDelta > 0f)
        {
            aggroTimeDelta -= Time.deltaTime;
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= backAwayDistance)
            {
                BackAway();

            }
            else if (distance <= attackDistance)
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

            if (distance < vision)
            {
                aggroTimeDelta = aggroTime;
                if(distance <= backAwayDistance)
                {
                    BackAway();

                } else if (distance <= attackDistance)
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

        void BackAway()
        {
            Vector3 targetPosition = (target.transform.position - transform.position).normalized * -3f;
            agent.SetDestination(targetPosition);
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
            Debug.Log("Shooting");
            Vector3 targetPosition = (target.transform.position - transform.position).normalized;
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.Euler(targetPosition.x, targetPosition.y, targetPosition.z));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(targetPosition * bulletForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(attackSpeed);
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

