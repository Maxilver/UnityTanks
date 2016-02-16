using UnityEngine;
using System.Collections;

public class Spawners : MonoBehaviour {

	public GameObject player;
	public GameObject spawner;
	public bool playerIsAlive = true;
	public ArrayList childSpawners = new ArrayList();  

	void Start () {
		float spawnAreaSize = (Game.areaSize / 2) - 1;
		for (var i = 0; i < 4; i++) {
			int xRevertered = (i < 2) ? 1 : -1;
			int yRevertered = (i % 2 == 0) ? 1 : -1;
			GameObject childSpawner = Instantiate(spawner, new Vector2(spawnAreaSize * xRevertered, spawnAreaSize * yRevertered), transform.rotation) as GameObject;
			childSpawner.transform.parent = transform;
			childSpawners.Add(childSpawner);
		}
	}

	void Update () {
		if (!playerIsAlive) {
			playerIsAlive = true;
			Invoke("ResurectPlayer", 1f);
		}
	}

	void ResurectPlayer() {
		GameObject randomSpawner = childSpawners[Random.Range(0, childSpawners.Count)] as GameObject;
		Instantiate(player, randomSpawner.transform.position, transform.rotation);
	}
}
