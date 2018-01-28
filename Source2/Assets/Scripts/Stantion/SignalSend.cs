using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalSend : MonoBehaviour {

	public GameObject signal;
	private float signalSpeed = 2f;

	private Vector2 signalPosition;
	private float delay = 3f;

	public void SendWave()
	{
		StartCoroutine(SignalFire (0));
	}

	IEnumerator SignalFire(int i)
	{
		if (i < 5) {
			GameObject signalClone =  Instantiate(signal, signal.transform.position, signal.transform.rotation); 
			signalClone.SetActive(true);

			Vector2 direction =  new Vector2 (signalClone.transform.position.x-transform.position.x, 
				signalClone.transform.position.y-transform.position.y);

			signalClone.GetComponent<Rigidbody2D>().AddForce(direction.normalized * signalSpeed);
			Destroy(signalClone, 10.0f);
	
			yield return new WaitForSeconds(delay);
			i++;
			StartCoroutine (SignalFire (i));	
		}
	}
}
