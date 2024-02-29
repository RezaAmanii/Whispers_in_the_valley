using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneHandler : MonoBehaviour
{

    private GameObject MC;
    private GameMaster GMscript;
    static string townsSceneString = "TownScene";

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

    


    private string[] Scenes = { 
        "TheWhisperingInn", // WhisperingInn(0)
        townsSceneString,        // Town @ WhisperingInn(1)
        townsSceneString,        // Town @ Alex(2)
        townsSceneString,        // Town @ Paul(3)
        townsSceneString,        // Town @ Nadine(4)
        townsSceneString,        // Town @ Mathew(5)
        townsSceneString,        // Town @ Julia(6)?
        townsSceneString,        // Town @ Church(7)
        townsSceneString,        // Town @ Teresa(8)
        "ChurchScene",      // Church(9)
        "AlexsHouseScene",  // AlexsHouse(10)
        "JuliasHouseScene", // JuliasHouse(11)
        "MathewsHouseScene", // MathewsHouse(12)
        "PaulsHouseScene", // PaulsHouse(13)
        "NadinesHouseScene", // NadinesHouse(14)
        "TeresasHouseScene" // TeresasHouse(15)
        }; 
       
    private Vector2[] positions = { 
        new Vector2(10, 0.6f),    // WhisperingInn(0) OK
        new Vector2(-12, -12),  // Town @ WhisperingInn(1) OK
        new Vector2(-6, 1),     // Town @ Alex(2) OK
        new Vector2(-1, -17),   // Town @ Paul(3) OK
        new Vector2(-15, -4),   // Town @ Nadine(4) OK
        new Vector2(13, -16),   // Town @ Mathew(5) OK
        new Vector2(10, 1),     // Town @ Julia(6) OK
        new Vector2(24, -6),    // Town @ Church(7)
        new Vector2(0, -4),     // Town @ Teresa(8)
        new Vector2(7.3f, 8.5f),      // Church (9)
        new Vector2(5.5f, 0.5f),      // AlexsHouse(10) OK
        new Vector2(5.5f, 0.5f),      // JuliasHouse(11) 
        new Vector2(5.5f, 0.5f),      // MathewsHouse(12)
        new Vector2(5.5f, 0.5f),      // PaulsHouse(13)
        new Vector2(2.5f, 0.5f),      // NadinesHouse(14)
        new Vector2(2.5f, 0.5f)       // TeresasHouse(15)

        
         };


    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.FindGameObjectWithTag("Player");
        GMscript = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    public void ChangeScene(int SceneIndex)
    {
        // If isNight is false, update the value from GMscript to make sure it is correct.
    
            if(GMscript.GetIsNight() && Scenes[SceneIndex] == "TownScene"){

                SceneManager.LoadScene("NightTown");
                MC.transform.position = positions[SceneIndex];
            }else{

                SceneManager.LoadScene(Scenes[SceneIndex]);
                MC.transform.position = positions[SceneIndex];
            }

        
    }

    
}
