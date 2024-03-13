using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetCaught : MonoBehaviour
{
    // Start is called before the first frame update

    private Action action;

    private void Awake()
    {
        action = GameObject.Find("CaughtTimeline").GetComponent<GetCaughtController>().Run;
    }

    public void Run()
    {
        action.Invoke();
    }
}