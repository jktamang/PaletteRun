using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentProperties : MonoBehaviour
{
    // Start is called before the first frame update

    enum Type {
        Open,
        Top,
        Bottom,
        Split
    };

    [SerializeField] int SegmentLength;
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
