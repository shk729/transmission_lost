using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidPausable : MonoBehaviour {
	protected bool pause = false;
	protected Rigidbody2D body;

	void Awake ()
	{
		body = GetComponent<Rigidbody2D>();
	}

	public void Hold() {
		pause = true;
		body.simulated = false;
	}

	public void UnHold() {
		pause = false;
		body.simulated = true;
	}


}
