using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    GameObject creditsText;
    bool showCredits = false;

    void Start()
    {
        creditsText = GameObject.Find("Credits");
        creditsText.SetActive(false);
    }

    public void ToggleCredits()
    {
        if (showCredits)
        {
            creditsText.SetActive(false);
            showCredits = false;
        }
        else
        {
            creditsText.SetActive(true);
            showCredits = true;
        }
    }
}
