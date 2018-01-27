using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

	[SerializeField]
	public Slider playerHPbar;

	public float curValue_slider;
	private float maxValue_slider = 300f;

	void Start()
	{
		playerHPbar_initialization ();
	}

	void playerHPbar_initialization ()
	{  
		curValue_slider = maxValue_slider;
		playerHPbar.minValue = 0;
		playerHPbar.maxValue = maxValue_slider;
		playerHPbar.value = curValue_slider;

	}

}
