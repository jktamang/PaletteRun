using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public ScoreManager scoreManager;
    public UIManager uiManager;
    float runSpeed = 40f;
    public float baseRunSpeed = 40f;
    public float maxRunSpeed = 70f;
    private bool hasJumped = false;
    private bool isColorToggleCalled = false;
    [SerializeField] SpriteRenderer eyes;
    [SerializeField] Sprite deadSprite;
    [SerializeField] Sprite blinkSprite;
    [SerializeField] Sprite eyeSprite;
    private float lastYPos = 0.0f;
    private float lastLastYPos = 0.0f;

    private bool isBlinking = false;
    private float blinkTimer = 0.0f;
    private float blinkTimeout = 3.0f;
    [SerializeField]
    private float blinkTimeoutLow = 3.0f;
    [SerializeField]
    private float blinkTimeoutHigh = 5.0f;
    [SerializeField]
    private float blinkDuration = 0.5f;

	private void Start()
	{
		lastYPos = gameObject.transform.localPosition.y;
		lastLastYPos = gameObject.transform.localPosition.y;

        blinkTimeout = Random.Range(blinkTimeoutLow, blinkTimeoutHigh);
	}

	void Move()
    {
        controller.Move(runSpeed * Time.fixedDeltaTime, false, hasJumped);
        eyes.gameObject.transform.localPosition = new Vector3(0.0f, lastLastYPos - gameObject.transform.localPosition.y, 0.0f);
        lastLastYPos = lastYPos;
        lastYPos = gameObject.transform.localPosition.y;
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
        isColorToggleCalled = CrossPlatformInputManager.GetButtonDown("ToggleColor");

        Move();
        ToggleColor();
        Blink();
    }

    bool CanMove()
    {
        return !uiManager.IsRulesActive() && !uiManager.IsGameOverActive() && !uiManager.IsPauseActive();
	}

    public void GameOver()
    {
        eyes.sprite = deadSprite;
	}

    void Blink()
    {
        blinkTimer += Time.deltaTime;
        if (isBlinking)
        {
            if (blinkTimer >= blinkDuration)
            {
                eyes.sprite = eyeSprite;
                blinkTimer = 0.0f;
                isBlinking = false;
                blinkTimeout = Random.Range(blinkTimeoutLow, blinkTimeoutHigh);
            }
		}
        else
        {
            if (blinkTimer >= blinkTimeout)
            {
                eyes.sprite = blinkSprite;
                blinkTimer = 0.0f;
                isBlinking = true;
			}
		}
	}
}
