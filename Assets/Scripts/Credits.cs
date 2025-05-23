using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject creditsText;
    bool showCredits = false;

    void Start()
    {
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
