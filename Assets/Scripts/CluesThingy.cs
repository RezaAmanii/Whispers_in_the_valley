// !!!! THIS IS THE ONE THAT WORKS DO NOT DELETE I AM BEGGING YOU !!!!

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CluesThingy : MonoBehaviour
{
    public Canvas dialogueCanvas; // Reference to the canvas containing the dialogue box
    public PlayerMovement playerMovementScript;
    private bool isInRange = false; // Flag to track if the player is in range

    void Start()
    {
        // Disable the dialogue canvas at the start of the game
        dialogueCanvas.enabled = false;
    }

    void Update()
    {
        // Check if either the "E" key or the "Space" key is pressed and the player is in range
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)) && isInRange)
        {
            if (dialogueCanvas.enabled)
                CloseDialogue();
            else
                OpenDialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            CloseDialogue();
        }
    }

    void OpenDialogue()
    {
        dialogueCanvas.enabled = true;
        playerMovementScript.enabled = false;
        // Additional logic to handle any other setup for the dialogue box
    }

    void CloseDialogue()
    {
        dialogueCanvas.enabled = false;
        playerMovementScript.enabled = true;
    }
}
