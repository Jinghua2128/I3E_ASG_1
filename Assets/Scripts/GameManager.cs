/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Manages game state including score, relic collection, key unlocking, and UI updates.
*/

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int totalCollectibles = 3; // Total number of relics needed
    private int collectedCount = 0; // Tracks how many relics have been collected
    public int CollectedCount => collectedCount; // Public read-only access to collected count

    public int score = 0; // Player score

    public bool HasKey = false; // Whether the player has picked up the key
    public TMP_Text collectibleText; // Reference to UI element displaying relic count
    public TMP_Text scoreText; // Reference to UI element displaying score

    public GameObject lockedBox; // Reference to the locked box GameObject
    private bool boxUnlocked = false; // Whether the locked box has been unlocked
    public GameObject keyObject; // Reference to the key GameObject

    void Awake()
    {
        // Reset all game state values at the start of runtime
        collectedCount = 0;
        score = 0;
        boxUnlocked = false;
        HasKey = false;
    }

    /// <summary>
    /// Called when a collectible is picked up.
    /// </summary>
    /// <param name="scoreValue">Score value awarded for this collectible.</param>
    /// <param name="isCrystal">If true, this is the final crystal collectible.</param>
    public void CollectItem(int scoreValue = 10, bool isCrystal = false)
    {
        collectedCount++; // Increase relic count
        score += scoreValue; // Increase score
        UpdateUI(); // Refresh the UI

        // If all collectibles are collected and box isn't unlocked yet
        if (collectedCount >= totalCollectibles && !boxUnlocked)
        {
            UnlockBox(); // Unlock the box

            if (keyObject != null)
            {
                keyObject.SetActive(true); // Show the key
                Debug.Log("Key has appeared!");
            }

            if (lockedBox != null)
            {
                lockedBox.SetActive(true); // Make sure locked box is visible
                Debug.Log("Locked box is now active!");
            }
        }
    }

    /// <summary>
    /// Adds points to the score without affecting relic count.
    /// </summary>
    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void Start()
    {
        // Ensure the game starts in a clean state
        collectedCount = 0;
        score = 0;
        boxUnlocked = false;
        HasKey = false;

        if (keyObject != null)
            keyObject.SetActive(false); // Hide key at start

        if (lockedBox != null)
            lockedBox.SetActive(false); // Hide box at start

        UpdateUI();
    }

    /// <summary>
    /// Plays unlock animation and sets boxUnlocked flag.
    /// </summary>
    void UnlockBox()
    {
        boxUnlocked = true;
        Debug.Log("Box unlocked!");

        if (lockedBox != null)
        {
            Animator anim = lockedBox.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Unlock"); // Play box animation
            }
        }
    }

    /// <summary>
    /// Updates the relic and score text UI.
    /// </summary>
    void UpdateUI()
    {
        if (collectibleText != null)
            collectibleText.text = $"Relics: {collectedCount}/{totalCollectibles}";

        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }
}
