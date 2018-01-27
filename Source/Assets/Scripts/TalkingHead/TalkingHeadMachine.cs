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


	public void NextState(State state) {
		currentState.Exit ();
		state.Enter ();
		currentState = state;
	}

	// Use this for initialization
	void Start () {
		panel.SetActive (false);
		State first;
		State state;
		State nextState;

		first = new JustWaitState(this, 3);
		state = first;
		state = sayLev ("Oкей, телеметрия вроде как в норме, давай приступать. Как ты знаешь, это единственная всеволновая передающая станция в этом секторе, так что починить ее надо как можно быстрее.", state);
		state = sayKesha("O, боже!!! Это же ЛЕВ!!!1" , state);
		state = sayKesha ("Да, знаю я, знаю. Я же ее и устанавливал в прошлом году. Не пойму только, с чего бы она вышла из строя.", state);
		state = sayLev ("Вот сейчас и поймешь, приступай к осмотру.", state);
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
		afterState.next = new HeadTalkState (this, headA, "Lev >=3", msg);
		return afterState.next;
	}

	State sayKesha(string msg, State afterState) {
		afterState.next = new HeadTalkState (this, headB, "Kesha", msg);
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
	public int waitText = 2; // sec
	public int waitAfterText = 5; // sec

	private float startTime; 

	public HeadTalkState(TalkingHeadMachine curMachine, GameObject head, string name, string text) {
		machine = curMachine;
		this.text = text;
		this.head = head;
		this.name = name;
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
		float onePercent = (float)waitText / 100;
		if (sec < onePercent) {
			return;
		}
		float percent = sec / onePercent;


		int textCount = Mathf.RoundToInt( (text.Length / 100f) * percent );

		if (textCount > text.Length)
			textCount = text.Length;
		if (textCount < 0)
			textCount = 0;
		machine.text.text = text.Substring (0, textCount );
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