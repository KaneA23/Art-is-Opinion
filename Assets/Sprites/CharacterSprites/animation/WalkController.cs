using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkController : MonoBehaviour {
	public GameObject PinkLady;
	public GameObject cloud;
	public float timeWaitPeople;
	public float timeWaitClouds;
	public int location;
	float x;
	float y;
	float z;

	public List<GameObject> peoplePrefabs;
	public List<GameObject> cloudPrefabs;

	private void Awake() {
		timeWaitPeople = 0.1f;
		timeWaitClouds = 0.1f;
		//location = Random.Range(0, 2);


		//if (location == 0) {
		//	Instantiate(PinkLady, new Vector3(-120, 24, 170), Quaternion.identity);

		//} else if (location == 1) {
		//	Instantiate(PinkLady, new Vector3(120, 24, 170), Quaternion.identity);

		//}


	}

	private void Update() {
		if (timeWaitPeople > 0) {
			timeWaitPeople -= Time.deltaTime;
			if (timeWaitPeople <= 0) {
				location = Random.Range(0, 2);
				z = Random.Range(160, 210);
				if  (z > 185) {
					z += 85;
				}

				if (location == 0) {
					Instantiate(PinkLady, new Vector3(-260, 24, z), Quaternion.identity);

				} else if (location == 1) {
					Instantiate(PinkLady, new Vector3(260, 24, z), Quaternion.identity);

				}
				timeWaitPeople = Random.Range(2, 6);
				Debug.Log(timeWaitPeople);
				Debug.Log("             ." + location);

			}
		}
		if (timeWaitClouds > 0) {
			timeWaitClouds -= Time.deltaTime;
			if (timeWaitClouds <= 0) {
				location = Random.Range(0, 2);
				z = Random.Range(300, 900);

				if (location == 0) {

					Instantiate(cloud, new Vector3(-400, 200, z), Quaternion.identity);

				} else if (location == 1) {
					Instantiate(cloud, new Vector3(400, 200, z), Quaternion.identity);

				}
				timeWaitClouds = Random.Range(30, 60);
				Debug.Log(timeWaitClouds);
				Debug.Log("             ." + location);

			}
		}
	}
}
