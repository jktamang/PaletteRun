using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SegmentGenerator : MonoBehaviour
{
    // [SerializeField] GameObject currentSegment;
    GameObject generationPoint;
    float distanceBetween;

    [SerializeField] GameObject[] segments;

    float segmentWidth = 18.0f;

    void Start()
    {
        generationPoint = GameObject.Find("SegmentSpawnPoint");
        SpawnSegment(0);
    }

    void SpawnSegment(int r)
    {
        transform.position = new Vector3(transform.position.x + segmentWidth, transform.position.y, transform.position.z);
        Instantiate(segments[r], transform.position, transform.rotation);
    }

    void Update()
    {
        if (transform.position.x < generationPoint.transform.position.x)
        {
            //insert weights for segments
            int r = Random.Range(1, segments.Length);
            SpawnSegment(r);
        }
    }
}
