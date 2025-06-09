using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GameOverUI : SimpleSingleton<GameOverUI>
{
    [SerializeField] GameObject retryBtn;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject newHighScore;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(bool show = true)
    {
        gameObject.SetActive(show);
        if (show)
        {
            EventSystem.current.SetSelectedGameObject(retryBtn);
            score.text = ScoreManager.instance.GetScore().ToString();
            newHighScore.gameObject.SetActive(ScoreManager.instance.GotNewHighScore());
        }
    }
}
