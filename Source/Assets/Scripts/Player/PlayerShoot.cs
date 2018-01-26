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
		bulletPosition = transform.position;

		if (Time.time>(lastShotTime + shootSpeed))
		{
			GameObject bulletClone =  Instantiate(bullet, bulletPosition, transform.rotation); 
			bulletClone.gameObject.SetActive (true);

			Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mouseDirection = new Vector2 (currentMousePosition.x - transform.position.x,
				currentMousePosition.y - transform.position.y );


			Debug.Log (currentMousePosition +" " +transform.position + " "+ mouseDirection.x+ " "+ mouseDirection.y);


			//Physics.IgnoreCollision(bulletClone.collider, collider);
			//bulletClone.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;

			bulletClone.GetComponent<Rigidbody2D>().AddForce(mouseDirection.normalized * bulletSpeed);
			Destroy(bulletClone, 10.0f);
			//Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D> ();
			//rb.AddForce(transform.forward*bulletImpulse, ForceMode2D.Impulse);

			lastShotTime = Time.time;
		}


	}
}
