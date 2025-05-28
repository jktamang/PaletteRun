using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : SimpleSingleton<MainMenuUIManager>
{
    // Start is called before the first frame update
    [SerializeField] GameObject controlsUI;
    void Start()
    {
        #if MOBILE_INPUT
            controlsUI.SetActive(false);
        #endif
    }
}
