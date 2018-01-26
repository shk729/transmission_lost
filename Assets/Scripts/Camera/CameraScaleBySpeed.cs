using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaleBySpeed : MonoBehaviour {

    private Camera mainCamera;
    private Transform player;
    private Transform space;

    private float additionalShift = 1f;	                                                                            	//additional shift to the border of screen

    void Awake() {
        mainCamera = this.GetComponent<Camera>();
        player = GameObject.Find("Spaceman").transform;
        space = GameObject.Find("Space BG").transform;
    }
	

	void FixedUpdate () {
      
        Vector3 tempCamera = transform.position;
        Vector3 tempSpace = space.position;
        Vector2 playerVelocity = PlayerMove.GetPlayerVelocity();

        mainCamera.orthographicSize = 5 + playerVelocity.magnitude / 2;

            float step = (5f + playerVelocity.magnitude/2) * Time.deltaTime;                                                //greater value -> faster camera movement

            tempCamera = Vector3.MoveTowards(transform.position,
                new Vector3(player.position.x + playerVelocity.x * additionalShift,
                            player.position.y + playerVelocity.y * additionalShift,
                            tempCamera.z), step);
        
       
        tempSpace.x = tempCamera.x;
        tempSpace.y = tempCamera.y;

        space.position = tempSpace;
        transform.position = tempCamera;
    }
}
