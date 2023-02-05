using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAttack : MonoBehaviour
{
    [Header("Dash Attack Damage (1 is default)")]
    [SerializeField] private int dashAttackDamage = 1;

    private IDamageable enemy;
    private PlayerMovement _playerMovement;
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
        }
    }
}
