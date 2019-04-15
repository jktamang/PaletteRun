using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameOverUI;
    private GameObject controlsUI;
    private GameObject pauseUI;

    void Start()
    {
        gameOverUI = GameObject.Find("GameOverUI");
        controlsUI = GameObject.Find("ControlsUI");

        gameOverUI.SetActive(false);
    }

    public void showGameOverUI()
    {
        gameOverUI.SetActive(true);
        controlsUI.SetActive(false);
    }

    //void showPauseUI()

}
