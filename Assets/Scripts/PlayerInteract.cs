using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering;

public class PlayerInteract : MonoBehaviour
{
    public UnityEvent interactPressedEvent = new UnityEvent();
    //private bool isInteracting = false; // Track interaction state

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddAction(UnityAction action)
    {
        interactPressedEvent.AddListener(action);
    }

    public void ClearAction(UnityAction action)
    {
        interactPressedEvent.RemoveListener(action);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player has interacted! Yippieeeee");
            interactPressedEvent.Invoke();

            
        }
    }

    // Call this method when the interaction is finished
    //public void FinishInteraction()
    //{
    //    isInteracting = false; // Reset interaction state
    //}
}
//public void StartInteraction()
//{
//    isInteracting = true;
//    // You may want to add additional logic here, such as disabling player movement
//}

//// Method to call when the player finishes interacting
//public void FinishInteraction()
//{
//    isInteracting = false;
//    // You may want to add additional logic here, such as re-enabling player movement
//}



