//using System;
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEditor.Experimental.GraphView;
//using UnityEngine;

//public class CluesThingy : MonoBehaviour
//{
//    public GameObject dialogueBox;
//    private PlayerMovement playerMovement;
//    private bool isActive = false;

//    void Start()
//    {
//        gameObject.SetActive(false);
//        playerMovement = FindObjectOfType<PlayerMovement>();

//    }

//    void Update()
//    {

//        if (Input.GetKeyDown(KeyCode.E))
//        {

//            if (isActive) { return; }
//            isActive = true;

//            gameObject.SetActive(true);

//        }

//    }

//}



using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CluesThingy : MonoBehaviour
{
    public Canvas dialogueCanvas; // Reference to the canvas containing the dialogue box
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
        // Additional logic to handle any other setup for the dialogue box
    }

    void CloseDialogue()
    {
        dialogueCanvas.enabled = false;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CluesThingy : MonoBehaviour
//{
//    public GameObject dialogueBox;
//    public PlayerMovement playerMovementScript; // Reference to the player movement script

//    private bool inRange = false;
//    private bool dialogueActive = false;

//    private void Awake()
//    {
//        dialogueBox.SetActive(false);
//    }

//    private void Update()
//    {
//        if (inRange && Input.GetKeyDown(KeyCode.E) && !dialogueActive)
//        {
//            ToggleDialogue(true);
//        }
//        else if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)) && dialogueActive)
//        {
//            ToggleDialogue(false);
//        }
//    }

//    void ToggleDialogue(bool activeState)
//    {
//        dialogueActive = activeState;
//        dialogueBox.SetActive(activeState);
//        playerMovementScript.enabled = !activeState; // Enable/disable the player movement script
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("MC"))
//        {
//            inRange = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("MC"))
//        {
//            inRange = false;
//        }
//    }
//}







//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CluesThingy : MonoBehaviour
//{
//    public GameObject dialogueBox;

//    private bool inRange = false;


//    private void Awake()
//    {
//        dialogueBox.SetActive(false);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("MC"))
//        {
//            inRange = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("MC"))
//        {
//            inRange = false;
//            HideDialogue();
//        }
//    }

//    void Update()
//    {
//        if (inRange && Input.GetKeyDown(KeyCode.E))
//        {
//            ToggleDialogue();
//        }
//    }

//    void ToggleDialogue()
//    {
//        dialogueBox.SetActive(!dialogueBox.activeSelf);
//    }

//    void HideDialogue()
//    {
//        dialogueBox.SetActive(false);
//    }
//}
