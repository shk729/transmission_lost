using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMachine : MonoBehaviour {
	[HideInInspector]
	public SMachineStep currentStep;

	public void Jump(SMachineStep step) {
		if (currentStep != null)
			currentStep.Exit ();
		if (step != null) {
			step.inProgress = true;
			step.Enter ();
		}
		currentStep = step;
	}

	void Update () {
		if (currentStep == null) {
			Next (0);
			if (currentStep == null)
				return;
		}
		if (currentStep.inProgress)
			currentStep.Run ();
		else 
			Next ();
	}

	void Next() {
		int index = currentStep.transform.GetSiblingIndex ();
		index++;
		Next (index);
	}

	void Next(int index) {
		int count = transform.childCount;
		if (count == 0)
			return;
		if (index >= count){
			Next (0);
			return;
		}
		Transform child = transform.GetChild (index);
		SMachineStep nextStep = child.GetComponent<SMachineStep> ();
		Jump (nextStep);
	}
}

public abstract class SMachineStep : MonoBehaviour {
	[HideInInspector]
	public bool inProgress = true;

	public virtual void Enter() {}
	public virtual void Run() { }
	public virtual void Exit() { }
	public void Done() {
		inProgress = false;
	}
	public SMachine GetSMachine() {
		return GetComponentInParent<SMachine> ();
	}
}
