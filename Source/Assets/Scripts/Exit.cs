using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_WEBPLAYER
		//Application.OpenURL(webplayerQuitURL);
		#else
		Application.Quit();
		#endif	
	}
}
