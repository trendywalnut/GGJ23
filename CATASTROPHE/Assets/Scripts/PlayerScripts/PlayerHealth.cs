using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField] private AudioClip[] hurtSFX;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private float timeForIFrames;
    public bool invulnerable;
    public bool inIFrames;

    private Material playerMat;

    private Animator animator;

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        playerMat = GetComponent<Renderer>().material;
        animator = GetComponent<Animator>();
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
        if (!invulnerable && !inIFrames)
        {
            inIFrames = true;
            StartCoroutine(HitEffect());
            StartCoroutine(HitAnimation());
            StartCoroutine(IFrames());
            PlayerCameraEffects.Instance.ShakeCamera(2, .1f);
            //VFX
            Instantiate(Resources.Load("VFX_Damage_Player"), transform.position, transform.rotation);
            //sfx
            AudioManager.instance.PlayerSFXPlayer(randomHurt());
            //reduce health
            if (currentHealth - damageAmount <= 0)
            {
                // Lose state
            }
            else
            {
                currentHealth -= damageAmount;
            }
        }        
    }
    private AudioClip randomHurt()
    {
        int i = Random.Range(0, hurtSFX.Length);
        return hurtSFX[i];
    }

    IEnumerator IFrames()
    {
        yield return new WaitForSeconds(timeForIFrames);
        inIFrames = false;
    }

    IEnumerator HitEffect()
    {
        playerMat.EnableKeyword("HITEFFECT_ON");
        yield return new WaitForSeconds(0.2f);
        playerMat.DisableKeyword("HITEFFECT_ON");
    }

    IEnumerator HitAnimation()
    {
        animator.SetBool("isHurt", true);
        yield return new WaitForSeconds(.4f);
        animator.SetBool("isHurt", false);
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
