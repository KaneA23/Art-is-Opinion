using UnityEngine;

public class CloudScript : MonoBehaviour {
	float timeWait = 240;

	float direction;
	float flip;

	private void Start() {
		flip = Random.Range(0, 2);

		if (flip == 0) {
			GetComponent<SpriteRenderer>().flipX = false;
		}
		if (flip == 1) {
			GetComponent<SpriteRenderer>().flipX = true;
		}

		if (transform.position.x < 0) {
			direction = Random.Range(0.02f, 0.1f);
		}
		if (transform.position.x > 0) {
			direction = Random.Range(-0.02f, -0.1f);
		}
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