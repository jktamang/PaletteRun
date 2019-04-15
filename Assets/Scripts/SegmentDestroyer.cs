using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentDestroyer : MonoBehaviour
{
    GameObject destroyPoint;

    // Start is called before the first frame update
    void Start()
    {
        destroyPoint = GameObject.Find("SegmentDestroyPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
