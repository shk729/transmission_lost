using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitChecker : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D target)
	{
		
		if (target.gameObject.tag == "Monster") 
		{
			
			target.gameObject.SetActive (false);
		}

	}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player") 
		{
			
		}
		else if (target.gameObject.tag == "Monster") 
		{

		}

		else Destroy (this.gameObject, 0f);
	}

}
