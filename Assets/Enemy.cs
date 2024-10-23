using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    public float speed = 2f; // Speed of the enemy movement
    public Transform pointA; // First empty GameObject (start point)
    public Transform pointB; // Second empty GameObject (end point)

    private Vector3 targetPosition; // The target position for the enemy to move towards

    private void Start()
    {
        // Start by moving towards pointB
        targetPosition = pointB.position;
    }

    private void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Move the enemy towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the enemy reaches one of the points, switch to the other point
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }

    // Handle collision with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the enemy collided with the player
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destroy the player on collision
        }
    }
}
