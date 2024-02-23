using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneHandler : MonoBehaviour
{

    private GameObject MC;
    static string townsSceneString = "NightScene";

    //0  TheWhisperingInn Interior
    //1  TheWhisperingInn Outside
    //2  AlexHouse Interior
    //3  AlexHouse Outside
    //4  MathewHouse Interior
    //5  MathewHouse Outside
    //6  SamuelsHouse Interior
    //7  SamuelsHouse Outside
    //8  PaulsHouse Interior
    //9  PaulsHouse Outside
    //10 TeresasHouse Interior
    //11 AlexHouse Day

    


    private string[] Scenes = { "TheWhisperingInn", townsSceneString, "AlexHouseScene", townsSceneString, 
        "MathewHouseScene", townsSceneString, "SamuelsHouseScene", townsSceneString, 
        "PaulsHouseScene", townsSceneString, "TeresaHouseScene", townsSceneString,
        "TownScene"};


    private Vector2[] positions = { new Vector2(-9,-20), new Vector2(-12, -12), new Vector2(-6.5f, 6.5f) , new Vector2(-6, 1), 
        new Vector2(14, 7), new Vector2(10, 1), new Vector2(-20, 2), new Vector2(-15, -4), 
        new Vector2(6, -18), new Vector2(-1, -17), new Vector2(21.5f, -14.5f), new Vector2(13, -16),
        new Vector2(-6, 1)};


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
