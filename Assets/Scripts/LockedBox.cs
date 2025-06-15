/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Manages interaction with the locked box, including prompting player and spawning the key after conditions are met.
*/

using UnityEngine;
using TMPro;
using System.Collections;

public class LockedBox : MonoBehaviour
{
    public TMP_Text promptText;        // UI prompt shown to player
    public GameObject keyObject;       // Key GameObject to spawn

    private GameManager gameManager;   // Reference to GameManager
    private bool playerInRange = false;// Is player in interaction zone
    private bool keySpawned = false;   // Has the key been spawned

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        if (promptText != null)
            promptText.gameObject.SetActive(false); // Hide prompt at start

        if (keyObject != null)
            keyObject.SetActive(false); // Hide key at start
    }

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Only proceed if player has enough collectibles
            if (gameManager != null && gameManager.CollectedCount >= gameManager.totalCollectibles && !keySpawned)
            {
                StartCoroutine(SpawnKeyAfterDelay(1f)); // Delay and spawn key
            }
            else
            {
                promptText.text = "Collect all 3 relics to unlock the key!";
            }
        }
    }

    // Coroutine to delay and then show the key
    IEnumerator SpawnKeyAfterDelay(float delay)
    {
        keySpawned = true;
        yield return new WaitForSeconds(delay);

        keyObject.SetActive(true);
        gameObject.SetActive(false); // Disable box
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;

        if (promptText != null)
        {
            // Show prompt depending on condition
            if (gameManager != null && gameManager.CollectedCount >= gameManager.totalCollectibles)
            {
                promptText.text = "Press E to unlock the key";
            }
            else
            {
                promptText.text = "Collect all 3 relics to unlock the key!";
            }

            promptText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;

        if (promptText != null)
            promptText.gameObject.SetActive(false); // Hide prompt
    }
}
