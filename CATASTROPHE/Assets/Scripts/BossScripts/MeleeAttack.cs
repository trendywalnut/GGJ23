using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private Vector3 startingSize;
    [SerializeField] private Vector3 endingSize;

    private float timer;
    private float timeToAttack;

    void Start()
    {
        timeToAttack = BossAttackSM.Instance.timeToMeleeAttack;
    }

    public void Expand()
    {

    }
}
