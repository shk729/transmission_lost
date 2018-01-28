using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollision : MonoBehaviour {

	public float monsterDamage =1f; 

	void OnTriggerStay2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player") 
		{
			target.gameObject.GetComponent<PlayerHP> ().curValue_slider -= monsterDamage;
			target.gameObject.GetComponent<PlayerHP> ().playerHPbar.value = target.gameObject.GetComponent<PlayerHP> ().curValue_slider;
		
			if (target.gameObject.GetComponent<PlayerHP> ().curValue_slider <= 0)
				GameObject.Find ("PanelsController").GetComponent<LosePanel> ().ShowStatus ();
		}

		if (target.gameObject.tag == "Stantion") 
		{
			target.gameObject.GetComponent<StantionHP> ().curValue_slider -= monsterDamage;
			target.gameObject.GetComponent<StantionHP> ().stantionHPbar.value = target.gameObject.GetComponent<StantionHP> ().curValue_slider;
	
			if (target.gameObject.GetComponent<StantionHP> ().curValue_slider <= 0)
				GameObject.Find ("PanelsController").GetComponent<LosePanel> ().ShowStatus ();
		}

	}

}
