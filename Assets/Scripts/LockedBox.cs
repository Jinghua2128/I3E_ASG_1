using UnityEngine;
using TMPro;
using System.Collections;

public class LockedBox : MonoBehaviour
{
    public TMP_Text promptText;
    public GameObject keyObject;

    private GameManager gameManager;
    private bool playerInRange = false;
    private bool keySpawned = false;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        if (promptText != null)
            promptText.gameObject.SetActive(false);

        if (keyObject != null)
            keyObject.SetActive(false);
    }

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameManager != null && gameManager.CollectedCount >= gameManager.totalCollectibles)
            {
            }
            else
            {
                promptText.text = "Collect all 3 relics to unlock the key!";
            }
        }
    }

    IEnumerator SpawnKeyAfterDelay(float delay)
    {
        keySpawned = true;
        yield return new WaitForSeconds(delay);

        keyObject.SetActive(true);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;

        if (promptText != null)
        {
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
            promptText.gameObject.SetActive(false);
    }
}
