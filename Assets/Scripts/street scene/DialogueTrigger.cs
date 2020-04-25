using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour {
	public Dialogue dialogue;
	float timeWait;
	float sceneChangeWait;
	public Animator anim;
	public GameObject CameraShutter;
	public GameObject Canvas;

	//private void Start() {
	//	timeWait = Random.Range(2, 4);
	//}

	private void Update() {
			

		if (timeWait > 0) {
			timeWait -= Time.deltaTime;
			if (timeWait <= 0) {
				TriggerDialogue();
			}
		}
		if (sceneChangeWait > 0) {
			sceneChangeWait -= Time.deltaTime;
			if (sceneChangeWait <= 0) {
				SceneManager.LoadScene("PaintScene");
			}
		}

	}

	public void StartDialog() {
		timeWait = Random.Range(2, 4);
	}

	public void No() {
		FindObjectOfType<DialogueManager>().EndDialogue();

		timeWait = Random.Range(2, 4);
	}

	public void Yes() {
		//GameObject o = Instantiate(CameraShutter, new Vector3(0, 0, 0), Quaternion.identity);
		//o.transform.parent = Canvas.transform;
		//o.transform.position = new Vector3(0, 0, 0);
		//Debug.Log(o.transform.position);

		//anim = CameraShutter.GetComponent<Animator>();
		//anim.SetTrigger("Active");

		sceneChangeWait = 2;
	}

	public void TriggerDialogue() {
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}