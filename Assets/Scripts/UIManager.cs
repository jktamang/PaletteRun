using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject gameOverUI;
    private GameObject controlsUI;
    private GameObject pauseUI;
    private GameObject retryBtn;
    private GameObject continueBtn;
    private Text audioButtonText;
    private AudioManager audioManager;

    void Start()
    {
        gameOverUI = GameObject.Find("GameOverUI");
        controlsUI = GameObject.Find("ControlsUI");
        pauseUI = GameObject.Find("PauseUI");

        retryBtn = gameOverUI.transform.Find("RetryBtn").gameObject;
        continueBtn = pauseUI.transform.Find("ContinueBtn").gameObject;
        GameObject audioBtn = pauseUI.transform.Find("AudioBtn").gameObject;
        audioButtonText = audioBtn.transform.Find("Text").GetComponent<Text>();

        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        #if !MOBILE_INPUT
            controlsUI.SetActive(false);
        #endif

        audioManager =
            GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        controlsUI.SetActive(false);

        EventSystem.current.SetSelectedGameObject(retryBtn);
    }

    public void ShowPauseUI()
    {
        pauseUI.SetActive(true);
        #if MOBILE_INPUT
            controlsUI.SetActive(false);
        #endif
        EventSystem.current.SetSelectedGameObject(continueBtn);

        audioButtonText.text = audioManager.GetAudioButtonText();
    }

    public void HidePauseUI()
    {
        pauseUI.SetActive(false);
        #if MOBILE_INPUT
            controlsUI.SetActive(true);
        #endif
    }

}
