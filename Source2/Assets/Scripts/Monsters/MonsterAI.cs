using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : RigidPausable {


	public float monsterHealth = 100;
	public float monsterSpeed = 0.2f;
	public float damage = 10f;
	private float rotationSpeed = 10f;

	private Rigidbody2D enemy;
	private GameObject player;
	private GameObject retranslator;

	public bool agressive = false;

	void Start ()
	{
		player = GameObject.Find("Player");
		retranslator = GameObject.Find("Retranslator");
		enemy = GetComponent<Rigidbody2D>();

	}

	void FixedUpdate ()
	{	
		if (pause)
			return;
		if (!agressive) {
			Vector2 tempForce = transform.position - retranslator.transform.position;
			transform.position = Vector3.Lerp (transform.position, retranslator.transform.position, Time.deltaTime * monsterSpeed);

			//rotation to retranslator
			enemy.freezeRotation = true;
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
		
		} else 
		{
			Vector2 tempForce = transform.position - player.transform.position;
			transform.position = Vector3.Lerp (transform.position, player.transform.position, Time.deltaTime * monsterSpeed);

			//rotation to player
			enemy.freezeRotation = true;
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
		}
	}
}
