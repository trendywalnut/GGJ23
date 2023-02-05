using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField][Range(1,3)] private int maxHealth;
    

    public void TakeDamage(int damage)
    {
        Debug.Log("take damage");
        //hit effect
        //hit noise
        maxHealth -= damage;
        if(maxHealth <= 0)
        {
            //death noise
            Destroy(gameObject);
        }
    }
}
