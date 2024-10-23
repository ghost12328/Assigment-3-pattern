using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{    public Transform player;        // Reference to the player's Transform
    public Vector3 offset = new Vector3(0, 0, -10);  // Offset to keep the camera behind the player

    void LateUpdate()
    {
        // Directly set the camera's position to match the player's, plus the offset
        transform.position = new Vector3(player.position.x, player.position.y, offset.z);
    }
}
