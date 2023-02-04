using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;
    private float dashTimer;
    private float cooldownTimer;

    [SerializeField] private Camera mainCam;

    private PlayerInput playerInput; //Instance of auto-generated C# class of our input map
    private Rigidbody2D rb;

    private Vector2 moveInput;
    private Vector2 mousePosition;
    private Vector2 activeMoveSpeed;

    private bool canDash = false;
    private bool isCooldownDone = false;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = playerInput.playerMap.Movement.ReadValue<Vector2>(); // Reads Vector2 from WASD or Left Stick
        mousePosition = mainCam.ScreenToWorldPoint(playerInput.playerMap.Mouse.ReadValue<Vector2>());
        //activeMoveSpeed = moveInput * moveSpeed;
        rb.velocity = moveInput * moveSpeed;

        if (cooldownTimer <= 0)
            isCooldownDone = true;
        else if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        if (canDash)
        {
            if (dashTimer > 0)
                dashTimer -= Time.deltaTime;

            Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 dashDirection = mousePosition - playerPosition;
            rb.velocity = dashDirection.normalized * dashSpeed;

            if (dashTimer <= 0)
                canDash = false;
        }
    }

    private void OnDash()
    {
        //Debug.Log("Dashed");
        if (isCooldownDone)
        {
            canDash = true;
            dashTimer = dashTime;
            cooldownTimer = dashCooldown;
        }
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
