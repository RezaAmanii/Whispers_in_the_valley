using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class WaitForTimeline : MonoBehaviour
{

    private PlayableDirector director;

    public string nextScene;

    // Start is called before the first frame update
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.stopped += DirectorStopped;
        director.played += DirectorStarted;
    }

    private void DirectorStopped(PlayableDirector obj)
    {
        SceneManager.LoadScene(nextScene);
    }

    private void DirectorStarted(PlayableDirector obj)
    {

    }
}
