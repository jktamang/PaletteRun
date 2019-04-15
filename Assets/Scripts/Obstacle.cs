using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    UIManager uiManager;
    bool gameOver = false;
    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.2f);
        uiManager.showGameOverUI();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Body") && !gameOver)
        {
            gameOver = true;
            GameObject body = GameObject.Find("Body");
            body.GetComponent<PlayerMovement>().enabled = false;
            body.GetComponent<CharacterController2D>().enabled = false;
            body.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GameObject.Find("Main Camera").GetComponent<CameraController>().SetInactive();
            StartCoroutine(GameOver());
        }
    }
}
