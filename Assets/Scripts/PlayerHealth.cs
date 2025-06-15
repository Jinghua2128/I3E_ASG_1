using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar;
    public Image healthFill;

    [Header("Audio")]
    public AudioClip hurtSound;
    private AudioSource audioSource;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        UpdateHealthColor();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;
        UpdateHealthColor();

        // Play hurt sound
        if (hurtSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        if (currentHealth <= 0)
        {
            Debug.Log("You Died!");
            GameOver();
        }
    }

    void UpdateHealthColor()
    {
        float healthPercent = (float)currentHealth / maxHealth;

        if (healthPercent > 0.5f)
            healthFill.color = Color.Lerp(Color.yellow, Color.green, (healthPercent - 0.5f) * 2);
        else
            healthFill.color = Color.Lerp(Color.red, Color.yellow, healthPercent * 2);
    }

    void GameOver()
    {
        Debug.Log("You Died!");
        StartCoroutine(RestartSceneAfterDelay());
    }

    IEnumerator RestartSceneAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
