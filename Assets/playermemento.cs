using UnityEngine;

public class PlayerMemento
{
    public Vector3 Position { get; private set; }
    public Vector2 Velocity { get; private set; }

    public PlayerMemento(Vector3 position, Vector2 velocity)
    {
        Position = position;
        Velocity = velocity;
    }
}
