using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager =
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Body"))
        {
            scoreManager.ScoreCoin();
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
