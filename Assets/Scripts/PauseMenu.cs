using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour
{
    bool isGamePaused = false;
    GameObject pauseUI;
    GameObject controlsUI;
    AudioSource bgMusic;

    void Start()
    {
        pauseUI = GameObject.Find("PauseUI");
        pauseUI.SetActive(false);
        controlsUI = GameObject.Find("ControlsUI");

        bgMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();

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
        pauseUI.SetActive(false);
        controlsUI.SetActive(true);
        Time.timeScale = 1f;
        bgMusic.volume = 1f;
        isGamePaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        controlsUI.SetActive(false);
        Time.timeScale = 0f;
        bgMusic.volume = 0.3f;
        isGamePaused = true;
    }
}
