using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour {
	public string next;
	public GameObject selector;
	int index;

	void Start() {
		Transform parent = transform.parent;
		int i = 0;
		foreach (Transform child in parent) {
			if (this.name == child.gameObject.name) index = i;
			i++;
		}
	}

	public void Run () {
		SceneManager.LoadScene (next);
	}

	void OnMouseEnter() {
		selector.GetComponent<SelectorScript> ().UpdateCursor( index );
	}

	void OnMouseUp() {
		Run ();
	}
}
