using UnityEngine;
using System.Collections;

public class Spawners : MonoBehaviour {

	public Transform player;
	public bool playerIsAlive = true;
	private ArrayList childSpawners = new ArrayList();  

	void Start () {
		foreach (Transform child in transform) {
			childSpawners.Add(child);
		}
	}

	void Update () {
		if (!playerIsAlive) {
			playerIsAlive = true;
			Invoke("ResurectPlayer", 1f);
		}
	}

	void ResurectPlayer() {
		Transform randomSpawner = childSpawners[Random.Range(0, childSpawners.Count)] as Transform;
		Instantiate(player, randomSpawner.position, transform.rotation);
	}
}
