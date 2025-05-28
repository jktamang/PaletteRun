using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class GameManager : SimpleSingleton<GameManager>
{
    public float currentTimeScale = 1.0f;
    public float timeScaleStep = 0.05f;

    [SerializeField]
    public int[] scoreThreshold = {200, 300, 500, 1000, 1500, 2000, 2500, 3000, 3500, 4000};
    int currentThreshold = 0;

    void Start()
    {
        currentThreshold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.instance.IsRulesActive()) return;
        if (UIManager.instance.IsPauseActive()) return;

        currentTimeScale = 1.0f + (GetScaleMultiplier() * timeScaleStep);
        Time.timeScale = currentTimeScale;
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            PauseMenu.instance.TogglePause();
        }
    }

    int GetScaleMultiplier()
    {
        if (currentThreshold >= scoreThreshold.Length) return 10;
        if (ScoreManager.instance.GetScore() > scoreThreshold[currentThreshold])
        {
            currentThreshold++;
            SpeedUpUI.instance.Trigger();
        }
        return currentThreshold;
    }
}
