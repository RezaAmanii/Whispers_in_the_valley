using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneHandler))]

public class GameMaster : MonoBehaviour
{
    

    private static GameMaster instance;
    private SceneHandler sceneHandler;
    public Vector2 lastCheckPointPosition;

    public bool isNight = false;

    [DoNotSerialize]
    public HashSet<int> interactedIDs = new HashSet<int>();



    public bool GetHasSpoken()
    {
        return interactedIDs.Count >= 5;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        sceneHandler = GetComponent<SceneHandler>();
    }
    public void LoadCheckpoint()
    {
        sceneHandler.ChangeScene(10);
        
        //player.transform.position = lastCheckPointPosition;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetIsNight(){
        isNight = true;
    }
    public bool GetIsNight(){
        return isNight;
    }
}
