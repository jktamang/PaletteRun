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
    private GameObject rulesUI;
    private GameObject retryBtn;
    private GameObject continueBtn;
    private GameObject closeRulesBtn;
    private GameObject mobileRules;
    private GameObject desktopRules;
    private GameObject rulesToggle;
    private Text audioButtonText;
    private AudioManager audioManager;
    private bool shouldShowRules;

    void Start()
    {
        gameOverUI = GameObject.Find("GameOverUI");
        controlsUI = GameObject.Find("ControlsUI");
        pauseUI = GameObject.Find("PauseUI");
        rulesUI = GameObject.Find("RulesUI");

        retryBtn = gameOverUI.transform.Find("RetryBtn").gameObject;
        continueBtn = pauseUI.transform.Find("ContinueBtn").gameObject;
        GameObject audioBtn = pauseUI.transform.Find("AudioBtn").gameObject;
        audioButtonText = audioBtn.transform.Find("Text").GetComponent<Text>();

        closeRulesBtn = rulesUI.transform.Find("CloseRulesBtn").gameObject;
        mobileRules = rulesUI.transform.Find("MobileRules").gameObject;
        desktopRules = rulesUI.transform.Find("DesktopRules").gameObject;
        rulesToggle = rulesUI.transform.Find("Toggle").gameObject;

        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);

        #if MOBILE_INPUT
            desktopRules.SetActive(false);
        #else
            mobileRules.SetActive(false);
            controlsUI.SetActive(false);
        #endif
        
        rulesUI.SetActive(false);

        shouldShowRules = PlayerPrefs.GetInt("shouldShowRules", 1) != 0;

        if (shouldShowRules)
            ShowRulesUI();

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

    public void ShowRulesUI()
    {
        Time.timeScale = 0f;
        rulesUI.SetActive(true);
        #if MOBILE_INPUT
            controlsUI.SetActive(false);
        #endif
        EventSystem.current.SetSelectedGameObject(closeRulesBtn);
    }

    public void HideRulesUI()
    {
        if (!rulesToggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("shouldShowRules", 0);
        }

        Time.timeScale = 1f;
        rulesUI.SetActive(false);
        #if MOBILE_INPUT
            controlsUI.SetActive(true);
        #endif
    }

    public bool IsRulesActive()
    {
        return rulesUI.activeInHierarchy;
	}

    public bool IsPauseActive()
    {
        return pauseUI.activeInHierarchy;
	}

    public bool IsGameOverActive()
    {
        return gameOverUI.activeInHierarchy;
	}
}
