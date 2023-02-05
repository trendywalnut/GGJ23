using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static BossHealth Instance { get; private set; }

    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth - damageAmount <= 0)
        {
            //Boss Dies
        }
        else
        {
            currentHealth -= damageAmount;
        }
    }



}
