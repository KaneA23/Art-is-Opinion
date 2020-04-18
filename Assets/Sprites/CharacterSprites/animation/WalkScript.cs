using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {

	float timeWait = 20;

	float direction;
	/// //////////////////////////////////////////// find the walk controller in the scene 
	public WalkController walkController;


	private void Start() {

		if (walkController.location == 0) {
			GetComponent<SpriteRenderer>().flipX = false;
			direction = 0.8f;

		}
		if (walkController.location == 1) {
			GetComponent<SpriteRenderer>().flipX = true;
			direction = -0.8f;
		}
	}

	private void Update() {
		
		transform.Translate(direction, 0, 0);
		Debug.Log(direction + " yesyezayezyutr");


		if (timeWait > 0) {
			timeWait -= Time.deltaTime;
			if (timeWait <= 0) {
				Destroy(gameObject);

			}
		}
	}
}
