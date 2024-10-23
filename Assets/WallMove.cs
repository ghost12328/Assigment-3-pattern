using UnityEngine;

public class WallMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    private float wallSpeed;
    private float wallLifetime;

    public void SetupWall(Vector2 direction, float speed, float lifetime)
    {
        moveDirection = direction;
        wallSpeed = speed;
        wallLifetime = lifetime;
        Destroy(gameObject, wallLifetime); // Destroy wall after lifetime
    }

    private void Update()
    {
        // Move the wall in the specified direction
        transform.Translate(moveDirection * wallSpeed * Time.deltaTime);
    }
}
