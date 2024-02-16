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
    //public string [][] nameLines;
    public float textSpeed;

    [SerializeField] private int index;
    private int currentID;

    private PlayerMovement playerMovement;
    private bool isActive = false;
    private VillagerAI npcMovement;
    private Animator npcAnimation;

    public PlayerInteract playerInteract; //new stuff here

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        dialogueTextComponent.text = string.Empty;
        nameTextComponent.text = string.Empty;
        playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement component not found!");
        }
        npcMovement = GetComponent<VillagerAI>();
        if (npcMovement == null)
        {
            Debug.LogError("NPCMovement component not found!");
        }
        //StartDialogue(0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueTextComponent.text == dialogueLines[currentID].speech[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                dialogueTextComponent.text = dialogueLines[currentID].speech[index];
                //nameTextComponent.text = dialogueLines[currentID].name;
            }
        }
    }

    public void StartDialogue(int index)
    {
        if (isActive) { return; }
        isActive = true; 

        gameObject.SetActive(true);
        //this.GetComponent<PlayerMovement>().enabled = false;
        
        if (playerMovement != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().StopMoving();
            playerMovement.enabled = false;

        }
        this.index = 0;
        currentID = index;
        nameTextComponent.text = dialogueLines[currentID].name;
        StartCoroutine(TypeLine());
        // NEW STUFF HERE

        //if (npcMovement != null)
        //{
        //    npcMovement.canMove = false;
        //}
        //GameObject.Find("NPC(Teresa)").GetComponent<VillagerAI>().enabled = false;
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject npc in npcs)
        {
            npc.GetComponent<VillagerAI>().SetIdle();
            npc.GetComponent<Animator>().enabled = false;
        }


    }

    IEnumerator TypeLine()
    {
        //nameTextComponent.text = nameLines[index]; DETTA FUCKADE PROGRESSION AV DIALOGEN vet ej varför 

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
            //playerInteract.FinishInteraction(); //stuff here

            //this.GetComponent<PlayerMovement>().enabled = true; 
            if (playerMovement != null)
            {
                playerMovement.enabled = true;

            }
            //if (npcMovement != null)
            //{
            //    npcMovement.canMove = true;
            //}
            //GameObject.Find("NPC(Teresa)").GetComponent<VillagerAI>().enabled = true;
            GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
            foreach (GameObject npc in npcs)
            {
                npc.GetComponent<VillagerAI>().SetMoving();
                npc.GetComponent<Animator>().enabled = true;
            }

        }
    }
}