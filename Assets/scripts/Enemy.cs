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
		float x;
		float y;
		do {
			x = Random.Range (-1, 2);
			y = Random.Range (-1, 2);
		}
		while(x == 0 && y == 0);
		goXY(x, y);	
		transform.rotation = Quaternion.Euler(rotation);
		Invoke("ChangeDirection", Random.Range(1f, 3f));

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.transform.CompareTag("bullet")) {
			Bang ();
			Destroy(gameObject);
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		CancelInvoke("ChangeDirection");
		ChangeDirection();
	}
}
