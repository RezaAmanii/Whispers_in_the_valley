using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public bool Contains(GameObject gameObject)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].gameObject == gameObject) 
                return true;
        }

        return false;
    }
}
