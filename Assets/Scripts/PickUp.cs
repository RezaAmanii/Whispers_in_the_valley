using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;
    public int id;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        if (GameObject.FindWithTag("GM").GetComponent<GameMaster>().interactedIDs.Contains(id))
        {
            Destroy(gameObject);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    inventory.id[i] = id;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    GameObject.FindWithTag("GM").GetComponent<GameMaster>().interactedPickUps.Add(id);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
