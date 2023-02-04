using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.gameObject.GetComponent<PlayerHealth>().GainHealth(healAmount);
            Destroy(this.gameObject);
        }
    }
}
