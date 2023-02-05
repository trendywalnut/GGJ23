using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private Vector3 startSize;
    [SerializeField] private Vector3 endingSize;

    private float timeToAttack;

    private bool playerInRange = false;
    public bool doneAttacking;

    void OnEnable()
    {
        timeToAttack = BossAttackSM.Instance.timeToMeleeAttack;
        transform.localScale = startSize;
        doneAttacking = false;
        //transform.localScale = startSize;
    }

    public void Expand()
    {
        transform.DOScale(endingSize, timeToAttack);
        StartCoroutine(AttackPlayer(BossAttackSM.Instance.meleeDamage));
    }

    IEnumerator AttackPlayer(int damage)
    {
        yield return new WaitForSeconds(timeToAttack);

        if (playerInRange)
        {
            PlayerHealth.Instance.TakeDamage(damage);
        }
        doneAttacking = true;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.localScale = startSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
