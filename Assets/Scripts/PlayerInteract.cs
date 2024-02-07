using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering;

public class PlayerInteract : MonoBehaviour
{
    public UnityEvent interactEvent = new UnityEvent();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddAction(UnityAction action)
    {
        interactEvent.AddListener(action);
    }

    public void ClearAction(UnityAction action)
    {
        interactEvent.RemoveListener(action);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactEvent.Invoke();
        }
    }
}
