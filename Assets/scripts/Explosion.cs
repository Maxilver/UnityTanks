using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private Rigidbody2D body;

	void Start() {
		Invoke("ExplosionEnd", 1f);
	}

	void ExplosionEnd() {
		Destroy(gameObject);
	}
}
