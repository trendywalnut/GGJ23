using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionIgnore : MonoBehaviour
{
    private CapsuleCollider2D playerCollider;
    void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, gameObject.GetComponent<BoxCollider2D>());
    }
}
