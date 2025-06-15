/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Handles door interaction logic, including UI prompts, key check, animations, and sound effects.
*/

using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [Header("Meshes")]
    public GameObject closedDoor; // Reference to the closed door mesh
    public GameObject openDoor;   // Reference to the open door mesh

    [Header("UI")]
    public GameObject interactionText; // "Press E" prompt
    public TMP_Text messageText;       // Message text for things like "You need a key!"

    [Header("Sound")]
    public AudioClip doorOpenSound;    // Sound to play when door opens
    public AudioSource audioSource;    // Audio source to play clip from

    private bool playerInRange = false; // Tracks if player is in trigger zone
    private GameManager gameManager;   // Reference to the GameManager
    private bool doorOpened = false;   // Flag to prevent re-opening

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>(); // Find GameManager in scene

        if (interactionText != null)
            interactionText.SetActive(false); // Hide interaction prompt at start

        if (messageText != null)
            messageText.text = ""; // Clear message text
    }

    void Update()
    {
        // Check for interaction input if player is nearby and door isn't opened
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !doorOpened)
        {
            if (gameManager != null && gameManager.HasKey)
            {
                // Open the door
                closedDoor.SetActive(false); // Hide closed door
                openDoor.SetActive(true);    // Show open door
                doorOpened = true;

                // Play door open sound
                if (doorOpenSound != null)
                {
                    if (audioSource != null)
                        audioSource.PlayOneShot(doorOpenSound); // Play from AudioSource
                    else
                        AudioSource.PlayClipAtPoint(doorOpenSound, transform.position); // Play at location
                }

                // Hide UI
                if (interactionText != null)
                    interactionText.SetActive(false);

                if (messageText != null)
                    messageText.text = "";
            }
            else
            {
                // Player doesn't have the key
                if (messageText != null)
                    messageText.text = "You need a key!";
            }
        }
    }

    // Detect player entering trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactionText != null && !doorOpened)
                interactionText.SetActive(true); // Show interaction prompt
        }
    }

    // Detect player leaving trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactionText != null)
                interactionText.SetActive(false); // Hide prompt

            if (messageText != null)
                messageText.text = ""; // Clear message
        }
    }
}
