using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public bool pause = false;
	public Transform mainCamera;
	public SpawnerMonster spawner;
	public DirectionArrow arrow;

	public GameObject headPanel;
	public UnityEngine.UI.Text headText;
	public GameObject headsContainer;
	public GameObject monsterTypesContainer;

	public void Hold() {
		pause = true;
		RigidPausable[] bodies = Object.FindObjectsOfType<RigidPausable>();
		foreach (RigidPausable body in bodies) {
			body.Hold ();
		}
	}

	public void UnHold() {
		pause = false;
		RigidPausable[] bodies =  Object.FindObjectsOfType<RigidPausable>();
		foreach (RigidPausable body in bodies) {
			body.UnHold ();
		}
	}
}
[System.Serializable]
public struct NamedPrefab {
	public string key;
	public Transform prefab;
}