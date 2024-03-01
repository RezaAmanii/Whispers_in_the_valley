using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockedEvent : MonoBehaviour
{
    public UnityEvent unlockEvent;
    public UnityEvent failedToUnlockEvent;
    public int RequiredId;
    private Inventory playerInventory;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void run()
    {
        if (playerInventory.Contains(RequiredId))
            unlockEvent.Invoke();
        else
            failedToUnlockEvent.Invoke();
    }
}
