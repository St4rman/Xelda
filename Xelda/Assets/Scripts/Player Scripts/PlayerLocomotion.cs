using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    Vector3 moveDirection;
    public Transform cameraObject;
    Rigidbody playerRb;

    public float movementSpeed = 7.0f;
    public float rotationSpeed = 15f;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRb =  GetComponent<Rigidbody>();

        cameraObject = Camera.main.transform;
        //change this later bruh
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right* inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y= 0;

        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRb.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if(targetDirection == Vector3.zeor) targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        transform.rotation = playerRotation;

    }
}
