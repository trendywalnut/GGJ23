using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public void GainHealth(int healAmount)
    {
        if (currentHealth + healAmount >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healAmount;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth - damageAmount <= 0)
        {
            //Lose state
        }
        else
        {
            currentHealth -= damageAmount;
        }

    }
}
