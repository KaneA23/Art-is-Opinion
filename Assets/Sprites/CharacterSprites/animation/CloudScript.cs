using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
	float timeWait = 240;

	float direction;
	public WalkController walkController;


	private void Start() {
		if (walkController.location == 0) {
			GetComponent<SpriteRenderer>().flipX = false;
			direction = Random.Range(0.1f, 0.2f);

		}
		if (walkController.location == 1) {
			GetComponent<SpriteRenderer>().flipX = true;
			direction = Random.Range(-0.1f, -0.2f);

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
