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
    public bool isRepeatable = true; // Flag to indicate if interaction can be repeated
    private PlayerInteract playerInteract;
    private Collider2D playerCollider;
    private bool hasInteracted = false; // Flag to track if interaction has occurred

    private void Start()
    {
        playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    private void RunEvent()
    {
        interactableEvent.Invoke();
        if (!isRepeatable)
        {
            // Disable further interaction if it's not repeatable
            hasInteracted = true;
            playerInteract.ClearAction(RunEvent);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == playerCollider && !hasInteracted)
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
