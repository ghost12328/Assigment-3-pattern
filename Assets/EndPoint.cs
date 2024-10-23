using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName;  // Name of the next scene to load

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with the endpoint
        if (other.CompareTag("Player"))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Load the next scene by its name
        SceneManager.LoadScene(nextSceneName);
    }
}
