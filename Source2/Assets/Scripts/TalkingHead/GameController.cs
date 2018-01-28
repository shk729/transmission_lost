using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public Transform mainCamera;
	public SpawnerMonster spawner;
	public DirectionArrow arrow;

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
