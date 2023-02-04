using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAI : MonoBehaviour
{

    //[SerializeField]
    //float moveSpeed;

    [SerializeField]
    float health = 10f;

    [SerializeField]
    float attackPower = 1f;

    [SerializeField]
    float attackDistance = 1f;

    [SerializeField]
    float attackSpeed = 2f;

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
            Debug.Log(distance);

            if (distance <= attackDistance)
            {
                yield return DoAttack();
            }
            else
            {
                Follow();
                Debug.Log("Follow");
            }
        }
        else
        {
            // if player is visible
            RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                Debug.Log(distance);

                if (distance <= attackDistance)
                {
                    yield return DoAttack();
                }
                else
                {
                    Follow();
                    aggroTimeDelta = aggroTime; //reset aggro
                    Debug.Log("Follow");
                }
            }
            else
            {
                DoPatrol();
                Debug.Log("Patrolling");

            }


        }

        void Follow()
        {
            agent.SetDestination(target.transform.position);
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
            Debug.Log("attack");

            yield return new WaitForSeconds(attackSpeed);
        }
    }
}

