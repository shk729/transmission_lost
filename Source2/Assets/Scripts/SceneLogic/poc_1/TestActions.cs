using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants {
	public static string SCENE_LOGIC = "SceneLogic";
}

public class TestSayStep : TestMachineStep {
	private static float CHAR_PER_SEC = 1f / 50;
	private static float WAIT_AFTER_TEXT = 5; // sec

	private string text;
	private GameObject head;
	private GameController game;
	private UnityEngine.UI.Text uiText;

	public TestSayStep(string head, string text) {
		this.text = text;
		game = GameObject.Find (Constants.SCENE_LOGIC).GetComponent<GameController>();
		uiText = game.headText;

		Transform[] heads = game.headsContainer.GetComponentsInChildren<Transform> (true);
		foreach(Transform curHead in heads) {
			if (curHead.name == head) {
				this.head = curHead.gameObject;
				break;
			}
		}
	}

	private int curChar = 0;
	private float startTime;

	public override void Enter () {
		game.headPanel.SetActive (true);
		head.SetActive (true);
		startTime = Time.time;
		curChar = 0;
	}

	public override void Exit (){
		game.headPanel.SetActive (false);
		head.SetActive (false);
	}

	public override void Run() {
		SkipOnKey ();
		float curTime = Time.time - startTime;
		if (curChar <= text.Length) {
			RenderText (curTime);
		} else if (curTime > WAIT_AFTER_TEXT) {
			Done ();
		}
	}

	private void SkipOnKey() {
		if (Input.GetKeyUp (KeyCode.E) || Input.GetMouseButton (1)) {
			Done ();
		}
	}

	private void RenderText(float sec) {
		if (sec < CHAR_PER_SEC)
			return;
		startTime = Time.time;
		uiText.text = text.Substring (0, curChar++);
	}
}


public class TestWaitStep : TestMachineStep {
	private float startTime;
	private float wait;

	public TestWaitStep(float waitSec) {
		this.wait = waitSec;
	}

	public override void Enter ()
	{
		startTime = Time.time;
	}

	public override void Run ()
	{
		float curTime = Time.time - startTime;
		if (curTime > wait) {
			Done ();
		}
	}
}

public class TestPauseStep : TestMachineStep {
	private bool pause;
	private GameController game;

	public TestPauseStep(bool pause) {
		this.pause = pause;
		game = GameObject.Find (Constants.SCENE_LOGIC).GetComponent<GameController>();
	}

	public override void Enter () {
		if (pause)
			game.Hold ();
		else
			game.UnHold ();
		Done ();
	}
}

public class TestMoveCameraStep : TestMachineStep {
	private Vector2 position;
	private GameController game;

	public TestMoveCameraStep(Vector2 position) {
		this.position = position;
		game = GameObject.Find (Constants.SCENE_LOGIC).GetComponent<GameController>();
	}

	public override void Enter () {
		game.mainCamera.position = position;
		Done ();
	}
}

public class TestSpawnMonster : TestMachineStep {
	private Vector2 position;
	private MonsterAI monster;
	private GameController game;
	private int count;

	public TestSpawnMonster( Vector2 position, string monsterName, int count) {
		this.count = count;
		this.position = position;
		game = GameObject.Find (Constants.SCENE_LOGIC).GetComponent<GameController>();

		MonsterAI[] types = game.monsterTypesContainer.GetComponentsInChildren<MonsterAI> (true);
		foreach (MonsterAI type in types) {
			if (type.name == monsterName) {
				monster = type;
				break;
			}
		}
	}

	private float startTime;
	private float spawnDelay = 0.5f;
	private int spawnCounter;

	public override void Enter () {
		startTime = Time.time;
		spawnCounter = count;
	}

	public override void Run () {
		if (spawnCounter <= 0) {
			Done ();
			return;
		}
		float curTime = Time.time - startTime;
		if (curTime > spawnDelay) {
			monster.SpawnNew (position);
			startTime = Time.time;
			spawnCounter--;
		}
	}
}


public class TestWaitPlayerInArea : TestMachineStep {
	private Collider2D player;
	private Collider2D area;

	public TestWaitPlayerInArea(string areaName) {
		area = GameObject.Find ("/Areas/" + areaName).GetComponent<Collider2D>();
		player = GameObject.Find ("/Player").GetComponent<Collider2D>();
	}

	public override void Run () {
		if (player.IsTouching (area)) {
			Done ();
		}
	}
}

public class TestWaitAllMonstersIsDeadStep : TestMachineStep {
	private float startTime;
	private float checkEverySec = 0.5f;
	
	public override void Run () {
		if (Time.time - startTime > checkEverySec) {
			startTime = Time.time;
			Check ();
		}
	}

	private void Check() {
		MonsterAI[] monsters = Object.FindObjectsOfType<MonsterAI> ();
		if (monsters.Length == 0) {
			Done ();
		}
	}
}

public class TestPOITriggerStep : TestMachineStep {
	private POIProgress poi;

	public TestPOITriggerStep(string poiName) {
		poi = GameObject.Find ("Retranslator/Canvas/" + poiName).GetComponent<POIProgress>();
	}

	public override void Enter () {
		poi.ResetPOI();
		poi.readyForCheck = true;
	}

	public override void Run () {
		if (poi.completed)
			Done ();
	}

	public override void Exit () {
		poi.readyForCheck = false;
	}
}

public class TestWinStep : TestMachineStep {
	public override void Run ()
	{
		WinPanel win = GameObject.Find ("PanelsController").GetComponent<WinPanel> ();
		win.ShowStatus ();
		if (next != null)
			Done ();
	}
}

public class TestShootSignalStep : TestMachineStep {
	private SignalSend stationSignal;

	public TestShootSignalStep() {
		stationSignal = GameObject.Find ("Retranslator").GetComponent<SignalSend>();
	}

	public override void Enter () {
		stationSignal.SendWave ();
		Done ();
	}
}

public class TestKillAllMonsters : TestMachineStep {
	public override void Enter () {
		MonsterAI[] allMonsters = Object.FindObjectsOfType<MonsterAI> ();
		foreach (MonsterAI monster in allMonsters) {
			monster.DieAndDestroy ();
		}
		Done ();
	}
}

public class TestArrowDirectionStep : TestMachineStep {
	private DirectionArrow arrow;
	private GameObject target;
	private string targetName;
	private GameController game;
	private bool active;

	public TestArrowDirectionStep(bool active, string target) {
		this.active = active;
		targetName = target;
		game = GameObject.Find (Constants.SCENE_LOGIC).GetComponent<GameController>();
		arrow = game.arrow;
	}

	public override void Enter () {
		if (active) {
			target = GameObject.Find (targetName);
			arrow.gameObject.SetActive (true);
			arrow.SetObjjectToDirection (target);
		} else {
			arrow.gameObject.SetActive (false);
		}
		Done ();
	}
}

public class TestWaitStationAngleStep : TestMachineStep {
	private Transform station;
	private Transform target;

	public TestWaitStationAngleStep(string targetName) {
		station = GameObject.Find ("Retranslator").GetComponent<Transform>();
		target = GameObject.Find (targetName).GetComponent<Transform>();
	}

	private float min;
	private float max;
	private float anglePlusMinus = 7f;

	public override void Enter () {
		GetAngles ();
	}

	public override void Run () {
		float stRotation = station.rotation.eulerAngles.z;
		Debug.Log ("Station rotation " + stRotation);
		if (min < max) {
			if (stRotation < max && stRotation > min) {
				Done ();
			}
		} else {
			if (stRotation > max && stRotation < min) {
				Done ();
			}
		}
	}
		
	private void GetAngles() {
		Vector3 playerPosition = station.position;
		Vector2 moveDirection  = new Vector2(target.position.x-playerPosition.x, target.position.y-playerPosition.y);

		float moveAngle = 0;
		float rotAngle = Mathf.Atan(moveDirection.normalized.y/moveDirection.normalized.x); 

		if (moveDirection.normalized.x>=0)
			moveAngle = rotAngle * Mathf.Rad2Deg-90;
		else if (moveDirection.normalized.x<0)
			moveAngle = rotAngle * Mathf.Rad2Deg+90;

		min = moveAngle - anglePlusMinus;
		max = moveAngle + anglePlusMinus;
		//arrow.rotation = Quaternion.Euler (0, 0, moveAngle+180);
	}
}

// RotateStationState
// KillAsteroidState
// KillOneAsteroidState