using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;



    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
    }

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
        PlayerCameraEffects.Instance.ShakeCamera(2, .1f);
        if (currentHealth - damageAmount <= 0)
        {
            //Lose state
        }
        else
        {
            currentHealth -= damageAmount;
        }
    }

    //Debug Testing
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        TakeDamage(1);
    //    }
    //}
}
