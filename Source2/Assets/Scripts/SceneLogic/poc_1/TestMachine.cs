using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainTestMachine : TestMachine {
	private string currentChain;
	private Dictionary<string, TestMachineStep> chains = new Dictionary<string, TestMachineStep>();
	private Dictionary<string, TestMachineStep> chainInitial = new Dictionary<string, TestMachineStep>();

	public ChainTestMachine() {
		currentChain = "default";
		chains [currentChain] = GetCurrent ();
		chainInitial [currentChain] = GetCurrent ();
	}

	public void selectChain(string name) {
		currentChain = name;
		TestMachineStep step = chains [currentChain];
		if (step == null) {
			step = new WaitNextStep ();
			chains [name] = step;
			chainInitial [name] = step;
		}
	}

	public void NextChainStep(TestMachineStep step) {
		chains [currentChain] = chains [currentChain].Next (step);
	}

	public TestMachineStep getInitialStep() {
		return chainInitial [currentChain];
	}

	public TestMachineStep getLastStep() {
		return chains [currentChain];
	}
}

public class TestMachine : MonoBehaviour {
	private TestMachineStep current = new WaitNextStep();

	void Update() {
		if (current == null)
			return;
		current.Run ();
		if (current.done)
			Next ();
	}

	private void Next() {
		current.Exit ();
		current = current.next;
		if (current == null)
			return;
		current.Enter ();
	}

	public TestMachineStep GetCurrent() {
		return current;
	}

	public void Next(TestMachineStep step) {
		current.next = step;
	}

	public void ChangeStep(TestMachineStep step) {
		current = step;
		step.Enter();
	}
}


public abstract class TestMachineStep {
	public TestMachineStep next;
	public bool done = false;


	public virtual void Enter () {}
	public virtual void Run () {}
	public virtual void Exit () {}

	public void Done() {
		done = true;
	}

	public T Next<T> (T next) where T : TestMachineStep {
		this.next = next;
		return next;
	}
}

public class WaitNextStep : TestMachineStep {
	public override void Run () {
		if (next != null) {
			Done ();
		}
	}
}
