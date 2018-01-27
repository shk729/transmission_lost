using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorScript : MonoBehaviour {
	
	public GameObject itemsParent;

	private GameObject selector;
	private List<GameObject> items;
	int current = 0;

	void Start() {
		selector = gameObject;
		items = new List<GameObject> ();
		foreach (Transform child in itemsParent.transform) {
			items.Add (child.gameObject);
		}
		UpdateCursor ();
	}

	void Update() {
		ChangeCursor ();

	}

	void ChangeCursor() {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {CursorUp ();UpdateCursor ();}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {CursorDown ();UpdateCursor ();}
		if (Input.GetKeyDown (KeyCode.Return)) {RunCursor (current);}
	}

	void CursorDown() {
		current++;
		if (current >= items.Count) { current = 0; }
	}

	void CursorUp() {
		current--;
		if (current < 0) {
			current = items.Count - 1;
		}
	}

	void UpdateCursor() {
		UpdateCursor (current);
	}

	public void UpdateCursor(int posItem) {
		current = posItem;
		GameObject item = items [posItem];

		SpriteRenderer itemSprite = item.GetComponent<SpriteRenderer> ();
		Vector3 pos = item.transform.position;
		pos.x = pos.x - (itemSprite.bounds.size.x / 2) - 0.6f;
		selector.transform.position = pos;
	}

	public void RunCursor(int posItem) {
		items [posItem].GetComponent<NextSceneScript> ().Run ();
	}
}
