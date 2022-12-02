using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float runSpeed = 2.0f;
    [SerializeField] private float turnSpeed = 2.0f;
    private Vector3 runVelocity;
    private Vector3 turnVelocity;
    private float horizontalInput;
    private float verticalInput;
    private float tempValue;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        runVelocity = Vector3.zero;

        runVelocity = transform.forward * runSpeed * verticalInput;
        turnVelocity = transform.up * turnSpeed * horizontalInput;
        runVelocity.y = 0;

        if(runVelocity == Vector3.zero)
            tempValue = Mathf.Lerp(tempValue, 0, Time.deltaTime * 5f);
        else
            tempValue = Mathf.Lerp(tempValue, 1, Time.deltaTime * 5f);

        playerAnimator.SetFloat("playerAnim", tempValue);
        controller.Move(runVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }
}
