using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
    private GameMaster gameMaster;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //transform.position = gameMaster.lastCheckPointPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = gameMaster.lastCheckPointPosition;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
