using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RulesUI : SimpleSingleton<RulesUI>
{
    [SerializeField] GameObject desktopRules;
    [SerializeField] GameObject mobileRules;
    [SerializeField] Toggle     rulesToggle;
    [SerializeField] GameObject closeRulesBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
	}

    public void HideRules()
    {
        if (!rulesToggle.isOn)
        {
            PlayerPrefs.SetInt("shouldShowRules", 0);
        }

        Time.timeScale = GameManager.instance.currentTimeScale;
        gameObject.SetActive(false);
#if MOBILE_INPUT
        //ControlsUI.instance.SetActive(true);
#endif
    }

    public void ShowRules()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        
        bool isMobile = false;
#if MOBILE_INPUT
        isMobile = true;
        //ControlsUI.instance.gameObject.SetActive(false);
#endif
        desktopRules.SetActive(!isMobile);
        mobileRules.SetActive(isMobile);

        EventSystem.current.SetSelectedGameObject(closeRulesBtn);
    }
}
