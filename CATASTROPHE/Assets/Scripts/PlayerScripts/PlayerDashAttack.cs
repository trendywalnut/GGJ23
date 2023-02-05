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
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Attack");
        if (CompareTag("Enemy"))
        {
            Debug.Log("HIT!!!!!");
            enemy = other.GetComponent<IDamageable>();
            enemy?.TakeDamage(dashAttackDamage);
        }
    }
}
