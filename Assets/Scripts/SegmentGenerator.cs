using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SegmentGenerator : MonoBehaviour
{
    // [SerializeField] GameObject currentSegment;
    GameObject generationPoint;
    int previousSegment = 0;

    [SerializeField] List<Segment> segments;

    void Start()
    {
        generationPoint = GameObject.Find("SegmentSpawnPoint");
        SpawnSegment(0);
    }

    void SpawnSegment(int r)
    {
        transform.position = new Vector3(transform.position.x + segments[previousSegment].SegmentLength, transform.position.y, transform.position.z);
        Instantiate(segments[r].gameObject, transform.position, transform.rotation);
    }

    void Update()
    {
        if (transform.position.x < generationPoint.transform.position.x)
        {
            //insert weights for segments
            int r = Random.Range(1, segments.Count);
            while (r == previousSegment)
            {
                r = Random.Range(1, segments.Count);
            }
            SpawnSegment(r);
            previousSegment = r;
        }
    }
}
