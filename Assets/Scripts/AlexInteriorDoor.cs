using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexInteriorDoor : MonoBehaviour
{
    private GameMaster gameMaster;
    private SceneHandler sceneHandler;

    void Start()
    {
        gameMaster = GameObject.FindWithTag("GM").GetComponent<GameMaster>();
        sceneHandler = GameObject.FindWithTag("GM").GetComponent<SceneHandler>();
    }

    public void Open()
    {
        if (gameMaster.isNight) 
        {
            sceneHandler.ChangeScene(3);
        }
        else 
        {
            sceneHandler.ChangeScene(11);
        }
    }
}
