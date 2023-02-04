using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAttack : MonoBehaviour
{
    [SerializeField] private float dashAttackDamage;
    private PlayerMovement _playerMovement;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Enemy"))
        {
            //do damage
        }
    }
}
