using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockedEvent : MonoBehaviour
{
    public UnityEvent unlockEvent;
    public UnityEvent failedToUnlockEvent;
    public int RequiredId;
    public int RequiredSpokenTo;
    private Inventory playerInventory;
    private GameMaster gameMaster;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        gameMaster = GameObject.FindWithTag("GM").GetComponent <GameMaster>();
    }

    public void run()
    {
        if (playerInventory.Contains(RequiredId) && gameMaster.GetHasSpoken(RequiredSpokenTo))
            unlockEvent.Invoke();
        else{
            failedToUnlockEvent.Invoke();
            Debug.Log(" test");
        }
    }
}
