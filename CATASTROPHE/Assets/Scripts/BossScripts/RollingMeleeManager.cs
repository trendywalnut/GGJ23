using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMeleeManager : MonoBehaviour
{

    public List<GameObject> meleeAttacks = new List<GameObject>();

    private float timeBetweenAttacks;

    private int attackToActivate;
    
    public bool finishedAllAttacks;

    private void OnEnable()
    {
        attackToActivate = 0;
        finishedAllAttacks = false;
        timeBetweenAttacks = BossAttackSM.Instance.timeBetweenRollingMelees;
        StartCoroutine(StartAttack());
    }

    private void Update()
    {
        if (meleeAttacks[meleeAttacks.Count - 1].GetComponent<MeleeAttack>().doneAttacking)
        {
            finishedAllAttacks = true;
        }
    }

    IEnumerator StartAttack()
    {
        while (!(attackToActivate == meleeAttacks.Count))
        {
            meleeAttacks[attackToActivate].SetActive(true);
            meleeAttacks[attackToActivate].GetComponent<MeleeAttack>().Expand();
            attackToActivate++;
            
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }

    private void OnDisable()
    {
        finishedAllAttacks = false;

        foreach (var attack in meleeAttacks)
        {
            attack.GetComponent<MeleeAttack>().doneAttacking = false;
        }

    }

}
