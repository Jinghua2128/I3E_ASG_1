using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [Header("Meshes")]
    public GameObject closedDoor;
    public GameObject openDoor;

    [Header("UI")]
    public GameObject interactionText;
    public TMP_Text messageText;

    [Header("Sound")]
    public AudioClip doorOpenSound;
    public AudioSource audioSource;

    private bool playerInRange = false;
    private GameManager gameManager;
    private bool doorOpened = false;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        if (interactionText != null)
            interactionText.SetActive(false);

        if (messageText != null)
            messageText.text = "";
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !doorOpened)
        {
            if (gameManager != null && gameManager.HasKey)
            {
                // Open the door
                closedDoor.SetActive(false);
                openDoor.SetActive(true);
                doorOpened = true;

                // Play sound
                if (doorOpenSound != null)
                {
                    if (audioSource != null)
                        audioSource.PlayOneShot(doorOpenSound);
                    else
                        AudioSource.PlayClipAtPoint(doorOpenSound, transform.position);
                }

                if (interactionText != null)
                    interactionText.SetActive(false);

                if (messageText != null)
                    messageText.text = "";
            }
            else
            {
                if (messageText != null)
                    messageText.text = "You need a key!";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactionText != null && !doorOpened)
                interactionText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactionText != null)
                interactionText.SetActive(false);

            if (messageText != null)
                messageText.text = "";
        }
    }
}
