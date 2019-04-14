using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockBehavior : MonoBehaviour
{
    public Rigidbody2D block;
    bool isGrounded = false;

    void Start()
    {
        block = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Body") && !isGrounded)
        {
            SceneFader sf = GetComponent<SceneFader>();
            sf.FadeOut(1.0f);
            GameObject body = GameObject.Find("Body");
            body.GetComponent<PlayerMovement>().enabled = false;
            body.GetComponent<CharacterController2D>().enabled = false;
            body.GetComponent<Rigidbody2D>().isKinematic = true;
            body.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameObject.Find("Main Camera").GetComponent<CameraController>().SetInactive();
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else if (col.gameObject.name.Equals("Tilemap"))
        {
            block.bodyType = RigidbodyType2D.Static;
            isGrounded = true;
        }
    }
}
