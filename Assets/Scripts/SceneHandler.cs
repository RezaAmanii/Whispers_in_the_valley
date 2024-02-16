using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private GameObject MC;


    private string[] Scenes = { "TheWhisperingInn", "TownScene", "ChurchScene" };
    private Vector2[] positions = { new Vector2(-9, -20), new Vector2(-12, -12), new Vector2(0, -6) };


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

    public void GoToTownScene()
    {
        ChangeScene(1); // Index 1 corresponds to the town scene in the Scenes array
    }

    public void GoToChurchScene()
    {
        ChangeScene(2); // Index 1 corresponds to the town scene in the Scenes array
    }
}
