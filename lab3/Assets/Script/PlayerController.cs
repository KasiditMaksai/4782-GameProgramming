using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveInput;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float speed = 5;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private PlayerAnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CollectibleType playerColor;
    [SerializeField] private float coyoteTime = 0.15f;
    [SerializeField] private float coyoteCount;

    [Header("Ground Check")] [SerializeField]
    private LayerMask groundLayers;

    [SerializeField] private float groundCheckDistance = 0.01f;

    private bool _isGrounded;

    private void Update()
    {
        CheckGround();
        SetAnimatorParameters();
        CheckCoyotetime();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
        FlipPlayerSprite();
    }

    public void Jump(float value)
    {
        //Debug.Log($"{value} is pressed");
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(transform.up * value, ForceMode2D.Impulse);
        coyoteCount = 0f;
    }

    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;
        TryJumping();
    }

    private void TryJumping()
    {
        if (!_isGrounded) return;

        Jump(jumpForce);
    }
    private void CheckCoyotetime()
    {
        if (_isGrounded)
        {
            coyoteCount = coyoteTime;
        }
        else
        {
            coyoteCount -= Time.deltaTime;
        }
    }
    private void FlipPlayerSprite()
    {
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput > 0)
        {
            transform.localScale = Vector3.one;
        }
    }
    private void TakeDamage()
    {
        GameManager.instance.ProcessPlayerDeath();
    }
    private void CheckGround()
    {
        var playerBounds = playerCollider.bounds;

        RaycastHit2D raycastHit = Physics2D.BoxCast(playerBounds.center, playerBounds.size,
            0f, Vector2.down, groundCheckDistance, groundLayers);
        _isGrounded = raycastHit.collider != null;
    }

    private void SetAnimatorParameters()
    {
        animatorController.SetAnimatorParameter(rb.velocity, _isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Collectibles collectible))
        {
            CollectibleType playerColor = collectible.color;

            switch (playerColor)
            {
                case CollectibleType.Yellow:
                    spriteRenderer.color = Color.yellow;
                    break;
                case CollectibleType.Green:
                    spriteRenderer.color = Color.green;
                    break;
                case CollectibleType.Red:
                    spriteRenderer.color = Color.red;
                    break;
            }

            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Finish"))
        {
            GameManager.instance.LoadNextLevel();
        }
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            TakeDamage();
        }
    }
}