using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    private GameObject player;
    public Vector2 lastCheckPointPosition;

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

        player = GameObject.FindWithTag("Player");
    }
    public void LoadCheckpoint()
    {
        player.transform.position = lastCheckPointPosition;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
