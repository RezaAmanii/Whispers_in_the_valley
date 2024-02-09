using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private GameObject MC;


    private string[] Scenes = { "TheWhisperingInn", "TownScene" };
    private Vector2[] positions = { new Vector2(-9,-20), new Vector2(-12, -12) };

    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChangeScene(int SceneIndex)
    {
        MC.transform.position = positions[SceneIndex];
        SceneManager.LoadScene(Scenes[SceneIndex]);
    }
}
