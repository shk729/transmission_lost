using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMachine : MonoBehaviour {
	public ScriptMachineState currentState;

	public void NextState(ScriptMachineState state) {
		currentState.Exit ();
		state.Enter ();
		currentState = state;
	}

	void Update () {
		if (currentState != null)
			currentState.Run ();
	}
}


public abstract class ScriptMachineState : MonoBehaviour {
	public ScriptMachine machine;
	public ScriptMachineState next;

	public virtual void Enter() {
		/*Debug.Log ("Base enter");
		if (next == null) {
			int index = transform.GetSiblingIndex ();
			Debug.Log ("Index is " + index);
			Transform sibling = transform.parent.GetChild (index + 1);
			Debug.Log ("Sibling is " + sibling);
			if (sibling != null)
				next = sibling.gameObject.GetComponent<ScriptMachineState>();
		}*/
	}
	public virtual void Run() {
		if (next != null) {
			machine.NextState (next);
		}
	}
	public virtual void Exit() {}
}