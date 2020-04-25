using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour {
	float sceneChangeWait;
	public GameObject cameraShutterClosed;
	public GameObject MenuUI;
	public GameObject Street;
	public void ButtonClicked() {
		cameraShutterClosed.transform.gameObject.SetActive(true);
		sceneChangeWait = 2;
	}

	void Update() {
		if (sceneChangeWait > 0) {
			sceneChangeWait -= Time.deltaTime;
			if (sceneChangeWait <= 0) {
				MenuUI.transform.gameObject.SetActive(true);
				Street.transform.gameObject.SetActive(false);
			}
		}
	}
}
