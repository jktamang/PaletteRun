using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #if MOBILE_INPUT
            GameObject.Find("ControlsDisplayUI").SetActive(false);
        #endif
    }
}
