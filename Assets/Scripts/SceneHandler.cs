using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private GameObject MC;


    private string[] Scenes = { "TheWhisperingInn", "TownScene", "TownScene", "ChurchScene" }; // town scenes in index order: TownScene(Default) = 1, TownScene(Exit Church) = 2
    private Vector2[] positions = { new Vector2(-9, -20), new Vector2(-12, -12), new Vector2(24, -6), new Vector2(0, -6) };


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
