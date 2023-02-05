using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Vector3 moveDirection;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float bulletLife;
    [SerializeField] private int bulletDamage;

    private void OnEnable()
    {
        Invoke("Destroy", bulletLife);
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealth.Instance.TakeDamage(bulletDamage);
        }
    }
}
