using UnityEngine;

public class CameraShutterScript : MonoBehaviour {
	float timeWait;
	public GameObject cameraShutterOpen;
	public CameraShutterScript CameraShutterScriptOpen;

	private void Start() {
		timeWait = 2;
	}

	// Update is called once per frame
	void Update() {
		if (timeWait > 0) {
			timeWait -= Time.deltaTime;

			if (timeWait <= 0) {
				if (this != cameraShutterOpen) {
					cameraShutterOpen.transform.gameObject.SetActive(true);
					CameraShutterScriptOpen.timeWait = 2;
					timeWait = 2;
				}
				transform.gameObject.SetActive(false);
			}
		}
	}
}