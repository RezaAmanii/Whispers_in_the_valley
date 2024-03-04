//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SFXmanager : MonoBehaviour
//{
 
//    public AudioClip dialogueSound;
//    public AudioClip doorOpenSound;
//    public AudioClip itemPickupSound;

//    private AudioSource audioSource;

//    private static SFXmanager instance;

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//            return;
//        }

//        audioSource = GetComponent<AudioSource>();
//        if (audioSource == null)
//        {
//            audioSource = gameObject.AddComponent<AudioSource>();
//        }
//    }

//    public void PlayDialogueSound()
//    {
//        audioSource.PlayOneShot(dialogueSound);
//    }

//    public void PlayDoorOpenSound()
//    {
//        audioSource.PlayOneShot(doorOpenSound);
//    }

//    public void PlayItemPickupSound()
//    {
//        audioSource.PlayOneShot(itemPickupSound);

//    }
//}
