using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSoundtrack : MonoBehaviour

{
    private SoundtrackScript soundtrackScript;

    // Start is called before the first frame update
    void Start()
    {
        soundtrackScript = GameObject.Find("Soundyyy").GetComponent<SoundtrackScript>();

    }

    public void Run()
    {
        soundtrackScript.PlaySecondSoundtrack();
    }
}
