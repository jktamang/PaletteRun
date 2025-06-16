using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : SimpleSingleton<PauseMenu>
{
    private bool isGamePaused = false;
    [SerializeField] AudioSource bgMusic;
    [SerializeField] PlayerMovement movement;

    [SerializeField] TextMeshProUGUI audioButtonText;
    [SerializeField] Slider volume;

    void Start()
    {
    }

    void Update()
    {
    }

    public void TogglePause()
    {
        if (isGamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        UIManager.instance.HidePauseUI();
        Time.timeScale = GameManager.instance.currentTimeScale;
        bgMusic.volume = 1f;
        isGamePaused = false;
        movement.enabled = true;
    }

    void Pause()
    {
        UIManager.instance.ShowPauseUI();
        audioButtonText.text = AudioManager.instance.GetAudioButtonText();
        Time.timeScale = 0f;
        bgMusic.volume = 0.2f;
        isGamePaused = true;
        movement.enabled = false;
    }

    public void SetVolumeSlider(float f)
    {
        volume.value = f;
	}

    public void OnSlideAudio()
    {
        AudioManager.instance.OnSlideAudio(volume.value);
	}
}
