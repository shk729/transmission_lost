using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel:MonoBehaviour {

	public GameObject losePanel;

	public void ShowStatus ()
	{		
		losePanel.SetActive (true);
		//Time.timeScale = 0;
	}

	public void OnResumeButton ()
	{
		SceneManager.UnloadSceneAsync("gameplay");
		SceneManager.LoadSceneAsync ("Menu");
	}

}
