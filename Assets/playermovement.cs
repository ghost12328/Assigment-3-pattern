using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;          // Player's horizontal movement speed
    public float jumpForce = 10f;         // Force applied when the player jumps
    public Transform groundCheck;         // Empty GameObject used to check if the player is grounded
    public LayerMask groundLayer;         // Layer representing the ground
    public float jumpCooldown = 1.5f;     // Time between jumps

    // Fall mechanics
    public float fallMultiplier = 2.5f;   // Multiplier to make the player fall faster
    public float lowJumpMultiplier = 2f;  // For shorter jumps if the player releases the jump key early

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float moveInput;
    private float jumpTimer = 0f;         // Timer to track when the player can jump again

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get player input (left/right arrow keys or A/D keys)
        moveInput = Input.GetAxis("Horizontal");

        // Move the player left and right
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Update the jump timer
        jumpTimer -= Time.deltaTime;

        // Check if the player is grounded (touching the ground)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Jump if grounded, the jump button is pressed, and the cooldown timer has passed
        if (Input.GetButtonDown("Jump") && isGrounded && jumpTimer <= 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimer = jumpCooldown;   // Reset the jump cooldown timer
        }

        // Apply fall multiplier to make the player fall faster
        if (rb.velocity.y < 0)  // If the player is falling
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // Apply low jump multiplier if the player releases the jump button early
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
