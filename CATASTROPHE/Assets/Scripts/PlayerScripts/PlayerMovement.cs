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
    private Vector2 playerPosition;
    private Vector2 dashDirection;

    private bool canDash = false;
    private bool isCooldownDone = false;

    public bool isDashing = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        moveInput = playerInput.playerMap.Movement.ReadValue<Vector2>(); // Reads Vector2 from WASD or Left Stick
        if (moveInput != Vector2.zero)
            //Debug.Log("Move Input: " + moveInput);
        mousePosition = mainCam.ScreenToWorldPoint(playerInput.playerMap.Mouse.ReadValue<Vector2>());
        rb.velocity = moveInput.normalized * moveSpeed;
        if(rb.velocity.x > 0)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
        }
        else if(rb.velocity.x < 0)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
        }
        else if(rb.velocity.y < 0 || rb.velocity.y > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", false);
        }

        if (cooldownTimer > 0)
        {
            isCooldownDone = false;
            cooldownTimer -= Time.deltaTime;
        }            
        if (cooldownTimer <= 0)
            isCooldownDone = true;

        if (canDash)
        {
            if (dashTimer > 0)
                dashTimer -= Time.deltaTime;
            rb.velocity = dashDirection.normalized * dashSpeed;

            if (dashTimer <= 0)
                canDash = false;
        }
    }

    private void OnDash()
    {
        if (isCooldownDone)
        {
            isDashing = true;
            StartCoroutine(DashAttackTime());
            Debug.Log("Dashed");
            playerPosition = new Vector2(transform.position.x, transform.position.y);
            dashDirection = mousePosition - playerPosition;

            canDash = true;
            dashTimer = dashTime;
            cooldownTimer = dashCooldown;
        }
    }

    IEnumerator DashAttackTime()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
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
