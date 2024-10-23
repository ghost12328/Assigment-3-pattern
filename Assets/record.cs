using System.Collections.Generic;
using UnityEngine;

public class ReplayManager : MonoBehaviour
{
    // List to store player states
    private List<PlayerMemento> savedStates = new List<PlayerMemento>();

    // Recording and replay intervals
    public float recordInterval = 0.1f;  // Time interval for recording states
    private float timeSinceLastRecord = 0f;

    public float replayInterval = 0.1f;  // Time interval between replay frames
    private float timeSinceLastReplay = 0f;
    private int replayIndex = 0;

    // Flags to control recording and replaying
    private bool isRecording = true;
    private bool isReplaying = false;

    // Reference to the player object
    public Player player;

    private void Update()
    {
        // Handle recording
        if (isRecording)
        {
            timeSinceLastRecord += Time.deltaTime;
            if (timeSinceLastRecord >= recordInterval)
            {
                SaveState();
                timeSinceLastRecord = 0f;
            }
        }

        // Handle replaying
        if (isReplaying)
        {
            Replay();
        }

        // Start replay when the 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartReplay();
        }

        // Reset replay when the 'T' key is pressed (optional)
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResetReplay();
        }
    }

    // Save the player's current state
    public void SaveState()
    {
        savedStates.Add(player.SaveState());
    }

    // Replay the recorded states with smooth playback
    public void Replay()
    {
        if (savedStates.Count > 0 && replayIndex < savedStates.Count)
        {
            // Replay one state at a time, based on the replay interval
            timeSinceLastReplay += Time.deltaTime;
            if (timeSinceLastReplay >= replayInterval)
            {
                player.RestoreState(savedStates[replayIndex]);
                replayIndex++;
                timeSinceLastReplay = 0f;
            }
        }
        else
        {
            // Stop replay when all states have been played
            isReplaying = false;
            replayIndex = 0;
        }
    }

    // Start the replay
    public void StartReplay()
    {
        isRecording = false;  // Stop recording when replay starts
        isReplaying = true;
    }

    // Reset replay (clear saved states)
    public void ResetReplay()
    {
        savedStates.Clear();
        isRecording = true;
        isReplaying = false;
        replayIndex = 0;
    }
}
