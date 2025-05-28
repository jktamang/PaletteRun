using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    void Start()
    {
    }

    public void Click()
    {
        PauseMenu.instance.TogglePause();
    }
}
