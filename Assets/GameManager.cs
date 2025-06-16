using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class GameManager : SimpleSingleton<GameManager>
{
    public float currentTimeScale = 1.0f;
    public float timeScaleStep = 0.05f;
    [SerializeField] FPSManager fpsManager;

    [SerializeField] TextAsset conventionTxt;

    [SerializeField]
    public int[] scoreThreshold = {200, 300, 500, 1000, 1500, 2000, 2500, 3000, 3500, 4000};
    
    public int currentThreshold = 0;
    public bool conventionMode = false;

    void Start()
    {
        currentThreshold = 0;
#if MOBILE_INPUT
        fpsManager.gameObject.SetActive(true);
#else
        fpsManager.gameObject.SetActive(false);
#endif
        conventionMode = conventionTxt.text.Equals("true");
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.instance.IsRulesActive()) return;
        if (UIManager.instance.IsGameOverActive()) return;
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            PauseMenu.instance.TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            PauseMenu.instance.TogglePause();
        }

        if (UIManager.instance.IsPauseActive()) return;

        if (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
            UIManager.instance.genericPrompt.Show("Set High Score:", (string str) =>
            {
                int value = 0;
                if (!int.TryParse(str, out value)) value = 0;
                ScoreManager.instance.SetHighScore(value);
            });

        UpdateTimeScale();
    }

    void UpdateTimeScale()
    {
        if (currentThreshold >= scoreThreshold.Length) return;
        if (ScoreManager.instance.GetScore() > scoreThreshold[currentThreshold])
        {
            currentThreshold++;
            SpeedUpUI.instance.Trigger();
            currentTimeScale = 1.0f + (currentThreshold * timeScaleStep);
            Time.timeScale = currentTimeScale;
        }
    }
}
