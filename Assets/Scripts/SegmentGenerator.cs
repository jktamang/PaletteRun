using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SegmentGenerator : SimpleSingleton<SegmentGenerator>
{
    // [SerializeField] GameObject currentSegment;
    GameObject generationPoint;
    int previousSegment = 0;

    [SerializeField] List<Segment> segments;
    [SerializeField] Segment buffer;

    void Start()
    {
        generationPoint = GameObject.Find("SegmentSpawnPoint");
        SpawnSegment(0);
    }

    void SpawnSegment(int r)
    {
        transform.position = new Vector3(transform.position.x + segments[previousSegment].SegmentLength + buffer.SegmentLength, transform.position.y, transform.position.z);
        Instantiate(segments[r].gameObject, transform.position, transform.rotation);
        Instantiate(buffer, new Vector3(transform.position.x + segments[r].SegmentLength , transform.position.y, transform.position.z), transform.rotation);
    }

    void Update()
    {
        if (transform.position.x < generationPoint.transform.position.x)
        {
            //insert weights for segments
            int r = Random.Range(1, segments.Count);
            while (r == previousSegment || segments[r].difficulty > GameManager.instance.currentThreshold)
            {
                r = Random.Range(1, segments.Count);
            }
            SpawnSegment(r);
            previousSegment = r;
        }
    }
}
