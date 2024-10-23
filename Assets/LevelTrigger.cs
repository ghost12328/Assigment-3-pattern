using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
   private bool lightNPCSpoken = false;
    private bool shadowNPCSpoken = false;

    public void NPCSpoken(string npcType)
    {
        if (npcType == "LightNPC")
        {
            lightNPCSpoken = true;
        }
        else if (npcType == "ShadowNPC")
        {
            shadowNPCSpoken = true;
        }

        // If both NPCs are spoken to, trigger the next level part
        if (lightNPCSpoken && shadowNPCSpoken)
        {
            TriggerNextLevel();
        }
    }

    void TriggerNextLevel()
    {
        // Code to move the player to the next part of the level
        Debug.Log("Both NPCs spoken to, moving to the next part of the level.");
    }
}
