using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFollow : MonoBehaviour {

    private Transform player;
    private Transform space;

    private float delaylShift = 0.4f;	        	

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        space = GameObject.Find("Space BG").transform;

    }

    void FixedUpdate()
    {

        Vector3 tempCamera = transform.position;
        Vector3 tempSpace = space.position;
        Vector2 playerVelocity = PlayerMove.GetPlayerVelocity();

			float step = (5f + playerVelocity.magnitude/2) * Time.deltaTime;               //greater value -> faster camera movement

            tempCamera = Vector3.MoveTowards(transform.position,
			new Vector3(player.position.x + playerVelocity.x * delaylShift,
				player.position.y + playerVelocity.y * delaylShift,
                                                                        tempCamera.z),
                                                                                step);
		
        tempSpace.x = tempCamera.x;
        tempSpace.y = tempCamera.y;

        space.position = tempSpace;
        transform.position = tempCamera;
    }
}
