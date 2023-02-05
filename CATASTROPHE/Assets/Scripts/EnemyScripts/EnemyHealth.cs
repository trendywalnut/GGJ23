using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField][Range(1,3)] private int maxHealth;
    [SerializeField] private float knockbackAmount;
    [SerializeField] private float knockbackTime;

    [SerializeField] private float timeToTweenOnDeath;

    private Material enemyMat;
    private Rigidbody2D rb;

    [SerializeField] private GameObject healthPickup;
    [SerializeField] private float healthSpawnChance = .5f;

    private void Start()
    {
        enemyMat = GetComponent<Renderer>().material;
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(int damage)
    {
        StartCoroutine(HitEffect());
        StartCoroutine(KnockBack());
        //Debug.Log("take damage");
        //hit effect
        //hit noise
        maxHealth -= damage;
        if(maxHealth <= 0)
        {
            //death noise
            //EnemyManager.Instance.aliveEnemies--;
            //Destroy(gameObject);
            StartCoroutine(EnemyDeathTween());

            //Spawn healthpickup
            if (Random.Range(0, 1) < healthSpawnChance)
            {
                StartCoroutine(SpawnHealthPickup());
            }
        }
    }

    IEnumerator KnockBack()
    {
        Transform playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<UnityEngine.AI.NavMeshAgent>().velocity = (transform.position - playerPos.position).normalized * knockbackAmount;
        yield return new WaitForSeconds(knockbackTime);
        GetComponent<UnityEngine.AI.NavMeshAgent>().velocity = Vector3.zero;
    }

    IEnumerator EnemyDeathTween()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), timeToTweenOnDeath);
        transform.DORotate(new Vector3(0, 0, 180), timeToTweenOnDeath);
        GetComponent<SpriteRenderer>().DOFade(0, timeToTweenOnDeath);

        //Transform playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //GetComponent<UnityEngine.AI.NavMeshAgent>().velocity = (transform.position - playerPos.position).normalized * knockbackAmount;

        yield return new WaitForSeconds(timeToTweenOnDeath);

        Destroy(this.gameObject);
    }

    IEnumerator HitEffect()
    {
        enemyMat.EnableKeyword("HITEFFECT_ON");
        yield return new WaitForSeconds(0.2f);
        enemyMat.DisableKeyword("HITEFFECT_ON");
    }

    IEnumerator SpawnHealthPickup()
    {
        yield return new WaitForSeconds(timeToTweenOnDeath - .2f);
        Instantiate(healthPickup, this.gameObject.transform.position, Quaternion.identity);
        Debug.Log("Health Spawned");
    }
}
