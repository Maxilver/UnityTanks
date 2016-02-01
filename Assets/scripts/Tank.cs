using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	public float speed = 150f;
	public GameObject boom;
	public Vector2 moveDirection;
	public Vector3 rotation = new Vector3(0, 0, 0);
	
	public void Bang() {
		Instantiate (boom, transform.position, transform.rotation);
	}

	public void goUp() {
		moveDirection = new Vector2(0, 1);
		rotation = new Vector3(0, 0, 0);
	}
	public void goDown() {
		moveDirection = new Vector2(0, -1);
		rotation = new Vector3(0, 0, 180);
	}
	public void goLeft() {
		moveDirection = new Vector2(-1, 0);
		rotation = new Vector3(0, 0, 90);
	}
	public void goRight() {
		moveDirection = new Vector2(1, 0);
		rotation = new Vector3(0, 0, 270);
	}
	
}
