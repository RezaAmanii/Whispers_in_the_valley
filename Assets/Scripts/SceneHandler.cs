using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private GameObject MC;


    private string[] Scenes = { "TheWhisperingInn", "TownScene", "Townscene", "TownScene", "TownScene", "TownScene", "Townscene", "TownScene", "TownScene", "ChurchScene" }; //TownScene exits in order = 
    // WhisperingInn(1), Teresa (2), Paul (3), Nadine (4), Matthew (5), Alex (6), Julia (7), Church (8)
    private Vector2[] positions = { new Vector2(-9,-20), new Vector2(-12, -12), new Vector2(-6, 1), new Vector2(-1, -17), new Vector2(-15, -4), new Vector2(13, -16), new Vector2(10, 1), new Vector2(24, -6), new Vector2(0, -4) };


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
