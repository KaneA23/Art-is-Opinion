using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour {
	float timeWait;
	public GameObject MenuUI;
	public GameObject Street;

	public void ButtonClicked() {
		timeWait = 2;
	}

	void Update() {
		if (timeWait > 0) {
			timeWait -= Time.deltaTime;
			if (timeWait <= 0) {
				MenuUI.transform.gameObject.SetActive(true);
				Street.transform.gameObject.SetActive(false);
			}
		}
	}
}
