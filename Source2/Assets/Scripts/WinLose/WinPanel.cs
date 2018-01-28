using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel:MonoBehaviour {
	
	public GameObject winPanel;

	public void ShowStatus ()
	{		
		winPanel.SetActive (true);
		//Time.timeScale = 0;
	}

	public void OnResumeButton ()
	{
		SceneManager.UnloadSceneAsync("gameplay");
		SceneManager.LoadSceneAsync ("Menu");
	}

}
