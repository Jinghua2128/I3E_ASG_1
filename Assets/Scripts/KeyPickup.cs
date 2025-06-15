/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Handles logic for picking up the key, updating GameManager state, and disabling the locked box.
*/

using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    public TMP_Text promptText;              // Prompt UI shown when near the key
    private bool playerInRange = false;      // Tracks if the player is near the key
    private GameManager gameManager;         // Reference to GameManager

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>(); // Locate GameManager

        if (promptText != null)
            promptText.gameObject.SetActive(false); // Hide prompt at the start
    }

    void Update()
    {
        // Check for interaction input
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (gameManager != null)
                gameManager.HasKey = true; // Player now has the key

            if (promptText != null)
                promptText.gameObject.SetActive(false); // Hide prompt

            GameObject lockedBox = GameObject.Find("lockedBox");
            if (lockedBox != null)
                lockedBox.SetActive(false); // Optionally hide the locked box

            Destroy(gameObject); // Remove the key object
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (promptText != null)
            {
                promptText.text = "Press E to collect the key";
                promptText.gameObject.SetActive(true); // Show prompt
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (promptText != null)
                promptText.gameObject.SetActive(false); // Hide prompt
        }
    }
}
