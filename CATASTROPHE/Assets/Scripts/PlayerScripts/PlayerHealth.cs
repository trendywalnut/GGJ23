using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField] private AudioClip[] hurtSFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int currentHealth;
    [SerializeField] private float timeForIFrames;
    public bool invulnerable;
    public bool inIFrames;

    private Material playerMat;

    private Animator animator;

    public TextMeshProUGUI healthUI;

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        playerMat = GetComponent<Renderer>().material;
        animator = GetComponent<Animator>();
        healthUI.SetText("Health: " + currentHealth.ToString());
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

        healthUI.SetText("Health: " + currentHealth.ToString());
    }

    public void TakeDamage(int damageAmount)
    {
        if (!invulnerable && !inIFrames)
        {
            inIFrames = true;
            StartCoroutine(HitEffect());
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
                death();
            }
            else
            {
                //animation
                StartCoroutine(HitAnimation());
                currentHealth -= damageAmount;
            }
            healthUI.SetText("Health: " + currentHealth.ToString());
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

    public void death()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        //sfx
        AudioManager.instance.PlayerSFXPlayer(randomHurt());
        animator.SetTrigger("death");
        Invoke("loadLoseScreen", 3.5f);
    }

    //spawn the explosion effect after the player death animation
    public void spawnDeathVFX()
    {
        Instantiate(Resources.Load("VFX_Death"), transform.position, transform.rotation);
    }

    //load lose screen
    public void loadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
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
