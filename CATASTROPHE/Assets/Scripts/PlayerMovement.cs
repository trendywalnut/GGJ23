using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private PlayerInput playerInput; //Instance of auto-generated C# class of our input map
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 mousePosition;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = playerInput.playerMap.Movement.ReadValue<Vector2>(); // Reads Vector2 from WASD or Left Stick
        mousePosition = playerInput.playerMap.Mouse.ReadValue<Vector2>();
        rb.velocity = moveInput * moveSpeed;
    }

    private void OnDash()
    {
        // Write dash code lol
        Debug.Log("Dashing towards: " + mousePosition);
    }

    private void OnEnable()
    {
        playerInput.playerMap.Enable();
    }

    private void OnDisable()
    {
        playerInput.playerMap.Disable();
    }
}
