using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    AudioManager audioManager;

    void Start()
    {
        audioManager =
            GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void Click()
    {
        Text audioButtonText = transform.Find("Text").GetComponent<Text>();
        audioManager.ToggleAudio();
        audioButtonText.text = audioManager.GetAudioButtonText();
    }
}
