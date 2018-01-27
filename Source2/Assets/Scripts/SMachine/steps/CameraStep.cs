using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStep : SMachineStep {
	public GameController game;
	public Vector2 position;

	public override void Run ()	{
		game.mainCamera.position = new Vector3 (position.x, position.y, game.mainCamera.position.z);
		Done ();
	}
}
