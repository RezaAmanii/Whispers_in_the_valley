using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour

{
    // Inventory list
    public GameObject[] inventory = new GameObject[10];


    // Adding items to the the inventory list
    public void addItem(GameObject item)
    {
        bool itemAdded = false;

        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item + " was added to the inventory!");
                itemAdded = true;
                break;
            }
        }

        if (!itemAdded)
        {
            Debug.Log("Inventory full");
        }
    }



    // Removing item fom the inventory list
    public void removeItem(GameObject item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == item)
            {
                inventory[i] = null;
                Debug.Log(item + " was removed from the inventory!");
                break;
            }
        }
    }




}
