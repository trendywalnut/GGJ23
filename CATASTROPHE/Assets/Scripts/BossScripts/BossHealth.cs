using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamageable
{
    public static BossHealth Instance { get; private set; }

    public int maxHealth;
    public int currentHealth;

    public bool isInvulnerable;

    [SerializeField]
    Animator animator;

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        isInvulnerable = false;
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isInvulnerable)
        {
            animator.SetTrigger("hurt");
            if (currentHealth - damageAmount <= 0)
            {
                //Boss Dies, Win Game
            }
            else
            {
                currentHealth -= damageAmount;
            }
        }
    }



}
