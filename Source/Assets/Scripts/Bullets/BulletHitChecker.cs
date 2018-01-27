using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitChecker : MonoBehaviour 
{
	[SerializeField]
	private ParticleSystem hitEffect;

	[SerializeField]
	private ParticleSystem monsterDie;


	void OnTriggerEnter2D(Collider2D target)
	{
		
		if (target.gameObject.tag == "Monster") 
		{
			/*
			//exlosion animation
			ParticleSystem hitEffect_clone =  Instantiate(hitEffect, transform.position, transform.rotation); 
			hitEffect_clone.gameObject.SetActive (true);
			Destroy (hitEffect_clone, hitEffect.duration);
			*/

			//monster die animation
			ParticleSystem monsterDie_clone =  Instantiate(monsterDie, target.transform.position, target.transform.rotation); 
			monsterDie_clone.gameObject.SetActive (true);
			Destroy (monsterDie_clone, monsterDie.duration);
			target.gameObject.SetActive (false);
		}

	}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player") {
			
		} else if (target.gameObject.tag == "Monster") {



		} else {

			//exlosion animation
			ParticleSystem hitEffect_clone =  Instantiate(hitEffect, transform.position, transform.rotation); 
			hitEffect_clone.gameObject.SetActive (true);
			Destroy (hitEffect_clone, 0.8f);

			Destroy (this.gameObject, 0f);
		}
	}

}
