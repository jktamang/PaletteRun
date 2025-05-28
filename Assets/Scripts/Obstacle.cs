using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    bool gameOver = false;
    void Start()
    {
    }

    void GameOver()
    {
        UIManager.instance.ShowGameOverUI();
        Time.timeScale = 0.0f;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.2f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Body") && !gameOver)
        {
            gameOver = true;
            col.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GameOver();
        }
    }
}
