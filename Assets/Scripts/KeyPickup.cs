using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    public TMP_Text promptText;
    private bool playerInRange = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        if (promptText != null)
            promptText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (gameManager != null)
                gameManager.HasKey = true;

            if (promptText != null)
                promptText.gameObject.SetActive(false);

            GameObject lockedBox = GameObject.Find("lockedBox");
            if (lockedBox != null)
                lockedBox.SetActive(false);

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (promptText != null)
                promptText.text = "Press E to collect the key";
                promptText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (promptText != null)
                promptText.gameObject.SetActive(false);
        }
    }
}
