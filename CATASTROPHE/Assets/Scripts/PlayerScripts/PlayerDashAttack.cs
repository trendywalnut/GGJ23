using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAttack : MonoBehaviour
{
    [Header("Dash Attack Damage (1 is default)")]
    [SerializeField] private int dashAttackDamage = 1;

    [Header("Combo Script")]
    [SerializeField] private DashCombo dashCombo;

    private IDamageable enemy;
    private IDamageable boss;
    private PlayerMovement _playerMovement;

    //VFX
    //[SerializeField] private GameObject dashHitVFX;
    void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && _playerMovement.isDashing)
        {
            enemy = other.GetComponent<IDamageable>();
            enemy?.TakeDamage(dashAttackDamage);

            //instantiate VFX
            Instantiate(Resources.Load("VFX_Hit_Slash"), other.gameObject.transform.position, gameObject.transform.rotation);
            dashCombo.IncreaseCombo();
        }

        if (other.CompareTag("Boss") && _playerMovement.isDashing)
        {
            boss = other.GetComponent<IDamageable>();
            boss?.TakeDamage(dashAttackDamage);

            //instantiate VFX
            Instantiate(Resources.Load("VFX_Hit_Slash"), other.gameObject.transform.position, gameObject.transform.rotation);
            dashCombo.IncreaseCombo();
        }
    }
}
