using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStreetScript : MonoBehaviour {

	float sceneChangeWait;
	
	public void DontSave() {
		sceneChangeWait = 2;
	}

	private void Update() {
		if (sceneChangeWait > 0) {
			sceneChangeWait -= Time.deltaTime;
			if (sceneChangeWait <= 0) {
				SceneManager.LoadScene("StreetScene");
			}
		}
	}
}
