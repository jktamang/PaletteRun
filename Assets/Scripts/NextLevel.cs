using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
	public string nextLevelName;
	public void Click()
	{
		SceneManager.LoadScene(nextLevelName);
	}
}
