using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitScriptState : ScriptMachineState {
	public int waitSec;
	private float startTime; 

	public override void Enter() {
		Debug.Log ("Enter wait script");
		base.Enter ();

		startTime = Time.time;
	}

	public override void Run() {
		float curTime = Time.time - startTime;
		if (curTime >= waitSec && next != null) {
			machine.NextState (next);
		}
	}
}
