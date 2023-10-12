using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100.0f;
    public float jumpForce = 5.0f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private float gravity = 9.81f;
    private float verticalSpeed = 0.0f;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        moveDirection = moveInput * forward * moveSpeed;
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);

        if (controller.isGrounded)
        {
            verticalSpeed = 0;

            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = jumpForce;
            }
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        moveDirection.y = verticalSpeed;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Move(Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}