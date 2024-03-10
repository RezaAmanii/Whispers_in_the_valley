using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundtrackScript : MonoBehaviour
{
    public AudioClip firstSoundtrack;
    public AudioClip secondSoundtrack;

    public float volume = 1.0f; 

    private static SoundtrackScript instance;
    private AudioSource audioSource;

    private GameMaster GMscript;

    private bool playSecondSoundtrack = false;

    private void Awake()
    {

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
        audioSource.volume = volume;
        audioSource.Play();
    }

    public void PlaySecondSoundtrack()
    {
        if (!playSecondSoundtrack)
        {
            audioSource.clip = secondSoundtrack;
            audioSource.volume = volume;
            audioSource.Play();

            playSecondSoundtrack=true;
        }
    }

    public void ToggleSoundtrack()
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