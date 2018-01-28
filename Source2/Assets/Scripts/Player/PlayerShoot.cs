using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : RigidPausable {

	//[SerializeField]
	public GameObject bullet;
	public float bulletSpeed = 0.5f;

	private Vector2 bulletPosition;

	public float bulletImpulse = 300f;
	public float shootSpeed = 0.2f;
	public float lastShotTime;

	void Start() {
		lastShotTime = 0;
	}

	void FixedUpdate () 
	{
		if (pause)
			return;
		if (Input.GetKey(KeyCode.Mouse0))
		{
			Fire ();
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();

		}
	}//	void FixedUpdate ()


	void Fire()
	{


		if (Time.time>(lastShotTime + shootSpeed))
		{
			Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mouseDirection = new Vector2 (currentMousePosition.x - transform.position.x,
				currentMousePosition.y - transform.position.y );

			bulletPosition.x = bullet.transform.position.x;
			bulletPosition.y = bullet.transform.position.y;


			GameObject bulletClone =  Instantiate(bullet, bulletPosition, transform.rotation); 
			bulletClone.gameObject.SetActive (true);

			bulletClone.GetComponent<Rigidbody2D>().AddForce(mouseDirection.normalized * bulletSpeed);
			Destroy(bulletClone, 4.0f);

			lastShotTime = Time.time;
		}


	}
}
