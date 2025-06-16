using UnityEngine;
using TMPro;

public class ScoreManager : SimpleSingleton<ScoreManager>
{
    int score;
    int coinScore = 0;
    int currentHighScore;
    int initialPositionX;
    int previousHighScore;
    [SerializeField] GameObject body;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] TextMeshProUGUI highScoreDisplay;
    
    void Start()
    {
        currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        initialPositionX = (int)body.transform.position.x;
        previousHighScore = currentHighScore;
    }

    void Update()
    {
        score = ((int)body.transform.position.x - initialPositionX) + coinScore;
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

    public void ScoreCoin()
    {
        coinScore += 20;
    }

    public bool GotNewHighScore()
    {
        return score > previousHighScore;
	}

    public void SetHighScore(int i)
    {
        PlayerPrefs.GetInt("HighScore", i);
        currentHighScore = i;
    }
}
