using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {

	float timeWait = 20;

	float direction;
	/// //////////////////////////////////////////// find the walk controller in the scene 


	private void Start() {

		if (transform.position.x < 0) {
			GetComponent<SpriteRenderer>().flipX = false;
			direction = 0.8f;

		}
		if (transform.position.x > 0) {
			GetComponent<SpriteRenderer>().flipX = true;
			direction = -0.8f;
		}
		GetComponent<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 0.5f, 0.5f, 1f);
	}

	private void Update() {
		
		transform.Translate(direction, 0, 0);


		if (timeWait > 0) {
			timeWait -= Time.deltaTime;
			if (timeWait <= 0) {
				Destroy(gameObject);

			}
		}
	}
}
