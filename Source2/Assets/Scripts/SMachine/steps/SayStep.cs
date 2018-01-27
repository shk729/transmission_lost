using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SayStep : SMachineStep {
	public GameObject head;
	public GameObject uiPanel;
	public Text headName;
	public Text headText;
	public string say;
	public string nameTitle;

	public float waitAfterTextSec = 1f;

	private float waitText = 3f;
	private float startTime;
	private float charPerSec = 1f / 50;

	public override void Enter () {
		startTime = Time.time;
		uiPanel.SetActive (true);
		head.SetActive (true);
		headName.text = nameTitle;
		headText.text = "";
	}

	override public void Run() {
		float curTime = Time.time - startTime;
		if (curTime < waitText) {
			RenderText (curTime);
		} else if (curTime < waitText + waitAfterTextSec) {
			// do nothing... Just wait
		} else {
			Done ();
		}
	}

	override public void Exit() {
		head.SetActive (false);
		uiPanel.SetActive (false);
	}

	private void RenderText(float sec) {
		int count = Mathf.RoundToInt( sec / charPerSec );

		if (count > say.Length)
			count = say.Length;
		headText.text = say.Substring (0, count);
	}
}
