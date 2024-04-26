using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audioSource;

    // AudioClip to be played
    public AudioClip audioClip;

    void Awake()
    {
        // Ensure only one instance of SoundManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Get the AudioSource component if not already assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();

            // Check if an audio clip is assigned
            if (audioClip != null)
            {
                PlaySound();
            }
            else
            {
                Debug.LogWarning("No audio clip assigned.");
            }
        }
    }

    // Play the assigned audio clip
    public void PlaySound()
    {
        // Check if the audioSource is assigned
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning("Audio source or audio clip is null.");
        }
    }
}

