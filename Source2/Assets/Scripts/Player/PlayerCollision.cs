﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

	[SerializeField]
	private Slider POI_Slider;

	private float curValue_slider;
	public float maxValue_slider = 1000f;
	public float POIinitialRadius = 0.03f;
	public float POIradius = 0.3f;

	void Start()
	{
		POI_Slider_initialization ();
	}

	void POI_Slider_initialization ()
	{  
		curValue_slider = 0;
		POI_Slider.minValue = 0;
		POI_Slider.maxValue = maxValue_slider;
		POI_Slider.value = curValue_slider;
	
	}

	void OnTriggerEnter2D(Collider2D target)
	{

		if (target.gameObject.tag == "Player") 
		{	
			POI_Slider.gameObject.SetActive (true);
			CircleCollider2D col = gameObject.GetComponent<CircleCollider2D> ();
			col.radius  = POIradius;
		
		}

	}

	void OnTriggerStay2D(Collider2D target)
	{	
		if (target.gameObject.tag == "Player")
		{
			POIchecking ();
		}
	}


	void OnTriggerExit2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player") 
		{
			CircleCollider2D col = gameObject.GetComponent<CircleCollider2D> ();
			col.radius  = POIinitialRadius;
			POI_Slider.gameObject.SetActive (false);
		}
	}

	void POIchecking ()
	{
		curValue_slider++;
		POI_Slider.value = curValue_slider;

		if (curValue_slider > 1000)
		{
			curValue_slider = 0;
			//another shit
		}  

		Debug.Log (curValue_slider);

	}

}
