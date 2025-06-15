/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Handles player health, UI updates, damage feedback, and game restart on death.
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health value
    private int currentHealth; // Current health

    public Slider healthBar; // Health bar UI slider
    public Image healthFill; // UI fill element to change color based on health

    [Header("Audio")]
    public AudioClip hurtSound; // Sound played when damaged
    private AudioSource audioSource; // Audio source to play hurt sound

    void Start()
    {
        currentHealth = maxHealth; // Set current health to max at game start
        healthBar.maxValue = maxHealth; // Set slider max
        healthBar.value = currentHealth; // Initialize slider value
        UpdateHealthColor(); // Set initial color of health bar

        // Initialize audio source
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// Called when the player takes damage.
    /// </summary>
    /// <param name="amount">Amount of health to reduce</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Decrease health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays in bounds
        healthBar.value = currentHealth; // Update slider
        UpdateHealthColor(); // Change color based on health

        // Play damage sound
        if (hurtSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        // If health is zero, trigger game over
        if (currentHealth <= 0)
        {
            Debug.Log("You Died!");
            GameOver();
        }
    }

    /// <summary>
    /// Changes the fill color based on health percent.
    /// </summary>
    void UpdateHealthColor()
    {
        float healthPercent = (float)currentHealth / maxHealth;

        if (healthPercent > 0.5f)
            healthFill.color = Color.Lerp(Color.yellow, Color.green, (healthPercent - 0.5f) * 2);
        else
            healthFill.color = Color.Lerp(Color.red, Color.yellow, healthPercent * 2);
    }

    /// <summary>
    /// Called when player health reaches zero.
    /// </summary>
    void GameOver()
    {
        Debug.Log("You Died!");
        StartCoroutine(RestartSceneAfterDelay());
    }

    /// <summary>
    /// Delays restart and reloads the current scene.
    /// </summary>
    IEnumerator RestartSceneAfterDelay()
    {
        yield return new WaitForSeconds(0f); // You can adjust delay time here
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
