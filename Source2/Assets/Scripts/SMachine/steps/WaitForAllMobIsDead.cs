using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForAllMobIsDead : SMachineStep {
	private float checkEvery = 0.5f;
	private float startTime;

	public override void Enter ()
	{
		startTime = Time.time;
	}

	public override void Run () {
		if (Time.time - startTime > checkEvery) {
			startTime = Time.time;
			Check ();
		}
	}

	private void Check() {
		MonsterAI[] monsters = Object.FindObjectsOfType<MonsterAI> ();
		if (monsters.Length == 0)
			Done ();
	}
}
