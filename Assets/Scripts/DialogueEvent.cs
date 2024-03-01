using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    private TestingDialogue dialogueManager;

    void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<TestingDialogue>(true);
    }


    public void run(int index)
    {
        dialogueManager.StartDialogue(index);
    }
}
