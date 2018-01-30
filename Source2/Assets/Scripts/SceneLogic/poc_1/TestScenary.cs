using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScenary : TestScenaryHelper {
	void Start () {
		say ("LevNorm", "This is my first speeech");
		wait (2);
		spawnMonster ("Spawners/SpawnerMonster1", "MonsterJigsaw", 4);
		stationSignal ();
		showArrow ("Satellite2");
		say ("KeshaNorm", "Oga, i moya.");
		pause ();
		wait (3);
		spawnMonster ("Spawners/SpawnerMonster1", "MonsterLeech", 4);
		unpause ();
		waitPOIActivation ("pointOfInterestRed");
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
}