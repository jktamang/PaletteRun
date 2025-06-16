using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : SimpleSingleton<UIManager>
{
    [SerializeField] GameObject controlsUI;
    [SerializeField] GameObject continueBtn;
    [SerializeField] GameObject closeRulesBtn;
    [SerializeField] AudioManager audioManager;

    public GenericPrompt genericPrompt;

    private bool shouldShowRules;

    void Start()
    {
        PauseMenu.instance.gameObject.SetActive(false);
        SpeedUpUI.instance.gameObject.SetActive(false);
        GameOverUI.instance.Show(false);


        #if !MOBILE_INPUT
            controlsUI.SetActive(false);
        #endif
        
        RulesUI.instance.gameObject.SetActive(false);

        //shouldShowRules = PlayerPrefs.GetInt("shouldShowRules", 1) != 0;

        //if (shouldShowRules)
            RulesUI.instance.ShowRules();
    }

    public void ShowGameOverUI()
    {
        GameOverUI.instance.Show();
        controlsUI.SetActive(false);
    }

    public void ShowPauseUI()
    {
        PauseMenu.instance.gameObject.SetActive(true);
        #if MOBILE_INPUT
            controlsUI.SetActive(false);
        #endif
        EventSystem.current.SetSelectedGameObject(continueBtn);
    }

    public void HidePauseUI()
    {
        PauseMenu.instance.gameObject.SetActive(false);
        #if MOBILE_INPUT
            controlsUI.SetActive(true);
        #endif
    }

    public bool IsRulesActive()
    {
        return RulesUI.instance.gameObject.activeInHierarchy;
	}

    public bool IsPauseActive()
    {
        return PauseMenu.instance.gameObject.activeInHierarchy;
	}

    public bool IsGameOverActive()
    {
        return GameOverUI.instance.gameObject.activeInHierarchy;
	}
}
