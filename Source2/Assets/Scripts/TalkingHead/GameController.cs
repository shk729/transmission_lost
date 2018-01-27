using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public void Hold() {
		RigidPausable[] bodies = Object.FindObjectsOfType<RigidPausable>();
		foreach (RigidPausable body in bodies) {
			Debug.Log (body);
			body.Hold ();
		}
	}

	public void UnHold() {
		RigidPausable[] bodies =  Object.FindObjectsOfType<RigidPausable>();
		foreach (RigidPausable body in bodies) {
			body.UnHold ();
		}
	}
}
