using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private GameObject player;
	static Rigidbody2D playerBody;

	Quaternion newRotation;
	float moveAngle;                                                      //angle in degrees
	float maxVelocity = 3.5f;

	Vector2 moveDirection;
	Vector2 currentMousePosition;

	// Use this for initialization
	void Awake ()
	{
		playerBody = GetComponent<Rigidbody2D>();
		player = this.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		KeyboardMove();
		MouseDirection ();

	}

	void MouseDirection()
	{
		currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mouseDirection = new Vector2 (currentMousePosition.x - transform.position.x,
			currentMousePosition.y - transform.position.y );
		Debug.DrawRay(transform.position, mouseDirection, Color.red);


		//rotation calculation
		float rotationSpeed = 10f;
		playerBody.freezeRotation = true;

		Vector3 eulerAngles = player.transform.rotation.eulerAngles;
		float playerAngle = eulerAngles.z;
		if (playerAngle > 180)
			playerAngle -= 360;
		float rotAngle = Mathf.Atan (currentMousePosition.normalized.y / currentMousePosition.normalized.x);

		if (currentMousePosition.normalized.x >= 0)
			moveAngle = rotAngle * Mathf.Rad2Deg - 90;
		else if (currentMousePosition.normalized.x < 0)
			moveAngle = rotAngle * Mathf.Rad2Deg + 90;

		newRotation = Quaternion.Euler (0, 0, moveAngle);
		player.transform.rotation = Quaternion.Slerp (player.transform.rotation, newRotation, Time.fixedDeltaTime * rotationSpeed);

		playerBody.freezeRotation = false;


	}

	void KeyboardMove()
	{
		float forceScale = 5f;

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		if (inputX != 0 || inputY != 0)
		{
			moveDirection = new Vector2(inputX * forceScale, inputY * forceScale);
			//PlayerMoveCalculation(moveDirection);
		}

		playerBody.AddForce (moveDirection * 1.5f);
	} //void KeyboardMove

	public static Vector2 GetPlayerVelocity()
	{
		return playerBody.velocity;
	}
		
}
