/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Handles collectible behavior, including interaction, SFX, VFX, and triggering GameManager score update.
*/

using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;     // Sound played when collected
    [SerializeField] private GameObject collectEffect;   // Visual effect when collected
    [SerializeField] private bool isCrystal = false;     // Is this the final crystal?

    public TMP_Text promptText;                          // Prompt shown near collectible

    private bool playerInRange = false;                  // Is player nearby?
    private GameManager gameManager;                     // Reference to GameManager

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Start()
    {
        if (promptText != null)
            promptText.gameObject.SetActive(false); // Hide prompt at start
    }

    private void Update()
    {
        // Trigger collect when player presses E near collectible
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            CollectItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (promptText != null)
                promptText.gameObject.SetActive(true); // Show prompt
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (promptText != null)
                promptText.gameObject.SetActive(false); // Hide prompt
        }
    }

    // Handles logic when item is collected
    private void CollectItem()
    {
        // Play collection sound
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        // Play particle effect
        if (collectEffect != null)
        {
            GameObject effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f); // Auto destroy effect
        }

        // Notify GameManager
        if (gameManager != null)
        {
            gameManager.CollectItem(10, isCrystal); // Pass score and crystal flag
        }

        if (promptText != null)
            promptText.gameObject.SetActive(false); // Hide prompt

        Destroy(gameObject); // Remove collectible
    }
}
