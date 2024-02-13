using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackScript : MonoBehaviour
{
    public AudioClip firstSoundtrack;
    public AudioClip secondSoundtrack;

    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure this GameObject persists across scene changes
        DontDestroyOnLoad(gameObject);

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Start playing the first soundtrack
        PlayFirstSoundtrack();
    }

    private void Update()
    {
        // Check for input to switch soundtracks
        if (Input.GetKeyDown(KeyCode.B))
        {
            // Toggle between soundtracks
            ToggleSoundtrack();
        }
    }

    private void PlayFirstSoundtrack()
    {
        // Set the first soundtrack clip and play it
        audioSource.clip = firstSoundtrack;
        audioSource.Play();
    }

    private void PlaySecondSoundtrack()
    {
        // Set the second soundtrack clip and play it
        audioSource.clip = secondSoundtrack;
        audioSource.Play();
    }

    private void ToggleSoundtrack()
    {
        // Toggle between the first and second soundtrack
        if (audioSource.clip == firstSoundtrack)
        {
            PlaySecondSoundtrack();
        }
        else
        {
            PlayFirstSoundtrack();
        }
    }
}
