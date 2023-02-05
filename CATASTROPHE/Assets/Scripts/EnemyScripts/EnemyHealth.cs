using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField][Range(1,3)] private int maxHealth;
    private Material enemyMat;

    private void Start()
    {
        enemyMat = GetComponent<Renderer>().material;
    }
    public void TakeDamage(int damage)
    {
        StartCoroutine(HitEffect());
        //Debug.Log("take damage");
        //hit effect
        //hit noise
        maxHealth -= damage;
        if(maxHealth <= 0)
        {
            //death noise
            EnemyManager.Instance.aliveEnemies--;
            Destroy(gameObject);
        }
    }

    IEnumerator HitEffect()
    {
        enemyMat.EnableKeyword("HITEFFECT_ON");
        yield return new WaitForSeconds(0.2f);
        enemyMat.DisableKeyword("HITEFFECT_ON");
    }
}
