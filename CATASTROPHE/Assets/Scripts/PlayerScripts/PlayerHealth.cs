using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    public bool invulnerable;

    private Material playerMat;



    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        playerMat = GetComponent<Renderer>().material;
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
        if (!invulnerable)
        {
            StartCoroutine(HitEffect());
            PlayerCameraEffects.Instance.ShakeCamera(2, .1f);
            //VFX
            Instantiate(Resources.Load("VFX_Damage_Player"), transform.position, transform.rotation);
            //reduce health
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

    IEnumerator HitEffect()
    {
        playerMat.EnableKeyword("HITEFFECT_ON");
        yield return new WaitForSeconds(0.2f);
        playerMat.DisableKeyword("HITEFFECT_ON");
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
