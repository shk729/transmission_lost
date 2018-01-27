using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	public List<GameObject> items;
	public GameObject selector;

	public void ChangeScene (string sceneName) {
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}
}
