using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameplayState : ScriptMachineState {
	public bool pause;
	public GameController game;

	override public void Enter() {
		if (pause) {
			game.Hold ();
		} else {
			game.UnHold ();
		}
	}
}
