using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : RigidPausable {

	[SerializeField]
	private ParticleSystem monsterDie;

	public float monsterHealth = 100;
	public float monsterSpeed = 0.2f;
	public float damage = 10f;
	private float rotationSpeed = 10f;

	private Rigidbody2D enemy;
	private GameObject player;
	private GameObject retranslator;
	private GameController game;

	public bool agressive = false;

	void Start ()
	{
		player = GameObject.Find("Player");
		retranslator = GameObject.Find("Retranslator");
		enemy = GetComponent<Rigidbody2D>();
		game = GameObject.Find (Constants.SCENE_LOGIC).GetComponent<GameController>();
		if (game.pause)
			Hold ();
	}

	void FixedUpdate ()
	{	
		if (pause)
			return;
		AILogic();
	}

	private void AILogic() {
		System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch ();
		stopwatch.Reset ();

		Debug.Log ("----------------------");
		if (!agressive) {
			stopwatch.Start ();
			Vector2 tempForce = transform.position - retranslator.transform.position;
			transform.position = Vector3.Lerp (transform.position, retranslator.transform.position, Time.deltaTime * monsterSpeed);

			//rotation to retranslator
			Vector3 eulerAngles = transform.rotation.eulerAngles;  
			float rotAngle = Mathf.Atan (tempForce.normalized.y / tempForce.normalized.x);

			float moveAngle = 0;
			if (tempForce.normalized.x >= 0)
				moveAngle = rotAngle * Mathf.Rad2Deg + 90;
			else if (tempForce.normalized.x < 0)
				moveAngle = rotAngle * Mathf.Rad2Deg - 90;
			Quaternion newRotation = Quaternion.Euler (0, 0, moveAngle);
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.fixedDeltaTime * rotationSpeed);
			enemy.freezeRotation = false;
			stopwatch.Stop ();
			Debug.Log ("Ticks: " + stopwatch.ElapsedTicks + " ms:" + stopwatch.ElapsedMilliseconds);
		} else 
		{
			Vector2 tempForce = transform.position - player.transform.position;
			transform.position = Vector3.Lerp (transform.position, player.transform.position, Time.deltaTime * monsterSpeed);
			//rotation to player
			enemy.freezeRotation = true;
			Vector3 eulerAngles = transform.rotation.eulerAngles;  
			float rotAngle = Mathf.Atan (tempForce.normalized.y / tempForce.normalized.x);
			float moveAngle = 0;
			if (tempForce.normalized.x >= 0) {
				moveAngle = rotAngle * Mathf.Rad2Deg + 90;
			} else if (tempForce.normalized.x < 0) {
				moveAngle = rotAngle * Mathf.Rad2Deg - 90;
			}
			Quaternion newRotation = Quaternion.Euler (0, 0, moveAngle);
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.fixedDeltaTime * rotationSpeed);
			enemy.freezeRotation = false;
		}
	}

	public void Die() {
		gameObject.SetActive (false);

		//EFFECT
		ParticleSystem monsterDie_clone =  Instantiate(monsterDie, transform.position, transform.rotation); 
		monsterDie_clone.gameObject.SetActive (true);

		Destroy (monsterDie_clone, monsterDie.duration);
	}

	public void SpawnNew(Vector2 position) {
		GameObject newMonster = Instantiate(gameObject, position, Quaternion.identity) as GameObject;
		newMonster.SetActive (true);
		MonsterAI newMonsterAI = newMonster.GetComponent<MonsterAI> ();
		newMonsterAI.monsterHealth = 100;
	}

	public void DieAndDestroy() {
		Die ();
		Destroy (this, monsterDie.duration + 0.5f);
	}
}
