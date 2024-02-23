using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundtrackScript : MonoBehaviour
{
    public AudioClip firstSoundtrack;
    public AudioClip secondSoundtrack;

    private static SoundtrackScript instance;
    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one instance of SoundtrackScript exists
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}

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
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleSoundtrack();
        }
    }

    private void PlayFirstSoundtrack()
    {
        audioSource.clip = firstSoundtrack;
        audioSource.Play();
    }

    private void PlaySecondSoundtrack()
    {
        audioSource.clip = secondSoundtrack;
        audioSource.Play();
    }

    private void ToggleSoundtrack()
    {
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