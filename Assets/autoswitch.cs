using System.Collections;
using UnityEngine;

public class AutoWorldSwitch : MonoBehaviour
{
    public LayerMask shadowLayer;  // Layer for shadow platforms
    public LayerMask lightLayer;   // Layer for light platforms

    // Sprite references for light and shadow world sprites
    public GameObject[] lightWorldSprites;  
    public GameObject[] shadowWorldSprites; 

    public Color lightWorldColor = Color.white;   // Color for the light world
    public Color shadowWorldColor = Color.black;  // Color for the shadow world

    private Camera mainCamera;
    private bool isLightWorld = true;  // Tracks the current world state
    public float switchInterval = 2f;  // Time in seconds between world switches

    void Start()
    {
        mainCamera = Camera.main;
        SwitchToLightWorld(); // Start in the light world
        StartCoroutine(SwitchWorlds()); // Start automatic world switching
    }

    IEnumerator SwitchWorlds()
    {
        while (true)
        {
            yield return new WaitForSeconds(switchInterval); // Wait for the switch interval
            if (isLightWorld)
            {
                SwitchToShadowWorld();
            }
            else
            {
                SwitchToLightWorld();
            }
        }
    }

    void SwitchToShadowWorld()
    {
        isLightWorld = false;

        // Disable light world sprites, enable shadow world sprites
        ToggleWorldSprites(lightWorldSprites, false);
        ToggleWorldSprites(shadowWorldSprites, true);

        // Handle platform collision switching
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("LightPlatform"), true);
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("ShadowPlatform"), false);

        // Change background color
        mainCamera.backgroundColor = shadowWorldColor;
    }

    void SwitchToLightWorld()
    {
        isLightWorld = true;

        // Enable light world sprites, disable shadow world sprites
        ToggleWorldSprites(lightWorldSprites, true);
        ToggleWorldSprites(shadowWorldSprites, false);

        // Handle platform collision switching
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("ShadowPlatform"), true);
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("LightPlatform"), false);

        // Change background color
        mainCamera.backgroundColor = lightWorldColor;
    }

    // Helper method to toggle visibility of world-specific sprites
    void ToggleWorldSprites(GameObject[] sprites, bool isVisible)
    {
        foreach (GameObject sprite in sprites)
        {
            sprite.SetActive(isVisible);
        }
    }

    // Returns whether it is the light world or not (can be accessed from other scripts)
    public bool IsLightWorld()
    {
        return isLightWorld;
    }
}
