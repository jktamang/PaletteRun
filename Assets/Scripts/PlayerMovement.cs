using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public ScoreManager scoreManager;
    public UIManager uiManager;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float baseRunSpeed = 40f;
    private bool hasJumped = false;
    private bool isColorToggleCalled = false;
    private const float MarginOfError = 0.03f;

    void Move()
    {   
        runSpeed = baseRunSpeed + Mathf.Min(Mathf.Floor(scoreManager.GetScore() / 200.0f), 20.0f);
        controller.Move(runSpeed * Time.fixedDeltaTime, false, hasJumped);
        hasJumped = false;
    }

    void ToggleColor()
    {
        if (isColorToggleCalled && controller.canToggleColor())
        {
            controller.ToggleColor();
        }
        else if (isColorToggleCalled)
        {
            controller.QueueToggleColor();
        }
        isColorToggleCalled = false;
    }

    void Update()
    {
        if (!CanMove()) return;
        //Project Settings > Input Manager
        hasJumped = CrossPlatformInputManager.GetButtonDown("Jump");
        isColorToggleCalled = CrossPlatformInputManager.GetButtonDown("ToggleColor") || CrossPlatformInputManager.GetButtonDown("ToggleColor2");

        Move();
        ToggleColor();
    }

    bool CanMove()
    {
        return !uiManager.IsRulesActive() && !uiManager.IsGameOverActive() && !uiManager.IsPauseActive();
	}
}
