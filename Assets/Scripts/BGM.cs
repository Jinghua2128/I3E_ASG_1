using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f;
    }

    void Start()
    {
        if (musicClip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
