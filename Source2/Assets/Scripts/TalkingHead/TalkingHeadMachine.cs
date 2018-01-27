using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingHeadMachine : MonoBehaviour {
	State currentState = new EndState();
	public GameObject panel;
	public Text name;
	public Text text;

	public GameObject headA;
	public GameObject headB;
	public GameController game;


	private float scaleTime;

	public void NextState(State state) {
		currentState.Exit ();
		state.Enter ();
		currentState = state;
	}

	// Use this for initialization
	void Start () {
		scaleTime = Time.timeScale;
		panel.SetActive (false);
		State first;
		State state;
		State nextState;

		first = new JustWaitState(this, 3);
		state = first;
		state = sayLev ("Oкей, телеметрия вроде как в норме, давай приступать. Как ты знаешь, это единственная всеволновая передающая станция в этом секторе, так что починить ее надо как можно быстрее.", state);
		//state = checkPOI ("pointOfInterest1", state);
		state = pause (true, state);
		state = sayKesha("O, боже!!! Это же ЛЕВЪ!!!1 >:3" , state);
		state = allMobIsDead (state);
		//state = playerInZone ("Zone_1", state);
		state = pause (true, state);
		state = camera (-19.6f, 8.6f, state);
		state = activateSpawner ("SpawnerMonster", state);
		state = sayKesha ("Да, знаю я, знаю. Я же ее и устанавливал в прошлом году. Не пойму только, с чего бы она вышла из строя.", state);
		state = pause (false, state);
		state = camera (0f, 0f, state);
		//state = activateSpawner (state);
		state = sayLev ("Вот сейчас и поймешь, приступай к осмотру.", state);
		//state = pause (false, state);
		state = wait (2, state);
		state = sayKesha ("A это еще что за хрень?!", state);
		state = sayLev ("а, теперь все понятно. Это, Майк, Hirudinea Kosmos, то бишь космические пиявки. Жрут электрооборудование, но не против и ремонтником закусить, так что мочи их смело! ", state);
		state = sayKesha ("Вот вам, твари инопланетные!", state);
		state = sayLev ("ты же в курсе что они тебя не слышат? Мало того что в вакууме звук не передается, так у этих милах и ушей-то нет!", state);
		state = sayKesha ("Вот кто бы мог подумать!", state);
		state = sayLev ("окей. Теперь, когда мы знаем причину поломки, то правиться с ремонтом будет нетрудно. Надо всего лишь вручную сориентировать станцию, откалибровать передачу по четырем ретрансляторам и включить программу автонастройки. Плевое дело!", state);

		state = sayKesha ("ну да, не тебе же руками многотонную станцию крутить. ", state);
		state = sayLev ("Ой, ну вот не надо тут! Крутить все равно двигатель ранца будет, а не ты. В общем приступай. Сначала сориентируй станцию на первый ретранслятор. Как только займешь нужное положение – запусти системы станции.", state);
		state = sayKesha ("Есть!", state);
		state = wait (2, state);
		state = sayLev ("теперь внимательно! Сначала включай нейтронный актуатор, затем квантовый редупликатор и только в конце – квантовый эмиттер.", state);
		state = sayKesha ("это сейчас на каком языке было?!", state);
		state = sayLev ("ладно, ладно! Сначала включай панель на правом боку станции, потом на левом и только после этого – пульт на днище. Не перепутай!", state);
		state = sayKesha ("Хорошо, сейчас…", state);

		state.next = first;

		currentState = first;
	}

	State wait(int sec, State after)  {
		after.next = new JustWaitState(this, sec);
		return after.next;
	}

	State sayLev(string msg, State afterState) {
		afterState.next = new HeadTalkState (this, headA, "ЛевЪ", msg);
		return afterState.next;
	}

	State sayKesha(string msg, State afterState) {
		afterState.next = new HeadTalkState (this, headB, "Кеша", msg);
		return afterState.next;
	}

	State pause(bool value, State afterState) {
		afterState.next =  new PauseState (this, value);
		return afterState.next;
	}

	State camera(float x, float y, State afterState) {
		afterState.next = new CameraPositionState (this, game.mainCamera, new Vector3 (x, y, game.mainCamera.position.z));
		return afterState.next;
	}

	State activateSpawner(string name, State afterState) {
		afterState.next = new ActivateSpawnerState (name, this);
		return afterState.next;
	}

	State playerInZone(string zoneName, State afterState) {
		afterState.next = new PlayerInZoneState (this, zoneName);
		return afterState.next;
	}

	State allMobIsDead(State afterState) {
		afterState.next = new AllMobIsDeadState (this);
		return afterState.next;
	}

	State checkPOI(string poiName, State afterState) {
		afterState.next = new POITriggerState (this, poiName);
		return afterState.next;
	}

	// Update is called once per frame
	void Update () {
		currentState.Run ();
	}
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


/*
class PauseState : State {
	public TalkingHeadMachine machine { get; set; }
	public State next { get; set; }

	public void Enter() {}
	public void Run () {}
	public void Exit() {} 
}
*/