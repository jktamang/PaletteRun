using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityStandardAssets.CrossPlatformInput;

public class MainMenuUIManager : SimpleSingleton<MainMenuUIManager>
{
    [SerializeField] TextAsset conventionTxt;

    [SerializeField] GameObject controlsUI;
    [SerializeField] GameObject controllerUI;
    [SerializeField] GameObject startBtn;
    [SerializeField] GameObject quitBtn;
    [SerializeField] VideoPlayer demoVideo;

    float demoTimer = 0.0f;
    [SerializeField] float demoTimeout = 30.0f;
    bool conventionMode = false;

    void Start()
    {
#if MOBILE_INPUT
            controlsUI.SetActive(false);
            controllerUI.SetActive(false);
#else
        var controllers = Input.GetJoystickNames();
        bool hasController = controllers.Length > 0;
        controlsUI.SetActive(!hasController);
        controllerUI.SetActive(hasController);
#endif

        EventSystem.current.SetSelectedGameObject(startBtn);

        demoVideo.gameObject.SetActive(false);

        conventionMode = conventionTxt.text.Equals("true");
        Time.timeScale = 1.0f;
#if UNITY_WEBGL
        quitBtn.SetActive(false);
#endif
    }

    public void Quit()
    {
        Application.Quit();
	}

	private void Update()
	{
        if (!conventionMode) return;
        Time.timeScale = 1.0f;
        if (!demoVideo.isPlaying)
        {
            demoTimer += Time.deltaTime;
            if (demoTimer >= demoTimeout)
            {
                demoVideo.gameObject.SetActive(true);
                demoVideo.Play();
                demoTimer = 0.0f;
                EventSystem.current.SetSelectedGameObject(null);
            }
		}
        else
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                demoTimer = 0.0f;
                demoVideo.gameObject.SetActive(false);
                demoVideo.Stop();
                EventSystem.current.SetSelectedGameObject(startBtn);
            }
		}
	}
}
