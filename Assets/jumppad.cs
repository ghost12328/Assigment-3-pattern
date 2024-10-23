using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float bounceForce = 10f; // The force applied when the player bounces off the platform

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the object is the player
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Apply an upward force to the player
                playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);
            }
        }
    }
}
