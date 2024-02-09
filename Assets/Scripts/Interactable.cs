using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))] //collider should be set to onTrigger
public class Interactable : MonoBehaviour
{

    public UnityEvent interactableEvent = new UnityEvent();
    private PlayerInteract playerInteract;
    private Collider2D playerCollider;


    private void Start()
    {
        playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
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
