using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityStandardAssets.CrossPlatformInput;

public class MainMenuUIManager : SimpleSingleton<MainMenuUIManager>
{
    // Start is called before the first frame update
    [SerializeField] GameObject controlsUI;
    [SerializeField] GameObject controllerUI;
    [SerializeField] GameObject startBtn;
    [SerializeField] VideoPlayer demoVideo;

    float demoTimer = 0.0f;
    float demoTimeout = 30.0f;

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
    }

    public void Quit()
    {
        Application.Quit();
	}

	private void Update()
	{
		if (!demoVideo.isPlaying)
        {
            demoTimer += Time.deltaTime;
            if (demoTimer >= demoTimeout)
            {
                demoVideo.gameObject.SetActive(true);
                demoVideo.Play();
			}
		}
        else
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                demoTimer = 0.0f;
                demoVideo.gameObject.SetActive(false);
                demoVideo.Pause();
			}
		}
	}
}
