/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Handles final crystal interaction. When collected, the game is won and a win message is shown.
*/

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalCrystal : MonoBehaviour
{
    public TMP_Text promptText;           // UI prompt to show instructions
    private bool playerInRange = false;   // Is player in range of the crystal?
    private GameManager gameManager;      // Reference to the GameManager
    private bool hasBeenCollected = false; // Prevents repeated interaction

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>(); // Find GameManager in scene

        if (promptText != null)
            promptText.gameObject.SetActive(false); // Hide prompt initially
    }

    void Update()
    {
        // Check for player input when near and not already collected
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !hasBeenCollected)
        {
            WinGame();
        }
    }

    /// <summary>
    /// Called when the player collects the final crystal.
    /// </summary>
    private void WinGame()
    {
        hasBeenCollected = true;

        // Add score and update UI through GameManager
        if (gameManager != null)
        {
            gameManager.CollectItem(50, true); // Flag this as final crystal
        }

        // Show winning message
        if (promptText != null)
        {
            promptText.text = "You Win!";
        }

        // Disable the crystal object
        gameObject.SetActive(false);
    }

    // When player enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenCollected)
        {
            playerInRange = true;

            if (promptText != null)
            {
                promptText.text = "Press E to claim the crystal!";
                promptText.gameObject.SetActive(true); // Show prompt
            }
        }
    }

    // When player exits the trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (promptText != null && !hasBeenCollected)
                promptText.gameObject.SetActive(false); // Hide prompt if not yet collected
        }
    }
}
