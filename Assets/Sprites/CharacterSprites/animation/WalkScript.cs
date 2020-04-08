using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {

    public GameObject PinkLady;


    void start() {
		Instantiate(PinkLady, new Vector3(120, 24, 170), Quaternion.identity);
	}

    void FixedUpdate() {

		PinkLady.transform.Translate(-0.8f, 0, 0);
    }
}
