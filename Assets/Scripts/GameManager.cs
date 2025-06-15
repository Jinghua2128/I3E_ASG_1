using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int totalCollectibles = 3;
    private int collectedCount = 0;
    public int CollectedCount => collectedCount;
    public bool AllCollectiblesCollected()
    {
        return collectedCount >= totalCollectibles;
    }


    public int score = 0;

    public bool HasKey = false;
    public TMP_Text collectibleText;
    public TMP_Text scoreText;

    public GameObject lockedBox;

    private bool boxUnlocked = false;
    public GameObject keyObject;

    public void CollectItem(int scoreValue = 10)
    {
        collectedCount++;
        score += scoreValue;
        UpdateUI();

        if (collectedCount >= totalCollectibles && !boxUnlocked)
        {
            UnlockBox();
            if (keyObject != null)
            {
                keyObject.SetActive(true);
                Debug.Log("Key has appeared!");
            }
        }
    }

    void Start()
    {
        UpdateUI();
    }


    void UnlockBox()
    {
        boxUnlocked = true;
        Debug.Log("Box unlocked!");
        if (lockedBox != null)
        {
            Animator anim = lockedBox.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Unlock");
            }
        }
    }

    void UpdateUI()
    {
        if (collectibleText != null)
            collectibleText.text = $"Relics: {collectedCount}/{totalCollectibles}";

        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }
}
