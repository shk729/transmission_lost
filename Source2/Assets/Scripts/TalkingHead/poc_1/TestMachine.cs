using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMachine : MonoBehaviour {
	void scenary() {


	}
}


abstract class TestMachineStep {
	public virtual void Enter () {}
	public virtual void Run () {}
	public virtual void Exit () {}
}

class A : TestMachineStep {}
class B : TestMachineStep {}