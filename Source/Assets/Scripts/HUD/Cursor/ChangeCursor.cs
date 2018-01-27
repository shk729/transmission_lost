using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour {

	public Texture2D mouseTexture;

	void Awake () {
		Cursor.visible = false;
		//Screen.showCursor=false;
	}
	void OnGUI () {
		Vector2 m = Event.current.mousePosition;
		GUI.depth=0;
		GUI.Label(new Rect(m.x,m.y,mouseTexture.width,mouseTexture.height),mouseTexture);
	}
}
