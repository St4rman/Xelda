using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    Vector3 moveDirection;
    public Transform cameraObject;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    public void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right* inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y= 0;

        Vector3 movementVelocity = moveDirection;
        
    }
}
