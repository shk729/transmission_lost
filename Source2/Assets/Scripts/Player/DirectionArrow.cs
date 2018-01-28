using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour {

	private Transform arrow;
	private Vector3 destination;

	void Start ()
	{		
		arrow = GetComponent<Transform> ();
		//destination = GameObject.Find("Retranslator").transform.position;
	}

	void FixedUpdate () {
		if (destination == null)
			return;
		Vector3 playerPosition = PlayerMove.GetPlayerPosition();
		Vector2 moveDirection  = new Vector2(destination.x-playerPosition.x, destination.y-playerPosition.y);

		float moveAngle = 0;
		float rotAngle = Mathf.Atan(moveDirection.normalized.y/moveDirection.normalized.x); 

		if (moveDirection.normalized.x>=0)
			moveAngle = rotAngle * Mathf.Rad2Deg-90;
		else if (moveDirection.normalized.x<0)
			moveAngle = rotAngle * Mathf.Rad2Deg+90;

		arrow.rotation = Quaternion.Euler (0, 0, moveAngle+180);
	}


	public void SetObjjectToDirection(GameObject target)
	{
		destination = target.transform.position;

	}
}
