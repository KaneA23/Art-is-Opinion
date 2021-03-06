﻿using UnityEngine;

/// <summary>
/// Created by Coral
/// this class controls the people in the background
/// </summary>
public class WalkScript : MonoBehaviour {

	private float timeWait = 15;
	private float direction;
	public GameObject prefabChild;

	/// <summary>
	/// this flips the sprits in the prefab and sets them walking in the furthest direction
	/// the parent is given a random colour value to change the colour of some clothes
	/// </summary>
	private void Start() {
		SpriteRenderer parentSpriteRender = GetComponent<SpriteRenderer>();
		SpriteRenderer childSpriteRender = prefabChild.GetComponent<SpriteRenderer>();

		if (transform.position.x < 0) {
			parentSpriteRender.flipX = false;
			childSpriteRender.flipX = false;
			direction = 0.8f;
		} else {
			parentSpriteRender.flipX = true;
			childSpriteRender.flipX = true;
			direction = -0.8f;
		}
		parentSpriteRender.material.color = Random.ColorHSV(0f, 1f, 1f, 0.5f, 0.5f, 1f);
	}

	/// <summary>
	/// once the person has reached the other side they are destroyed
	/// </summary>
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