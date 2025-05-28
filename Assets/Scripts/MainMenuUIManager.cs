using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuUIManager : SimpleSingleton<MainMenuUIManager>
{
    // Start is called before the first frame update
    [SerializeField] GameObject controlsUI;
    [SerializeField] GameObject startBtn;
    void Start()
    {
#if MOBILE_INPUT
            controlsUI.SetActive(false);
#endif
        EventSystem.current.SetSelectedGameObject(startBtn);
    }

    public void Quit()
    {
        Application.Quit();
	}
}
