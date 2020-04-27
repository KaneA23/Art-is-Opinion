using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	bool gallery = false;
	bool menu = false;
	float menuWait;
	float galleryWait;
	public GameObject MenuUI;
	public GameObject GalleryUI;
	public Vector3 GalleryCanvas; 
	
	private void Awake() {
		transform.position = new Vector3(0, 44, 0);
	}

	public void Gallery() {
		if (menu == false) {
			gallery = true;
			galleryWait = 3;
			GalleryUI.transform.gameObject.SetActive(true);
			MenuUI.transform.gameObject.SetActive(false);
		}
	}

	public void Menu() {
		if (gallery == false) {
			menu = true;
			menuWait = 3;
			GalleryUI.transform.gameObject.SetActive(false);
			MenuUI.transform.gameObject.SetActive(true);
		}
	}

	public void Painting() {
		transform.position = new Vector3(GalleryCanvas.x + 25, GalleryCanvas.y, GalleryCanvas.z);
	}
	public void NotPainting() {
		transform.position = new Vector3(0, 44, 0);
	}

	private void Update() {
		if (gallery == true) {
			Quaternion newRotation = Quaternion.AngleAxis(-90, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .04f);
		}
		if (galleryWait > 0) {
			galleryWait -= Time.deltaTime;
			if (galleryWait <= 0) {
				gallery = false;
			}
		}
		if (menu == true) {
			Quaternion newRotation = Quaternion.AngleAxis(0, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.04f);
		}
		if (menuWait > 0) {
			menuWait -= Time.deltaTime;
			if (menuWait <= 0) {
				menu = false;
			}
		}
	}
}
