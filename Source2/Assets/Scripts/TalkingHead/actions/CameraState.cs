using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState : ScriptMachineState {
	public Transform camera;
	public Vector2 position;

	public override void Enter () {
		camera.position = new Vector3 (position.x, position.y, camera.position.z);
	}
}
