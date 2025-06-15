/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Adds score to the player when they touch a coin and plays a sound before destroying the coin.
*/

using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1;               // Value awarded when collected
    public AudioClip collectSound;           // Sound played upon collection
    public AudioSource audioSource;          // Optional audio source

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if player collides
        {
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddScore(scoreValue); // Add score to GameManager
            }

            // Play collection sound if assigned
            if (collectSound != null)
            {
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(collectSound); // Play through attached source
                }
                else
                {
                    AudioSource.PlayClipAtPoint(collectSound, transform.position); // Play at world location
                }
            }

            Destroy(gameObject); // Remove coin from scene
        }
    }
}
