using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStep : SMachineStep {
	public bool pause;

	private GameController game;

	override public void Enter() {
		if (game == null)
			game = GetGameController ();
		if (pause) {
			game.Hold ();
		} else {
			game.UnHold ();
		}
		Done ();
	}

	private GameController GetGameController() {
		return GetComponentInParent<GameController> ();
	}
}
