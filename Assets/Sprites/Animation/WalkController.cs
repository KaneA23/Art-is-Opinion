using System.Collections.Generic;
using UnityEngine;

public class WalkController : MonoBehaviour {
	float timeWaitPeople = 0.2f;
	float timeWaitClouds = 0.2f;
	int location;
	float startX;
	float x;
	float y;
	float z;

	public List<GameObject> peoplePrefabs;
	public List<GameObject> cloudPrefabs;
	GameObject Prefabs = null;

	private void Start() {
		startX = Random.Range(-200, 200);
		z = Random.Range(160, 210);
		if (z > 185) {
			z += 85;
		}
		Prefabs = GameObject.Instantiate(peoplePrefabs[Random.Range(0, peoplePrefabs.Count)], new Vector3(startX, 24, z), Quaternion.identity);

		startX = Random.Range(-300, 300);
		z = Random.Range(300, 900);
		Prefabs = GameObject.Instantiate(cloudPrefabs[Random.Range(0, peoplePrefabs.Count)], new Vector3(startX, 200, z), Quaternion.identity);
	}

	private void Update() {
		if (timeWaitPeople > 0) {
			timeWaitPeople -= Time.deltaTime;
			if (timeWaitPeople <= 0) {
				location = Random.Range(0, 2);
				z = Random.Range(160, 210);
				if (z > 185) {
					z += 85;
				}

				if (location == 0) {
					Prefabs = GameObject.Instantiate(peoplePrefabs[Random.Range(0, peoplePrefabs.Count)], new Vector3(-260, 24, z), Quaternion.identity);

				} else if (location == 1) {
					Prefabs = GameObject.Instantiate(peoplePrefabs[Random.Range(0, peoplePrefabs.Count)], new Vector3(260, 24, z), Quaternion.identity);
				}
				timeWaitPeople = Random.Range(2, 6);
			}
		}

		if (timeWaitClouds > 0) {
			timeWaitClouds -= Time.deltaTime;
			if (timeWaitClouds <= 0) {
				location = Random.Range(0, 2);
				z = Random.Range(300, 900);

				if (location == 0) {
					Prefabs = GameObject.Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Count)], new Vector3(-400, 200, z), Quaternion.identity);

				} else if (location == 1) {
					Prefabs = GameObject.Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Count)], new Vector3(400, 200, z), Quaternion.identity);
				}
				timeWaitClouds = Random.Range(10, 30);
			}
		}
	}
}