using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockedEvent : MonoBehaviour
{
    public UnityEvent Event;
    public GameObject RequiredObject;
    private Inventory playerInventory;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void run()
    {
        if (playerInventory.Contains(RequiredObject))
            Event.Invoke();
    }
}
