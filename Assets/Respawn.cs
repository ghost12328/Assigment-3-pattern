using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint;  // Reference to the empty GameObject (Respawn Point)
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the death zone
        if (other.CompareTag("DeathZone"))
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        // Move the player to the respawn point
        transform.position = respawnPoint.position;
        // You can also reset health, animations, etc., if needed
    }
}
