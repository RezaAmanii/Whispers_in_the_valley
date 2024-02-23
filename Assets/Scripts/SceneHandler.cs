using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private GameObject MC;


    private string[] Scenes = { "TheWhisperingInn", "TownScene", "AlexHouseScene" };
    private Vector2[] positions = { new Vector2(-9,-20), new Vector2(-12, -12), new Vector2(6, 1) };


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
