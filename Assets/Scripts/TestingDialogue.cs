using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct dialoguePiece
{
    public string name;
    public string[] speech;
}

[System.Serializable]
public class TestingDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextComponent;
    public TextMeshProUGUI nameTextComponent;
    public dialoguePiece[] dialogueLines;
    public float textSpeed;
    public AudioClip spacePressSound;
    public AudioSource audioSource; 

    [SerializeField] private int index;
    private int currentID;

    private PlayerMovement playerMovement;
    private bool isActive = false;

    private GameMaster GMscript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        dialogueTextComponent.text = string.Empty;
        nameTextComponent.text = string.Empty;
        playerMovement = FindObjectOfType<PlayerMovement>();
        GMscript = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaySpacePressSound();
            if (dialogueTextComponent.text == dialogueLines[currentID].speech[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                dialogueTextComponent.text = dialogueLines[currentID].speech[index];
            }
        }
    }

    void PlaySpacePressSound()
    {
        if (audioSource != null && spacePressSound != null)
        {
            audioSource.PlayOneShot(spacePressSound);
        }
    }

    public void StartDialogue(int index)
    {
        // Testar att trigga natten med sängen.
        if(index == 7){
            GMscript.SetIsNight();
        }
            
        if (isActive) { return; }
        isActive = true; 

        gameObject.SetActive(true);
        
        if (playerMovement != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().StopMoving();
            playerMovement.enabled = false;

        }
        this.index = 0;
        currentID = index;
        nameTextComponent.text = dialogueLines[currentID].name;
        StartCoroutine(TypeLine());

        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject npc in npcs)
        {
            npc.GetComponent<VillagerAI>().SetIdle();
            npc.GetComponent<Animator>().enabled = false;
            npc.GetComponent<VillagerAI>().enabled = false;
        }


    }

    IEnumerator TypeLine()
    {
        //nameTextComponent.text = nameLines[index]; DETTA FUCKADE PROGRESSION AV DIALOGEN vet ej varf?r 

        foreach (char c in dialogueLines[currentID].speech[index].ToCharArray())
        {
            dialogueTextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    void NextLine()
    {
        if (index < dialogueLines[currentID].speech.Length - 1)
        {
            dialogueTextComponent.text = string.Empty;
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            isActive = false;
            index = 0;
            dialogueTextComponent.text = string.Empty;
            gameObject.SetActive(false);

            if (playerMovement != null)
            {
                playerMovement.enabled = true;

            }

            GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
            foreach (GameObject npc in npcs)
            {
                npc.GetComponent<VillagerAI>().SetMoving();
                npc.GetComponent<Animator>().enabled = true;
                npc.GetComponent<VillagerAI>().enabled = true;
            }

        }
    }
}