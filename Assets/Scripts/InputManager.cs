using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Make a singelton easy to call
    public static InputManager instance;

    public bool MenuOpenCloseInput { get; private set; }

    private PlayerInput playerInput;

    private InputAction menuOpenCloseAction;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        playerInput = GetComponent<PlayerInput>();
        menuOpenCloseAction = playerInput.actions["MenuOpenClose"];
        
    }

   
    void Update()
    {
        MenuOpenCloseInput = menuOpenCloseAction.WasPressedThisFrame();
        
    }
}
