using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTimeScale = 1.0f;
    public float timeScaleStep = 0.05f;
    public ScoreManager scoreManager;
    public UIManager uiManager;

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
        if (uiManager.IsRulesActive()) return;
        if (uiManager.IsPauseActive()) return;

        currentTimeScale = 1.0f + (GetScaleMultiplier() * timeScaleStep);
        Time.timeScale = currentTimeScale;
    }

    int GetScaleMultiplier()
    {
        if (currentThreshold >= scoreThreshold.Length) return 10;
        if (scoreManager.GetScore() > scoreThreshold[currentThreshold])
        {
            currentThreshold++;
            uiManager.speedUpUI.Trigger();
            Debug.Log("Current Score: " + scoreManager.GetScore() + ". Current Treshold is " + currentThreshold);
        }
        return currentThreshold;
    }
}
