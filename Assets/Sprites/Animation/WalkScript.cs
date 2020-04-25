using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {

	float timeWait = 20;

	float direction;

	public GameObject prefabChild;


	private void Start() {
		SpriteRenderer parentSpriteRender = GetComponent<SpriteRenderer>();
		SpriteRenderer childSpriteRender = prefabChild.GetComponent<SpriteRenderer>();
		

		if (transform.position.x < 0) {
			parentSpriteRender.flipX = false;
			childSpriteRender.flipX = false;
			/////////////////////////////////////////////////////////////////
			direction = 0.8f;

		}
		if (transform.position.x > 0) {
			parentSpriteRender.flipX = true;
			childSpriteRender.flipX = true;
			//////////////////////////////////////////////////////////
			direction = -0.8f;
		}
		parentSpriteRender.material.color = Random.ColorHSV(0f, 1f, 1f, 0.5f, 0.5f, 1f);
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
