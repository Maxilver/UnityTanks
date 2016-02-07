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

	public void goXY(float x = 0, float y = 0) {
		moveDirection = new Vector2 (x, y);
		if (x != 0 || y != 0) {
			float eulerZ = Mathf.Rad2Deg * Mathf.Atan2(-x, y);
			rotation = new Vector3(0, 0, eulerZ);
		}
	}
	
}
