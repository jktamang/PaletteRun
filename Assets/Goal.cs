using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Body"))
        {
        	SceneFader sf = GetComponent<SceneFader>();
        	sf.FadeOut(1.0f);
            // Time.timeScale = 0.0f;
            GameObject body = GameObject.Find("Body");
        	body.GetComponent<PlayerMovement>().enabled = false;
        	body.GetComponent<CharacterController2D>().enabled = false;
            body.GetComponent<Rigidbody2D>().isKinematic = true;
            body.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameObject.Find("Main Camera").GetComponent<CameraController>().SetInactive();
        }
    }
}
