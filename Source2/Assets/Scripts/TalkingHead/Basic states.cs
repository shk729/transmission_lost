using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basicstates : MonoBehaviour {

}










public interface State {
	TalkingHeadMachine machine { get; set; }
	State next { get; set; }

	void Enter();
	void Run ();
	void Exit();
}



public class HeadTalkState : State {
	string text;
	string name;
	GameObject head;

	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }
	public float waitText = 2; // sec
	public int waitAfterText = 5; // sec

	private float startTime; 
	private float charPerSec = 1f / 50;

	public HeadTalkState(TalkingHeadMachine curMachine, GameObject head, string name, string text) {
		machine = curMachine;
		this.text = text;
		this.head = head;
		this.name = name;
		waitText = (float) text.Length * charPerSec;
	}

	public void Enter() {
		startTime = Time.time;
		machine.panel.SetActive (true);
		head.SetActive (true);
		machine.name.text = name;
		machine.text.text = "";
	}

	public void Run() {
		float curTime = Time.time - startTime;
		if (curTime < waitText) {
			RenderText (curTime);
		} else if (curTime < waitText + waitAfterText) {
			// do nothing... Just wait
		} else {
			machine.NextState (next);
		}
	}

	public void Exit() {
		head.SetActive (false);
		machine.panel.SetActive (false);
	}

	private void RenderText(float sec) {
		int count = Mathf.RoundToInt( sec / charPerSec );

		if (count > text.Length)
			count = text.Length;
		machine.text.text = text.Substring (0, count);
	}
}

public class EndState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	public void Enter() {}
	public void Run () {}
	public void Exit() {}
}


public class JustWaitState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	private int waitSec;
	private float startTime; 

	public JustWaitState(TalkingHeadMachine curMachine, int sec) {
		this.machine = curMachine;
		waitSec = sec;
	}


	public void Enter() {
		startTime = Time.time;
	}

	public void Run () {
		float curTime = Time.time - startTime;
		if (curTime >= waitSec) {
			machine.NextState (next);
		}
	}
	public void Exit() {}
}


class PauseState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	public bool pause;

	public PauseState(TalkingHeadMachine curMachine, bool pause) {
		this.pause = pause;
		machine = curMachine;
	}

	public void Enter() {
		if (pause) {
			machine.game.Hold ();
		} else {
			machine.game.UnHold ();
		}
	}
	public void Run () {
		if (next != null) {
			machine.NextState (next);
		}
	}
	public void Exit() {

	}
}

class CameraPositionState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	private Vector3 pos;
	private Transform camera;

	public CameraPositionState (TalkingHeadMachine machine, Transform camera, Vector3 pos) {
		this.machine = machine;
		this.pos = pos;
		this.camera = camera;
	}

	public void Enter() {
		camera.position = pos;
	}
	public void Run () {
		if (next != null) {
			machine.NextState (next);
		}
	}
	public void Exit() {} 
}

class ActivateSpawnerState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	private string name;
	private SpawnerMonster spawner;


	public ActivateSpawnerState(string name, TalkingHeadMachine machine) {
		this.machine = machine;
		this.name = name;
	}

	public void Enter() {
		spawner = GameObject.Find ("/SceneObjects/" + name).GetComponent<SpawnerMonster> ();
		spawner.ActivateSpawner ();
	}

	public void Run () {
		if (next != null)
			machine.NextState (next);
	}
	public void Exit() {}
}


class PlayerInZoneState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	public PlayerInZoneState (TalkingHeadMachine machine, string zoneName) {
		this.zoneName = zoneName;
		this.machine = machine;
	}

	private Collider2D player;
	private Collider2D area;
	private string zoneName;

	public void Enter() {
		area = GameObject.Find ("/Areas/" + zoneName).GetComponent<Collider2D>();
		player = GameObject.Find ("/Player").GetComponent<Collider2D>();
		Debug.Log ("Areas " + area + " , " + player);
	}
	public void Run () {
		if (player.IsTouching (area)) {
			machine.NextState (next);
		}
	}
	public void Exit() {} 
}

class AllMobIsDeadState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	private float startTime;
	private float checkEverySec = 0.5f;

	public AllMobIsDeadState(TalkingHeadMachine machine) {
		this.machine = machine;
	}

	public void Enter() {
		startTime = Time.time;
	}
	public void Run () {
		if (Time.time - startTime > checkEverySec) {
			startTime = Time.time;
			Check ();
		}
	}
	public void Exit() {} 

	private void Check() {
		MonsterAI[] monsters = Object.FindObjectsOfType<MonsterAI> ();
		if (monsters.Length == 0) {
			machine.NextState (next);
		}

	}
}

class POITriggerState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	private string poi_name;
	private POIProgress poi;

	public POITriggerState(TalkingHeadMachine machine, string poi_name) {
		this.machine = machine;
		this.poi_name = poi_name;
	}


	public void Enter() {
		poi = GameObject.Find ("Retranslator/Canvas/" + poi_name).GetComponent<POIProgress>();
		poi.readyForCheck = true;
	}
	public void Run () {
		if (poi.completed) {
			machine.NextState (next);
		}
	}
	public void Exit() {} 
}


class CheckStationAngleState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	private GameObject station;
	private float min;
	private float max;

	public CheckStationAngleState(TalkingHeadMachine machine, GameObject station, float min, float max) {
		this.machine = machine;
		this.station = station;
		this.min = min;
		this.max = max;
	}

	public void Enter() {}
	public void Run () {
		float stRotation = station.transform.rotation.eulerAngles.z;
		Debug.Log ("Station rotation " + stRotation);
		if (stRotation < max && stRotation > min) {
			machine.NextState (next);
		}
	}
	public void Exit() {} 
}

class ShootStationState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	private SignalSend stationSignal;

	public ShootStationState(TalkingHeadMachine machine) {
		this.machine = machine;
	}

	public void Enter() {
		stationSignal = GameObject.Find ("Retranslator").GetComponent<SignalSend>();
	}
	public void Run () {
		stationSignal.SendWave ();
		machine.NextState (next);
	}
	public void Exit() {} 
}


class KillAllState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	public KillAllState(TalkingHeadMachine machine) {
		this.machine = machine;
	}

	public void Enter() {}
	public void Run () {
		MonsterAI[] allMonsters = Object.FindObjectsOfType<MonsterAI> ();
		foreach (MonsterAI monster in allMonsters) {
			monster.Die ();
		}
	}
	public void Exit() {} 
}


class WinState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	public WinState(TalkingHeadMachine machine) {
		this.machine = machine;
	}

	public void Enter() {}
	public void Run () {}
	public void Exit() {} 
}

/*
class PauseState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	public void Enter() {}
	public void Run () {}
	public void Exit() {} 
}
*/