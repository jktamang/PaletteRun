using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    // float score;
    int initialPositionX;
    GameObject body;
    Text scoreDisplay;
    
    void Start()
    {
        scoreDisplay = GameObject.Find("Score").GetComponent<Text>();
        body = GameObject.Find("Body");
        initialPositionX = (int)body.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = ((int)body.transform.position.x - initialPositionX).ToString();
    }
}
