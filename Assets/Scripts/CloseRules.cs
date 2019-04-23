using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRules : MonoBehaviour
{
    UIManager uiManager;

    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void Click()
    {
        uiManager.HideRulesUI();
    }
}
