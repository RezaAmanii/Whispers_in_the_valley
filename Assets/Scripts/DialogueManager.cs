using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public void SetDialogue(string speakerName, string dialogue)
    {
        nameText.text = speakerName;
        dialogueText.text = dialogue;
    }
}
