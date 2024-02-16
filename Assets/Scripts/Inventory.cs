using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public int[] id;
    public GameObject[] slots;

    public bool Contains(int id)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (this.id[i] == id) 
                return true;
        }

        return false;
    }
}
