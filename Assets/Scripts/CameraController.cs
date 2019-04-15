using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	private Vector3 offset;
	private Vector3 temp;
    private bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (active)
        {
            temp.x = player.transform.position.x + offset.x;
            temp.y = transform.position.y;
            temp.z = transform.position.z;
            transform.position = temp;
        }
    }

    public void SetInactive()
    {
        active = false;
    }
}
