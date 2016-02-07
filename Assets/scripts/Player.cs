using UnityEngine;
using System.Collections;

public class Player : Tank {

	public Transform barrel;
	public Transform bullet;
	private GameObject[] spawners;
	private Transform cannon;

	void Start() {
		spawners = GameObject.FindGameObjectsWithTag("Respawn");
	
		foreach (Transform child in transform) {
			if (child.transform.CompareTag("Cannon")) {
				cannon = child;
			}
		}
	}

	void FixedUpdate() {
		rigidbody2D.AddForce(moveDirection * speed);

		var cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion cannonRotation = Quaternion.LookRotation(transform.position - cursorPosition, Vector3.forward);
		cannon.rotation = cannonRotation;
		cannon.eulerAngles = new Vector3 (0, 0, cannon.eulerAngles.z);

		//cannon.RotateAround (Vector3.zero, Vector3.forward, 20 * Time.deltaTime);
		//cannon.localRotation = cannonRotation;
		//cannon.LookAt (transform.position - cursorPosition, Vector3.forward);

	}

	void Update () {	
		if(Input.GetMouseButtonDown(0))	{
			Instantiate(bullet, barrel.position, cannon.rotation);
		}

		float MovementY = 0;
		if (Input.GetKey (KeyCode.W) || Input.GetKey ("up")) {
			MovementY++;
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey ("down")) {
			MovementY--;
		}

		float MovementX = 0;
		if (Input.GetKey(KeyCode.A) || Input.GetKey("left")) {
			MovementX--;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey("right")) {
			MovementX++;
		}

		goXY (MovementX, MovementY);
		transform.rotation = Quaternion.Euler(rotation);

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.CompareTag("enemy")) { 
			Bang ();
			spawners[0].transform.GetComponent<Spawners>().playerIsAlive = false;
			Destroy(gameObject);
		}
	}


}
