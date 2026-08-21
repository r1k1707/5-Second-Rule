using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.15f;
    [SerializeField] private float dashCooldown = 1f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator _anim;

    // Set up the references for the player idle animations
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";

    private Vector2 lastMoveDirection;
    private bool isDashing;
    private bool canDash = true;

    // Allows other scripts to check if the player is currently dashing
    public bool IsDashing => isDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Connects in the references into active code
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Normal movement
        if (!isDashing)
        {
            rb.linearVelocity = moveInput * moveSpeed;
        }

        // Remember the last direction the player was moving
        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput.normalized;
        }
    }

    #region PLAYER_CONTROLS

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    #endregion

    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;

        // Dash in the direction the player was last moving
        rb.linearVelocity = lastMoveDirection * dashSpeed;

        // Dash lasts for this amount of time
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

        // Wait before allowing another dash
        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }

    private void Update()
    {
        _anim.SetFloat(_horizontal, moveInput.x);
        _anim.SetFloat(_vertical, moveInput.y);

        if (moveInput != Vector2.zero)
        {
            _anim.SetFloat(_lastHorizontal, moveInput.x);
            _anim.SetFloat( _lastVertical, moveInput.y);
        }
    }
}