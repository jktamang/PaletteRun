using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    public Rigidbody2D block;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Body") && block.isKinematic)
        {
            block.isKinematic = false;
        }
    }
}
