/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Plays background music across scenes using DontDestroyOnLoad.
*/

using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip musicClip;        // BGM audio clip
    private AudioSource audioSource;   // AudioSource component for playback

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Keep this object across scene loads

        // Try to get or create an AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // Configure audio source
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f;
    }

    void Start()
    {
        // Start playing music if not already playing
        if (musicClip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
