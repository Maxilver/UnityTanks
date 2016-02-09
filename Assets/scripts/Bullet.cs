using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 250f;

	void Start() {
		float bulletAngle = transform.eulerAngles.z;
		bulletAngle *= Mathf.Deg2Rad;
		rigidbody2D.AddForce(new Vector2(-Mathf.Sin(bulletAngle), Mathf.Cos(bulletAngle)) * speed);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (!collider.transform.CompareTag ("Player")) {
			Destroy (gameObject);
		}
	}

}
