using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalCrystal : MonoBehaviour
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
            WinGame();
        }
    }

    private void WinGame()
    {
        if (promptText != null)
        {
            promptText.text = "You Win!";
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (promptText != null)
            {
                promptText.text = "Press E to claim the crystal!";
                promptText.gameObject.SetActive(true);
            }
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
