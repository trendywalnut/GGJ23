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
    float backAwayDistance = 7f;

    [SerializeField]
    List<Transform> patrolPoints;
    private int destPoint = 0;

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
        if (aggroTimeDelta > 0f)
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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
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
                    aggroTimeDelta = aggroTime; //reset aggro
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
            if (patrolPoints.Count == 0)
                return;

            agent.destination = patrolPoints[destPoint].position;
            destPoint = (destPoint + 1) % patrolPoints.Count;
        }

        //TODO
        IEnumerator DoAttack()
        {
            Vector3 targetPosition = (target.transform.position - transform.position).normalized;
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.Euler(targetPosition.x, targetPosition.y, targetPosition.z));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(targetPosition * bulletForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}

