using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // First empty GameObject (starting point)
    public Transform pointB; // Second empty GameObject (ending point)
    public float speed = 2f; // Platform movement speed

    private Vector3 targetPosition; // Target to move the platform to

    private void Start()
    {
        // Set initial target to pointB (or you can start at pointA if you want)
        targetPosition = pointB.position;
    }

    private void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Switch the target position between pointA and pointB
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }
}
