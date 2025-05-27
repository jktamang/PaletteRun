using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTimeScale = 1.0f;
    public float maxTimeScale = 2.0f;
    public float timeScaleStep = 0.05f;
    public ScoreManager scoreManager;
    public UIManager uiManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (uiManager.IsRulesActive()) return;
        currentTimeScale = Mathf.Min(1.0f + ((Mathf.Floor(scoreManager.GetScore() / 200.0f) * timeScaleStep)), maxTimeScale);
        Time.timeScale = currentTimeScale;
    }
}
