using UnityEngine;
using System.Collections;

public class Player : Tank {

	public Transform barrel;
	public Transform bullet;
	private GameObject[] spawners;

	void Start() {
		spawners = GameObject.FindGameObjectsWithTag("Respawn");
	}

	void FixedUpdate() {
		rigidbody2D.AddForce(moveDirection * speed);
	}

	void Update () {	
		if(Input.GetMouseButtonDown(0))	{
			Instantiate(bullet, barrel.position, transform.rotation);
		}

		if(Input.GetKey(KeyCode.W) || Input.GetKey("up")) {
			goUp();
		}
		else if(Input.GetKey(KeyCode.S) || Input.GetKey("down")) {
			goDown();
		}
		else if(Input.GetKey(KeyCode.A) || Input.GetKey("left")) {
			goLeft();
		}
		else if(Input.GetKey(KeyCode.D) || Input.GetKey("right")) {
			goRight();
		}
		else {
			moveDirection = new Vector2(0, 0);
		}

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
