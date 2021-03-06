using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            //look up what this does man idk
            //pretty much a lambda function storing the readvalue in movement input and then adding it to the player controls 
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }


    public void HandleAllInput()
    {
        HandleMovementInput();
        //handleJump
        //HandleAction
    }
    private void HandleMovementInput()
    {
        verticalInput  = movementInput.y;
        horizontalInput = movementInput.x;
    }
}
