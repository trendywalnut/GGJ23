using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBounce : MonoBehaviour
{
    Rigidbody2D _rb;
    CapsuleCollider2D playerCollider;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, gameObject.GetComponent<CircleCollider2D>());
        _rb.AddForce(new Vector2(Random.Range(-3, 3), Random.Range(-3, 3)));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rb.AddForce(new Vector2(Random.Range(-2,2), Random.Range(-2,2)));
    }


}
