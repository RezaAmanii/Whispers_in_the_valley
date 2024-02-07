using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public GameObject playerGameObject;
    public UnityEvent interactableEvent = new UnityEvent();
    private PlayerInteract playerInteract;
    private Collider2D playerCollider;


    private void Start()
    {
        playerInteract = playerGameObject.GetComponent<PlayerInteract>();
        playerCollider = playerGameObject.GetComponent<Collider2D>();
    }


    private void RunEvent()
    { 
        interactableEvent.Invoke(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == playerCollider)
        {
            playerInteract.AddAction(RunEvent);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerCollider)
        {
            playerInteract.ClearAction(RunEvent);
        }
    }
}
