using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    PauseMenu pause;
    void Start()
    {
        pause = GameObject.Find("PauseManager").GetComponent<PauseMenu>();
    }

    public void Click()
    {
        pause.TogglePause();
    }
}
