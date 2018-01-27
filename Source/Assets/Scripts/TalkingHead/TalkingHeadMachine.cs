using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingHeadMachine : MonoBehaviour {
	State currentState;
	public GameObject panel;
	public Text name;
	public Text text;

	public GameObject headA;


	public void NextState(State state) {
		currentState.Exit ();
		state.Enter ();
		currentState = state;
	}

	// Use this for initialization
	void Start () {
		State first;
		State state;
		State nextState;

		first = new JustWaitState(this, 3 );
		state = first;
		state.next = new HeadTalkState (this, headA, "Boss", "Fuuuuuuck!!!11!adinadin!");
		state = state.next;
		state.next = new HeadTalkState (this, headA, "Boss #1", "Hmmm... It's almost OKAY");
		state = state.next;
		state.next = first;

		currentState = first;
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