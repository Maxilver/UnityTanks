using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float dampTime = 0.15f;
	public static Transform target;

	private Vector3 velocity = Vector3.zero;

	void Update () 
	{
		if (target) {
			Vector3 point = camera.WorldToViewportPoint (new Vector3 (target.position.x, target.position.y, target.position.z));
			Vector3 delta = new Vector3 (target.position.x, target.position.y, target.position.z) - camera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;

			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
		} else {
			var playerObject = GameObject.FindWithTag ("Player");
			if (playerObject) {
				target = playerObject.transform;
			}
		}
		
	}

}
