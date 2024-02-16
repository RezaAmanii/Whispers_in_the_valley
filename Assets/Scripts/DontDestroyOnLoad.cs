using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);

        // If there's more than one object with the same tag, destroy the new one
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // Ensure this object persists across scene transitions
            DontDestroyOnLoad(gameObject);
        }
    }
}
