using UnityEngine;

public class WorldSprite : MonoBehaviour
{
    public enum WorldType { Light, Dark }
    public WorldType spriteWorld; // Specify the sprite's world in the Inspector

    private SpriteRenderer spriteRenderer;
    private worldswitch worldSwitch; // Reference to the worldswitch script

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Find the worldswitch script
        worldSwitch = FindObjectOfType<worldswitch>();

        // Set the initial visibility based on the starting world
        UpdateVisibility(worldSwitch.IsLightWorld());
    }

    void Update()
    {
        // Update visibility whenever the world changes
        UpdateVisibility(worldSwitch.IsLightWorld());
    }

    void UpdateVisibility(bool isLightWorld)
    {
        // Show or hide sprite based on the current world
        if (spriteWorld == WorldType.Light)
        {
            spriteRenderer.enabled = isLightWorld; // Show in light world
        }
        else if (spriteWorld == WorldType.Dark)
        {
            spriteRenderer.enabled = !isLightWorld; // Show in dark world
        }
    }
}
