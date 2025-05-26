using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    // Start is called before the first frame update

    enum Type {
        Open,
        Top,
        Bottom,
        Split
    };

    [SerializeField] public int SegmentLength = 18;
    [SerializeField] Type StartType;
    [SerializeField] Type EndType;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
