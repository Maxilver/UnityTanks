using UnityEngine;
using System.Collections;

public class Enemy : Tank {

	private Rigidbody2D body;

	void Start() {
		ChangeDirection();
	}
	
	void FixedUpdate() {
	    rigidbody2D.AddForce(moveDirection * speed);
	}

	void ChangeDirection() {
		switch (Random.Range (1, 5)) {
			case 1:
   				goUp();
				break;
			case 2:
				goDown();
				break;
			case 3:
				goLeft();
				break;
			case 4:
				goRight();
				break;
		}

		transform.rotation = Quaternion.Euler(rotation);
		Invoke("ChangeDirection", Random.Range(1f, 3f));

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.transform.CompareTag("bullet")) { 
			Bang ();
			Destroy(gameObject);
			Destroy(collider.gameObject);
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		CancelInvoke("ChangeDirection");
		ChangeDirection();
	}
}
