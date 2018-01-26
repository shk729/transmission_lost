using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	//[SerializeField]
	public GameObject bullet;
	public float bulletSpeed = 1f;

	private Vector2 bulletPosition;

	public float bulletImpulse = 300f;
	public float shootSpeed = 0.2f;
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
			Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mouseDirection = new Vector2 (currentMousePosition.x - transform.position.x,
				currentMousePosition.y - transform.position.y );

			bulletPosition.x = bullet.transform.position.x;
			bulletPosition.y = bullet.transform.position.y;


			GameObject bulletClone =  Instantiate(bullet, bulletPosition, transform.rotation); 
			bulletClone.gameObject.SetActive (true);

			bulletClone.GetComponent<Rigidbody2D>().AddForce(mouseDirection.normalized * bulletSpeed);
			Destroy(bulletClone, 10.0f);

			lastShotTime = Time.time;
		}


	}
}
