using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksControl : MonoBehaviour {

	[SerializeField]
	private ParticleSystem destroyEffect;

	public void Destroy ()
	{
		ParticleSystem destroyEffect_clone =  Instantiate(destroyEffect, transform.position, transform.rotation); 
		destroyEffect_clone.gameObject.SetActive (true);
		Destroy (destroyEffect_clone, destroyEffect.duration);

		Destroy (this.gameObject, 0f);
	
	}

}
