using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollision : MonoBehaviour {

	public Collider2D player;
	public Collider2D station;
	public float monsterDamage =1f; 

	public void Start() {
		player = GameObject.Find ("/Player").GetComponent<Collider2D>();
		station =  GameObject.Find ("Retranslator").GetComponent<Collider2D>();
	}

	void OnTriggerStay2D(Collider2D target)
	{
		
		//if (target.gameObject.tag == "Player") 
		if (target == player)
		{
			target.gameObject.GetComponent<PlayerHP> ().curValue_slider -= monsterDamage;
			target.gameObject.GetComponent<PlayerHP> ().playerHPbar.value = target.gameObject.GetComponent<PlayerHP> ().curValue_slider;
		
			if (target.gameObject.GetComponent<PlayerHP> ().curValue_slider <= 0)
				GameObject.Find ("PanelsController").GetComponent<LosePanel> ().ShowStatus ();
		}

		//if (target.gameObject.tag == "Stantion") 
		else if (target == station) 
		{
			target.gameObject.GetComponent<StantionHP> ().curValue_slider -= monsterDamage;
			target.gameObject.GetComponent<StantionHP> ().stantionHPbar.value = target.gameObject.GetComponent<StantionHP> ().curValue_slider;
	
			if (target.gameObject.GetComponent<StantionHP> ().curValue_slider <= 0)
				GameObject.Find ("PanelsController").GetComponent<LosePanel> ().ShowStatus ();
		}

	}

}
