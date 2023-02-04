using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAI : MonoBehaviour
{

    //[SerializeField]
    //float moveSpeed;

    //[SerializeField]
    //float health;

    //[SerializeField]
    //float damage;

    [SerializeField]
    GameObject target;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        LockOn();
    }

    void LockOn()
    {
        agent.SetDestination(target.transform.position);
    }
}
