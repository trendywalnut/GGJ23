using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileLifetime;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Vector2 targetDir;

    public void SetVelocity(Vector2 targetDirection)
    {
        targetDir = targetDirection;
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = targetDir * projectileSpeed;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(projectileLifetime);
        transform.DOScale(Vector3.zero, 0.1f);
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealth.Instance.TakeDamage(1);
            Destroy();
        }
        //else if (collision.tag != "Enemy")
        //{
        //    Destroy();
        //}
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        //TODO damage player
    //        Destroy(gameObject);
    //    } else if (!collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
