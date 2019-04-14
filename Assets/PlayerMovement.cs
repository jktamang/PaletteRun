using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    private bool hasJumped = false;
    private bool isColorToggleCalled = false;
    private const float MarginOfError = 0.03f;

    void Move()
    {
        if (horizontalMove < -MarginOfError)
        {
            controller.Move(-runSpeed * Time.fixedDeltaTime, false, hasJumped);
        }
        else if (horizontalMove > MarginOfError)
        {
            controller.Move(runSpeed * Time.fixedDeltaTime, false, hasJumped);
        }
        else
        {
            controller.Move(0f * Time.fixedDeltaTime, false, hasJumped);
            CrossPlatformInputManager.SetAxisZero("Horizontal");
        }
        hasJumped = false;
    }

    void ToggleColor()
    {
        if (isColorToggleCalled && controller.canToggleColor())
        {
            controller.ToggleColor();
        }
        isColorToggleCalled = false;
    }

    void Update()
    {
        horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        hasJumped = CrossPlatformInputManager.GetButtonDown("Jump");
        isColorToggleCalled = CrossPlatformInputManager.GetButtonDown("ToggleColor");

        Debug.Log(horizontalMove);
        Move();
        ToggleColor();

    }
}
