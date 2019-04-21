using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;
    private GameObject pauseUI;
    private GameObject controlsUI;
    private GameObject continueBtn;
    private AudioSource bgMusic;
    private UIManager uiManager;
    private PlayerMovement movement;

    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        bgMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        movement = GameObject.Find("Body").GetComponent<PlayerMovement>();

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isGamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        uiManager.HidePauseUI();
        Time.timeScale = 1f;
        bgMusic.volume = 1f;
        isGamePaused = false;
        movement.enabled = true;
    }

    void Pause()
    {
        uiManager.ShowPauseUI();
        Time.timeScale = 0f;
        bgMusic.volume = 0.2f;
        isGamePaused = true;
        movement.enabled = false;
    }
}
