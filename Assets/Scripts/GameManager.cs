/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Manages game state including score, relic collection, key unlocking, and UI updates.
*/
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance for easy access
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

    [Header("Player Health")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public Slider healthBar;
    public Image healthFill;

    [Header("Audio")]
    public AudioClip hurtSound;
    private AudioSource audioSource;

    void Awake()
    {
        // Reset all game state values at the start of runtime
        collectedCount = 0;
        score = 0;
        boxUnlocked = false;
        HasKey = false;
        //Lazy singleton pattern to ensure only one instance of GameManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Ensure only one instance exists
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject); // Keep this object across scenes
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
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.maxValue = maxHealth;

        if (healthBar != null)
            healthBar.value = currentHealth;

        UpdateHealthColor();
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
                UpdateUI();
            }
        }
        UpdateUI();
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

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.value = currentHealth;

        UpdateHealthColor();

        if (hurtSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        if (currentHealth <= 0)
        {
            Debug.Log("You Died!");
            StartCoroutine(RestartSceneAfterDelay());
        }
    }

    private void UpdateHealthColor()
    {
        if (healthFill == null) return;

        float healthPercent = (float)currentHealth / maxHealth;

        if (healthPercent > 0.5f)
            healthFill.color = Color.Lerp(Color.yellow, Color.green, (healthPercent - 0.5f) * 2);
        else
            healthFill.color = Color.Lerp(Color.red, Color.yellow, healthPercent * 2);
    }

    private IEnumerator RestartSceneAfterDelay()
    {
        yield return new WaitForSeconds(0f); // adjust delay if needed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Optional: reset health if needed
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.value = currentHealth;
        UpdateHealthColor();
    }
}

