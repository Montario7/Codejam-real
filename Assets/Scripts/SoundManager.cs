using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SoundManager : BaseManager
{
    public static SoundManager instance;

    private AudioSource audioSource;

    public AudioClip audioClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize(); // Call the base class initialization
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioClip != null)
        {
            PlaySound();
        }
        else
        {
            LogMessage("No audio clip assigned."); // Use the base class method
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("SoundManager initialized.");
    }

    public void PlaySound()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            LogMessage("Audio source or audio clip is null."); // Use the base class method
        }
    }
}
