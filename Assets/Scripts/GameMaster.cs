using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneHandler))]

public class GameMaster : MonoBehaviour
{


    private static GameMaster instance;
    private SceneHandler sceneHandler;
    public Vector2 lastCheckPointPosition;

    public bool isNight = false;

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
        sceneHandler.ChangeScene(2);
        
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
