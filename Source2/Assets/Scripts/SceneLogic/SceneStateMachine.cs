﻿using System.Collections;
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

        first = new JustWaitState(this, 1);
        state = first;
		/*
         state = pause(true, state);  
         state = sayLev("Oкей, телеметрия вроде как в норме, давай приступать. Как ты знаешь, это единственная всеволновая передающая станция в этом секторе, так что починить ее надо как можно быстрее.", state);
         state = sayKesha("Да знаю я, знаю. Я же ее и устанавливал в прошлом году. Не пойму только, с чего бы она вышла из строя. ", state);
         state = sayLev("Вот сейчас и поймешь, приступай к осмотру.", state);
         state = pause(false, state);
         state = activateSpawner("SpawnerMonster1", state);
         state = playerInZone("Zone_1", state);
         state = pause(true, state);
         state = camera(-0.51f, -4.51f, state);
         state = sayKesha("A это еще что за хрень?!", state);
         state = sayLev("А, теперь все понятно. Это, Иннокентий, Hirudinea Kosmos, то бишь космические пиявки. Жрут электрооборудование, но не против и ремонтником закусить, так что мочи их смело! ", state);
         state = pause(false, state);
         state = sayKesha("Вот вам, твари инопланетные!", state);
         state = sayLev("Ты же в курсе что они тебя не слышат? Мало того что в вакууме звук не передается, так у этих милах и ушей-то нет!", state);
         state = sayKesha("Вот кто бы мог подумать!", state);
         state = allMobIsDead(state);
         state = sayLev("Окей. Теперь, когда мы знаем причину поломки, то справиться с ремонтом будет нетрудно. Надо всего лишь вручную сориентировать станцию, откалибровать передачу ", state);
         state = sayLev("по четырем ретрансляторам и включить программу автонастройки. Плевое дело!", state);
         state = sayKesha("Ну да, не тебе же руками многотонную станцию крутить. ", state);
         state = setArrow(true, "Satellite1", state);
         state = sayLev("Ой, ну вот не надо тут! Крутить все равно двигатель ранца будет, а не ты. В общем приступай. Сначала сориентируй станцию на первый ретранслятор. Как только займешь нужное положение – запусти системы станции.", state);
         state = sayKesha("Есть!", state);
         state = checkStationAngle(2,6, state);
         state = setArrow(false, "Satellite1", state);
         state = pause(true, state);
         state = sayLev("Теперь внимательно! Сначала включай нейтронный актуатор, затем квантовый редупликатор и только в конце – тахионный эмиттер.", state);
         state = sayKesha("Это сейчас на каком языке было?!", state);
         state = sayLev("Ладно, ладно! Сначала включай красную панель на правом боку станции, потом зеленую на левом и только после этого – синий пульт на днище. Не перепутай!", state);
         state = pause(false, state);
         state = sayKesha("Хорошо, сейчас…", state);
         state = activateSpawner("SpawnerMonster1_03", state);
         state = checkPOI("pointOfInterestRed", state);
         state = activateSpawner("SpawnerMonster1_01", state);
         state = checkPOI("pointOfInterestGreen", state);
         state = activateSpawner("SpawnerMonster1_02", state);
         state = checkPOI("pointOfInterestBlue", state);
         state = camera(3.92f, 2.73f, state);
         state = sendRetranslatorWave (state);
         state = wait(2, state);
         state = destroyOneAsteroid("Rock (3)", state);
         state = pause(true, state);
         state = activateSpawner("SpawnerMonster2", state);
         state = camera(17.91f, 17.24f, state);
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
         state = checkPOI("pointOfInterestGreen", state);
         state = checkPOI("pointOfInterestRed", state);
         state = checkPOI("pointOfInterestBlue", state);
         state = sayKesha("Сигнал пошел!", state);
         state = sendRetranslatorWave(state);
         state = sayLev("Подтверждаю, есть сигнал! Отлично, осталось еще три ретранслятора.", state); 
         */
          state = wait(5, state);
          state = sayLev("Так, теперь давай наводи на второй ретранслятор… опа, опять пиявки! Расправься сначала с ними.", state);
         state = activateSpawner("SpawnerMonster3_01", state);
         state = activateSpawner("SpawnerMonster3_02", state);
         state = sayKesha("Счас они у меня попляшут!", state);
          state = allMobIsDead(state);
        state = setArrow(true, "Satellite2", state);
        state = sayLev("Наводи на второй ретранслятор", state);
          state = checkStationAngle(268, 272, state);
        state = setArrow(false, "Satellite2", state);
        state = sayLev("Запускай, красный пульт, зеленый пульт и синий пульт!", state);
          state = sayKesha("Запускаю, красный, зеленый, синий.!", state);
          activateSpawner("SpawnerMonster1_03", state);
          state = checkPOI("pointOfInterestRed", state);
         activateSpawner("SpawnerMonster1_01", state);
         state = checkPOI("pointOfInterestGreen", state);
         state = activateSpawner("SpawnerMonster3_01", state);
         state = checkPOI("pointOfInterestBlue", state);
          state = sendRetranslatorWave (state);
          state = sayLev("Так, запуск есть, а ретранслятор ответа не дает. Ну-ка, слетай к нему да глянь в чем дело.", state);
        state = setArrow(true, "Satellite2", state);
        state = sayKesha("Так далеко же, заблужусь!", state);
          state = sayLev("Заблудишься – останешься без премии! Давай, пошевеливайся, а то опять пиявки налетят.", state);
          state = sayKesha("Эх, гоняют туда-сюда, как какого-то бессмертного пони…", state);
          state = playerInZone("Zone_2", state);
        state = setArrow(false, "Satellite2", state);
        state = activateSpawner("SpawnerMonster3_03", state);
         state = sayKesha("Вот же гады, они и ретранслятор теперь жрут. Ну сейчас вы у меня отведаете освежающей плазмы!", state);
          state = sayLev("И откуда спрашивается у тебя плазма может вылезти? У тебя же лазерный излучатель, специально чтоб станцию не попортить.", state);
          state = sayKesha("Нууу… ну и ладно, пусть будут яркие когерентные лучи любви!", state);
          state = allMobIsDead(state);
        state = setArrow(true, "Retranslator", state);
        state = sayLev("Пока ты тут упражняешься в остроумии, твари опять начали грызть станцию…", state);
         state = activateSpawner("SpawnerMonster1", state);
         state = activateSpawner("SpawnerMonster1_03", state);
         state = sayKesha("ДА ВОТ ЖЕ ГАДЫ!", state);
          state = allMobIsDead(state);
        state = setArrow(false, "Retranslator", state);
        state = sayLev("так, ладно, теперь все должно заработать как надо. Давай, красный, зеленый, синий. ", state);
          state = checkPOI("pointOfInterestRed", state);
         state = activateSpawner("SpawnerMonster1_01", state);
         state = checkPOI("pointOfInterestGreen", state);
         state = activateSpawner("SpawnerMonster1_02", state);
         state = checkPOI("pointOfInterestBlue", state);
         state = sayKesha("Помню я, можно по два раза не повторять. Красный, зеленый и… ну этот, как его там, забыл.", state);
          state = sayLev("Во-во, не повторять ему.", state);
         state = sendRetranslatorWave (state);
          state = sayKesha("Пошла передача!", state);
        state = setArrow(true, "Satellite3", state);
        state = sayLev("Есть контакт, молоток! Еще две и все готово. Наводи на третий ретранслятор.", state);
        state = activateSpawner("SpawnerMonster4_01", state);
        state = activateSpawner("SpawnerMonster4_02", state);
        state = activateSpawner("SpawnerMonster4_02", state);
        state = checkStationAngle(178, 182, state);
        state = setArrow(false, "Satellite3", state);
        state = sayKesha("Опять пиявки, счас я им!", state);
        state = allMobIsDead(state);
        state = sayLev("В этот раз все просто, красный, синий и зеленый, прям как светофор.", state);
        state = sayKesha("Это что за светофор такой, с синим-то?", state);
        state = sayLev("Космический! Не умничай тут, настраивай.", state);
        state = activateSpawner("SpawnerMonster4_03", state);
        state = checkPOI("pointOfInterestRed", state);
        state = activateSpawner("SpawnerMonster4_01", state);
        state = checkPOI("pointOfInterestBlue", state);
        state = activateSpawner("SpawnerMonster4_02", state);
        state = checkPOI("pointOfInterestGreen", state);
         state = sendRetranslatorWave (state);
        state = sayKesha("Есть, пошел сигнал!", state);
        state = pause(true, state);
        state = activateSpawner("SpawnerMonster4_04", state);
        state = camera(-15.5f, -17.5f, state);
        state = wait(1, state);
        state = killAll (state);// тут нужно убить пачку мобов скриптом
        state = pause(false, state);
        state = activateSpawner("SpawnerMonster4_05", state);        
        state = sayKesha("ЧТООООАА?!!", state);
        state = sayLev("упс, похоже надо было сначала включить квантовый редупликатор… Короче, быстро избавься от этих… не знаю кого и запусти станцию еще раз!", state);
        state = allMobIsDead(state);
        state = sayKesha("А точно надо?", state);
        state = sayLev("Надо, Кеша, надо… Как светофор, только наоборот, зеленый, синий, красный.", state);
        state = sayKesha("Ладно…", state);
        state = activateSpawner("SpawnerMonster4_01", state);
        state = checkPOI("pointOfInterestGreen", state);
        state = activateSpawner("SpawnerMonster4_02", state);
        state = checkPOI("pointOfInterestBlue", state);
        state = activateSpawner("SpawnerMonster4_01", state);
        state = activateSpawner("SpawnerMonster4_02", state);
        state = checkPOI("pointOfInterestRed", state);
		state = sendRetranslatorWave (state);
        state = setArrow(true, "Satellite4", state);
        state = sayLev("Так, идет сигнал, замечательно! Остался финальный рывок. Наводи на четвертый ретранслятор и жми синий, красный, зеленый. Тут уже точно, без ошибок.", state);
        state = checkStationAngle(88, 92, state);
        state = setArrow(false, "Satellite4", state);
        state = sayKesha("Ну хорошо что наконец-то без ошибок. Так, нажимаем…", state);
        state = checkPOI("pointOfInterestBlue", state);
        state = checkPOI("pointOfInterestRed", state);
        state = checkPOI("pointOfInterestGreen", state);
		state = sendRetranslatorWave (state);
        state = rotateAndShootStation(state);
        state = destroyAsteroids (state);
        state = activateSpawner("SpawnerMonster5_01", state);
        state = activateSpawner("SpawnerMonster5_02", state);
        state = activateSpawner("SpawnerMonster5_03", state);
        state = activateSpawner("SpawnerMonster5_04", state);
        state = activateSpawner("SpawnerMonster5_05", state);
        state = activateSpawner("SpawnerMonster5_06", state);
        state = activateSpawner("SpawnerMonster5_07", state);
        state = activateSpawner("SpawnerMonster5_08", state);
        state = activateSpawner("SpawnerMonster5_09", state);
        state = activateSpawner("SpawnerMonster5_10", state);
        state = activateSpawner("SpawnerMonster5_11", state);
        state = activateSpawner("SpawnerMonster5_12", state);
        state = activateSpawner("SpawnerMonster5_13", state);
        state = activateSpawner("SpawnerMonster5_14", state);
        state = sayKesha("ДА ВЫ ИЗДЕВАЕТЕСЬ!!! Ктож это все хоронить-то будет?!", state);
        state = sayLev("Меньше трепа, больше стрельбы! Не дай им сломать станцию, да и себя тоже!", state);
        state = sayKesha("НУ ВСЕ, РЕДИСКИ КОСМИЧЕСКИЕ, СЕЙЧАС ВЫ ПОЗНАЕТЕ ВСЮ МЕРУ МОЕГО ГНЕВА!", state);
        state = wait(30, state);
        state = sayLev("Они так и будут лезть! Запускай передачу еще раз, аварийная частота – красный, зеленый, красный! Иначе конец!", state);
        state = sayKesha("Сейчас, мне бы только успеть…", state);
        state = checkPOI("pointOfInterestRed", state);
        state = checkPOI("pointOfInterestGreen", state);
        state = checkPOI("pointOfInterestRed", state);
		state = sendRetranslatorWave (state);
		state = killAll (state);
        state = sayKesha("Ох, ну и толпы же их были однако...", state);
        state = sayLev("Ладно, все хорошо, что хорошо заканчивается. Возвращайся на челнок, на отгул ты себе сегодня точно заработал.", state);
        state = sayKesha("…И на премию!", state);
        state = sayLev("Еще чего, перетопчешься. Давай, сегодня еще 4 спутника облететь надо.", state);
        state = sayKesha("охххх…", state);
		state = win (state);
        // the end


		// state = setArrow (true, "Satellite2", state);
		// state = destroyOneAsteroid("Rock (3)", state);  Убить Адин Кратер с имененм Rock (3)

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

	State sendRetranslatorWave(State afterState) {
		afterState.next = new ShootStationState (this);
		return afterState.next;
	}

	State killAll(State afterState) {
		afterState.next = new KillAllState (this);
		return afterState.next;
	}

	State win(State afterState) {
		afterState.next = new WinState (this);
		return afterState.next;
	}

	State rotateAndShootStation(State afterState) {
		afterState.next = new RotateStationState (this);
		return afterState.next;
	}

	State setArrow(bool activate, string target, State afterState) {
		afterState.next = new DirectArrowState (this, game.arrow, target, activate);
		return afterState.next;
	}

	State destroyAsteroids(State afterState) {
		afterState.next = new KillAsteroidState (this);
		return afterState.next;
	}

	State destroyOneAsteroid(string name, State afterState) {
		afterState.next = new KillOneAsteroidState (this, name);
		return afterState.next;
	}

	// Update is called once per frame
	void Update () {
		currentState.Run ();
	}
}