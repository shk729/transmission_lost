using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitChecker : MonoBehaviour 
{
	[SerializeField]
	private ParticleSystem hitEffect;

	[SerializeField]
	private ParticleSystem monsterDie;

	public float damage = 30f;


	void OnTriggerEnter2D(Collider2D target)
	{
		
		if (target.gameObject.tag == "Monster") 
		{
			target.GetComponent<MonsterAI>().monsterHealth -= damage;
			target.GetComponent<MonsterAI> ().agressive = true;

			MonsterAI monster = target.GetComponent<MonsterAI> ();
			if (monster.monsterHealth <= 0) { monster.Die (); }
		}

	}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player") {
			
		}  else {

			//exlosion animation
			ParticleSystem hitEffect_clone =  Instantiate(hitEffect, transform.position, transform.rotation); 
			hitEffect_clone.gameObject.SetActive (true);
			//GetComponent<AudioSource>().PlayOneShot(hitSound);
			Destroy (hitEffect_clone, hitEffect.duration);
			Destroy (this.gameObject, 0f);
		}
	}

}
