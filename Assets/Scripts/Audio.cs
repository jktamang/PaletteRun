using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Audio : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI audioButtonText;
    void Start()
    {
    }

    public void Click()
    {
        AudioManager.instance.ToggleAudio();
        audioButtonText.text = AudioManager.instance.GetAudioButtonText();
    }
}
