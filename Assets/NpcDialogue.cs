using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public string[] dialogueLines;  // Array for multiple dialogue lines
    public GameObject dialogueBox;  // UI element to show dialogue
    public Text dialogueText;       // Reference to the UI text
    private int currentLine = 0;    // Tracks the current line of dialogue
    private bool playerInRange = false;
    private bool dialogueFinished = false;  // To check if dialogue is finished

    void Start()
    {
        // Ensure the dialogue box is hidden at the start of the game
        dialogueBox.SetActive(false);

        // Ensure the NPC is not re-enabled if dialogue has finished
        if (dialogueFinished)
        {
            gameObject.SetActive(false);  // Keep NPC hidden if it was already finished
        }
    }

    void Update()
    {
        // If player is in range and presses "F", show the next dialogue line
        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !dialogueFinished)
        {
            ShowNextDialogue();
        }
    }

    void ShowNextDialogue()
    {
        // Check if we are still within the dialogue lines
        if (currentLine < dialogueLines.Length)
        {
            dialogueBox.SetActive(true);    // Show dialogue box
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
        }
        else
        {
            // Dialogue finished, hide dialogue box and make the NPC disappear
            dialogueBox.SetActive(false);
            dialogueFinished = true;
            gameObject.SetActive(false);  // NPC disappears after dialogue is done
        }
    }

    // Trigger when player enters NPC range
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !dialogueFinished)
        {
            playerInRange = true;
        }
    }

    // Trigger when player exits NPC range
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);  // Hide dialogue box when player leaves range
        }
    }
}
