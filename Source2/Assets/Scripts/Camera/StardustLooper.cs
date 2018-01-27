using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustLooper : MonoBehaviour {

	private ParticleSystem starDust;


	void Awake(){
	
		starDust = GetComponent<ParticleSystem> ();
	}

	void Start () {
		
	}

	void FixedUpdate () {
		
		var vel = starDust.velocityOverLifetime;
		Vector3 player = PlayerMove.GetPlayerVelocity ();

		vel.x = -player.x/2;
		vel.z = -player.y/2;

	}
}
