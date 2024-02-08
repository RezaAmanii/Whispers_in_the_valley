using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestingDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextComponent;
    public TextMeshProUGUI nameTextComponent;
    public string[] dialogueLines;
    public string[] nameLines;
    public float textSpeed;

    private int index;
    

    // Start is called before the first frame update
    void Start()
    {
        dialogueTextComponent.text = string.Empty;
        nameTextComponent.text = nameLines[index];
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueTextComponent.text == dialogueLines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                dialogueTextComponent.text = dialogueLines[index];
                nameTextComponent.text = nameLines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //nameTextComponent.text = nameLines[index]; DETTA FUCKADE PROGRESSION AV DIALOGEN vet ej varför 

        foreach (char c in dialogueLines[index].ToCharArray())
        {
            dialogueTextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueTextComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
