using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StantionHP : MonoBehaviour {

	[SerializeField]
	public Slider stantionHPbar;

	public float curValue_slider;
	public float maxValue_slider = 2000f;

	void Start()
	{
		playerHPbar_initialization ();
	}

	void playerHPbar_initialization ()
	{  
		curValue_slider = maxValue_slider;
		stantionHPbar.minValue = 0;
		stantionHPbar.maxValue = maxValue_slider;
		stantionHPbar.value = curValue_slider;

	}
}
