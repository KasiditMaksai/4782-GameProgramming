using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveInput;
    [SerializeField] private float jump = 5f;
    [SerializeField] private float speed = 5;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CollectibleType playerColor;
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log($"{value} is pressed");
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
        }
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

            Destroy(collectible.gameObject);
        }
    }
}


