using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToScene : MonoBehaviour {
	public string jumpSceneName;

	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
			Jump ();
	}

	void Jump() {
		UnityEngine.SceneManagement.SceneManager.LoadScene (jumpSceneName);
	}
}
