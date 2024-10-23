using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    // Save the player's current state (position and velocity)
    public PlayerMemento SaveState()
    {
        return new PlayerMemento(transform.position, rb.velocity);
    }

    // Restore the player's state (position and velocity)
    public void RestoreState(PlayerMemento memento)
    {
        transform.position = memento.Position;
        rb.velocity = memento.Velocity;
    }
}
