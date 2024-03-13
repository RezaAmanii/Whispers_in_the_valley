using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public int id;

    private void Start()
    {
        if (GameObject.FindWithTag("GM").GetComponent<GameMaster>().interactedIDs.Contains(id))
            Run();
    }

    public void Run()
    {
        GameObject.FindWithTag("GM").GetComponent<GameMaster>().interactedIDs.Add(id);
        Destroy(gameObject);
    }
}
