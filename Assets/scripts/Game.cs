using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

	public static float areaSize;

	//public bool gameIsOn = false;
	public float minSize;
	public GameObject image;
	public GameObject player;
	public GameObject wall;
	public GameObject spawners;
	public GameObject enemy;

	private bool validated = true;

	public void GameStart() {
		if (validated) {
			BuildWalls();
			Instantiate(spawners, new Vector2(0, 0), transform.rotation);
			Instantiate(enemy, new Vector2(0, 0), transform.rotation);
			GameObject playerObject = Instantiate(player, new Vector2(0, -1), transform.rotation) as GameObject;
			CameraController.target = playerObject.transform;
			image.SetActive(false);
		}
	}

	public void areaSizeValidate() {
		string text = image.transform.Find("Size").GetComponent<InputField>().text;
		validated = false;
		float size;
		if (float.TryParse(text, out size)) {
			print (size);
			print (validated);

			if (size >= minSize) {
				validated = true;
				areaSize = size;
			}
		}
	}

	void Awake() {
		areaSize = minSize;
		image.transform.Find ("Size").GetComponent<InputField>().text = minSize.ToString();
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
