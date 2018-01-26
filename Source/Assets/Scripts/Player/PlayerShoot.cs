using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	//[SerializeField]
	public GameObject bullet;

	private Transform bulletPosition;

	public float bulletImpulse = 300f;
	public float shootSpeed = 1;
	public float lastShotTime;

	void Start() {
		lastShotTime = 0;
	}

	void FixedUpdate () 
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			Fire ();
		}
	}//	void FixedUpdate ()


	void Fire()
	{
		if (Time.time>(lastShotTime + shootSpeed))
		{
			GameObject bulletClone =  Instantiate(bullet, bulletPosition, transform.rotation); 

			//Physics.IgnoreCollision(bulletClone.collider, collider);

			Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D> ();
			rb.AddForce(transform.forward*bulletImpulse, ForceMode2D.Impulse);

			lastShotTime = Time.time;
		}


	}
}
