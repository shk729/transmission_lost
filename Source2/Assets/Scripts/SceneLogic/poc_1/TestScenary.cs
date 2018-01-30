using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScenary : TestScenaryHelper {
	void Start () {
		/*say ("LevNorm", "This is my first speeech");
		wait (2);
		spawnMonster ("Spawners/SpawnerMonster1", "MonsterJigsaw", 4);
		stationSignal ();
		showArrow ("Satellite2");
		say ("KeshaNorm", "Oga, i moya.");
		pause ();
		wait (3);
		spawnMonster ("Spawners/SpawnerMonster1", "MonsterLeech", 4);
		unpause ();
		moveCamera (-0.51f, -4.51f);
		waitPOIActivation ("pointOfInterestRed");*/

		pause ();
		say ("LevNorm", "Oкей, телеметрия вроде как в норме, давай приступать. Как ты знаешь, это единственная всеволновая передающая станция в этом секторе, так что починить ее надо как можно быстрее.");
		say ("KeshaSuperPanic", "О, боже!!! Это же левъ !!!  >:3 ");
		say("KeshaNorm", "Да знаю я, знаю. Я же ее и устанавливал в прошлом году. Не пойму только, с чего бы она вышла из строя. ");
        say("LevNorm", "Вот сейчас и поймешь, приступай к осмотру.");
		unpause ();
		spawnMonster ("Spawners/SpawnerMonster1", "MonsterLeech", 10);
		waitPlayerInArea ("Zone_1");
		pause ();
		moveCamera (-0.51f, -4.51f);
		say ("KeshaPanic", "A это еще что за хрень?!");
		say ("LevNorm", "А, теперь все понятно. Это, Иннокентий, Hirudinea Kosmos, то бишь космические пиявки. Жрут электрооборудование, но не против и ремонтником закусить, так что мочи их смело! ");
		unpause ();
		say ("KeshaPanic", "Вот вам, твари инопланетные!");
		say ("LevNorm", "Ты же в курсе что они тебя не слышат? Мало того что в вакууме звук не передается, так у этих милах и ушей-то нет!");
		say ("KeshaNorm", "Вот кто бы мог подумать!");
		waitAllMonstersAreDead ();
		say ("LevNorm", "Окей. Теперь, когда мы знаем причину поломки, то справиться с ремонтом будет нетрудно. Надо всего лишь вручную сориентировать станцию, откалибровать передачу ");
		say ("LevNorm", "по четырем ретрансляторам и включить программу автонастройки. Плевое дело!");
		say ("KeshaNorm", "Ну да, не тебе же руками многотонную станцию крутить. ");
		showArrow ("Satellite1");
		say ("LevNorm", "Вращай станцию! Указатель подскажет куда должен смотреть излучатель станции!");
		say ("LevPanic", "Ой, ну вот не надо тут! Крутить все равно двигатель ранца будет, а не ты. В общем приступай. Сначала сориентируй станцию на первый ретранслятор. Как только займешь нужное положение – запусти системы станции.");
		say ("KeshaNorm", "Есть!");
		waitStationAngle ("Satellite1");
		hideArrow ();
		pause ();
		say ("LevNorm", "Млдц! Станция под нужным углом");

		say ("LevNorm", "Теперь внимательно! Сначала включай нейтронный актуатор, затем квантовый редупликатор и только в конце – тахионный эмиттер.");
		say ("KeshaPanic", "Это сейчас на каком языке было?!");
		say ("LevNorm", "Ладно, ладно! Сначала включай красную панель на правом боку станции, потом зеленую на левом и только после этого – синий пульт на днище. Не перепутай!");
		unpause ();
		say ("KeshaNorm", "Хорошо, сейчас…");
		waitPOIActivation ("pointOfInterestRed");
		spawnMonster ("Spawners/SpawnerMonster1_03", "MonsterLeech", 5);
		spawnMonster ("Spawners/SpawnerMonster1_01", "MonsterLeech", 5);
		waitPOIActivation ("pointOfInterestGreen");
		spawnMonster ("Spawners/SpawnerMonster1_02", "MonsterLeech", 5);
		waitPOIActivation ("pointOfInterestBlue");
		waitStationAngle ("Satellite1");
		moveCamera (3.92f, 2.73f);
		stationSignal ();
		wait (2);
		// Здесь уничтожение астероида "Rock (3)"
		pause();
		spawnMonster ("Spawners/SpawnerMonster2", "MonsterRock", 2);
		moveCamera (17.91f, 17.24f);
		say ("KeshaSuperPanic", "Это что еще за нафиг?!");
		say ("LevPanic", "Ого, это ж как наша станция на местные астероиды влияет! Разберись с ними, и запускай еще раз.");
		unpause ();
		waitAllMonstersAreDead ();
		say ("KeshaNorm", "Ффух, здоровенные, гады. Ладно, приступаю к запуску.");
		say ("LevNorm", "Давай, сначала ре… тьфу, короче зеленый пульт, красный пульт и синий пульт!");
		say ("KeshaNorm", "Принято, зеленый, красный, синий. Так бы сразу, а то выражается, понимаешь… ");
		say ("LevPanic", "Я все слышу!");
		say ("KeshaPanic", "Будет исполнено, Лев Михалыч!");
		say ("LevNorm", "Так-то лучше…");
		waitPOIActivation ("pointOfInterestGreen");
		waitPOIActivation ("pointOfInterestRed");
		waitPOIActivation ("pointOfInterestBlue");
		stationSignal ();
		say ("KeshaNorm", "Сигнал пошел!");
		say ("LevNorm", "Подтверждаю, есть сигнал! Отлично, осталось еще три ретранслятора.");
		//win ();

        


         /*

         state = sayLev(, state); 
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
		state = win (state);*/
		// the end
		say ("LevPanic", "Конец сценария...");
	}
}




public class TestScenaryHelper : ChainTestMachine {
	public void say(string who, string what) {
		NextChainStep (new TestSayStep (who, what));
	}

	public void wait(float seconds) {
		NextChainStep (new TestWaitStep (seconds));
	}

	public void pause() {
		NextChainStep (new TestPauseStep(true));
	}
	public void unpause() {
		NextChainStep (new TestPauseStep(false));
	}

	public void moveCamera(string sceneObjectName) {
		GameObject target = GameObject.Find (sceneObjectName);
		NextChainStep (new TestMoveCameraStep(target.transform.position));
	}

	public void moveCamera(float x, float y) {
		NextChainStep (new TestMoveCameraStep( new Vector2(x, y) ));
	}

	public void spawnMonster(string spawnerName, string monsterName, int count) {
		GameObject target = GameObject.Find (spawnerName);
		NextChainStep ( new TestSpawnMonster(target.transform.position, monsterName, count) );
	}

	public void spawnMonster(float x, float y, string monsterName, int count) {
		NextChainStep ( new TestSpawnMonster( new Vector2(x, y), monsterName, count) );
	}

	public void waitPlayerInArea(string areaName) {
		NextChainStep (new TestWaitPlayerInArea(areaName));
	}

	public void waitAllMonstersAreDead() {
		NextChainStep ( new TestWaitAllMonstersIsDeadStep() );
	}

	public void waitPOIActivation(string poiName) {
		NextChainStep (new TestPOITriggerStep(poiName) );
	}

	public void killAllMonsters() {
		NextChainStep (new TestKillAllMonsters());
	}

	public void showArrow(string targetName) {
		NextChainStep (new TestArrowDirectionStep(true, targetName));
	}

	public void hideArrow() {
		NextChainStep (new TestArrowDirectionStep(false, ""));
	}

	public void waitStationAngle(string target) {
		NextChainStep ( new TestWaitStationAngleStep(target) );
	}

	public void stationSignal() {
		NextChainStep ( new TestShootSignalStep() );
	}

	public void win() {
		NextChainStep ( new TestWinStep() );
	}
}