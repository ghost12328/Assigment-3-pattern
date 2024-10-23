using System.Collections;
using UnityEngine;

public class AutomaticWorldSwitch : MonoBehaviour
{
    public float switchInterval = 2f; // Time in seconds between world switches
    private bool isLightWorld = true; // Start with the light world
    private Camera mainCamera;
    
    public LayerMask shadowLayer;  // Layer for shadow platforms
    public LayerMask lightLayer;   // Layer for light platforms
    public GameObject npcLight;    // Reference to the Light NPC
    public GameObject npcShadow;   // Reference to the Shadow NPC

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SwitchWorlds());
    }

    IEnumerator SwitchWorlds()
    {
        while (true)
        {
            yield return new WaitForSeconds(switchInterval);
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
        npcLight.SetActive(false);
        npcShadow.SetActive(true);
        
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("LightPlatform"), true);
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("ShadowPlatform"), false);
        mainCamera.backgroundColor = Color.black;

        isLightWorld = false; // Update the current world state
    }

    void SwitchToLightWorld()
    {
        npcLight.SetActive(true);
        npcShadow.SetActive(false);
        
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("ShadowPlatform"), true);
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("LightPlatform"), false);
        mainCamera.backgroundColor = Color.white;

        isLightWorld = true; // Update the current world state
    }
}
