using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1;
    public AudioClip collectSound;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddScore(scoreValue);
            }

            if (collectSound != null)
            {
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(collectSound);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);
                }
            }

            Destroy(gameObject);
        }
    }
}
