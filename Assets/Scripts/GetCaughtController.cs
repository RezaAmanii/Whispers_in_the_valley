using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GetCaughtController : MonoBehaviour
{

    private PlayableDirector director;
    private GameMaster gameMaster;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        director = GetComponent<PlayableDirector>();
        director.stopped += DirectorStopped;
        director.played += DirectorStarted;
        gameMaster = GameObject.FindWithTag("GM").GetComponent<GameMaster>();
    }

    private void DirectorStopped(PlayableDirector obj)
    {
        gameMaster.LoadCheckpoint();
        player.GetComponent<PlayerMovement>().enabled = true;
        director.time = 0;
    }

    private void DirectorStarted(PlayableDirector obj)
    {
        player.GetComponent<PlayerMovement>().StopMoving();
        player.GetComponent<PlayerMovement>().enabled = false;
    }


    public void Run()
    {
        director.Play();
    }
}