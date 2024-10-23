using UnityEngine;
using UnityEngine.SceneManagement;  // For restarting the level

public class LevelTimer : MonoBehaviour
{
    public float timeRemaining = 60f;  // Set the initial time in seconds
    public bool timerIsRunning = false;  // Tracks if the timer is active
    public UnityEngine.UI.Text timerText;  // Reference to a UI Text to display the timer (optional)

    void Start()
    {
        // Start the timer when the level begins
        timerIsRunning = true;
        UpdateTimerText();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Countdown
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                // Time has run out, restart the level
                timeRemaining = 0;
                timerIsRunning = false;
                RestartLevel();
            }
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            // Display the remaining time in the format "MM:SS"
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void RestartLevel()
    {
        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
