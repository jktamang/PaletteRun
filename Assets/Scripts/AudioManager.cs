using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SimpleSingleton<AudioManager>
{
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("AudioVolume", 1.0f);
        PauseMenu.instance.SetVolumeSlider(AudioListener.volume);
    }

    public void ToggleAudio()
    {
        AudioListener.volume = (AudioListener.volume == 0.0f) ? 1.0f : 0.0f;
        PlayerPrefs.SetFloat("AudioVolume", AudioListener.volume);
    }

    public void OnSlideAudio(float f)
    {
        AudioListener.volume = Mathf.Clamp01(f);
        PlayerPrefs.SetFloat("AudioVolume", AudioListener.volume);
    }

    public string GetAudioButtonText()
    {
        return (AudioListener.volume == 0.0f) ? "Audio: Off" : "Audio: On";
    }
}
