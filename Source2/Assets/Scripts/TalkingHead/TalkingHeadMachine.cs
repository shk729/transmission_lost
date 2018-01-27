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
        state = pause(true, state);
        state = sayLev("Oкей, телеметрия вроде как в норме, давай приступать. Как ты знаешь, это единственная всеволновая передающая станция в этом секторе, так что починить ее надо как можно быстрее.", state);
        state = sayKesha("да знаю я, знаю. Я же ее и устанавливал в прошлом году. Не пойму только, с чего бы она вышла из строя. ", state);
        state = sayLev("Вот сейчас и поймешь, приступай к осмотру.", state);
        state = pause(false, state);
        state = playerInZone("Zone_1", state);
        state = pause(true, state);
        state = camera(-19.6f, 8.6f, state);
        state = sayKesha("A это еще что за хрень?!", state);
        state = sayLev("А, теперь все понятно. Это, Иннокентий, Hirudinea Kosmos, то бишь космические пиявки. Жрут электрооборудование, но не против и ремонтником закусить, так что мочи их смело! ", state);
        state = pause(false, state);
        state = sayKesha("Вот вам, твари инопланетные!", state);
        state = sayLev("Ты же в курсе что они тебя не слышат? Мало того что в вакууме звук не передается, так у этих милах и ушей-то нет!", state);
        state = sayKesha("Вот кто бы мог подумать!", state);
        state = allMobIsDead(state);
        state = sayLev("Окей. Теперь, когда мы знаем причину поломки, то правиться с ремонтом будет нетрудно. Надо всего лишь вручную сориентировать станцию, откалибровать передачу по четырем ретрансляторам и включить программу автонастройки. Плевое дело!", state);
        state = sayKesha("Ну да, не тебе же руками многотонную станцию крутить. ", state);
        state = sayLev("Ой, ну вот не надо тут! Крутить все равно двигатель ранца будет, а не ты. В общем приступай. Сначала сориентируй станцию на первый ретранслятор. Как только займешь нужное положение – запусти системы станции.", state);
        state = sayKesha("Есть!", state);

        state = pause(true, state);
        state = sayLev("Теперь внимательно! Сначала включай нейтронный актуатор, затем квантовый редупликатор и только в конце – тахионный эмиттер.", state);
        state = sayKesha("Это сейчас на каком языке было?!", state);
        state = sayLev("Ладно, ладно! Сначала включай красную панель на правом боку станции, потом зеленую на левом и только после этого – синий пульт на днище. Не перепутай!", state);
        state = pause(false, state);
        state = sayKesha("Хорошо, сейчас…", state);
        state = checkPOI("pointOfInterest3", state);
        state = checkPOI("pointOfInterest2", state);
        state = checkPOI("pointOfInterest1", state);
        state = pause(true, state);
        state = activateSpawner("SpawnerMonster", state);
        state = camera(-19.6f, 8.6f, state);
        state = sayKesha("Это что еще за нафиг?!", state);
        state = sayLev("Ого, это ж как наша станция на местные астероиды влияет! Разберись с ними, и запускай еще раз.", state);
        state = pause(false, state);
        state = allMobIsDead(state);
        state = sayKesha("Ффух, здоровенные, гады. Ладно, приступаю к запуску.", state);
        state = sayLev("Давай, сначала ре… тьфу, короче зеленый пульт, красный пульт и синий пульт!", state);
        state = sayKesha("Принято, зеленый, красный, синий. Так бы сразу, а то выражается, понимаешь… ", state);
        state = sayLev("Я все слышу!", state);
        state = sayKesha("Будет исполнено, Лев Михалыч!", state);
        state = sayLev("Так-то лучше…", state);
        state = checkPOI("pointOfInterest2", state);
        state = checkPOI("pointOfInterest3", state);
        state = checkPOI("pointOfInterest1", state);
        state = sayKesha("Сигнал пошел!", state);
        state = sayLev("Подтверждаю, есть сигнал! Отлично, осталось еще три.", state);

        //	state = camera (-19.6f, 8.6f, state);
        //	state = activateSpawner (state);
        //	state = pause (false, state);
        //	state = camera (0f, 0f, state);
        //state = activateSpawner (state);
        //state = pause (false, state);
        //	state = wait (2, state);
        //	state = wait (2, state);
        //	state = sayLev ("теперь внимательно! Сначала включай нейтронный актуатор, затем квантовый редупликатор и только в конце – квантовый эмиттер.", state);
        //	
        //	state = sayLev ("ладно, ладно! Сначала включай панель на правом боку станции, потом на левом и только после этого – пульт на днище. Не перепутай!", state);
        //	
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

	State activateSpawner(State afterState) {
		afterState.next = new ActivateSpawnerState (this);
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

	public ActivateSpawnerState(TalkingHeadMachine machine) {
		this.machine = machine;
	}

	public void Enter() {
		machine.game.spawner.ActivateSpawner ();
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