using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public GameObject MC;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string sceneName, float x, float y)
    {
        SceneManager.LoadScene(sceneName);
        MC.transform.position = new Vector3(x, y, 0);
    }
}
