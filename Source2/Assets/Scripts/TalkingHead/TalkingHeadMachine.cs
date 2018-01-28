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
	public GameObject retranslator;

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
        state = sayLev("Подтверждаю, есть сигнал! Отлично, осталось еще три ретранслятора.", state);

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

		// state = checkStationAngle (10, 20, state);  Вращение станции  по оси Z  (rotation  Z)
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

	State checkStationAngle(float min, float max, State afterState) {
		afterState.next = new CheckStationAngleState (this, retranslator, min, max);
		return afterState.next;
	}

	// Update is called once per frame
	void Update () {
		currentState.Run ();
	}
}