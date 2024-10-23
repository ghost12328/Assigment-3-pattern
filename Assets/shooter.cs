using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject lightWallPrefab; // Prefab for light wall
    public GameObject shadowWallPrefab; // Prefab for shadow wall
    public Transform spawnPoint; // Where the wall is spawned from
    public float shootInterval = 2f; // Time between shots
    public float wallLifetime = 5f; // Time before the wall is destroyed
    public Vector2 moveDirection = Vector2.left; // Direction the wall moves
    public float wallSpeed = 3f; // Speed of the wall

    private void Start()
    {
        // Start the shooting routine
        InvokeRepeating("ShootWall", 1f, shootInterval);
    }

    void ShootWall()
    {
        // Alternate between shooting light and shadow walls
        GameObject wallToShoot = (Random.Range(0, 2) == 0) ? lightWallPrefab : shadowWallPrefab;
        
        if (wallToShoot != null)
        {
            GameObject spawnedWall = Instantiate(wallToShoot, spawnPoint.position, Quaternion.identity);
            WallMovement wallMovement = spawnedWall.GetComponent<WallMovement>();
            if (wallMovement != null)
            {
                wallMovement.SetupWall(moveDirection, wallSpeed, wallLifetime);
            }
        }
    }
}
