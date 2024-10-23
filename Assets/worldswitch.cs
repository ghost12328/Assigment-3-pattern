using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class worldswitch : MonoBehaviour
{
    public LayerMask shadowLayer;  // Layer for shadow platforms
    public LayerMask lightLayer;   // Layer for light platforms

    // NPC references
    public GameObject npcLight;   
    public GameObject npcShadow; 

    // Sprite references for light and shadow world sprites
    public GameObject[] lightWorldSprites;  
    public GameObject[] shadowWorldSprites; 

    // Tilemap references for light and shadow worlds
    public Tilemap lightWorldTilemap;  
    public Tilemap shadowWorldTilemap;

    public Color lightWorldColor = Color.white;   // Color for the light world
    public Color shadowWorldColor = Color.black;  // Color for the shadow world

    private Camera mainCamera;
    private bool isLightWorld = true;  // Tracks the current world state

    void Start()
    {
        mainCamera = Camera.main;
        SwitchToLightWorld();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToShadowWorld();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToLightWorld();
        }
    }

    void SwitchToShadowWorld()
    {
        isLightWorld = false;

        // Disable light NPC, enable shadow NPC
        npcLight.SetActive(false);
        npcShadow.SetActive(true);

        // Disable light world sprites, enable shadow world sprites
        ToggleWorldSprites(lightWorldSprites, false);
        ToggleWorldSprites(shadowWorldSprites, true);

        // Enable shadow world tilemap, disable light world tilemap
        lightWorldTilemap.gameObject.SetActive(false);
        shadowWorldTilemap.gameObject.SetActive(true);

        // Handle platform collision switching
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("LightPlatform"), true);
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("ShadowPlatform"), false);

        // Change background color
        mainCamera.backgroundColor = shadowWorldColor;
    }

    void SwitchToLightWorld()
    {
        isLightWorld = true;

        // Enable light NPC, disable shadow NPC
        npcLight.SetActive(true);
        npcShadow.SetActive(false);

        // Enable light world sprites, disable shadow world sprites
        ToggleWorldSprites(lightWorldSprites, true);
        ToggleWorldSprites(shadowWorldSprites, false);

        // Enable light world tilemap, disable shadow world tilemap
        lightWorldTilemap.gameObject.SetActive(true);
        shadowWorldTilemap.gameObject.SetActive(false);

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
