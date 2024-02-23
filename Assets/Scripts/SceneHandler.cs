using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private GameObject MC;


    private string[] Scenes = { 
        "TheWhisperingInn", // WhisperingInn(0)
        "TownScene",        // Town @ WhisperingInn(1)
        "Townscene",        // Town @ Alex(2)
        "TownScene",        // Town @ Paul(3)
        "TownScene",        // Town @ Nadine(4)
        "TownScene",        // Town @ Mathew(5)
        "Townscene",        // Town @ Alex(6)?
        "TownScene",        // Town @ Julia(7)
        "TownScene",        // Town @ Church(8)
        "ChurchScene",      // Church(9)
        "AlexsHouseScene",  // AlexsHouse(10)
        "JuliasHouseScene", // JuliasHouse(11)
        "MathewsHouseScene", // MathewsHouse(12)
        "PaulsHouseScene", // PaulsHouse(13)
        "NadinesHouseScene" // NadinesHouse(14)
        }; 
       
    private Vector2[] positions = { 
        new Vector2(-0,20),    // WhisperingInn(0)
        new Vector2(-12, -12),  // Town @ WhisperingInn(1)
        new Vector2(-6, 1),     // Town @ Alex(2)
        new Vector2(-1, -17),   // Town @ Paul(3)
        new Vector2(-15, -4),   // Town @ Nadine(4)
        new Vector2(13, -16),   // Town @ Mathew(5)
        new Vector2(10, 1),     // Town @ Alex(6)?
        new Vector2(24, -6),    // Town @ Julia(7)
        new Vector2(0, -4),     // Town @ Church(8)
        new Vector2(0, 0),
        new Vector2(6, 1)       //AlexsHouse(10)
        
         };


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
