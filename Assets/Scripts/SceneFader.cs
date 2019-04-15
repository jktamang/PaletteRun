using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour {
	[SerializeField] Image image;
	[SerializeField] GameObject ui;
    // GameObject controlsUI;


	void Start()
	{
		Disable();
		ui.SetActive(false);
        // controlsUI = GameObject.Find("ControlsUI");
	}

	public void Disable()
	{
		image.enabled = false;
	}

	public void Enable()
	{
		image.enabled = true;
	}

	public void FadeIn(float duration)
	{
		// Enable();
		image.canvasRenderer.SetAlpha(1.0f);
		image.CrossFadeAlpha(0.0f, duration, false);
	}

	IEnumerator ShowUI()
	{
		yield return new WaitForSeconds(1.0f);
		ui.SetActive(true);
	}

	public void FadeOut(float duration)
	{
		Enable();
        // controlsUI.SetActive(false);
		image.canvasRenderer.SetAlpha(0.0f);
		image.CrossFadeAlpha(1.0f, duration, false);
		StartCoroutine(ShowUI());
	}	
}