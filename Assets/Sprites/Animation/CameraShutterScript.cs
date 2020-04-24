using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShutterScript : MonoBehaviour
{
	float timeWait = 2;
	public GameObject cameraShutterOpen;
	public GameObject cameraShutterClosed;

	private void Awake() {
		cameraShutterOpen.transform.gameObject.SetActive(true);
		cameraShutterClosed.transform.gameObject.SetActive(false);

	}
	// Update is called once per frame
	void Update() {
		if (timeWait > 0) {
			timeWait -= Time.deltaTime;
			if (timeWait <= 0) {
				cameraShutterOpen.transform.gameObject.SetActive(false);

			}
		}
	}
}
