using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEvilSpawner : ScriptMachineState {
	public SpawnerMonster spawner;

	public override void Enter (){
		spawner.ActivateSpawner ();
	}
}
