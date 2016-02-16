using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public bool gameIsOn = false;
	public static float areaSize = 10;
	public GameObject wall;
	public GameObject spawners;
	public GameObject enemy;

	void Awake() {
		BuildWalls();
		Instantiate(spawners, new Vector2(0, 0), transform.rotation);
		Instantiate(enemy, new Vector2(0, 0), transform.rotation);
	}

	void BuildWalls() {
		GameObject wallsParent = new GameObject("WallsParent");
		Quaternion wallRotation = Quaternion.Euler (0, 0, 0);
		for (var i = 0; i < 4; i++) {
			int reverted = (i < 2) ? 1 : -1;
			Vector2 wallPosition = (i % 2 == 0) ? new Vector2(0, reverted * areaSize / 2) : new Vector2(reverted * areaSize / 2, 0);
			GameObject wallInst = Instantiate(wall, wallPosition, wallRotation) as GameObject;
			wallInst.transform.parent = wallsParent.transform;
			wallInst.transform.localScale = new Vector3(areaSize + wallInst.transform.localScale.y, wallInst.transform.localScale.y, wallInst.transform.localScale.z);
			wallRotation *= Quaternion.Euler(0, 0, 90);
		}
	}
}
