using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score;
    int currentHighScore;
    int initialPositionX;
    GameObject body;
    Text scoreDisplay;
    Text highScoreDisplay;
    
    void Start()
    {
        currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreDisplay = GameObject.Find("Score").GetComponent<Text>();
        highScoreDisplay = GameObject.Find("HighScore").GetComponent<Text>();
        body = GameObject.Find("Body");
        initialPositionX = (int)body.transform.position.x;
    }

    void Update()
    {
        score = (int)body.transform.position.x - initialPositionX;
        scoreDisplay.text = score.ToString();
        StoreHighScore();
        highScoreDisplay.text = currentHighScore.ToString();

    }

    public void StoreHighScore()
    {
        if (IsHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
            currentHighScore = score;
        }
    }

    public bool IsHighScore()
    {
        return score > currentHighScore;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
