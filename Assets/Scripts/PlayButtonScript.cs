using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayButtonScript : MonoBehaviour {
	float timeWait;
	public GameObject MenuUI;
	public GameObject Street;
	public GameObject cameraShutterClosed;


	public void ButtonClicked() {
		cameraShutterClosed.transform.gameObject.SetActive(true);
		timeWait = 2;
	}

	void Update() {
		if (timeWait > 0) {
			timeWait -= Time.deltaTime;
			if (timeWait <= 0) {
				Street.transform.gameObject.SetActive(true);
				MenuUI.transform.gameObject.SetActive(false);
			}
		}
	}
}
